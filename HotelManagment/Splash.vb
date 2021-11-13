Public Class Splash
    Private Sub Splash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        PB.Increment(1)
        Pr.Text = Convert.ToString(PB.Value) + "%"
        If PB.Value = 100 Then
            Me.Hide()
            Login.Show()
            Timer1.Enabled = False
        End If

    End Sub


End Class
