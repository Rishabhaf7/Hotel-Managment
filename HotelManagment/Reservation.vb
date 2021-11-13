Imports System.Data.SqlClient
Public Class Reservation

    Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Rishabh Gupta\Downloads\Technos.in\HotelManagment\HotelVbDb.mdf;Integrated Security=True")
    Private Sub Reservation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Display()
    End Sub

    'Private Sub FillClient()
    '    con.Open()
    '    Dim cmd As New SqlCommand("Select * from Clienttbl", con)
    '    Dim adapter As New SqlDataAdapter(cmd)
    '    Dim Tbl As New DataTable()
    '    adapter.Fill(Tbl)
    '    Clid.DataSource = Tbl
    '    Clid.DisplayMember = Clid
    '    Clid.ValueMember = Clid
    '    Clid.DataBindings.Add("Text", Tbl, "Clid")
    '    con.Close()
    'End Sub

    'Private Sub FillRoom()
    '    con.Open()
    '    Dim cmd As New SqlCommand("Select * from Roomtbl", con)
    '    Dim adapter As New SqlDataAdapter(cmd)
    '    Dim Tbl As New DataTable()
    '    adapter.Fill(Tbl)
    '    'Clid.DataSource = Tbl
    '    'Clid.DisplayMember = Clid
    '    'Clid.ValueMember = Clid
    '    RNo.DataBindings.Add("Text", Tbl, "Rid")
    '    con.Close()
    'End Sub

    'Private Sub getname()
    '    con.Open()
    '    Dim query = "select * from clienttbl where clid=" & Clid.Text & ""
    '    Dim cmd As New SqlCommand(query, con)
    '    Dim dt As New DataTable
    '    Dim reader As SqlDataReader
    '    reader = cmd.ExecuteReader()
    '    While reader.Read
    '        ClName.Text = "" + reader(1).ToString()
    '    End While
    '    con.Close()
    'End Sub

    Private Sub Display()
        con.Open()
        Dim sql = "Select * from Reservationtbl"
        Dim adapter As SqlDataAdapter
        adapter = New SqlDataAdapter(sql, con)
        Dim builder As SqlCommandBuilder
        builder = New SqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        ResDGV.DataSource = ds.Tables(0)
        con.Close()
    End Sub

    Private Sub Clear()
        ClName.Clear()
        RNo.Clear()
        Din.ResetText()
        Dout.ResetText()
    End Sub

    Dim Key = 0
    Private Sub ResDGV_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles ResDGV.CellMouseClick
        Dim row As DataGridViewRow = ResDGV.Rows(e.RowIndex)
        ClName.Text = row.Cells(1).Value.ToString
        RNo.Text = row.Cells(2).Value.ToString
        Din.Text = row.Cells(3).Value.ToString
        Dout.Text = row.Cells(4).Value.ToString
        If RNo.Text = "" Then
            Key = 0
        Else
            Key = Convert.ToInt32(row.Cells(0).Value.ToString)
        End If
    End Sub

    Private Sub button1_click(sender As Object, e As EventArgs) Handles Button1.Click
        con.Open()
        Dim query As String
        query = "insert into reservationtbl values('" & ClName.Text & "','" & RNo.Text & "','" & Din.Text & "','" & Dout.Text & "')"
        Dim cmd As New SqlCommand
        cmd = New SqlCommand(query, con)
        cmd.ExecuteNonQuery()
        MsgBox("Reservation Done !")
        con.Close()
        UpdateRoom()
        Display()
        Clear()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim R As New Room
        R.Show()
        Me.Hide()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim S As New Staff
        S.Show()
        Me.Hide()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim Cl As New Client
        Cl.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Clear()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        con.Open()
        Dim query As String
        query = "update Reservationtbl Set Clientname='" & ClName.Text & "',Roomid='" & RNo.Text & "',Datein='" & Din.Text & "',Dateout='" & Dout.Text & "' where Resid=" & Key & ""
        Dim cmd As SqlCommand
        cmd = New SqlCommand(query, con)
        cmd.ExecuteNonQuery()
        MsgBox("Detail Updated !")
        con.Close()
        Display()
        Clear()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Key = 0 Then
            MsgBox("Missing Information !")
        Else
            Try
                con.Open()
                Dim query As String
                query = "Delete from Reservationtbl where Resid=" & Key & ""
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, con)
                cmd.ExecuteNonQuery()
                MsgBox("Reservation Deleted !")
                con.Close()
                Display()
                Clear()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub UpdateRoom()
        Dim Status = "Booked"
        Try
            con.Open()
            Dim query As String
            query = "update Roomtbl Set RStatus='" & Status & "' where Rid=" & RNo.Text & ""
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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