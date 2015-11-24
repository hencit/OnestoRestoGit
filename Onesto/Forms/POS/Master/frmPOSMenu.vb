Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class frmPOSMenu
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim flag As Integer

    Private Sub frmPOSMenu_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If flag = 0 Then
            If MsgBox("Data belum tersimpan, Anda yakin mau menutup form ini?", vbYesNo + vbCritical, Me.Text) = vbNo Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub frmPOSMenu_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Add item cmbPRStatus
        cmd = New SqlCommand("select menu_category_code from mt_menu_category where active = 1", cn)

        cn.Open()
        Dim myReader = cmd.ExecuteReader

        cbKategori.Items.Add("Semua")

        While myReader.Read
            cbKategori.Items.Add(myReader.GetString(0))
        End While

        myReader.Close()
        cn.Close()

        cbKategori.SelectedIndex = 0

        clear_obj()
        lock_obj(True)
        clear_lvw()

        If ListView1.Items.Count > 0 Then
            ListView1.Items.Item(0).Selected = True
            ListView1_Click(sender, e)
        End If
    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        If flag = 0 And btnAdd.Enabled = False Then lock_obj(True)
        With ListView1.SelectedItems.Item(0)
            flag = 1
            txtKodeMenu.Text = .SubItems.Item(0).Text
            txtNamaMenu.Text = .SubItems.Item(1).Text
            txtMenuKategori.Text = .SubItems.Item(2).Text
            txtSatuan.Text = .SubItems.Item(3).Text
            txtSalesPrice.Text = FormatNumber(.SubItems.Item(4).Text, 0)
        End With
    End Sub

    Public Property MenuKategori() As String
        Get
            Return txtMenuKategori.Text
        End Get
        Set(ByVal Value As String)
            txtMenuKategori.Text = Value
        End Set
    End Property

    Sub clear_lvw()
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Kode Menu", 150)
            .Columns.Add("Nama", 200)
            .Columns.Add("Kategori", 100)
            .Columns.Add("Satuan", 80)
            .Columns.Add("Harga Satuan", 100, HorizontalAlignment.Right)
        End With

        cmd = New SqlCommand("sp_mt_menu_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@menu_name", SqlDbType.NVarChar, 100)
        prm1.Value = IIf(txtFilter.Text = "", DBNull.Value, txtFilter.Text)
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@menu_category_code", SqlDbType.NVarChar, 20)
        prm2.Value = IIf(cbKategori.SelectedIndex = 0, DBNull.Value, cbKategori.SelectedItem.ToString)

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        Dim lvItem As ListViewItem
        Dim intCurrRow As Integer

        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(0)))
            lvItem.Tag = intCurrRow 'ID

            For i = 1 To 3
                lvItem.SubItems.Add(myReader.Item(i))
            Next

            lvItem.SubItems.Add(FormatNumber(myReader.Item(4), 0))

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
        flag = 0
        txtKodeMenu.Text = ""
        txtNamaMenu.Text = ""
        txtMenuKategori.Text = ""
        txtSatuan.Text = ""
        txtSalesPrice.Text = CStr(FormatNumber(0, 0))
    End Sub

    Sub lock_obj(ByVal isLock As Boolean)
        txtKodeMenu.ReadOnly = isLock
        txtNamaMenu.ReadOnly = isLock
        btnMenuKategori.Enabled = Not isLock
        txtSatuan.ReadOnly = isLock
        txtSalesPrice.ReadOnly = isLock

        btnEdit.Enabled = isLock
        btnAdd.Enabled = isLock
        btnSave.Enabled = Not isLock
        btnCancel.Enabled = Not isLock

        If flag = 0 Then
            txtKodeMenu.ReadOnly = isLock
            btnDelete.Enabled = False
        Else
            txtKodeMenu.ReadOnly = True
            btnDelete.Enabled = Not isLock
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        clear_obj()
        clear_lvw()
        lock_obj(False)
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        lock_obj(False)
        If flag <> 0 Then txtKodeMenu.ReadOnly = True
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        lock_obj(True)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtKodeMenu.Text = "" Then
            MsgBox("Kode tidak boleh kosong!", vbCritical + vbOKOnly, Me.Text)
            txtKodeMenu.Focus()
            Exit Sub
        End If

        If txtNamaMenu.Text = "" Then
            MsgBox("Nama tidak boleh kosong!", vbCritical + vbOKOnly, Me.Text)
            txtNamaMenu.Focus()
            Exit Sub
        End If

        If txtMenuKategori.Text = "" Then
            MsgBox("Kategori tidak boleh kosong!", vbCritical + vbOKOnly, Me.Text)
            txtMenuKategori.Focus()
            Exit Sub
        End If

        '@menu_code nvarchar(20),
        '@menu_name nvarchar(100) = null,
        '@menu_category_code nvarchar(20) = null,
        '@satuan nvarchar(20) = null,
        '@sales_price decimal(18,0) = 0,
        '@user_code nvarchar(50) = null
        Try
            cmd = New SqlCommand(IIf(flag = 0, "sp_mt_menu_INS", "sp_mt_menu_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@menu_code", SqlDbType.NVarChar, 20)
            prm1.Value = txtKodeMenu.Text
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@menu_name", SqlDbType.NVarChar, 100)
            prm2.Value = txtNamaMenu.Text
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@menu_category_code", SqlDbType.NVarChar, 20)
            prm3.Value = txtMenuKategori.Text
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@satuan", SqlDbType.NVarChar, 20)
            prm4.Value = txtSatuan.Text
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@sales_price", SqlDbType.Decimal)
            prm5.Value = FormatNumber(txtSalesPrice.Text)

            Dim prm10 As SqlParameter = cmd.Parameters.Add("@user_code", SqlDbType.NVarChar, 50)
            prm10.Value = My.Settings.UserName

            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            clear_lvw()
            lock_obj(True)
            flag = 1
        Catch ex As Exception
            If ConnectionState.Open = True Then cn.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If flag <> 0 Then
            If MsgBox("Anda yakin menghapus?", vbYesNo + vbCritical, Me.Text) = vbYes Then
                Try
                    cmd = New SqlCommand("DELETE mt_menu WHERE menu_code = '" + txtKodeMenu.Text + "' ", cn)

                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                    clear_obj()
                    btnAdd_Click(sender, e)

                Catch ex As Exception
                    MsgBox("Error Message : " + ex.Message)
                    If ConnectionState.Open = True Then cn.Close()
                End Try
            End If
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

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        clear_lvw()
    End Sub

    Private Sub cbKategori_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbKategori.SelectedIndexChanged
        btnFilter_Click(sender, e)
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            btnFilter_Click(sender, e)
        End If
    End Sub

    Private Sub txtSalesPrice_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSalesPrice.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtSalesPrice_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSalesPrice.LostFocus
        If txtSalesPrice.Text = "" Then
            txtSalesPrice.Text = FormatNumber(1, 0)
        End If
        If CInt(txtSalesPrice.Text) < 0 Then
            txtSalesPrice.Text = FormatNumber(CInt(txtSalesPrice.Text) * -1, 0)
        End If
        txtSalesPrice.Text = FormatNumber(txtSalesPrice.Text, 0)
    End Sub

    Private Sub btnMenuKategori_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMenuKategori.Click
        Dim NewFormDialog As New fdlMenuCategory
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub
End Class