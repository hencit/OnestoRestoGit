Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class frmPOSMenuCategory
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim flag As Integer

    Private Sub frmPOSMenuCategory_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If flag = 0 Then
            If MsgBox("Data belum tersimpan, Anda yakin mau menutup form ini?", vbYesNo + vbCritical, Me.Text) = vbNo Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub frmPOSMenuCategory_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
            txtKodeKategori.Text = .SubItems.Item(0).Text
            txtNamaKategori.Text = .SubItems.Item(1).Text
        End With
    End Sub
    Sub clear_lvw()
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Kode Kategori", 150)
            .Columns.Add("Nama Kategori", 150)
        End With

        cmd = New SqlCommand("select menu_category_code,menu_category_name from mt_menu_category where active = 1", cn)

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
        flag = 0
        txtKodeKategori.Text = ""
        txtNamaKategori.Text = ""
    End Sub

    Sub lock_obj(ByVal isLock As Boolean)
        txtKodeKategori.ReadOnly = isLock
        txtNamaKategori.ReadOnly = isLock

        btnEdit.Enabled = isLock
        btnAdd.Enabled = isLock
        btnSave.Enabled = Not isLock
        btnCancel.Enabled = Not isLock

        If flag = 0 Then
            txtKodeKategori.ReadOnly = isLock
            btnDelete.Enabled = False
        Else
            txtKodeKategori.ReadOnly = True
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
        If flag <> 0 Then txtKodeKategori.ReadOnly = True
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        lock_obj(True)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtKodeKategori.Text = "" Then
            MsgBox("Kode kategori tidak boleh kosong!", vbCritical + vbOKOnly, Me.Text)
            txtKodeKategori.Focus()
            Exit Sub
        End If

        If txtNamaKategori.Text = "" Then
            MsgBox("Nama kategori tidak boleh kosong!", vbCritical + vbOKOnly, Me.Text)
            txtNamaKategori.Focus()
            Exit Sub
        End If

        Try
            cmd = New SqlCommand(IIf(flag = 0, "sp_mt_menu_category_INS", "sp_mt_menu_category_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm2 As SqlParameter = cmd.Parameters.Add("@menu_category_code", SqlDbType.NVarChar, 20)
            prm2.Value = txtKodeKategori.Text
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@menu_category_name", SqlDbType.NVarChar, 50)
            prm3.Value = txtNamaKategori.Text
            Dim prm10 As SqlParameter = cmd.Parameters.Add("@user_code", SqlDbType.NVarChar, 50)
            prm10.Value = My.Settings.UserName

            cn.Open()
            cmd.ExecuteReader()
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
                    cmd = New SqlCommand("DELETE mt_menu_category WHERE menu_category_code = '" + txtKodeKategori.Text + "' ", cn)

                    cn.Open()
                    cmd.ExecuteReader()
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
End Class