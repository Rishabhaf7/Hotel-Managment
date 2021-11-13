Public Class Admin_Login
    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Application.Exit()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Login.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Pass.Text = "Admin" Then
            Dim Staff As New Staff
            Staff.Show()
            Me.Hide()
        Else
            MsgBox("Wrong Password !")
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.CheckState = CheckState.Checked Then
            Pass.PasswordChar = ""
        Else
            Pass.PasswordChar = "*"
        End If
    End Sub
End Class