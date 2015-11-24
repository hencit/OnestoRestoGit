Public Class frmAbout
    Private Sub frmAbout_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label1.Text = "Versi : " + GetSysInit("versi")
        Label2.Text = "Dibuat khusus untuk : " + GetSysInit("company")
        MaximizeBox = False
        MinimizeBox = False
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class