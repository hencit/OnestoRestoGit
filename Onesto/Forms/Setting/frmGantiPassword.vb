Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Security.Cryptography
Public Class frmGantiPassword
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand

    Private Sub frmGantiPassword_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtKodeUser.Text = My.Settings.UserName
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtPasswordLama.Text = "" Then
            MsgBox("Password lama tidak boleh kosong", vbCritical)
            txtPasswordLama.Focus()
            Exit Sub
        End If

        If txtPasswordBaru.Text = "" Then
            MsgBox("Password baru tidak boleh kosong", vbCritical)
            txtPasswordBaru.Focus()
            Exit Sub
        End If

        If txtPasswordBaru2.Text = "" Then
            MsgBox("Ulang password baru tidak boleh kosong", vbCritical)
            txtPasswordBaru2.Focus()
            Exit Sub
        End If

        If MsgBox("Anda yakin ubah password?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            Try
                cmd = New SqlCommand("SELECT [password] FROM mt_user where active=1 and user_code='" & txtKodeUser.Text & "' ", cn)
                cn.Open()

                Dim myReader As SqlDataReader = cmd.ExecuteReader()

                If myReader.HasRows Then
                    myReader.Read()
                    '-------------------------DECRYPT FROM DB-------------------------------
                    Dim cipherText As String = myReader.GetString(0)
                    Dim password As String = "dexter"
                    Dim wrapper As New Dencrypt(password)
                    Dim LoginPassword As String = wrapper.DecryptData(cipherText)
                    '-------------------------END OF DECRYPT--------------------------------
                    cn.Close()
                    If txtPasswordLama.Text <> LoginPassword Then
                        MsgBox("Password Lama salah!", vbCritical)
                        txtPasswordLama.Text = ""
                        txtPasswordLama.Focus()
                        Exit Sub
                    End If

                    If txtPasswordBaru.Text <> txtPasswordBaru2.Text Then
                        MsgBox("Password baru berbeda dengan Ulang password baru!", vbCritical)
                        txtPasswordBaru.Text = ""
                        txtPasswordBaru2.Text = ""
                        txtPasswordBaru.Focus()
                        Exit Sub
                    End If

                    GantiPassword()
                Else
                    cn.Close()
                    MsgBox("User ini sudah tidak aktif, penggantian password dibatalkan", vbCritical)
                    Me.Close()
                End If
            Catch ex As Exception
                MsgBox("Error Message : " + ex.Message)
                If ConnectionState.Open = True Then cn.Close()
            End Try
        End If

    End Sub

    Sub GantiPassword()
        Try
            '------------------------ENCRYPTING PASSWORD----------------------------
            Dim plainText As String = txtPasswordBaru.Text
            Dim password As String = "dexter"

            Dim wrapper As New Dencrypt(password)
            Dim EncryptPass As String = wrapper.EncryptData(plainText)
            '------------------------END OF ENCRYPTING PASSWORD----------------------------
            cmd = New SqlCommand("sp_mt_user_UPD", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@user_code", SqlDbType.NVarChar, 50)
            prm1.Value = txtKodeUser.Text
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@password", SqlDbType.NVarChar, 50)
            prm2.Value = EncryptPass
            Dim prm5 = cmd.Parameters.Add("@submit", SqlDbType.NVarChar, 50)
            prm5.Value = My.Settings.UserName
            
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            MsgBox("Ubah password berhasil!", vbInformation)
            Me.Close()
        Catch ex As Exception
            MsgBox("Error Message : " + ex.Message)
            If ConnectionState.Open = True Then cn.Close()
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class