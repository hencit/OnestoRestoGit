Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Public Class frmUser
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim Flag As Integer

    Private Sub frmUser_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Flag = 0 Then
            If MsgBox("Data belum tersimpan, Anda yakin mau menutup form ini?", vbYesNo + vbCritical, Me.Text) = vbNo Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub frmUser_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        clear_obj()
        lock_obj(True)
        clear_lvw()

        'If ListView1.Items.Count > 0 Then
        '    ListView1.Items.Item(0).Selected = True
        '    ListView1_Click(sender, e)
        'End If
    End Sub
    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        If Flag = 0 And btnAdd.Enabled = False Then lock_obj(True)
        With ListView1.SelectedItems.Item(0)
            '-------------------------DECRYPT FROM DB-------------------------------
            Dim cipherText As String = .SubItems.Item(1).Text
            Dim password As String = "dexter"
            Dim wrapper As New Dencrypt(password)
            Dim DecryptPassword As String = wrapper.DecryptData(cipherText)
            '-------------------------END OF DECRYPT--------------------------------

            Flag = 1
            txtKodeUser.Text = .SubItems.Item(0).Text
            txtUserPassword.Text = DecryptPassword
        End With
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
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

        cmd = New SqlCommand("SELECT value from sys_init where code='val' ", cn)
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

        If userCount < userVal Then
            Flag = 0
            clear_obj()
            lock_obj(False)
        Else
            MsgBox("Jumlah user lebih dari " + CStr(userVal) + " silahkan membeli user tambahan!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        lock_obj(False)
        If Flag <> 0 Then txtKodeUser.ReadOnly = True
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        lock_obj(True)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        

        If txtKodeUser.Text = "" Then
            MsgBox("Kode user tidak boleh kosong !", vbCritical, Me.Text)
            txtKodeUser.Focus()
            Exit Sub
        End If

        If txtUserPassword.Text = "" Then
            MsgBox("Password tidak boleh kosong !", vbCritical, Me.Text)
            txtUserPassword.Focus()
            Exit Sub
        End If

        If txtKodeUser.Text.Contains(" ") Then
            MsgBox("Kode user berisi spasi ' ', silahkan diisi kembali dengan benar!", vbCritical, Me.Text)
            txtKodeUser.Clear()
            txtKodeUser.Focus()
            Exit Sub
        End If
        Try
            '------------------------ENCRYPTING PASSWORD----------------------------
            Dim plainText As String = txtUserPassword.Text
            Dim password As String = "dexter"

            Dim wrapper As New Dencrypt(password)
            Dim EncryptPass As String = wrapper.EncryptData(plainText)
            '------------------------END OF ENCRYPTING PASSWORD----------------------------
            cmd = New SqlCommand(IIf(Flag = 0, "sp_mt_user_INS", "sp_mt_user_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@user_code", SqlDbType.NVarChar, 50)
            prm1.Value = txtKodeUser.Text
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@password", SqlDbType.NVarChar, 50)
            prm2.Value = EncryptPass
            Dim prm5 = cmd.Parameters.Add("@submit", SqlDbType.NVarChar, 50)
            prm5.Value = My.Settings.UserName

            If Flag = 0 Then
                Dim prm3 As SqlParameter = cmd.Parameters.Add("@row_count", SqlDbType.Int)
                prm3.Direction = ParameterDirection.Output
                cn.Open()
                cmd.ExecuteReader()
                cn.Close()
                If prm3.Value = 1 Then
                    MsgBox("Kode user sudah ada!", vbCritical, Me.Text)
                ElseIf prm3.Value = 2 Then
                    MsgBox("Kode user sudah pernah dihapus!", vbCritical, Me.Text)
                Else
                    clear_lvw()
                    lock_obj(True)
                    Flag = 1
                End If
            Else
                cn.Open()
                cmd.ExecuteReader()
                cn.Close()
                clear_lvw()
                lock_obj(True)
            End If
        Catch ex As Exception
            MsgBox("Error Message : " + ex.Message)
            If ConnectionState.Open = True Then cn.Close()
        End Try

    End Sub

    Sub clear_lvw()
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Kode User", 400)
            .Columns.Add("Password", 0)
        End With

        cmd = New SqlCommand("SELECT user_code,password FROM mt_user WHERE active = 1 AND user_code <> 'ADMIN' ", cn)

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        Dim lvItem As ListViewItem
        Dim intCurrRow As Integer

        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(0)))
            lvItem.Tag = intCurrRow 'ID

            lvItem.SubItems.Add(myReader.Item(1))

            If intCurrRow Mod 2 = 0 Then
                lvItem.BackColor = Color.Lavender
            Else
                lvItem.BackColor = Color.White
            End If
            lvItem.UseItemStyleForSubItems = True

            ListView1.Items.Add(lvItem)
            intCurrRow += 1
        End While

        myReader.Close()
        cn.Close()
    End Sub

    Sub clear_obj()
        Flag = 0
        txtKodeUser.Text = ""
        txtUserPassword.Text = ""
    End Sub

    Sub lock_obj(ByVal isLock As Boolean)
        txtKodeUser.ReadOnly = isLock
        txtUserPassword.ReadOnly = isLock

        btnEdit.Enabled = isLock
        btnAdd.Enabled = isLock
        btnSave.Enabled = Not isLock
        btnCancel.Enabled = Not isLock

        If Flag = 0 Then
            txtKodeUser.ReadOnly = isLock
            btnDelete.Enabled = False
            btnOtorisasi.Enabled = False
        Else
            txtKodeUser.ReadOnly = True
            btnDelete.Enabled = Not isLock
            btnOtorisasi.Enabled = Not isLock
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
       

        If MsgBox("Anda yakin menghapus?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            cmd = New SqlCommand("sp_mt_user_DEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@user_code", SqlDbType.NVarChar, 50)
            prm1.Value = txtKodeUser.Text
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@submit", SqlDbType.NVarChar, 50)
            prm2.Value = My.Settings.UserName

            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

            clear_lvw()
            clear_obj()
            lock_obj(True)
        End If
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ListView1Sorter = New lvColumnSorter()
        ListView1.ListViewItemSorter = ListView1Sorter
    End Sub

    Private Sub ListView1_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles ListView1.ColumnClick
        If (e.Column = ListView1Sorter.SortColumn) Then
            ' Reverse the current sort direction for this column.
            If (ListView1Sorter.Order = Windows.Forms.SortOrder.Ascending) Then
                ListView1Sorter.Order = Windows.Forms.SortOrder.Descending
            Else
                ListView1Sorter.Order = Windows.Forms.SortOrder.Ascending
            End If
        Else
            ' Set the column number that is to be sorted; default to ascending.
            ListView1Sorter.SortColumn = e.Column
            ListView1Sorter.Order = Windows.Forms.SortOrder.Ascending
        End If

        ' Perform the sort with these new sort options.
        ListView1.Sort()
    End Sub

    Private Sub btnOtorisasi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOtorisasi.Click
        

        With frmOtorisasi
            .m_Flag = 1
            .UserCode = txtKodeUser.Text
            .MdiParent = frmMenu
            .Show()
        End With
    End Sub
End Class