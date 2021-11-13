Imports System.Data.SqlClient

Public Class Staff

    Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Rishabh Gupta\Downloads\Technos.in\HotelManagment\HotelVbDb.mdf;Integrated Security=True")

    Private Sub Display()
        con.Open()
        Dim sql = "Select * from Stafftbl"
        Dim adapter As SqlDataAdapter
        adapter = New SqlDataAdapter(sql, con)
        Dim builder As SqlCommandBuilder
        builder = New SqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        StaffDGV.DataSource = ds.Tables(0)
        con.Close()
    End Sub

    Private Sub Clear()
        SName.Clear()
        GenTb.Clear()
        SPhone.Clear()
        SPass.Clear()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Clear()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        con.Open()
        Dim query As String
        query = "insert into Stafftbl values('" & SName.Text & "','" & SPhone.Text & "','" & GenTb.Text & "','" & SPass.Text & "')"
        Dim cmd As New SqlCommand
        cmd = New SqlCommand(query, con)
        cmd.ExecuteNonQuery()
        MsgBox("Staff Detail Inserted !")
        con.Close()
        Display()
        Clear()
    End Sub
    Dim Key = 0

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If SName.Text = "" Or GenTb.Text = "" Or SPhone.Text = "" Or SPass.Text = "" Then
            MsgBox("Missing Information")
        Else
            Try
                con.Open()
                Dim query As String
                query = "update Stafftbl Set Stname='" & SName.Text & "',Stphone='" & SPhone.Text & "',Stgender='" & GenTb.Text & "',Stpass='" & SPass.Text & "' where Sid=" & Key & ""
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, con)
                cmd.ExecuteNonQuery()
                MsgBox("Staff Detail Updated !")
                con.Close()
                Display()
                Clear()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Key = 0 Then
            MsgBox("Missing Information !")
        Else
            Try
                con.Open()
                Dim query As String
                query = "Delete from Stafftbl where Sid=" & Key & ""
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, con)
                cmd.ExecuteNonQuery()
                MsgBox("Staff Detail Deleted !")
                con.Close()
                Display()
                Clear()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub StaffDGV_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles StaffDGV.CellMouseClick
        Dim row As DataGridViewRow = StaffDGV.Rows(e.RowIndex)
        SName.Text = row.Cells(1).Value.ToString
        SPhone.Text = row.Cells(2).Value.ToString
        GenTb.Text = row.Cells(3).Value.ToString
        SPass.Text = row.Cells(4).Value.ToString
        If SName.Text = "" Then
            Key = 0
        Else
            Key = Convert.ToInt32(row.Cells(0).Value.ToString)
        End If
    End Sub

    Private Sub Staff_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Display()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim Cl As New Client
        Cl.Show()
        Me.Hide()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim R As New Room
        R.Show()
        Me.Hide()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim Res As New Reservation
        Res.Show()
        Me.Hide()
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        Login.Show()
        Me.Hide()
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        Login.Show()
        Me.Hide()
    End Sub
End Class