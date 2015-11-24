Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class frmDelegasiTugasList
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand

    Dim m_Status As String
    Dim isShowAll As Boolean
    Dim val1, val2 As String

    Private Sub frmDelegasiTugasList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 Then
            If ListView1.SelectedItems.Count > 0 Then
                Dim tempTugasNo As String
                With ListView1.SelectedItems.Item(0)
                    tempTugasNo = .SubItems.Item(0).Text
                End With

                With fdlApprove
                    .m_TugasNo = tempTugasNo
                    .MdiParent = frmMenu
                    .Show()
                End With
            Else
                MsgBox("Silahkan pilih tugas terlebih dahulu!", vbCritical)
                ListView1.Focus()
            End If
        End If
    End Sub


    Private Sub frmDelegasiTugasList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Add item cbStatus
        cmd = New SqlCommand("select [status] from sys_status where flag = 'delegasi_tugas' order by sort asc ", cn)

        cn.Open()
        Dim myReader = cmd.ExecuteReader

        While myReader.Read
            cbStatus.Items.Add(myReader.GetString(0))
        End While

        chbDate.Checked = False
        chbDate_CheckedChanged(sender, e)

        myReader.Close()
        cn.Close()

        btnFilter_Click(sender, e)
        cbStatus.SelectedIndex = 0

        lock_obj()
    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        With ListView1.SelectedItems.Item(0)
            txtNoTugasD.Text = .SubItems.Item(0).Text
            txtDeskripsiD.Text = .SubItems.Item(2).Text
            txtNamaKaryawanD.Text = .SubItems.Item(3).Text
            m_Status = .SubItems.Item(5).Text

            If .SubItems.Item(9).Text = "True" Then
                cbApprove1.Checked = True
            Else
                cbApprove1.Checked = False
            End If

            txtApprove1Persentase.Text = .SubItems.Item(10).Text

            If .SubItems.Item(12).Text = "True" Then
                cbApprove2.Checked = True
            Else
                cbApprove2.Checked = False
            End If

            txtApprove2Persentase.Text = .SubItems.Item(13).Text
        End With
        lock_obj()
        'a.tugas_no,0
        'a.tugas_date,1
        'a.tugas_description,2
        'a.karyawan_name,3
        'a.dept_code,4
        'a.tugas_status,5
        'a.due_date,6
        'a.finish_date,7
        'a.finish_percent,8
        'a.approve1_flag,9
        'a.approve1_percent,10
        'a.approve1_notes,11
        'a.approve2_flag,12
        'a.approve2_percent,13
        'a.approve2_notes,14
    End Sub

    Sub clear_obj()
        txtNoTugasD.Text = ""
        txtDeskripsiD.Text = ""
        txtNamaKaryawanD.Text = ""
        m_Status = ""
        cbApprove1.Checked = False
        txtApprove1Persentase.Text = "0"
        cbApprove2.Checked = False
        txtApprove2Persentase.Text = "0"
    End Sub

    Sub lock_obj()
        If m_Status = "Selesai" Then
            gbApprove1.Enabled = True
            gbApprove2.Enabled = False
        ElseIf m_Status = "Approve1" Then
            gbApprove1.Enabled = False
            gbApprove2.Enabled = True
        Else
            gbApprove1.Enabled = False
            gbApprove2.Enabled = False
        End If
    End Sub
    Sub clear_lvw()
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("No Tugas", 50)
            .Columns.Add("Tanggal Tugas", 100)
            .Columns.Add("Deskripsi", 200)
            .Columns.Add("Nama Karyawan", 120)
            .Columns.Add("Kode Departemen", 120)
            .Columns.Add("Status", 80)
            .Columns.Add("Deadline", 100)
            .Columns.Add("Tanggal Selesai", 150)
            .Columns.Add("Persentase Selesai", 80)
            .Columns.Add("approve1_flag", 0)
            .Columns.Add("approve1_percent", 0)
            .Columns.Add("Approve1 Notes", 100)
            .Columns.Add("approve2_flag", 0)
            .Columns.Add("approve2_percent", 0)
            .Columns.Add("Approve2 Notes", 100)
        End With

        cmd = New SqlCommand("sp_tr_tugas_list_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@tugas_no", SqlDbType.NVarChar, 50)
        prm1.Value = IIf(txtNoTugas.Text = "", DBNull.Value, txtNoTugas.Text)
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@tugas_description", SqlDbType.NVarChar, 255)
        prm2.Value = IIf(txtDeskripsi.Text = "", DBNull.Value, txtDeskripsi.Text)
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@tugas_date_from", SqlDbType.SmallDateTime)
        prm3.Value = IIf(isShowAll = False, dtpPRDateFrom.Value.Date, DBNull.Value)
        Dim prm4 As SqlParameter = cmd.Parameters.Add("@tugas_date_to", SqlDbType.SmallDateTime)
        prm4.Value = IIf(isShowAll = False, dtpPRDateTo.Value.Date, DBNull.Value)
        Dim prm5 As SqlParameter = cmd.Parameters.Add("@karyawan_name", SqlDbType.NVarChar, 50)
        prm5.Value = IIf(txtNamaKaryawan.Text = "", DBNull.Value, txtNamaKaryawan.Text)
        Dim prm6 As SqlParameter = cmd.Parameters.Add("@dept_code", SqlDbType.NVarChar, 50)
        prm6.Value = IIf(txtDept.Text = "", DBNull.Value, txtDept.Text)
        Dim prm7 As SqlParameter = cmd.Parameters.Add("@tugas_status", SqlDbType.NVarChar, 50)
        If cbStatus.SelectedIndex = 0 Then
            prm7.Value = "All"
        Else
            prm7.Value = cbStatus.Text
        End If

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        Dim lvItem As ListViewItem
        Dim intCurrRow As Integer

        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(0)))
            lvItem.Tag = intCurrRow 'ID
            
            lvItem.SubItems.Add(myReader.GetDateTime(1))
            lvItem.SubItems.Add(myReader.GetString(2))
            lvItem.SubItems.Add(myReader.GetString(3))
            lvItem.SubItems.Add(myReader.GetString(4))
            lvItem.SubItems.Add(myReader.GetString(5))
            lvItem.SubItems.Add(myReader.GetDateTime(6))
            For i = 7 To 14
                If myReader.Item(i) Is System.DBNull.Value Then
                    lvItem.SubItems.Add("")
                Else
                    lvItem.SubItems.Add(myReader.Item(i))
                End If
            Next

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

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        clear_lvw()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        val1 = "tr_tugas_"
        val2 = "tambah"
        If otorisasi(val1 + val2) = False Then
            MsgBox("Anda tidak mempunyai otorisasi " + val2 + " modul ini!,Silahkan hubungi administrator anda untuk diberikan otorisasi", vbCritical)
            Exit Sub
        End If

        With frmDelegasiTugas
            .m_Flag = 0
            .MdiParent = frmMenu
            .Show()
        End With
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

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        val1 = "tr_tugas_"
        val2 = "buka"
        If otorisasi(val1 + val2) = False Then
            MsgBox("Anda tidak mempunyai otorisasi " + val2 + " modul ini!,Silahkan hubungi administrator anda untuk diberikan otorisasi", vbCritical)
            Exit Sub
        End If

        Dim tempTugasNo As String
        With ListView1.SelectedItems.Item(0)
            tempTugasNo = .SubItems.Item(0).Text
        End With

        With frmDelegasiTugas
            .m_Flag = 1
            .m_TugasNo = tempTugasNo
            .MdiParent = frmMenu
            .Show()
        End With
    End Sub

    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        val1 = "tr_tugas_"
        val2 = "buka"
        If otorisasi(val1 + val2) = False Then
            MsgBox("Anda tidak mempunyai otorisasi " + val2 + " modul ini!,Silahkan hubungi administrator anda untuk diberikan otorisasi", vbCritical)
            Exit Sub
        End If

        If ListView1.SelectedItems.Count > 0 Then
            ListView1_DoubleClick(sender, e)
        Else
            MsgBox("Silahkan pilih tugas terlebih dahulu!", vbCritical)
            ListView1.Focus()
        End If
    End Sub


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ListView1Sorter = New lvColumnSorter()
        ListView1.ListViewItemSorter = ListView1Sorter
    End Sub

    Private Sub cbStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbStatus.SelectedIndexChanged
        btnFilter_Click(sender, e)
    End Sub

    Private Sub txtSkuName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDept.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then btnFilter_Click(sender, e)
    End Sub

    Private Sub txtCName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDeskripsi.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then btnFilter_Click(sender, e)
    End Sub

    Private Sub txtSONo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNamaKaryawan.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then btnFilter_Click(sender, e)
    End Sub

    Private Sub txtWONo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNoTugas.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then btnFilter_Click(sender, e)
    End Sub

    Private Sub chbDate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chbDate.CheckedChanged
        If chbDate.Checked = True Then
            dtpPRDateFrom.Enabled = True
            dtpPRDateTo.Enabled = True
            isShowAll = False
        Else
            dtpPRDateFrom.Enabled = False
            dtpPRDateTo.Enabled = False
            dtpPRDateFrom.Value = Now
            dtpPRDateTo.Value = Now
            isShowAll = True
        End If
    End Sub

    Private Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        chbDate.Checked = False
        txtNamaKaryawan.Text = ""
        txtDeskripsi.Text = ""
        txtNoTugas.Text = ""
        txtDept.Text = ""
        cbStatus.SelectedIndex = 0
    End Sub

    'Autorefresh---Hendra
    Public Sub frmDelegasiTugasListShow(ByVal sender As System.Object, ByVal e As System.EventArgs)
        btnFilter_Click(sender, e)
    End Sub

    Private Sub btnApprove1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprove1.Click
        val1 = "tr_tugas_"
        val2 = "approve1"
        If otorisasi(val1 + val2) = False Then
            MsgBox("Anda tidak mempunyai otorisasi " + val2 + " modul ini!,Silahkan hubungi administrator anda untuk diberikan otorisasi", vbCritical)
            Exit Sub
        End If

        If CInt(txtApprove1Persentase.Text) = 0 Then
            MsgBox("Approval Persentase tugas tidak boleh kosong!", vbCritical + vbOKOnly, Me.Text)
            txtApprove1Persentase.Focus()
            Exit Sub
        End If

        If MsgBox("Anda yakin approve tugas ini?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            Try
                cmd = New SqlCommand("sp_tr_tugas_APPROVE1", cn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim prm1 As SqlParameter = cmd.Parameters.Add("@tugas_no", SqlDbType.Int)
                prm1.Value = CInt(txtNoTugasD.Text)
                Dim prm12 As SqlParameter = cmd.Parameters.Add("@approve1_flag", SqlDbType.Bit)
                prm12.Value = True
                Dim prm3 As SqlParameter = cmd.Parameters.Add("@approve1_percent", SqlDbType.Int)
                prm3.Value = CInt(txtApprove1Persentase.Text)
                Dim prm8 As SqlParameter = cmd.Parameters.Add("@tugas_status", SqlDbType.NVarChar, 25)
                prm8.Value = "Approve1"

                Dim prm22 As SqlParameter = cmd.Parameters.Add("@user_code", SqlDbType.NVarChar, 50)
                prm22.Value = My.Settings.UserName

                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()

                clear_obj()
                clear_lvw()
                lock_obj()

            Catch ex As Exception
                If ConnectionState.Open = True Then cn.Close()
                MsgBox("Error Message : " + ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnApprove2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprove2.Click
        val1 = "tr_tugas_"
        val2 = "approve2"
        If otorisasi(val1 + val2) = False Then
            MsgBox("Anda tidak mempunyai otorisasi " + val2 + " modul ini!,Silahkan hubungi administrator anda untuk diberikan otorisasi", vbCritical)
            Exit Sub
        End If

        If CInt(txtApprove2Persentase.Text) = 0 Then
            MsgBox("Approval Persentase tugas tidak boleh kosong!", vbCritical + vbOKOnly, Me.Text)
            txtApprove2Persentase.Focus()
            Exit Sub
        End If


        If MsgBox("Anda yakin approve tugas ini?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            Try
                cmd = New SqlCommand("sp_tr_tugas_approve2", cn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim prm1 As SqlParameter = cmd.Parameters.Add("@tugas_no", SqlDbType.Int)
                prm1.Value = CInt(txtNoTugasD.Text)
                Dim prm12 As SqlParameter = cmd.Parameters.Add("@approve2_flag", SqlDbType.Bit)
                prm12.Value = True
                Dim prm3 As SqlParameter = cmd.Parameters.Add("@approve2_percent", SqlDbType.Int)
                prm3.Value = CInt(txtApprove2Persentase.Text)
                
                Dim prm8 As SqlParameter = cmd.Parameters.Add("@tugas_status", SqlDbType.NVarChar, 25)
                prm8.Value = "Complete"

                Dim prm22 As SqlParameter = cmd.Parameters.Add("@user_code", SqlDbType.NVarChar, 50)
                prm22.Value = My.Settings.UserName

                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()

                clear_obj()
                clear_lvw()
                lock_obj()
            Catch ex As Exception
                If ConnectionState.Open = True Then cn.Close()
                MsgBox("Error Message : " + ex.Message)
            End Try
        End If
    End Sub

    Private Sub txtApprove1Persentase_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtApprove1Persentase.LostFocus
        If txtApprove1Persentase.Text = "" Then
            txtApprove1Persentase.Text = "0"
        End If
        If CInt(txtApprove1Persentase.Text) > 100 Then
            txtApprove1Persentase.Text = "100"
        End If
    End Sub

    Private Sub txtApprove2Persentase_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtApprove2Persentase.LostFocus
        If txtApprove2Persentase.Text = "" Then
            txtApprove2Persentase.Text = "0"
        End If
        If CInt(txtApprove2Persentase.Text) > 100 Then
            txtApprove2Persentase.Text = "100"
        End If
    End Sub

    Private Sub txtApprove1Persentase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtApprove1Persentase.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtApprove2Persentase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtApprove2Persentase.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
End Class