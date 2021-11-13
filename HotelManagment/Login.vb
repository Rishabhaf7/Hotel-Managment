Imports System.Data.SqlClient

Public Class Login

    Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Rishabh Gupta\Downloads\Technos.in\HotelManagment\HotelVbDb.mdf;Integrated Security=True")

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        Application.Exit()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Admin_Login.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Sid.Text = "" Or SPass.Text = "" Then
            MsgBox("Enter Your Name and Password !")
        Else
            con.Open()
            Dim query = "Select * from Stafftbl where Stname='" & Sid.Text & "' AND Stpass='" & SPass.Text & "' "
            Dim Cmd As New SqlCommand(query, con)
            Dim da As SqlDataAdapter = New SqlDataAdapter(Cmd)
            Dim ds As DataSet = New DataSet()
            da.Fill(ds)
            Dim a As Integer
            a = ds.Tables(0).Rows.Count
            If a = 0 Then
                MsgBox("Wrong ID Or Password ")
            Else
                Reservation.Show()
                Me.Hide()
            End If
            con.Close()
            End If
    End Sub

    Private Sub CB1_CheckedChanged(sender As Object, e As EventArgs) Handles CB1.CheckedChanged
        If CB1.CheckState = CheckState.Checked Then
            SPass.PasswordChar = ""
        Else
            SPass.PasswordChar = "*"
        End If
    End Sub
End Class