Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class frmOtorisasi
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim flag As Integer
    Dim flag_detail As Integer
    Dim m_role_code As String
    Dim val1, val2 As String

    Private Sub frmOtorisasi_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        flag = 0
        clear_objD()
        clear_lvw()
        lock_objD(False)
    End Sub

    Private Sub frmOtorisasi_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'If flag = 0 Then
        '    If MsgBox("Data belum tersimpan, Anda yakin mau menutup form ini?", vbYesNo + vbCritical, Me.Text) = vbNo Then
        '        e.Cancel = True
        '    End If
        'End If
    End Sub

    Public Property m_Flag() As Integer
        Get
            Return flag
        End Get
        Set(ByVal Value As Integer)
            flag = Value
        End Set
    End Property

    Public Property m_Flag_detail() As Integer
        Get
            Return flag_detail
        End Get
        Set(ByVal Value As Integer)
            flag_detail = Value
        End Set
    End Property

    Public Property UserCode() As String
        Get
            Return txtUserCode.Text
        End Get
        Set(ByVal Value As String)
            txtUserCode.Text = Value
        End Set
    End Property

    Public Property RoleCode() As String
        Get
            Return m_role_code
        End Get
        Set(ByVal Value As String)
            m_role_code = Value
        End Set
    End Property

    Public Property Detail() As String
        Get
            Return txtDetail.Text
        End Get
        Set(ByVal Value As String)
            txtDetail.Text = Value
        End Set
    End Property

    Public Property Category() As String
        Get
            Return txtCategory.Text
        End Get
        Set(ByVal Value As String)
            txtCategory.Text = Value
        End Set
    End Property

    Sub clear_objD()
        flag_detail = 0
        m_role_code = ""
        txtDetail.Text = ""
        txtCategory.Text = ""
    End Sub

    Sub lock_objD(ByVal isLock As Boolean)
        btnRole.Enabled = Not isLock
        btnSaveD.Enabled = Not isLock
        btnDeleteD.Enabled = Not isLock
        btnAddD.Enabled = Not isLock
    End Sub

    Sub clear_lvw()
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("otorisasi_dtl_id", 0)
            .Columns.Add("role_code", 0)
            .Columns.Add("Detail", 500)
            .Columns.Add("Kategori", 330)
        End With

        cmd = New SqlCommand("sp_mt_user_otorisasi_dtl_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@user_code", SqlDbType.NVarChar, 50)
        prm1.Value = txtUserCode.Text

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        Dim lvItem As ListViewItem
        Dim intCurrRow As Integer

        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(0)))
            lvItem.Tag = intCurrRow 'ID

            lvItem.SubItems.Add(myReader.Item(1))
            lvItem.SubItems.Add(myReader.Item(2))
            lvItem.SubItems.Add(myReader.Item(3))

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

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        With ListView1.SelectedItems.Item(0)
            flag_detail = .SubItems.Item(0).Text
            m_role_code = .SubItems.Item(1).Text
            txtDetail.Text = .SubItems.Item(2).Text
            txtCategory.Text = .SubItems.Item(3).Text

            If btnSaveD.Enabled = True Then
                btnRole.Enabled = False
            End If
        End With
    End Sub

    Private Sub btnSaveD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveD.Click
        val1 = "mt_otorisasi_"
        val2 = "simpan"
        If otorisasi(val1 + val2) = False Then
            MsgBox("Anda tidak mempunyai otorisasi " + val2 + " modul ini!,Silahkan hubungi administrator anda untuk diberikan otorisasi", vbCritical)
            Exit Sub
        End If

        If txtUserCode.Text = "" Then
            MsgBox("Kode User tidak boleh kosong!", vbCritical, "Warning")
            txtUserCode.Focus()
            Exit Sub
        End If

            If m_role_code = "" Then
                MsgBox("Silahkan pilih detail otorisasi terlebih dahulu!", vbCritical + vbOKOnly, Me.Text)
                btnRole.Focus()
                Exit Sub
            End If
        
        Try
            cmd = New SqlCommand("sp_mt_user_otorisasi_dtl_INS", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm11 As SqlParameter = cmd.Parameters.Add("@user_code", SqlDbType.NVarChar, 50)
            prm11.Value = txtUserCode.Text
            Dim prm12 As SqlParameter = cmd.Parameters.Add("@role_code", SqlDbType.NVarChar, 50)
            prm12.Value = m_role_code
            Dim prm14 As SqlParameter = cmd.Parameters.Add("@row_count", SqlDbType.Int)
            prm14.Direction = ParameterDirection.Output

            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

            clear_lvw()
            clear_objD()

        Catch ex As Exception
            MsgBox("Error Message: " + ex.Message)
            If ConnectionState.Open = True Then cn.Close()
        End Try

    End Sub

    Private Sub btnDeleteD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteD.Click
        val1 = "mt_otorisasi_"
        val2 = "hapus"
        If otorisasi(val1 + val2) = False Then
            MsgBox("Anda tidak mempunyai otorisasi " + val2 + " modul ini!,Silahkan hubungi administrator anda untuk diberikan otorisasi", vbCritical)
            Exit Sub
        End If

        If flag_detail = 0 Then
            Exit Sub
        End If

        cmd = New SqlCommand("sp_mt_user_otorisasi_dtl_DEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@otorisasi_dtl_id", SqlDbType.Int)
        prm1.Value = flag_detail

        cn.Open()
        cmd.ExecuteReader()
        cn.Close()

        clear_lvw()
        clear_objD()

        btnRole.Enabled = True
    End Sub

    Private Sub btnAddD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddD.Click
        btnRole.Enabled = True
        clear_objD()
    End Sub

    Private Sub btnRole_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRole.Click
        val1 = "mt_otorisasi_"
        val2 = "tambah"
        If otorisasi(val1 + val2) = False Then
            MsgBox("Anda tidak mempunyai otorisasi " + val2 + " modul ini!,Silahkan hubungi administrator anda untuk diberikan otorisasi", vbCritical)
            Exit Sub
        End If

        If txtUserCode.Text = "" Then
            MsgBox("Kode User tidak boleh kosong!", vbCritical, "Warning")
            txtUserCode.Focus()
            Exit Sub
        End If

        Dim NewFormDialog As New fdlRole
        NewFormDialog.UserCode = txtUserCode.Text
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        clear_lvw()
        clear_objD()
    End Sub

    'Autorefresh---Hendra
    Public Sub frmOtorisasiRefresh(ByVal sender As System.Object, ByVal e As System.EventArgs)
        btnFilter_Click(sender, e)
    End Sub
End Class