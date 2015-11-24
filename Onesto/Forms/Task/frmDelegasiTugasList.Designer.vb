<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDelegasiTugasList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDelegasiTugasList))
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.chbDate = New System.Windows.Forms.CheckBox()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.btnView = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDept = New System.Windows.Forms.TextBox()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpPRDateFrom = New System.Windows.Forms.DateTimePicker()
        Me.txtNamaKaryawan = New System.Windows.Forms.TextBox()
        Me.dtpPRDateTo = New System.Windows.Forms.DateTimePicker()
        Me.cbStatus = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtNoTugas = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDeskripsi = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNoTugasD = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtDeskripsiD = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtNamaKaryawanD = New System.Windows.Forms.TextBox()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnApprove1 = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtApprove1Persentase = New System.Windows.Forms.TextBox()
        Me.cbApprove1 = New System.Windows.Forms.CheckBox()
        Me.gbApprove1 = New System.Windows.Forms.GroupBox()
        Me.gbApprove2 = New System.Windows.Forms.GroupBox()
        Me.txtApprove2Persentase = New System.Windows.Forms.TextBox()
        Me.cbApprove2 = New System.Windows.Forms.CheckBox()
        Me.btnApprove2 = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.gbApprove1.SuspendLayout()
        Me.gbApprove2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(12, 172)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(1005, 369)
        Me.ListView1.TabIndex = 1
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.List
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(842, 547)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(84, 26)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'chbDate
        '
        Me.chbDate.AutoSize = True
        Me.chbDate.Location = New System.Drawing.Point(13, 20)
        Me.chbDate.Name = "chbDate"
        Me.chbDate.Size = New System.Drawing.Size(87, 17)
        Me.chbDate.TabIndex = 0
        Me.chbDate.Text = "Dari Tanggal"
        Me.chbDate.UseVisualStyleBackColor = True
        '
        'btnFilter
        '
        Me.btnFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFilter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFilter.Location = New System.Drawing.Point(916, 67)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(84, 26)
        Me.btnFilter.TabIndex = 9
        Me.btnFilter.Text = "Show"
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'btnView
        '
        Me.btnView.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnView.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView.Location = New System.Drawing.Point(932, 547)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(84, 26)
        Me.btnView.TabIndex = 3
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(323, 76)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 13)
        Me.Label6.TabIndex = 99
        Me.Label6.Text = "Departemen"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(880, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(119, 25)
        Me.Label5.TabIndex = 71
        Me.Label5.Text = "List Tugas"
        '
        'txtDept
        '
        Me.txtDept.Location = New System.Drawing.Point(412, 71)
        Me.txtDept.MaxLength = 50
        Me.txtDept.Name = "txtDept"
        Me.txtDept.Size = New System.Drawing.Size(181, 20)
        Me.txtDept.TabIndex = 6
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClear.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.Location = New System.Drawing.Point(826, 67)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(84, 26)
        Me.btnClear.TabIndex = 8
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(229, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 13)
        Me.Label7.TabIndex = 65
        Me.Label7.Text = "Sampai"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(323, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 13)
        Me.Label3.TabIndex = 97
        Me.Label3.Text = "Nama Karyawan"
        '
        'dtpPRDateFrom
        '
        Me.dtpPRDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpPRDateFrom.Location = New System.Drawing.Point(126, 18)
        Me.dtpPRDateFrom.Name = "dtpPRDateFrom"
        Me.dtpPRDateFrom.Size = New System.Drawing.Size(97, 20)
        Me.dtpPRDateFrom.TabIndex = 1
        '
        'txtNamaKaryawan
        '
        Me.txtNamaKaryawan.Location = New System.Drawing.Point(412, 41)
        Me.txtNamaKaryawan.MaxLength = 50
        Me.txtNamaKaryawan.Name = "txtNamaKaryawan"
        Me.txtNamaKaryawan.Size = New System.Drawing.Size(181, 20)
        Me.txtNamaKaryawan.TabIndex = 4
        '
        'dtpPRDateTo
        '
        Me.dtpPRDateTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpPRDateTo.Location = New System.Drawing.Point(275, 18)
        Me.dtpPRDateTo.Name = "dtpPRDateTo"
        Me.dtpPRDateTo.Size = New System.Drawing.Size(97, 20)
        Me.dtpPRDateTo.TabIndex = 2
        '
        'cbStatus
        '
        Me.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbStatus.FormattingEnabled = True
        Me.cbStatus.Location = New System.Drawing.Point(638, 69)
        Me.cbStatus.Name = "cbStatus"
        Me.cbStatus.Size = New System.Drawing.Size(112, 21)
        Me.cbStatus.TabIndex = 7
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.chbDate)
        Me.GroupBox1.Controls.Add(Me.btnFilter)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtDept)
        Me.GroupBox1.Controls.Add(Me.btnClear)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.dtpPRDateFrom)
        Me.GroupBox1.Controls.Add(Me.txtNamaKaryawan)
        Me.GroupBox1.Controls.Add(Me.dtpPRDateTo)
        Me.GroupBox1.Controls.Add(Me.cbStatus)
        Me.GroupBox1.Controls.Add(Me.txtNoTugas)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtDeskripsi)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1005, 105)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filter By"
        '
        'txtNoTugas
        '
        Me.txtNoTugas.Location = New System.Drawing.Point(126, 44)
        Me.txtNoTugas.MaxLength = 50
        Me.txtNoTugas.Name = "txtNoTugas"
        Me.txtNoTugas.Size = New System.Drawing.Size(181, 20)
        Me.txtNoTugas.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(597, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 95
        Me.Label1.Text = "Status"
        '
        'txtDeskripsi
        '
        Me.txtDeskripsi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeskripsi.Location = New System.Drawing.Point(126, 72)
        Me.txtDeskripsi.MaxLength = 255
        Me.txtDeskripsi.Name = "txtDeskripsi"
        Me.txtDeskripsi.Size = New System.Drawing.Size(181, 21)
        Me.txtDeskripsi.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Tugas No."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Deskripsi Tugas"
        '
        'txtNoTugasD
        '
        Me.txtNoTugasD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNoTugasD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoTugasD.Location = New System.Drawing.Point(12, 146)
        Me.txtNoTugasD.MaxLength = 50
        Me.txtNoTugasD.Name = "txtNoTugasD"
        Me.txtNoTugasD.ReadOnly = True
        Me.txtNoTugasD.Size = New System.Drawing.Size(127, 21)
        Me.txtNoTugasD.TabIndex = 364
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(8, 130)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(61, 13)
        Me.Label10.TabIndex = 365
        Me.Label10.Text = "No Tugas *"
        '
        'txtDeskripsiD
        '
        Me.txtDeskripsiD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeskripsiD.Location = New System.Drawing.Point(145, 146)
        Me.txtDeskripsiD.MaxLength = 255
        Me.txtDeskripsiD.Name = "txtDeskripsiD"
        Me.txtDeskripsiD.ReadOnly = True
        Me.txtDeskripsiD.Size = New System.Drawing.Size(265, 21)
        Me.txtDeskripsiD.TabIndex = 366
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(142, 130)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 13)
        Me.Label8.TabIndex = 367
        Me.Label8.Text = "Deskripsi *"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(413, 130)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 13)
        Me.Label9.TabIndex = 369
        Me.Label9.Text = "Nama Karyawan"
        '
        'txtNamaKaryawanD
        '
        Me.txtNamaKaryawanD.Location = New System.Drawing.Point(416, 146)
        Me.txtNamaKaryawanD.MaxLength = 50
        Me.txtNamaKaryawanD.Name = "txtNamaKaryawanD"
        Me.txtNamaKaryawanD.ReadOnly = True
        Me.txtNamaKaryawanD.Size = New System.Drawing.Size(141, 20)
        Me.txtNamaKaryawanD.TabIndex = 368
        Me.txtNamaKaryawanD.TabStop = False
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
        'btnApprove1
        '
        Me.btnApprove1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnApprove1.ImageIndex = 2
        Me.btnApprove1.ImageList = Me.ImageList1
        Me.btnApprove1.Location = New System.Drawing.Point(144, 11)
        Me.btnApprove1.Name = "btnApprove1"
        Me.btnApprove1.Size = New System.Drawing.Size(29, 25)
        Me.btnApprove1.TabIndex = 394
        Me.btnApprove1.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(128, 18)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(15, 13)
        Me.Label20.TabIndex = 397
        Me.Label20.Text = "%"
        '
        'txtApprove1Persentase
        '
        Me.txtApprove1Persentase.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtApprove1Persentase.Location = New System.Drawing.Point(76, 15)
        Me.txtApprove1Persentase.MaxLength = 3
        Me.txtApprove1Persentase.Name = "txtApprove1Persentase"
        Me.txtApprove1Persentase.Size = New System.Drawing.Size(46, 21)
        Me.txtApprove1Persentase.TabIndex = 396
        '
        'cbApprove1
        '
        Me.cbApprove1.AutoSize = True
        Me.cbApprove1.Enabled = False
        Me.cbApprove1.Location = New System.Drawing.Point(5, 20)
        Me.cbApprove1.Name = "cbApprove1"
        Me.cbApprove1.Size = New System.Drawing.Size(66, 17)
        Me.cbApprove1.TabIndex = 398
        Me.cbApprove1.Text = "Approve"
        Me.cbApprove1.UseVisualStyleBackColor = True
        '
        'gbApprove1
        '
        Me.gbApprove1.Controls.Add(Me.txtApprove1Persentase)
        Me.gbApprove1.Controls.Add(Me.cbApprove1)
        Me.gbApprove1.Controls.Add(Me.btnApprove1)
        Me.gbApprove1.Controls.Add(Me.Label20)
        Me.gbApprove1.Location = New System.Drawing.Point(565, 123)
        Me.gbApprove1.Name = "gbApprove1"
        Me.gbApprove1.Size = New System.Drawing.Size(183, 44)
        Me.gbApprove1.TabIndex = 399
        Me.gbApprove1.TabStop = False
        Me.gbApprove1.Text = "Approve 1"
        Me.gbApprove1.Visible = False
        '
        'gbApprove2
        '
        Me.gbApprove2.Controls.Add(Me.txtApprove2Persentase)
        Me.gbApprove2.Controls.Add(Me.cbApprove2)
        Me.gbApprove2.Controls.Add(Me.btnApprove2)
        Me.gbApprove2.Controls.Add(Me.Label11)
        Me.gbApprove2.Location = New System.Drawing.Point(758, 122)
        Me.gbApprove2.Name = "gbApprove2"
        Me.gbApprove2.Size = New System.Drawing.Size(183, 44)
        Me.gbApprove2.TabIndex = 400
        Me.gbApprove2.TabStop = False
        Me.gbApprove2.Text = "Approve 2"
        Me.gbApprove2.Visible = False
        '
        'txtApprove2Persentase
        '
        Me.txtApprove2Persentase.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtApprove2Persentase.Location = New System.Drawing.Point(76, 15)
        Me.txtApprove2Persentase.MaxLength = 3
        Me.txtApprove2Persentase.Name = "txtApprove2Persentase"
        Me.txtApprove2Persentase.Size = New System.Drawing.Size(46, 21)
        Me.txtApprove2Persentase.TabIndex = 396
        '
        'cbApprove2
        '
        Me.cbApprove2.AutoSize = True
        Me.cbApprove2.Enabled = False
        Me.cbApprove2.Location = New System.Drawing.Point(5, 20)
        Me.cbApprove2.Name = "cbApprove2"
        Me.cbApprove2.Size = New System.Drawing.Size(66, 17)
        Me.cbApprove2.TabIndex = 398
        Me.cbApprove2.Text = "Approve"
        Me.cbApprove2.UseVisualStyleBackColor = True
        '
        'btnApprove2
        '
        Me.btnApprove2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnApprove2.ImageIndex = 2
        Me.btnApprove2.ImageList = Me.ImageList1
        Me.btnApprove2.Location = New System.Drawing.Point(144, 11)
        Me.btnApprove2.Name = "btnApprove2"
        Me.btnApprove2.Size = New System.Drawing.Size(29, 25)
        Me.btnApprove2.TabIndex = 394
        Me.btnApprove2.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(128, 18)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(15, 13)
        Me.Label11.TabIndex = 397
        Me.Label11.Text = "%"
        '
        'frmDelegasiTugasList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1028, 585)
        Me.Controls.Add(Me.gbApprove2)
        Me.Controls.Add(Me.gbApprove1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtNamaKaryawanD)
        Me.Controls.Add(Me.txtDeskripsiD)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtNoTugasD)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmDelegasiTugasList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "List Tugas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbApprove1.ResumeLayout(False)
        Me.gbApprove1.PerformLayout()
        Me.gbApprove2.ResumeLayout(False)
        Me.gbApprove2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents chbDate As System.Windows.Forms.CheckBox
    Friend WithEvents btnFilter As System.Windows.Forms.Button
    Friend WithEvents btnView As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDept As System.Windows.Forms.TextBox
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpPRDateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtNamaKaryawan As System.Windows.Forms.TextBox
    Friend WithEvents dtpPRDateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNoTugas As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDeskripsi As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNoTugasD As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtDeskripsiD As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtNamaKaryawanD As System.Windows.Forms.TextBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents btnApprove1 As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtApprove1Persentase As System.Windows.Forms.TextBox
    Friend WithEvents cbApprove1 As System.Windows.Forms.CheckBox
    Friend WithEvents gbApprove1 As System.Windows.Forms.GroupBox
    Friend WithEvents gbApprove2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtApprove2Persentase As System.Windows.Forms.TextBox
    Friend WithEvents cbApprove2 As System.Windows.Forms.CheckBox
    Friend WithEvents btnApprove2 As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
End Class
