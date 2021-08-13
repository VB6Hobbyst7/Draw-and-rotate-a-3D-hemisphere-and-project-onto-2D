Imports System.Windows.Media.Media3D

Public NotInheritable Class FormMain
    Private ReadOnly Deu As New System.Globalization.CultureInfo("de-DE")
    Private hemisphere As ClassHemisphere
    Private program_has_finished_loading As Boolean
    Private ReadOnly DarkBlue As Color = Color.FromArgb(0, 0, 50)
    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackColor = Color.FromArgb(160, 176, 167)
        TextBox_phi.Text = My.Resources.zero
        TextBox_theta.Text = My.Resources.zero
    End Sub

    Private Async Sub FormMain_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Await Task.Run(Sub() hemisphere = New ClassHemisphere(radius:=350.0))

        TextBox_Kamera.Text = Math.Round(hemisphere.Camera, 0).ToString(Deu)
        TextBox_Fenster.Text = Math.Round(hemisphere.Window_distance, 0).ToString(Deu)
        Await hemisphere.calculate_Async()
        PictureBox1.Image = ClassHemisphere.displayedBitmap
        program_has_finished_loading = True
    End Sub

    Private Async Sub FormMain_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode

            Case Keys.W

                If hemisphere.Theta > 0US Then
                    hemisphere.Theta -= 1US
                    find_Vector()
                    Await hemisphere.calculate_Async()
                    PictureBox1.Image = ClassHemisphere.displayedBitmap
                End If

            Case Keys.S

                If hemisphere.Theta < 90US Then
                    hemisphere.Theta += 1US
                    find_Vector()
                    Await hemisphere.calculate_Async()
                    PictureBox1.Image = ClassHemisphere.displayedBitmap
                End If

            Case Keys.A

                If hemisphere.Phi < 360US Then
                    hemisphere.Phi += 1US
                    find_Vector()
                    Await hemisphere.calculate_Async()
                    PictureBox1.Image = ClassHemisphere.displayedBitmap
                End If
                If hemisphere.Phi = 360US Then hemisphere.Phi = 0US

            Case Keys.D

                If hemisphere.Phi > 0US Then
                    hemisphere.Phi -= 1US
                    find_Vector()
                    Await hemisphere.calculate_Async()
                    PictureBox1.Image = ClassHemisphere.displayedBitmap
                End If

            Case Else
                Exit Select
        End Select

        TextBox_theta.Text = hemisphere.Theta.ToString(Deu).PadLeft(2, "0"c) & " °"

        TextBox_phi.Text = hemisphere.Phi.ToString(Deu).PadLeft(2, "0"c) & " °"

    End Sub

    Private Async Sub Form1_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseWheel
        If e.Delta > 0 Then
            hemisphere.change_Camera_height(50.0)
        Else
            hemisphere.change_Camera_height(-50.0)
        End If
        Await hemisphere.calculate_Async()
        TextBox_Kamera.Text = Math.Round(hemisphere.Camera, 0).ToString(Deu)
    End Sub

    Private Async Sub TextBox_Kamera_TextChanged(sender As Object, e As EventArgs) Handles TextBox_Kamera.TextChanged
        If hemisphere IsNot Nothing AndAlso program_has_finished_loading Then
            If Double.TryParse(TextBox_Kamera.Text, hemisphere.Camera) Then
                TextBox_Kamera.ForeColor = DarkBlue
                hemisphere.Camera_Vector = New Vector3D(0, 0, hemisphere.Camera)
                Await hemisphere.calculate_Async()
                PictureBox1.Image = ClassHemisphere.displayedBitmap
                GC.Collect()
            Else
                TextBox_Kamera.ForeColor = Color.Red
            End If
        End If
    End Sub

    Private Sub TextBox_Fenster_TextChanged(sender As Object, e As EventArgs) Handles TextBox_Fenster.TextChanged
        If hemisphere IsNot Nothing Then

            Dim successful1 As Boolean = Double.TryParse(TextBox_Kamera.Text, hemisphere.Camera)
            Dim window As Double
            Dim successful2 As Boolean = Double.TryParse(TextBox_Fenster.Text, window)

            If window >= hemisphere.Camera OrElse Not successful1 OrElse Not successful2 Then
                TextBox_Fenster.ForeColor = Color.Red
            Else
                TextBox_Fenster.ForeColor = DarkBlue
                hemisphere.Window_distance = window
            End If
        End If
    End Sub

    Private Async Sub NumericUpDown_x_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown_x.ValueChanged
        hemisphere.rotation_angle_x = NumericUpDown_x.Value
        Await hemisphere.calculate_Async()
        PictureBox1.Image = ClassHemisphere.displayedBitmap
        GC.Collect()
    End Sub

    Private Async Sub find_Vector()
        Dim found_Vector As Vector3D = Await find_Vector_Async()
        TextBox_x.Text = Math.Round(found_Vector.X, 3).ToString(Deu)
        TextBox_y.Text = Math.Round(found_Vector.Y, 3).ToString(Deu)
        TextBox_z.Text = Math.Round(found_Vector.Z, 3).ToString(Deu)
    End Sub

    Private Async Function find_Vector_Async() As Task(Of Vector3D)
        Return Await Task.Run(Function() hemisphere.getVector(CDbl(hemisphere.Theta), CDbl(hemisphere.Phi)))
    End Function

End Class