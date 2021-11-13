<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Splash
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Pr = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PB = New System.Windows.Forms.ProgressBar()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(72, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(439, 42)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Hotel Managment System"
        '
        'Pr
        '
        Me.Pr.AutoSize = True
        Me.Pr.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pr.ForeColor = System.Drawing.Color.White
        Me.Pr.Location = New System.Drawing.Point(251, 105)
        Me.Pr.Name = "Pr"
        Me.Pr.Size = New System.Drawing.Size(43, 36)
        Me.Pr.TabIndex = 1
        Me.Pr.Text = "%"
        '
        'Timer1
        '
        '
        'PB
        '
        Me.PB.Location = New System.Drawing.Point(-1, 240)
        Me.PB.Name = "PB"
        Me.PB.Size = New System.Drawing.Size(580, 10)
        Me.PB.TabIndex = 2
        '
        'Splash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Brown
        Me.ClientSize = New System.Drawing.Size(579, 250)
        Me.Controls.Add(Me.PB)
        Me.Controls.Add(Me.Pr)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Splash"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Pr As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents PB As ProgressBar
End Class
