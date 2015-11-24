Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class FrmLogin
    Dim isPassed As Boolean

    Private Sub FrmLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Text = "Login - Versi : " + GetSysInit("versi")
        MaximizeBox = False
        MinimizeBox = False
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim cn As SqlConnection = New SqlConnection(strConnection)
        Dim cmd As SqlCommand = New SqlCommand("SELECT user_code,[password] FROM mt_user where active=1 and user_code='" & txtUserID.Text & "' ", cn)

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        If Not myReader.HasRows Then
            MsgBox("User belum terdaftar!", vbOKOnly + vbCritical, "Login")
            txtPassword.Text = ""
            txtUserID.Focus()
        Else
            myReader.Read()
            '-------------------------DECRYPT FROM DB-------------------------------
            Dim cipherText As String = myReader.GetString(1)
            Dim password As String = "dexter"
            Dim wrapper As New Dencrypt(password)
            Dim LoginPassword As String = wrapper.DecryptData(cipherText)
            '-------------------------END OF DECRYPT--------------------------------

            If txtPassword.Text <> LoginPassword Then
                MsgBox("Password salah!", vbOKOnly + vbCritical, "Login")
                txtPassword.Text = ""
                txtPassword.Focus()
            Else
                frmMenu.Show()
                frmMenu.ToolStripStatusLabel1.Text = "User login: " + txtUserID.Text
                My.Settings.UserName = myReader.GetString(0)
                My.Settings.Save()
                isPassed = True
                Me.Close()

                myReader.Close()

                'cmd = New SqlCommand("usp_sys_company_SEL", cn)
                'cmd.CommandType = CommandType.StoredProcedure

                'prm = cmd.Parameters.Add("@company_id", SqlDbType.Int)
                'prm.Value = 1

                'myReader = cmd.ExecuteReader()
                'While myReader.Read
                '    p_CompanyName = myReader.GetString(2)
                'End While
                frmMenu.Text = frmMenu.Text + " - " + GetSysInit("company")
            End If
            'Do While myReader.Read()
            'Console.WriteLine("{0},{1}", myReader.GetString(1), myReader.GetString(2))
            'passwd = myReader.GetString(2)
            'Loop

        End If
        myReader.Close()
        cn.Close()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        End
    End Sub

    Private Sub FrmLogin_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If isPassed = False Then End
        Me.Dispose()
    End Sub

    Private Sub txtPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnLogin_Click(sender, e)
        End If
    End Sub
    
End Class