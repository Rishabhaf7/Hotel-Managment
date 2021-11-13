Imports System.Data.SqlClient

Public Class Room
    Private Sub Room_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Display()
    End Sub

    Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Rishabh Gupta\Downloads\Technos.in\HotelManagment\HotelVbDb.mdf;Integrated Security=True")

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        con.Open()
        Dim query As String
        query = "insert into Roomtbl values('" & RPhone.Text & "','" & RStatus.Text & "')"
        Dim cmd As New SqlCommand
        cmd = New SqlCommand(query, con)
        cmd.ExecuteNonQuery()
        MsgBox("Room Detail Inserted !")
        con.Close()
        Display()
        Clear()
    End Sub


    Private Sub Display()
        con.Open()
        Dim sql = "Select * from Roomtbl"
        Dim adapter As SqlDataAdapter
        adapter = New SqlDataAdapter(sql, con)
        Dim builder As SqlCommandBuilder
        builder = New SqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        RoomDGV.DataSource = ds.Tables(0)
        con.Close()
    End Sub

    Private Sub Clear()
        RPhone.Clear()
        RStatus.Clear()
    End Sub

    Dim Key = 0
    Private Sub RoomDGV_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles RoomDGV.CellMouseClick
        Dim row As DataGridViewRow = RoomDGV.Rows(e.RowIndex)
        RPhone.Text = row.Cells(1).Value.ToString
        RStatus.Text = row.Cells(2).Value.ToString
        If RPhone.Text = "" Then
            Key = 0
        Else
            Key = Convert.ToInt32(row.Cells(0).Value.ToString)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Clear()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If RPhone.Text = "" Or RStatus.Text = "" Then
            MsgBox("Missing Information")
        Else
            Try
                con.Open()
                Dim query As String
                query = "update Roomtbl Set Rname='" & RPhone.Text & "',RStatus='" & RStatus.Text & "' where RId=" & Key & ""
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, con)
                cmd.ExecuteNonQuery()
                MsgBox("Room Detail Updated !")
                con.Close()
                Display()
                Clear()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub


    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        If Key = 0 Then
            MsgBox("Missing Information !")
        Else
            Try
                con.Open()
                Dim query As String
                query = "Delete from RoomTbl where Rid=" & Key & ""
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, con)
                cmd.ExecuteNonQuery()
                MsgBox("Room Detail Deleted !")
                con.Close()
                Display()
                Clear()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim S As New Staff
        S.Show()
        Me.Hide()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim Cl As New Client
        Cl.Show()
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