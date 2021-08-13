<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMain
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label_Phi = New System.Windows.Forms.Label()
        Me.Label_theta = New System.Windows.Forms.Label()
        Me.Label_x = New System.Windows.Forms.Label()
        Me.Label_y = New System.Windows.Forms.Label()
        Me.Label_z = New System.Windows.Forms.Label()
        Me.TextBox_phi = New System.Windows.Forms.TextBox()
        Me.TextBox_theta = New System.Windows.Forms.TextBox()
        Me.TextBox_x = New System.Windows.Forms.TextBox()
        Me.TextBox_y = New System.Windows.Forms.TextBox()
        Me.TextBox_z = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label_Kamera = New System.Windows.Forms.Label()
        Me.Label_Fenster = New System.Windows.Forms.Label()
        Me.TextBox_Kamera = New System.Windows.Forms.TextBox()
        Me.TextBox_Fenster = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NumericUpDown_x = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown_x, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label_Phi
        '
        Me.Label_Phi.AutoSize = True
        Me.Label_Phi.Location = New System.Drawing.Point(606, 5)
        Me.Label_Phi.Name = "Label_Phi"
        Me.Label_Phi.Size = New System.Drawing.Size(44, 23)
        Me.Label_Phi.TabIndex = 0
        Me.Label_Phi.Text = "ϕ [°]"
        '
        'Label_theta
        '
        Me.Label_theta.AutoSize = True
        Me.Label_theta.Location = New System.Drawing.Point(606, 69)
        Me.Label_theta.Name = "Label_theta"
        Me.Label_theta.Size = New System.Drawing.Size(42, 23)
        Me.Label_theta.TabIndex = 1
        Me.Label_theta.Text = "θ [°]"
        '
        'Label_x
        '
        Me.Label_x.AutoSize = True
        Me.Label_x.Location = New System.Drawing.Point(606, 133)
        Me.Label_x.Name = "Label_x"
        Me.Label_x.Size = New System.Drawing.Size(18, 23)
        Me.Label_x.TabIndex = 2
        Me.Label_x.Text = "x"
        '
        'Label_y
        '
        Me.Label_y.AutoSize = True
        Me.Label_y.Location = New System.Drawing.Point(606, 197)
        Me.Label_y.Name = "Label_y"
        Me.Label_y.Size = New System.Drawing.Size(19, 23)
        Me.Label_y.TabIndex = 3
        Me.Label_y.Text = "y"
        '
        'Label_z
        '
        Me.Label_z.AutoSize = True
        Me.Label_z.Location = New System.Drawing.Point(606, 261)
        Me.Label_z.Name = "Label_z"
        Me.Label_z.Size = New System.Drawing.Size(18, 23)
        Me.Label_z.TabIndex = 4
        Me.Label_z.Text = "z"
        '
        'TextBox_phi
        '
        Me.TextBox_phi.Location = New System.Drawing.Point(606, 33)
        Me.TextBox_phi.Name = "TextBox_phi"
        Me.TextBox_phi.ReadOnly = True
        Me.TextBox_phi.Size = New System.Drawing.Size(100, 31)
        Me.TextBox_phi.TabIndex = 5
        '
        'TextBox_theta
        '
        Me.TextBox_theta.Location = New System.Drawing.Point(606, 97)
        Me.TextBox_theta.Name = "TextBox_theta"
        Me.TextBox_theta.ReadOnly = True
        Me.TextBox_theta.Size = New System.Drawing.Size(100, 31)
        Me.TextBox_theta.TabIndex = 6
        '
        'TextBox_x
        '
        Me.TextBox_x.Location = New System.Drawing.Point(606, 161)
        Me.TextBox_x.Name = "TextBox_x"
        Me.TextBox_x.ReadOnly = True
        Me.TextBox_x.Size = New System.Drawing.Size(100, 31)
        Me.TextBox_x.TabIndex = 7
        '
        'TextBox_y
        '
        Me.TextBox_y.Location = New System.Drawing.Point(606, 225)
        Me.TextBox_y.Name = "TextBox_y"
        Me.TextBox_y.ReadOnly = True
        Me.TextBox_y.Size = New System.Drawing.Size(100, 31)
        Me.TextBox_y.TabIndex = 8
        '
        'TextBox_z
        '
        Me.TextBox_z.Location = New System.Drawing.Point(606, 289)
        Me.TextBox_z.Name = "TextBox_z"
        Me.TextBox_z.ReadOnly = True
        Me.TextBox_z.Size = New System.Drawing.Size(100, 31)
        Me.TextBox_z.TabIndex = 9
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(600, 600)
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'Label_Kamera
        '
        Me.Label_Kamera.AutoSize = True
        Me.Label_Kamera.Location = New System.Drawing.Point(606, 325)
        Me.Label_Kamera.Name = "Label_Kamera"
        Me.Label_Kamera.Size = New System.Drawing.Size(108, 23)
        Me.Label_Kamera.TabIndex = 11
        Me.Label_Kamera.Text = "Kamerahöhe"
        '
        'Label_Fenster
        '
        Me.Label_Fenster.AutoSize = True
        Me.Label_Fenster.Location = New System.Drawing.Point(606, 389)
        Me.Label_Fenster.Name = "Label_Fenster"
        Me.Label_Fenster.Size = New System.Drawing.Size(107, 23)
        Me.Label_Fenster.TabIndex = 12
        Me.Label_Fenster.Text = "Fensterhöhe"
        '
        'TextBox_Kamera
        '
        Me.TextBox_Kamera.Location = New System.Drawing.Point(606, 353)
        Me.TextBox_Kamera.Name = "TextBox_Kamera"
        Me.TextBox_Kamera.Size = New System.Drawing.Size(100, 31)
        Me.TextBox_Kamera.TabIndex = 13
        '
        'TextBox_Fenster
        '
        Me.TextBox_Fenster.Location = New System.Drawing.Point(606, 417)
        Me.TextBox_Fenster.Name = "TextBox_Fenster"
        Me.TextBox_Fenster.Size = New System.Drawing.Size(100, 31)
        Me.TextBox_Fenster.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(606, 453)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(169, 23)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Drehung um x-Achse"
        '
        'NumericUpDown_x
        '
        Me.NumericUpDown_x.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericUpDown_x.Location = New System.Drawing.Point(606, 481)
        Me.NumericUpDown_x.Maximum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumericUpDown_x.Minimum = New Decimal(New Integer() {180, 0, 0, -2147483648})
        Me.NumericUpDown_x.Name = "NumericUpDown_x"
        Me.NumericUpDown_x.Size = New System.Drawing.Size(120, 33)
        Me.NumericUpDown_x.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(730, 477)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(16, 23)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "°"
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(778, 606)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NumericUpDown_x)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox_Fenster)
        Me.Controls.Add(Me.TextBox_Kamera)
        Me.Controls.Add(Me.Label_Fenster)
        Me.Controls.Add(Me.Label_Kamera)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TextBox_z)
        Me.Controls.Add(Me.TextBox_y)
        Me.Controls.Add(Me.TextBox_x)
        Me.Controls.Add(Me.TextBox_theta)
        Me.Controls.Add(Me.TextBox_phi)
        Me.Controls.Add(Me.Label_z)
        Me.Controls.Add(Me.Label_y)
        Me.Controls.Add(Me.Label_x)
        Me.Controls.Add(Me.Label_theta)
        Me.Controls.Add(Me.Label_Phi)
        Me.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "FormMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "hemisphere rotation"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown_x, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label_Phi As Label
    Friend WithEvents Label_theta As Label
    Friend WithEvents Label_x As Label
    Friend WithEvents Label_y As Label
    Friend WithEvents Label_z As Label
    Friend WithEvents TextBox_phi As TextBox
    Friend WithEvents TextBox_theta As TextBox
    Friend WithEvents TextBox_x As TextBox
    Friend WithEvents TextBox_y As TextBox
    Friend WithEvents TextBox_z As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label_Kamera As Label
    Friend WithEvents Label_Fenster As Label
    Friend WithEvents TextBox_Kamera As TextBox
    Friend WithEvents TextBox_Fenster As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents NumericUpDown_x As NumericUpDown
    Friend WithEvents Label2 As Label
End Class
