Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO

Public Class frmMenu
    'Dim strConnection As String = My.Settings.ConnStr
    'Dim cn As SqlConnection = New SqlConnection(strConnection)
    'Dim cmd As SqlCommand
    Dim menuheader As String = "Onesto"
    Private Sub frmMenu_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Text = menuheader
        Try
            Dim fileReader As System.IO.StreamReader
            fileReader = My.Computer.FileSystem.OpenTextFileReader("C:\ProgramData\kbh.txt")

            Dim stringReader As String
            stringReader = fileReader.ReadLine()

            If stringReader = "k0t4r0m1n4m1" Then
                Dim strConnection As String = My.Settings.ConnStr
                Dim cn As SqlConnection = New SqlConnection(strConnection)
                Dim cmd As SqlCommand
                Dim userCount As Integer
                Dim userEncrypt As String
                Dim userVal As Integer

                cmd = New SqlCommand("select COUNT(user_code) from mt_user WHERE active=1 and user_code <>'ADMIN' ", cn)

                cn.Open()
                Dim myReader = cmd.ExecuteReader

                While myReader.Read
                    userCount = myReader.GetInt32(0)
                End While

                myReader.Close()
                cn.Close()

                cmd = New SqlCommand("SELECT value from sys_init where code='val'", cn)
                cn.Open()
                Dim myReader1 = cmd.ExecuteReader

                While myReader1.Read
                    userEncrypt = myReader1.GetString(0)
                End While

                myReader1.Close()
                cn.Close()

                '-------------------------DECRYPT FROM DB-------------------------------
                Dim cipherText As String = userEncrypt
                Dim password As String = "onesto"
                Dim wrapper As New Dencrypt(password)
                userVal = CInt(wrapper.DecryptData(cipherText))
                '-------------------------END OF DECRYPT--------------------------------

                If userCount <= userVal Then
                    FrmLogin.ShowDialog()
                Else
                    MsgBox("Jumlah user lebih dari " + CStr(userVal) + " silahkan membeli user tambahan!", MsgBoxStyle.Critical)
                    End
                End If
            End If
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Critical)
            MsgBox("System error tidak bisa login, silahkan menghubungi kami untuk bantuan lebih lanjut.", MsgBoxStyle.Critical)
            End
        End Try
    End Sub
   
    Private Sub frmMenu_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox("Anda yakin ingin keluar dari aplikasi?", vbCritical + vbOKCancel, Me.Text) = vbCancel Then
            e.Cancel = True
        End If
    End Sub
    Private m_ChildFormNumber As Integer

    Private Sub UserCardToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserCardToolStripMenuItem.Click
        frmUser.MdiParent = Me
        frmUser.Show()
        frmUser.BringToFront()
    End Sub

    Private Sub LogOutToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogOutToolStripMenuItem1.Click
        If MsgBox("Anda yakin log out?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            Me.Text = menuheader
            FrmLogin.ShowDialog()
        End If
    End Sub

    Private Sub GantiPasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GantiPasswordToolStripMenuItem.Click
        frmGantiPassword.MdiParent = Me
        frmGantiPassword.Show()
        frmGantiPassword.BringToFront()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        frmAbout.MdiParent = Me
        frmAbout.Show()
        frmAbout.BringToFront()
    End Sub

    Private Sub POSToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POSToolStripMenuItem1.Click
        frmPOS.MdiParent = Me
        frmPOS.Show()
        frmPOS.BringToFront()
    End Sub

    Private Sub TableToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TableToolStripMenuItem.Click
        frmTable.MdiParent = Me
        frmTable.Show()
        frmTable.BringToFront()
    End Sub

    Private Sub MenuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuToolStripMenuItem.Click
        frmPOSMenu.MdiParent = Me
        frmPOSMenu.Show()
        frmPOSMenu.BringToFront()
    End Sub

    Private Sub MenuKategoriToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuKategoriToolStripMenuItem.Click
        frmPOSMenuCategory.MdiParent = Me
        frmPOSMenuCategory.Show()
        frmPOSMenuCategory.BringToFront()
    End Sub

    Private Sub ReceiptToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReceiptToolStripMenuItem.Click
        frmPOSReceipt.MdiParent = Me
        frmPOSReceipt.Show()
        frmPOSReceipt.BringToFront()
    End Sub

    Private Sub PenjualanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PenjualanToolStripMenuItem.Click
        rptPOS.MdiParent = Me
        rptPOS.Show()
        rptPOS.BringToFront()
    End Sub
End Class