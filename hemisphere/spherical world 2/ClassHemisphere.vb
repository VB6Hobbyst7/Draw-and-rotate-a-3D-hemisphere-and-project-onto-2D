#Disable Warning IDE1006 ' Benennungsstile
#Disable Warning CA1707 ' Bezeichner dürfen keine Unterstriche enthalten
#Disable Warning CA1051 ' Sichtbare Instanzfelder nicht deklarieren
#Disable Warning CA2211 ' Nicht konstante Felder dürfen nicht sichtbar sein

Imports System.Windows.Media.Media3D
Imports SkiaSharp

Public Class VecThetaPhi
    Public Vect As Vector3D
    Public Theta As Double
    Public Phi As Double
    Public Grid As Vector3D
    Public Sub New(vec As Vector3D, the As Double, ph As Double, Gri As Vector3D)
        Me.Vect = vec
        Me.Theta = the
        Me.Phi = ph
        Me.Grid = Gri
    End Sub
End Class

Public NotInheritable Class ClassHemisphere

    Public Phi As UInt16
    Public Theta As UInt16
    ''' <summary>
    ''' This list contains all vectors that point from the coordinate origin to the surface.
    ''' And the related Phi and Theta angles.
    ''' </summary>
    Private ReadOnly LstVecThetaPhi As New List(Of VecThetaPhi)

    ''' <summary>
    ''' The camera position on the z-axis (we look towards the +z arrow). 
    ''' </summary>
    Public Camera As Double = 1500.0
    ''' <summary>
    ''' The projection window position on the z-axis. Abs!
    ''' </summary>
    Public Window_distance As Double = 700.0

    Private ReadOnly point_of_origin As New PointF(0.0F, 0.0F)
    ''' <summary>
    ''' Radius of this hemisphere
    ''' </summary>
    Private ReadOnly Radius As Double
    ''' <summary>
    ''' It is to be drawn a 2D line to the point of the set Phi and Theta.
    ''' </summary>
    Private projected_arrow As PointF
    ''' <summary>
    ''' in degrees
    ''' </summary>
    Public rotation_angle_x As Double

    Public Shared displayedBitmap As System.Drawing.Bitmap
    Public Camera_Vector As Vector3D

    Public Sub New(ByVal radius As Double)
        Me.Radius = radius
        Camera_Vector = New Vector3D(0, 0, Camera)
        Dim OneHalf As Double = 1.0 / 2.0
        For _phi As Double = 0.0 To 360.0 Step OneHalf
            For _theta As Double = 0.0 To 90.0 Step OneHalf
                Dim vec As New Vector3D(
                                    radius * Math.Cos(_phi * Math.PI / 180.0) * Math.Sin(_theta * Math.PI / 180.0),
                                    radius * Math.Sin(_phi * Math.PI / 180.0) * Math.Sin(_theta * Math.PI / 180.0),
                                    radius * Math.Cos(_theta * Math.PI / 180.0))
                '–––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––
                Dim GridVec1 As Vector3D
                Select Case CSng(_theta)
                    Case 15.0F, 30.0F, 45.0F, 60.0F, 75.0F
                        GridVec1 = New Vector3D(
                        radius * Math.Cos(_phi * Math.PI / 180.0) * Math.Sin(_theta * Math.PI / 180.0),
                        radius * Math.Sin(_phi * Math.PI / 180.0) * Math.Sin(_theta * Math.PI / 180.0),
                        radius * Math.Cos(_theta * Math.PI / 180.0))
                    Case Else
                        GridVec1 = New Vector3D(0.0, 0.0, 0.0)
                End Select
                LstVecThetaPhi.Add(New VecThetaPhi(vec, _theta, _phi, GridVec1))
                '–––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––
                Dim GridVec2 As Vector3D
                Select Case CSng(_phi)
                    Case 0.0F, 15.0F, 30.0F, 45.0F, 60.0F, 75.0F, 90.0F, 105.0F, 120.0F, 135.0F, 150.0F, 165.0F, 180.0F, 195.0F, 210.0F, 225.0F, 240.0F, 255.0F, 270.0F, 285.0F, 300.0F, 315.0F, 330.0F, 345.0F
                        GridVec2 = New Vector3D(
                                            radius * Math.Cos(_phi * Math.PI / 180.0) * Math.Sin(_theta * Math.PI / 180.0),
                                            radius * Math.Sin(_phi * Math.PI / 180.0) * Math.Sin(_theta * Math.PI / 180.0),
                                            radius * Math.Cos(_theta * Math.PI / 180.0))
                    Case Else
                        GridVec2 = New Vector3D(0.0, 0.0, 0.0)
                End Select
                LstVecThetaPhi.Add(New VecThetaPhi(vec, _theta, _phi, GridVec2))
            Next
        Next
    End Sub

    Public Function getVector(ThetaValue As Double, PhiValue As Double) As Vector3D
        Dim Value As Vector3D = (From item In LstVecThetaPhi
                                 Where item.Theta = ThetaValue And item.Phi = PhiValue
                                 Select item.Vect).FirstOrDefault
        Return Value
    End Function

    Private Shared Function Rotate_around_the_x_axis(ByVal vec As Vector3D, ByVal angle As Double) As Vector3D
        Return New Vector3D(vec.X,
                            vec.Y * Math.Cos(angle * Math.PI / 180.0) - vec.Z * Math.Sin(angle * Math.PI / 180.0),
                            vec.Y * Math.Sin(angle * Math.PI / 180.0) + vec.Z * Math.Cos(angle * Math.PI / 180.0))
    End Function

    Public Sub change_Camera_height(ByVal dz As Double)
        Camera += dz
        Camera_Vector = New Vector3D(0, 0, Camera)
    End Sub

    Public Async Function calculate_Async() As Task(Of Boolean)
        Return Await Task.Run(Function() Verarbeitung())
    End Function

    Private Function Verarbeitung() As Boolean
        displayedBitmap = Nothing

        Dim imageInfo As New SKImageInfo(FormMain.PictureBox1.Size.Width, FormMain.PictureBox1.Size.Height)
        Using surface As SKSurface = SKSurface.Create(imageInfo)
            Using canvas As SKCanvas = surface.Canvas
                canvas.Translate(300.0F, 300.0F)

                Using DarkBlue As New SKPaint With {
                                .TextSize = 64.0F,
                                .IsAntialias = True,
                                .Color = New SKColor(0, 0, 122),
                                 .Style = SKPaintStyle.Fill
                                 }

                    Using BrightYellow As New SKPaint With {
                        .TextSize = 64.0F,
                        .IsAntialias = True,
                        .Color = New SKColor(255, 255, 77),
                        .Style = SKPaintStyle.Fill
                        }

                        Using Magenta As New SKPaint With {
                            .TextSize = 64.0F,
                            .IsAntialias = True,
                            .Color = New SKColor(255, 0, 115),
                            .Style = SKPaintStyle.Fill
                               }


                            For i As Integer = 0 To LstVecThetaPhi.Count - 1 Step 1


                                Dim rotated_vec As Vector3D = Rotate_around_the_x_axis(LstVecThetaPhi(i).Vect, rotation_angle_x)

                                '–––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––
                                ' Every point that is more than 90° from the camera direction (=back side) does not need to be drawn. 
                                '–––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––

                                '    If Vector3D.AngleBetween(Camera_Vector, rotated_vec) > 90.0001 Then ' 90.0001 because the precision of a ‘double’ is finite..
                                '        Continue For
                                '    End If

                                '–––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––
                                ' calculate position, projection, and draw the points.
                                '–––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––

                                Dim Angle_in_degrees As Double = Vector3D.AngleBetween(rotated_vec, New Vector3D(rotated_vec.X, rotated_vec.Y, 0.0))

                                If Double.IsNaN(Angle_in_degrees) Then
                                    Continue For
                                End If
                                Dim vertical_height As Double = Radius * Math.Sin(Angle_in_degrees * Math.PI / 180.0) ' Opposite cathetus


                                If rotated_vec.Z < Window_distance Then ' The object is not further back than the window (the window is not in the object). When false, don't draw!

                                    Dim projected_Point As New PointF(
                                        CSng((Camera - Window_distance) / (Camera - vertical_height) * rotated_vec.X),
                                        CSng(-(Camera - Window_distance) / (Camera - vertical_height) * rotated_vec.Y))

                                    If LstVecThetaPhi(i).Grid.X = 0.0 AndAlso LstVecThetaPhi(i).Grid.Y = 0.0 AndAlso LstVecThetaPhi(i).Grid.Z = 0.0 Then
                                        ' draw the hemisphere
                                        canvas.DrawPoint(projected_Point.X, projected_Point.Y, DarkBlue)
                                    Else
                                        ' draw the grid (Gitternetz)
                                        Dim SKPoints0 As New SKPoint(projected_Point.X + 2.0F, projected_Point.Y + 2.0F)
                                        Dim SKPoints1 As New SKPoint(projected_Point.X + 1.0F, projected_Point.Y + 1.0F)
                                        Dim SKPoints2 As New SKPoint(projected_Point.X, projected_Point.Y)
                                        Dim SKPoints3 As New SKPoint(projected_Point.X - 1.0F, projected_Point.Y - 1.0F)
                                        Dim SKPoints4 As New SKPoint(projected_Point.X - 2.0F, projected_Point.Y - 2.0F)
                                        canvas.DrawPoints(SKPointMode.Lines, {SKPoints0, SKPoints1, SKPoints2, SKPoints3, SKPoints4}, BrightYellow)
                                    End If
                                End If
                            Next


                            '–––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––
                            ' Draw a line which is showing the set Phi and Theta.
                            '–––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––

                            Dim Arrow As Vector3D = Rotate_around_the_x_axis(getVector(CDbl(Me.Theta), CDbl(Me.Phi)), rotation_angle_x)
                            Dim Angle As Double = Vector3D.AngleBetween(Arrow, New Vector3D(Arrow.X, Arrow.Y, 0.0))
                            If Not Double.IsNaN(Angle) Then
                                Dim vertical As Double = Arrow.Length * Math.Sin(Angle * Math.PI / 180.0)
                                projected_arrow = New PointF(
                                                  CSng((Camera - Window_distance) / (Camera - vertical) * Arrow.X),
                                                  CSng(-(Camera - Window_distance) / (Camera - vertical) * Arrow.Y))
                                Dim SKPoints1 As New SKPoint(projected_arrow.X + 1.0F, projected_arrow.Y + 1.0F)
                                Dim SKPoints2 As New SKPoint(projected_arrow.X, projected_arrow.Y)
                                Dim SKPoints3 As New SKPoint(projected_arrow.X - 1.0F, projected_arrow.Y - 1.0F)
                                canvas.DrawLine(point_of_origin.X, point_of_origin.Y, SKPoints1.X, SKPoints1.Y, Magenta)
                                canvas.DrawLine(point_of_origin.X, point_of_origin.Y, SKPoints2.X, SKPoints2.Y, Magenta)
                                canvas.DrawLine(point_of_origin.X, point_of_origin.Y, SKPoints3.X, SKPoints3.Y, Magenta)
                                'canvas.DrawLine(point_of_origin.X, point_of_origin.Y, projected_arrow.X, projected_arrow.Y, Magenta)
                            End If
                        End Using
                    End Using
                End Using
            End Using

            '–––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––
            ' get the data into displayedBitmap because the PictureBox is only accepting an usual System.Drawing.Bitmap.
            '–––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––

            Using image As SKImage = surface.Snapshot()
                Using data As SKData = image.Encode(SKEncodedImageFormat.Png, 100)
                    Using mStream As New IO.MemoryStream(data.ToArray())
                        displayedBitmap = New Bitmap(mStream, False)
                    End Using
                End Using
            End Using

        End Using
        Return True
    End Function
End Class
#Enable Warning IDE1006 ' Benennungsstile
#Enable Warning CA1707 ' Bezeichner dürfen keine Unterstriche enthalten
#Enable Warning CA1051 ' Sichtbare Instanzfelder nicht deklarieren
#Enable Warning CA2211 ' Nicht konstante Felder dürfen nicht sichtbar sein