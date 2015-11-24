<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPOS
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPOS))
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.btnPOS = New System.Windows.Forms.Button()
        Me.btnTable = New System.Windows.Forms.Button()
        Me.txtTableCode = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtDeskripsi = New System.Windows.Forms.TextBox()
        Me.txtMenu = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnVoid = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.txtBillNo = New System.Windows.Forms.TextBox()
        Me.btnAddDtl = New System.Windows.Forms.Button()
        Me.btnMenu = New System.Windows.Forms.Button()
        Me.btnDeleteDtl = New System.Windows.Forms.Button()
        Me.btnSaveDtl = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbType = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtSatuan = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtHargaSatuan = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtDisc = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtSubtotalDtl = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtTotalSub = New System.Windows.Forms.TextBox()
        Me.txtTotalDisc = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtTotalGrand = New System.Windows.Forms.TextBox()
        Me.txtTotalTax = New System.Windows.Forms.TextBox()
        Me.txtTotalGross = New System.Windows.Forms.TextBox()
        Me.btnSaveHeader = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCatatan = New System.Windows.Forms.TextBox()
        Me.btnReceipt = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cbTransType = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtFreetext1 = New System.Windows.Forms.TextBox()
        Me.lblJumlahBaris = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtTotalAddDisc = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnFilter
        '
        Me.btnFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnFilter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFilter.ImageIndex = 0
        Me.btnFilter.Location = New System.Drawing.Point(14, 580)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(29, 25)
        Me.btnFilter.TabIndex = 277
        Me.btnFilter.Text = "..."
        Me.btnFilter.UseVisualStyleBackColor = True
        Me.btnFilter.Visible = False
        '
        'btnPOS
        '
        Me.btnPOS.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPOS.ImageIndex = 0
        Me.btnPOS.Location = New System.Drawing.Point(204, 6)
        Me.btnPOS.Name = "btnPOS"
        Me.btnPOS.Size = New System.Drawing.Size(29, 25)
        Me.btnPOS.TabIndex = 1
        Me.btnPOS.Text = "..."
        Me.btnPOS.UseVisualStyleBackColor = True
        '
        'btnTable
        '
        Me.btnTable.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTable.ImageIndex = 0
        Me.btnTable.Location = New System.Drawing.Point(204, 89)
        Me.btnTable.Name = "btnTable"
        Me.btnTable.Size = New System.Drawing.Size(29, 25)
        Me.btnTable.TabIndex = 5
        Me.btnTable.Text = "..."
        Me.btnTable.UseVisualStyleBackColor = True
        '
        'txtTableCode
        '
        Me.txtTableCode.Location = New System.Drawing.Point(93, 92)
        Me.txtTableCode.MaxLength = 50
        Me.txtTableCode.Name = "txtTableCode"
        Me.txtTableCode.ReadOnly = True
        Me.txtTableCode.Size = New System.Drawing.Size(102, 20)
        Me.txtTableCode.TabIndex = 4
        Me.txtTableCode.TabStop = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(14, 95)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(34, 13)
        Me.Label27.TabIndex = 276
        Me.Label27.Text = "Table"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Box.png")
        Me.ImageList1.Images.SetKeyName(1, "add.png")
        Me.ImageList1.Images.SetKeyName(2, "Checkmark.png")
        Me.ImageList1.Images.SetKeyName(3, "Remove.png")
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(49, 124)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(50, 13)
        Me.Label19.TabIndex = 275
        Me.Label19.Text = "Deskripsi"
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(589, 531)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(34, 13)
        Me.Label18.TabIndex = 274
        Me.Label18.Text = "Menu"
        Me.Label18.Visible = False
        '
        'txtDeskripsi
        '
        Me.txtDeskripsi.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDeskripsi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDeskripsi.Location = New System.Drawing.Point(52, 140)
        Me.txtDeskripsi.MaxLength = 255
        Me.txtDeskripsi.Name = "txtDeskripsi"
        Me.txtDeskripsi.Size = New System.Drawing.Size(303, 20)
        Me.txtDeskripsi.TabIndex = 9
        '
        'txtMenu
        '
        Me.txtMenu.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMenu.Location = New System.Drawing.Point(592, 547)
        Me.txtMenu.MaxLength = 50
        Me.txtMenu.Name = "txtMenu"
        Me.txtMenu.ReadOnly = True
        Me.txtMenu.Size = New System.Drawing.Size(80, 20)
        Me.txtMenu.TabIndex = 270
        Me.txtMenu.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(14, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 271
        Me.Label6.Text = "Bill No."
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(849, 579)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(83, 26)
        Me.btnCancel.TabIndex = 30
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(579, 579)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(83, 26)
        Me.btnEdit.TabIndex = 27
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(669, 579)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(83, 26)
        Me.btnAdd.TabIndex = 28
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnVoid
        '
        Me.btnVoid.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnVoid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVoid.Location = New System.Drawing.Point(401, 579)
        Me.btnVoid.Name = "btnVoid"
        Me.btnVoid.Size = New System.Drawing.Size(83, 26)
        Me.btnVoid.TabIndex = 25
        Me.btnVoid.Text = "Void"
        Me.btnVoid.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(759, 579)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(83, 26)
        Me.btnSave.TabIndex = 29
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(14, 168)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(927, 238)
        Me.ListView1.TabIndex = 260
        Me.ListView1.TabStop = False
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.List
        '
        'dtpDate
        '
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDate.Location = New System.Drawing.Point(93, 65)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(102, 20)
        Me.dtpDate.TabIndex = 3
        '
        'txtBillNo
        '
        Me.txtBillNo.Location = New System.Drawing.Point(93, 9)
        Me.txtBillNo.MaxLength = 20
        Me.txtBillNo.Name = "txtBillNo"
        Me.txtBillNo.ReadOnly = True
        Me.txtBillNo.Size = New System.Drawing.Size(102, 20)
        Me.txtBillNo.TabIndex = 0
        '
        'btnAddDtl
        '
        Me.btnAddDtl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddDtl.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddDtl.ImageIndex = 1
        Me.btnAddDtl.ImageList = Me.ImageList1
        Me.btnAddDtl.Location = New System.Drawing.Point(912, 135)
        Me.btnAddDtl.Name = "btnAddDtl"
        Me.btnAddDtl.Size = New System.Drawing.Size(29, 25)
        Me.btnAddDtl.TabIndex = 17
        Me.btnAddDtl.UseVisualStyleBackColor = True
        '
        'btnMenu
        '
        Me.btnMenu.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMenu.ImageIndex = 0
        Me.btnMenu.ImageList = Me.ImageList1
        Me.btnMenu.Location = New System.Drawing.Point(13, 137)
        Me.btnMenu.Name = "btnMenu"
        Me.btnMenu.Size = New System.Drawing.Size(29, 25)
        Me.btnMenu.TabIndex = 8
        Me.btnMenu.UseVisualStyleBackColor = True
        '
        'btnDeleteDtl
        '
        Me.btnDeleteDtl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteDtl.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteDtl.ImageIndex = 3
        Me.btnDeleteDtl.ImageList = Me.ImageList1
        Me.btnDeleteDtl.Location = New System.Drawing.Point(879, 135)
        Me.btnDeleteDtl.Name = "btnDeleteDtl"
        Me.btnDeleteDtl.Size = New System.Drawing.Size(29, 25)
        Me.btnDeleteDtl.TabIndex = 16
        Me.btnDeleteDtl.UseVisualStyleBackColor = True
        '
        'btnSaveDtl
        '
        Me.btnSaveDtl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveDtl.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveDtl.ImageIndex = 2
        Me.btnSaveDtl.ImageList = Me.ImageList1
        Me.btnSaveDtl.Location = New System.Drawing.Point(844, 135)
        Me.btnSaveDtl.Name = "btnSaveDtl"
        Me.btnSaveDtl.Size = New System.Drawing.Size(29, 25)
        Me.btnSaveDtl.TabIndex = 15
        Me.btnSaveDtl.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 278
        Me.Label1.Text = "Tanggal"
        '
        'txtStatus
        '
        Me.txtStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtStatus.Location = New System.Drawing.Point(839, 6)
        Me.txtStatus.MaxLength = 50
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(102, 20)
        Me.txtStatus.TabIndex = 6
        Me.txtStatus.TabStop = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(784, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 280
        Me.Label2.Text = "Status"
        '
        'cbType
        '
        Me.cbType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbType.Enabled = False
        Me.cbType.FormattingEnabled = True
        Me.cbType.Location = New System.Drawing.Point(515, 546)
        Me.cbType.Name = "cbType"
        Me.cbType.Size = New System.Drawing.Size(71, 21)
        Me.cbType.TabIndex = 283
        Me.cbType.Visible = False
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(512, 530)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(28, 13)
        Me.Label4.TabIndex = 284
        Me.Label4.Text = "Tipe"
        Me.Label4.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(358, 124)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(23, 13)
        Me.Label7.TabIndex = 298
        Me.Label7.Text = "Qty"
        '
        'txtQty
        '
        Me.txtQty.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtQty.Location = New System.Drawing.Point(361, 140)
        Me.txtQty.MaxLength = 10
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(51, 20)
        Me.txtQty.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(415, 124)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 13)
        Me.Label8.TabIndex = 300
        Me.Label8.Text = "Satuan"
        '
        'txtSatuan
        '
        Me.txtSatuan.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSatuan.Location = New System.Drawing.Point(418, 140)
        Me.txtSatuan.MaxLength = 50
        Me.txtSatuan.Name = "txtSatuan"
        Me.txtSatuan.ReadOnly = True
        Me.txtSatuan.Size = New System.Drawing.Size(62, 20)
        Me.txtSatuan.TabIndex = 11
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(483, 124)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 13)
        Me.Label9.TabIndex = 302
        Me.Label9.Text = "Harga Satuan"
        '
        'txtHargaSatuan
        '
        Me.txtHargaSatuan.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHargaSatuan.Location = New System.Drawing.Point(486, 140)
        Me.txtHargaSatuan.MaxLength = 20
        Me.txtHargaSatuan.Name = "txtHargaSatuan"
        Me.txtHargaSatuan.ReadOnly = True
        Me.txtHargaSatuan.Size = New System.Drawing.Size(100, 20)
        Me.txtHargaSatuan.TabIndex = 12
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(589, 123)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(39, 13)
        Me.Label10.TabIndex = 304
        Me.Label10.Text = "Disc %"
        '
        'txtDisc
        '
        Me.txtDisc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDisc.Location = New System.Drawing.Point(592, 139)
        Me.txtDisc.MaxLength = 3
        Me.txtDisc.Name = "txtDisc"
        Me.txtDisc.Size = New System.Drawing.Size(50, 20)
        Me.txtDisc.TabIndex = 13
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(645, 123)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(46, 13)
        Me.Label11.TabIndex = 306
        Me.Label11.Text = "Subtotal"
        '
        'txtSubtotalDtl
        '
        Me.txtSubtotalDtl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSubtotalDtl.Location = New System.Drawing.Point(648, 139)
        Me.txtSubtotalDtl.MaxLength = 20
        Me.txtSubtotalDtl.Name = "txtSubtotalDtl"
        Me.txtSubtotalDtl.ReadOnly = True
        Me.txtSubtotalDtl.Size = New System.Drawing.Size(183, 20)
        Me.txtSubtotalDtl.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(694, 494)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 316
        Me.Label5.Text = "Subtotal"
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(695, 443)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(49, 13)
        Me.Label12.TabIndex = 315
        Me.Label12.Text = "Discount"
        '
        'txtTotalSub
        '
        Me.txtTotalSub.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalSub.Location = New System.Drawing.Point(801, 494)
        Me.txtTotalSub.Name = "txtTotalSub"
        Me.txtTotalSub.ReadOnly = True
        Me.txtTotalSub.Size = New System.Drawing.Size(140, 20)
        Me.txtTotalSub.TabIndex = 22
        Me.txtTotalSub.TabStop = False
        Me.txtTotalSub.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalDisc
        '
        Me.txtTotalDisc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalDisc.Location = New System.Drawing.Point(801, 443)
        Me.txtTotalDisc.Name = "txtTotalDisc"
        Me.txtTotalDisc.ReadOnly = True
        Me.txtTotalDisc.Size = New System.Drawing.Size(140, 20)
        Me.txtTotalDisc.TabIndex = 20
        Me.txtTotalDisc.TabStop = False
        Me.txtTotalDisc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(695, 550)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(63, 13)
        Me.Label13.TabIndex = 309
        Me.Label13.Text = "Grand Total"
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(694, 521)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(80, 13)
        Me.Label14.TabIndex = 308
        Me.Label14.Text = "Pajak Restoran"
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(695, 418)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(61, 13)
        Me.Label15.TabIndex = 307
        Me.Label15.Text = "Gross Total"
        '
        'txtTotalGrand
        '
        Me.txtTotalGrand.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalGrand.Location = New System.Drawing.Point(801, 550)
        Me.txtTotalGrand.Name = "txtTotalGrand"
        Me.txtTotalGrand.ReadOnly = True
        Me.txtTotalGrand.Size = New System.Drawing.Size(140, 20)
        Me.txtTotalGrand.TabIndex = 24
        Me.txtTotalGrand.TabStop = False
        Me.txtTotalGrand.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalTax
        '
        Me.txtTotalTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalTax.Location = New System.Drawing.Point(801, 521)
        Me.txtTotalTax.Name = "txtTotalTax"
        Me.txtTotalTax.ReadOnly = True
        Me.txtTotalTax.Size = New System.Drawing.Size(140, 20)
        Me.txtTotalTax.TabIndex = 23
        Me.txtTotalTax.TabStop = False
        Me.txtTotalTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalGross
        '
        Me.txtTotalGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalGross.Location = New System.Drawing.Point(801, 418)
        Me.txtTotalGross.Name = "txtTotalGross"
        Me.txtTotalGross.ReadOnly = True
        Me.txtTotalGross.Size = New System.Drawing.Size(140, 20)
        Me.txtTotalGross.TabIndex = 19
        Me.txtTotalGross.TabStop = False
        Me.txtTotalGross.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnSaveHeader
        '
        Me.btnSaveHeader.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSaveHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveHeader.ImageIndex = 0
        Me.btnSaveHeader.Location = New System.Drawing.Point(49, 580)
        Me.btnSaveHeader.Name = "btnSaveHeader"
        Me.btnSaveHeader.Size = New System.Drawing.Size(29, 25)
        Me.btnSaveHeader.TabIndex = 317
        Me.btnSaveHeader.Text = "..."
        Me.btnSaveHeader.UseVisualStyleBackColor = True
        Me.btnSaveHeader.Visible = False
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 487)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 319
        Me.Label3.Text = "Catatan"
        '
        'txtCatatan
        '
        Me.txtCatatan.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtCatatan.Location = New System.Drawing.Point(14, 503)
        Me.txtCatatan.MaxLength = 255
        Me.txtCatatan.Multiline = True
        Me.txtCatatan.Name = "txtCatatan"
        Me.txtCatatan.Size = New System.Drawing.Size(323, 60)
        Me.txtCatatan.TabIndex = 18
        '
        'btnReceipt
        '
        Me.btnReceipt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReceipt.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReceipt.Location = New System.Drawing.Point(490, 579)
        Me.btnReceipt.Name = "btnReceipt"
        Me.btnReceipt.Size = New System.Drawing.Size(83, 26)
        Me.btnReceipt.TabIndex = 26
        Me.btnReceipt.Text = "Bayar"
        Me.btnReceipt.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(14, 41)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(61, 13)
        Me.Label16.TabIndex = 322
        Me.Label16.Text = "Trans Type"
        '
        'cbTransType
        '
        Me.cbTransType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTransType.Enabled = False
        Me.cbTransType.FormattingEnabled = True
        Me.cbTransType.Location = New System.Drawing.Point(93, 36)
        Me.cbTransType.Name = "cbTransType"
        Me.cbTransType.Size = New System.Drawing.Size(102, 21)
        Me.cbTransType.TabIndex = 2
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(784, 39)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(38, 13)
        Me.Label17.TabIndex = 324
        Me.Label17.Text = "Faktur"
        '
        'txtFreetext1
        '
        Me.txtFreetext1.Location = New System.Drawing.Point(839, 34)
        Me.txtFreetext1.MaxLength = 50
        Me.txtFreetext1.Name = "txtFreetext1"
        Me.txtFreetext1.Size = New System.Drawing.Size(102, 20)
        Me.txtFreetext1.TabIndex = 7
        '
        'lblJumlahBaris
        '
        Me.lblJumlahBaris.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblJumlahBaris.AutoSize = True
        Me.lblJumlahBaris.Location = New System.Drawing.Point(13, 409)
        Me.lblJumlahBaris.Name = "lblJumlahBaris"
        Me.lblJumlahBaris.Size = New System.Drawing.Size(65, 13)
        Me.lblJumlahBaris.TabIndex = 325
        Me.lblJumlahBaris.Text = "Total Items :"
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(695, 468)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(103, 13)
        Me.Label20.TabIndex = 327
        Me.Label20.Text = "Tambahan Discount"
        '
        'txtTotalAddDisc
        '
        Me.txtTotalAddDisc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalAddDisc.Location = New System.Drawing.Point(801, 468)
        Me.txtTotalAddDisc.Name = "txtTotalAddDisc"
        Me.txtTotalAddDisc.Size = New System.Drawing.Size(140, 20)
        Me.txtTotalAddDisc.TabIndex = 21
        Me.txtTotalAddDisc.TabStop = False
        Me.txtTotalAddDisc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'frmPOS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(953, 611)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.txtTotalAddDisc)
        Me.Controls.Add(Me.lblJumlahBaris)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtFreetext1)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.cbTransType)
        Me.Controls.Add(Me.btnReceipt)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCatatan)
        Me.Controls.Add(Me.btnSaveHeader)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtTotalSub)
        Me.Controls.Add(Me.txtTotalDisc)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtTotalGrand)
        Me.Controls.Add(Me.txtTotalTax)
        Me.Controls.Add(Me.txtTotalGross)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtSubtotalDtl)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtDisc)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtHargaSatuan)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtSatuan)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtQty)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cbType)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnFilter)
        Me.Controls.Add(Me.btnPOS)
        Me.Controls.Add(Me.btnTable)
        Me.Controls.Add(Me.txtTableCode)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.btnAddDtl)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtDeskripsi)
        Me.Controls.Add(Me.txtMenu)
        Me.Controls.Add(Me.btnMenu)
        Me.Controls.Add(Me.btnDeleteDtl)
        Me.Controls.Add(Me.btnSaveDtl)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnVoid)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.dtpDate)
        Me.Controls.Add(Me.txtBillNo)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPOS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "POS"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnFilter As System.Windows.Forms.Button
    Friend WithEvents btnPOS As System.Windows.Forms.Button
    Friend WithEvents btnTable As System.Windows.Forms.Button
    Friend WithEvents txtTableCode As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents btnAddDtl As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtDeskripsi As System.Windows.Forms.TextBox
    Friend WithEvents txtMenu As System.Windows.Forms.TextBox
    Friend WithEvents btnMenu As System.Windows.Forms.Button
    Friend WithEvents btnDeleteDtl As System.Windows.Forms.Button
    Friend WithEvents btnSaveDtl As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnVoid As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtBillNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbType As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtQty As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtSatuan As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtHargaSatuan As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtDisc As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtSubtotalDtl As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtTotalSub As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalDisc As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtTotalGrand As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalTax As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalGross As System.Windows.Forms.TextBox
    Friend WithEvents btnSaveHeader As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCatatan As System.Windows.Forms.TextBox
    Friend WithEvents btnReceipt As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cbTransType As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtFreetext1 As System.Windows.Forms.TextBox
    Friend WithEvents lblJumlahBaris As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtTotalAddDisc As System.Windows.Forms.TextBox
End Class
