Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class frmPOS
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim flag As Integer
    Dim flag_detail As Integer

    Private Sub frmPOS_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If flag = 0 Then
            If MsgBox("Data belum tersimpan, Anda yakin mau menutup form ini?", vbYesNo + vbCritical, Me.Text) = vbNo Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub frmPOS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        flag = 0

        cbTransType.Items.Add("Dine In")
        cbTransType.Items.Add("Take Away")
        cbTransType.SelectedIndex = 0

        cbType.Items.Add("M")
        cbType.Items.Add("J")
        cbType.SelectedIndex = 0

        clear_obj()
        clear_objD()
        clear_lvw()
        lock_obj(False)
        lock_objD(False)
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

    Public Property BillNo() As String
        Get
            Return txtBillNo.Text
        End Get
        Set(ByVal Value As String)
            txtBillNo.Text = Value
        End Set
    End Property

    Public Property TableCode() As String
        Get
            Return txtTableCode.Text
        End Get
        Set(ByVal Value As String)
            txtTableCode.Text = Value
        End Set
    End Property

    Public Property MenuCode() As String
        Get
            Return txtMenu.Text
        End Get
        Set(ByVal Value As String)
            txtMenu.Text = Value
        End Set
    End Property

    Public Property Deskripsi() As String
        Get
            Return txtDeskripsi.Text
        End Get
        Set(ByVal Value As String)
            txtDeskripsi.Text = Value
        End Set
    End Property

    Public Property Type() As Integer
        Get
            Return cbType.SelectedIndex
        End Get
        Set(ByVal Value As Integer)
            cbType.SelectedIndex = Value
        End Set
    End Property

    Public Property Qty() As String
        Get
            Return txtQty.Text
        End Get
        Set(ByVal Value As String)
            txtQty.Text = Value
        End Set
    End Property

    Public Property Satuan() As String
        Get
            Return txtSatuan.Text
        End Get
        Set(ByVal Value As String)
            txtSatuan.Text = Value
        End Set
    End Property

    Public Property HargaSatuan() As String
        Get
            Return txtHargaSatuan.Text
        End Get
        Set(ByVal Value As String)
            txtHargaSatuan.Text = Value
        End Set
    End Property

    Public Property Disc() As String
        Get
            Return txtDisc.Text
        End Get
        Set(ByVal Value As String)
            txtDisc.Text = Value
        End Set
    End Property

    Public Property m_SubTotalDtl() As String
        Get
            Return txtSubtotalDtl.Text
        End Get
        Set(ByVal Value As String)
            txtSubtotalDtl.Text = Value
        End Set
    End Property

    Sub clear_obj()
        flag = 0
        txtBillNo.Text = ""
        txtTableCode.Text = ""
        dtpDate.Value = FormatDateTime(Now, DateFormat.ShortDate)
        txtStatus.Text = ""
        txtCatatan.Text = ""
        txtFreetext1.Text = ""

        txtTotalGross.Text = FormatNumber(0)
        txtTotalDisc.Text = FormatNumber(0)
        txtTotalAddDisc.Text = FormatNumber(0)
        txtTotalSub.Text = FormatNumber(0)
        txtTotalTax.Text = FormatNumber(0)
        txtTotalGrand.Text = FormatNumber(0)
    End Sub

    Sub clear_objD()
        flag_detail = 0
        txtMenu.Text = ""
        txtDeskripsi.Text = ""
        txtQty.Text = "0"
        txtSatuan.Text = ""
        txtHargaSatuan.Text = FormatNumber(0, 0)
        txtDisc.Text = "0"
        txtSubtotalDtl.Text = FormatNumber(0, 0)
    End Sub

    Sub lock_obj(ByVal isLock As Boolean)
        'txtBillNo.ReadOnly = isLock
        txtCatatan.ReadOnly = isLock
        txtFreetext1.ReadOnly = isLock
        dtpDate.Enabled = Not isLock

        cbTransType.Enabled = Not isLock
        btnEdit.Enabled = isLock
        btnAdd.Enabled = isLock
        btnSave.Enabled = Not isLock
        btnCancel.Enabled = Not isLock
        btnTable.Enabled = Not isLock

        txtTotalAddDisc.ReadOnly = isLock

        If flag = 0 Then
            'txtBillNo.ReadOnly = False
            btnVoid.Enabled = False
            btnReceipt.Enabled = False
        Else
            'txtBillNo.ReadOnly = True
            btnVoid.Enabled = Not isLock
            btnReceipt.Enabled = Not isLock
        End If

        If cbTransType.SelectedIndex = 0 Then
            btnTable.Enabled = Not isLock
        Else
            btnTable.Enabled = False
        End If
    End Sub

    Sub lock_objD(ByVal isLock As Boolean)
        btnMenu.Enabled = Not isLock
        txtDeskripsi.ReadOnly = isLock
        txtQty.ReadOnly = isLock
        txtDisc.ReadOnly = isLock
        btnSaveDtl.Enabled = Not isLock
        btnDeleteDtl.Enabled = Not isLock
        btnAddDtl.Enabled = Not isLock

        If txtStatus.Text = "PAID" Then
            btnSaveDtl.Enabled = False
            btnDeleteDtl.Enabled = False
            btnAddDtl.Enabled = False
        End If
    End Sub

    Sub clear_lvw()
        Try
            With ListView1
                .Clear()
                .View = View.Details
                .Columns.Add("pos_dtl_id", 0)
                .Columns.Add("type", 0)
                .Columns.Add("Kode Menu", 0)
                .Columns.Add("Deskripsi", 300)
                .Columns.Add("Qty", 75)
                .Columns.Add("Satuan", 100)
                .Columns.Add("Harga Satuan", 150, HorizontalAlignment.Right)
                .Columns.Add("Discount", 100, HorizontalAlignment.Right)
                .Columns.Add("Subtotal", 200, HorizontalAlignment.Right)
            End With

            If flag <> 0 Then
                cmd = New SqlCommand("sp_tr_pos_dtl_SEL", cn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim prm1 As SqlParameter = cmd.Parameters.Add("@bill_no", SqlDbType.NVarChar, 20)
                prm1.Value = txtBillNo.Text

                cn.Open()

                Dim myReader As SqlDataReader = cmd.ExecuteReader()

                Dim lvItem As ListViewItem
                Dim i As Integer, intCurrRow As Integer

                While myReader.Read
                    lvItem = New ListViewItem(CStr(myReader.Item(0))) 'pos_dtl_id
                    lvItem.Tag = intCurrRow 'ID

                    For i = 1 To 3
                        If myReader.Item(i) Is System.DBNull.Value Then
                            lvItem.SubItems.Add("")
                        Else
                            lvItem.SubItems.Add(myReader.Item(i))
                        End If
                    Next

                    If CDec(myReader.Item(4)) Mod 1 = 0 Then
                        lvItem.SubItems.Add(FormatNumber(myReader.Item(4), 0)) 'qty tanpa koma
                    Else
                        lvItem.SubItems.Add(FormatNumber(myReader.Item(4), 3)) 'qty dgn koma
                    End If

                    lvItem.SubItems.Add(myReader.Item(5)) 'satuan
                    lvItem.SubItems.Add(FormatNumber(myReader.Item(6), 0)) 'unit price
                    lvItem.SubItems.Add(myReader.Item(7)) 'disc
                    lvItem.SubItems.Add(FormatNumber(myReader.Item(8), 0)) 'subtotal

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

                lblJumlahBaris.Text = "Total Items : " + CStr(ListView1.Items.Count)
            End If
        Catch ex As Exception
            MsgBox("Error Message : " + ex.Message)
            If ConnectionState.Open = True Then cn.Close()
        End Try

    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        With ListView1.SelectedItems.Item(0)
            flag_detail = .SubItems.Item(0).Text

            If .SubItems.Item(1).Text = "M" Then
                cbType.SelectedIndex = 0
            Else
                cbType.SelectedIndex = 1
            End If

            txtMenu.Text = .SubItems.Item(2).Text
            txtDeskripsi.Text = .SubItems.Item(3).Text
            txtQty.Text = .SubItems.Item(4).Text
            txtSatuan.Text = .SubItems.Item(5).Text
            txtHargaSatuan.Text = FormatNumber(.SubItems.Item(6).Text, 0)
            txtDisc.Text = .SubItems.Item(7).Text
            txtSubtotalDtl.Text = FormatNumber(.SubItems.Item(8).Text, 0)

            If btnSaveDtl.Enabled = True Then
                btnMenu.Enabled = False
            End If

            'a.pos_dtl_id,0
            'a.line_type,1
            'a.code,2
            'a.deskripsi,3
            'a.qty,4
            'ISNULL(b.satuan,'') as satuan,5
            'a.unit_price,6
            'a.disc,7
            'a.subtotal,8
        End With
    End Sub

    Sub view_record()
        Try
            cmd = New SqlCommand("sp_tr_pos_SEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm2 As SqlParameter = cmd.Parameters.Add("@bill_no", SqlDbType.NVarChar, 20)
            prm2.Value = txtBillNo.Text

            cn.Open()

            Dim myReader As SqlDataReader = cmd.ExecuteReader()

            While myReader.Read
                dtpDate.Text = myReader.GetDateTime(1)
                txtTableCode.Text = myReader.GetString(2)
                txtStatus.Text = myReader.GetString(4)
                txtTotalGross.Text = FormatNumber(myReader.GetDecimal(5), 0)
                txtTotalDisc.Text = FormatNumber(myReader.GetDecimal(6), 0)
                txtTotalSub.Text = FormatNumber(myReader.GetDecimal(7), 0)
                txtTotalTax.Text = FormatNumber(myReader.GetDecimal(8), 0)
                txtTotalGrand.Text = FormatNumber(myReader.GetDecimal(9), 0)
                txtCatatan.Text = myReader.GetString(10)
                txtFreetext1.Text = myReader.GetString(12)
                txtTotalAddDisc.Text = FormatNumber(myReader.GetDecimal(13), 0)

            End While

            myReader.Close()
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            If ConnectionState.Open = True Then cn.Close()
        End Try

        'a.bill_no,0
        'a.pos_date,1
        'a.table_code,2
        'a.payment_method,3
        'a.pos_status,4
        'a.total_gross,5
        'a.total_disc,6
        'a.total_sub,7
        'a.total_tax,8
        'a.total_grand,9

    End Sub

    Sub saveHeader()
        If txtBillNo.Text = "" Then
            txtBillNo.Text = GetSysNumber("POS")
        End If

        Try
            cmd = New SqlCommand(IIf(flag = 0, "sp_tr_pos_INS", "sp_tr_pos_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm0 As SqlParameter = cmd.Parameters.Add("@bill_no", SqlDbType.NVarChar, 20)
            prm0.Value = txtBillNo.Text
            Dim prm1 As SqlParameter = cmd.Parameters.Add("@pos_date", SqlDbType.DateTime)
            prm1.Value = dtpDate.Value
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@table_code", SqlDbType.NVarChar, 20)
            prm2.Value = txtTableCode.Text
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@total_gross", SqlDbType.Decimal)
            prm4.Value = CDec(txtTotalGross.Text)
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@total_disc", SqlDbType.Decimal)
            prm5.Value = CDec(txtTotalDisc.Text)
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@total_sub", SqlDbType.Decimal)
            prm6.Value = CDec(txtTotalSub.Text)
            Dim prm7 As SqlParameter = cmd.Parameters.Add("@total_tax", SqlDbType.Decimal)
            prm7.Value = CDec(txtTotalTax.Text)
            Dim prm8 As SqlParameter = cmd.Parameters.Add("@total_grand", SqlDbType.Decimal)
            prm8.Value = CDec(txtTotalGrand.Text)
            Dim prm9 As SqlParameter = cmd.Parameters.Add("@keterangan", SqlDbType.NVarChar, 255)
            prm9.Value = txtCatatan.Text
            Dim prm10 As SqlParameter = cmd.Parameters.Add("@free_text1", SqlDbType.NVarChar, 50)
            prm10.Value = txtFreetext1.Text
            Dim prm11 As SqlParameter = cmd.Parameters.Add("@total_add_disc", SqlDbType.Decimal)
            prm11.Value = CDec(txtTotalAddDisc.Text)

            Dim prm22 As SqlParameter = cmd.Parameters.Add("@user_code", SqlDbType.NVarChar, 50)
            prm22.Value = My.Settings.UserName

            If flag = 0 Then
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()

                flag = 1
                txtBillNo.ReadOnly = True
            Else
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
            End If

            view_record()
        Catch ex As Exception
            MsgBox("Error Message saveHeader(): " + ex.Message)
            If ConnectionState.Open = 1 Then cn.Close()
            clear_objD()
        End Try
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        flag = 0
        clear_obj()
        clear_objD()
        clear_lvw()
        lock_obj(False)
        lock_objD(False)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        lock_obj(True)
        lock_objD(True)
        clear_objD()
        flag_detail = 0
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtTableCode.Text = "" Then
            MsgBox("Meja belum diisi!", vbCritical + vbOKOnly, Me.Text)
            btnTable.Focus()
            Exit Sub
        End If

        Try
            saveHeader()

            lock_obj(True)
            lock_objD(True)

        Catch ex As Exception
            MsgBox("Error Message: " + ex.Message)
            If ConnectionState.Open = 1 Then cn.Close()
        End Try
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        clear_objD()
        lock_obj(False)
        lock_objD(False)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoid.Click
        If txtTableCode.Text = "" Then
            MsgBox("Meja belum diisi!", vbCritical + vbOKOnly, Me.Text)
            btnTable.Focus()
            Exit Sub
        End If

        If flag <> 0 Then
            If MsgBox("Anda yakin untuk membatalkan transaksi ini?", vbYesNo + vbCritical, Me.Text) = vbYes Then
                cmd = New SqlCommand("sp_tr_pos_VOID", cn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim prm0 As SqlParameter = cmd.Parameters.Add("@bill_no", SqlDbType.NVarChar, 20)
                prm0.Value = txtBillNo.Text
                Dim prm1 As SqlParameter = cmd.Parameters.Add("@table_code", SqlDbType.NVarChar, 20)
                prm1.Value = txtTableCode.Text
                Dim prm2 As SqlParameter = cmd.Parameters.Add("@user_code", SqlDbType.NVarChar, 50)
                prm2.Value = My.Settings.UserName

                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()


                clear_obj()
                btnAdd_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub btnSaveDtl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveDtl.Click
        Try
            If txtTableCode.Text = "" Then
                MsgBox("Meja belum diisi!", vbCritical + vbOKOnly, Me.Text)
                btnTable.Focus()
                Exit Sub
            End If

            If txtMenu.Text = "" Then
                MsgBox("Silahkan pilih menu terlebih dahulu!", vbCritical + vbOKOnly, Me.Text)
                btnMenu.Focus()
                Exit Sub
            End If

            cmd = New SqlCommand(IIf(flag_detail = 0, "sp_tr_pos_dtl_INS", "sp_tr_pos_dtl_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@bill_no", SqlDbType.NVarChar, 20)
            prm1.Value = txtBillNo.Text
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@line_type", SqlDbType.NVarChar, 1)
            prm2.Value = cbType.Text
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@code", SqlDbType.NVarChar, 20)
            prm3.Value = txtMenu.Text
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@deskripsi", SqlDbType.NVarChar, 100)
            prm4.Value = txtDeskripsi.Text
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@qty", SqlDbType.Decimal)
            prm5.Value = CDec(txtQty.Text)
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@unit_price", SqlDbType.Decimal)
            prm6.Value = CDec(txtHargaSatuan.Text)
            Dim prm7 As SqlParameter = cmd.Parameters.Add("@disc", SqlDbType.Int)
            prm7.Value = CInt(txtDisc.Text)
            Dim prm8 As SqlParameter = cmd.Parameters.Add("@subtotal", SqlDbType.Decimal)
            prm8.Value = CDec(txtSubtotalDtl.Text)


            '@bill_no nvarchar(20) = null,
            '@line_type nvarchar(1) = null,
            '@code nvarchar(20) = null,
            '@deskripsi nvarchar(100) = null,
            '@qty decimal(18,3) = 0,
            '@unit_price decimal(18,0) = 0,
            '@disc int = 0,
            '@subtotal decimal(18,0) = 0

            If flag_detail <> 0 Then
                Dim prm17 As SqlParameter = cmd.Parameters.Add("@pos_dtl_id", SqlDbType.Int)
                prm17.Value = flag_detail
            End If

            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            clear_lvw()
            clear_objD()
            view_record()
            btnMenu.Focus()
        Catch ex As Exception
            MsgBox("Error Message : " + ex.Message)
            If ConnectionState.Open = True Then cn.Close()
        End Try
    End Sub

    Private Sub btnDeleteD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteDtl.Click
        If flag_detail = 0 Then Exit Sub
        If MsgBox("Anda yakin menghapus baris ini?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            Try
                cmd = New SqlCommand("sp_tr_pos_dtl_DEL", cn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim prm1 As SqlParameter = cmd.Parameters.Add("@bill_no", SqlDbType.NVarChar, 20)
                prm1.Value = txtBillNo.Text

                Dim prm2 As SqlParameter = cmd.Parameters.Add("@pos_dtl_id", SqlDbType.Int)
                prm2.Value = flag_detail

                cn.Open()
                cmd.ExecuteReader()
                cn.Close()

                clear_lvw()
                clear_objD()
                view_record()

                btnMenu.Enabled = True
                btnMenu.Focus()
            Catch ex As Exception
                MsgBox("Error Message : " + ex.Message)
                If ConnectionState.Open = True Then cn.Close()
            End Try
        End If
    End Sub

    Private Sub btnAddD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddDtl.Click
        btnMenu.Enabled = True
        clear_objD()
        btnMenu.Focus()
    End Sub

    Private Sub btnMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMenu.Click
        If txtTableCode.Text = "" Then
            MsgBox("Meja belum diisi!", vbCritical + vbOKOnly, Me.Text)
            btnTable.Focus()
            Exit Sub
        End If

        saveHeader()

        Dim NewFormDialog As New fdlMenu
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTable.Click
        Dim NewFormDialog As New fdlTable
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.TableCode = txtTableCode.Text
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnPOS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPOS.Click
        Dim NewFormDialog As New fdlPOS
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        view_record()
        clear_lvw()
        lock_obj(False)
        lock_objD(False)
    End Sub

    'Autorefresh---Hendra
    Public Sub frmPOSRefresh(ByVal sender As System.Object, ByVal e As System.EventArgs)
        btnFilter_Click(sender, e)
    End Sub

    Private Sub txtQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQty.KeyPress
        Dim tb As TextBox
        tb = CType(sender, TextBox)

        If Char.IsControl(e.KeyChar) Then
            If e.KeyChar.Equals(Chr(Keys.Return)) Then
                Me.SelectNextControl(tb, True, True, False, True)
                e.Handled = True
            End If
        End If

        If (Not e.KeyChar = ChrW(Keys.Back) And ("0123456789.,").IndexOf(e.KeyChar) = -1) Then
            e.Handled = True
        End If

        

    End Sub

    Private Sub txtDisc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDisc.KeyPress
        Dim tb As TextBox
        tb = CType(sender, TextBox)

        If Char.IsControl(e.KeyChar) Then
            If e.KeyChar.Equals(Chr(Keys.Return)) Then
                Me.SelectNextControl(tb, True, True, False, True)
                e.Handled = True
            End If
        End If

        If (Not e.KeyChar = ChrW(Keys.Back) And ("0123456789").IndexOf(e.KeyChar) = -1) Then
            e.Handled = True
        End If

    End Sub

    Private Sub txtHargaSatuan_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHargaSatuan.KeyPress
        Dim tb As TextBox
        tb = CType(sender, TextBox)

        If Char.IsControl(e.KeyChar) Then
            If e.KeyChar.Equals(Chr(Keys.Return)) Then
                Me.SelectNextControl(tb, True, True, False, True)
                e.Handled = True
            End If
        End If

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If

       

    End Sub

    Private Sub txtQty_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQty.LostFocus
        Try
            If txtQty.Text = "" Then
                txtQty.Text = "1"
            End If
            If CDec(txtQty.Text) < 0 Then
                txtQty.Text = CStr(CDec(txtQty.Text) * -1)
            End If
            get_SubtotalDtl()
        Catch ex As Exception
            txtQty.Text = "1"
            get_SubtotalDtl()
        End Try

    End Sub

    Private Sub txtHargaSatuan_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHargaSatuan.LostFocus
        If txtHargaSatuan.Text = "" Then
            txtHargaSatuan.Text = "1"
        End If
        If CInt(txtHargaSatuan.Text) < 0 Then
            txtHargaSatuan.Text = CStr(CInt(txtHargaSatuan.Text) * -1)
        End If
        get_SubtotalDtl()
    End Sub

    Private Sub txtDisc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDisc.LostFocus
        Try
            If txtDisc.Text = "" Then
                txtDisc.Text = "0"
            End If
            If CDec(txtDisc.Text) < 0 Then
                txtDisc.Text = CStr(CDec(txtDisc.Text) * -1)
            End If
            get_SubtotalDtl()
        Catch ex As Exception
            txtDisc.Text = "0"
            get_SubtotalDtl()
        End Try
    End Sub

    Private Sub txtTotalAddDisc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotalAddDisc.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtTotalAddDisc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTotalAddDisc.LostFocus
        Try
            If txtTotalAddDisc.Text = "" Then
                txtTotalAddDisc.Text = "0"
            End If
            If CDec(txtTotalAddDisc.Text) < 0 Then
                txtTotalAddDisc.Text = CStr(CDec(txtTotalAddDisc.Text) * -1)
            End If

            saveHeader()
            view_record()
        Catch ex As Exception
            txtTotalAddDisc.Text = "0"
        End Try
    End Sub

    Sub get_SubtotalDtl()
        txtSubtotalDtl.Text = FormatNumber(CStr((CDec(txtQty.Text) * CInt(txtHargaSatuan.Text)) - ((CDec(txtQty.Text) * CInt(txtHargaSatuan.Text)) * (CInt(txtDisc.Text) / 100))), 0)
    End Sub


    Private Sub cbType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbType.SelectedIndexChanged
        If btnAddDtl.Enabled = False Then Exit Sub

        If cbType.SelectedItem.ToString = "M" Then
            txtHargaSatuan.ReadOnly = True
        ElseIf cbType.SelectedItem.ToString = "J" Then
            txtHargaSatuan.ReadOnly = False
        End If
    End Sub

    Private Sub btnSaveHeader_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveHeader.Click
        saveHeader()
    End Sub

    'AutosaveHeader
    Public Sub frmPOSAutosaveHeader(ByVal sender As System.Object, ByVal e As System.EventArgs)
        btnSaveHeader_Click(sender, e)
    End Sub

    
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReceipt.Click
        If txtTableCode.Text = "" Then
            MsgBox("Meja belum diisi!", vbCritical + vbOKOnly, Me.Text)
            btnTable.Focus()
            Exit Sub
        End If

        With fdlSettle
            .billNo = txtBillNo.Text
            .MdiParent = frmMenu
            .Show()
            .BringToFront()
        End With
    End Sub

    Private Sub cbTransType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbTransType.SelectedIndexChanged
        If cbTransType.SelectedIndex = 1 Then
            If txtTableCode.Text <> "" Then
                tableRelease(txtTableCode.Text)
            End If
            txtTableCode.Text = "Take-Away"
        Else
            txtTableCode.Text = ""
        End If
        lock_obj(False)
    End Sub

    Sub tableRelease(ByVal TableCode As String)
        Try
            cmd = New SqlCommand("sp_mt_table_RELEASE", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@table_code", SqlDbType.NVarChar, 20)
            prm1.Value = TableCode

            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            MsgBox("Error Message tableRelease() : " + ex.Message)
            If ConnectionState.Open = True Then cn.Close()
        End Try
    End Sub

    Private Sub btnMenu_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnMenu.KeyPress
        If Char.IsControl(e.KeyChar) Then
            If e.KeyChar.Equals(Chr(Keys.Return)) Then
                btnMenu_click(sender, e)
            End If
        End If

    End Sub

    Private Sub txtDeskripsi_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDeskripsi.KeyPress
        Dim tb As TextBox
        tb = CType(sender, TextBox)

        If Char.IsControl(e.KeyChar) Then
            If e.KeyChar.Equals(Chr(Keys.Return)) Then
                Me.SelectNextControl(tb, True, True, False, True)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtSatuan_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSatuan.KeyPress
        Dim tb As TextBox
        tb = CType(sender, TextBox)

        If Char.IsControl(e.KeyChar) Then
            If e.KeyChar.Equals(Chr(Keys.Return)) Then
                Me.SelectNextControl(tb, True, True, False, True)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtSubtotalDtl_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSubtotalDtl.KeyPress
        Dim tb As TextBox
        tb = CType(sender, TextBox)

        If Char.IsControl(e.KeyChar) Then
            If e.KeyChar.Equals(Chr(Keys.Return)) Then
                Me.SelectNextControl(tb, True, True, False, True)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnSaveDtl_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnSaveDtl.KeyPress
        If Char.IsControl(e.KeyChar) Then
            If e.KeyChar.Equals(Chr(Keys.Return)) Then
                btnSaveDtl_Click(sender, e)
            End If
        End If
    End Sub


    
End Class