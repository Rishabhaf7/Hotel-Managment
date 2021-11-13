Imports System.Data.SqlClient

Public Class Client

    Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Rishabh Gupta\Downloads\Technos.in\HotelManagment\HotelVbDb.mdf;Integrated Security=True")
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        con.Open()
        Dim query As String
        query = "insert into ClientTbl values('" & ClNameTb.Text & "','" & GenTb.Text & "','" & ClAge.Text & "','" & ClPhoneTb.Text & "','" & CountryTb.Text & "')"
        Dim cmd As New SqlCommand
        cmd = New SqlCommand(query, con)
        cmd.ExecuteNonQuery()
        MsgBox("Client Inserted !")
        con.Close()
        Display()
        Clear()
    End Sub

    Private Sub Display()
        con.Open()
        Dim sql = "Select * from ClientTbl"
        Dim adapter As SqlDataAdapter
        adapter = New SqlDataAdapter(sql, con)
        Dim builder As SqlCommandBuilder
        builder = New SqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        ClientDGV.DataSource = ds.Tables(0)
        con.Close()
    End Sub

    Private Sub Clear()
        ClNameTb.Clear()
        GenTb.Clear()
        ClAge.Clear()
        ClPhoneTb.Clear()
        CountryTb.Clear()
    End Sub

    Dim Key = 0
    Private Sub ClientDGV_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles ClientDGV.CellMouseClick
        Dim row As DataGridViewRow = ClientDGV.Rows(e.RowIndex)
        ClNameTb.Text = row.Cells(1).Value.ToString
        GenTb.Text = row.Cells(2).Value.ToString
        ClAge.Text = row.Cells(3).Value.ToString
        ClPhoneTb.Text = row.Cells(4).Value.ToString
        CountryTb.Text = row.Cells(5).Value.ToString
        If ClNameTb.Text = "" Then
            Key = 0
        Else
            Key = Convert.ToInt32(row.Cells(0).Value.ToString)
        End If
    End Sub

    Private Sub Client_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Display()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Clear()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Key = 0 Then
            MsgBox("Missing Information !")
        Else
            Try
                con.Open()
                Dim query As String
                query = "Delete from ClientTbl where Clid=" & Key & ""
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, con)
                cmd.ExecuteNonQuery()
                MsgBox("Client Deleted !")
                con.Close()
                Display()
                Clear()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ClNameTb.Text = "" Or GenTb.Text = "" Or ClAge.Text = "" Or ClPhoneTb.Text = "" Or CountryTb.Text = "" Then
            MsgBox("Missing Information")
        Else
            Try
                con.Open()
                Dim query As String
                query = "update ClientTbl Set Clname='" & ClNameTb.Text & "',Clgender='" & GenTb.Text & "',Clage='" & ClAge.Text & "',Clphone='" & ClPhoneTb.Text & "',Clcountry='" & CountryTb.Text & "' where ClId=" & Key & ""
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, con)
                cmd.ExecuteNonQuery()
                MsgBox("Client Detail Updated !")
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