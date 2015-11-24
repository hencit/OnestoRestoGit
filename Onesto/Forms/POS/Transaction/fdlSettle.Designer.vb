<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fdlSettle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fdlSettle))
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtBillNo = New System.Windows.Forms.TextBox()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbReceipt = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTotalPembayaran = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTotalPengembalian = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCatatan = New System.Windows.Forms.TextBox()
        Me.txtTableCode = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtTotalAddDisc = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 273
        Me.Label6.Text = "Bill No."
        '
        'txtBillNo
        '
        Me.txtBillNo.Location = New System.Drawing.Point(110, 11)
        Me.txtBillNo.MaxLength = 20
        Me.txtBillNo.Name = "txtBillNo"
        Me.txtBillNo.ReadOnly = True
        Me.txtBillNo.Size = New System.Drawing.Size(209, 20)
        Me.txtBillNo.TabIndex = 0
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(109, 90)
        Me.txtStatus.MaxLength = 50
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(209, 20)
        Me.txtStatus.TabIndex = 3
        Me.txtStatus.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 282
        Me.Label2.Text = "Status"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 200)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 326
        Me.Label5.Text = "Subtotal"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(4, 147)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(49, 13)
        Me.Label12.TabIndex = 325
        Me.Label12.Text = "Discount"
        '
        'txtTotalSub
        '
        Me.txtTotalSub.Location = New System.Drawing.Point(110, 200)
        Me.txtTotalSub.Name = "txtTotalSub"
        Me.txtTotalSub.ReadOnly = True
        Me.txtTotalSub.Size = New System.Drawing.Size(209, 20)
        Me.txtTotalSub.TabIndex = 6
        Me.txtTotalSub.TabStop = False
        Me.txtTotalSub.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalDisc
        '
        Me.txtTotalDisc.Location = New System.Drawing.Point(110, 147)
        Me.txtTotalDisc.Name = "txtTotalDisc"
        Me.txtTotalDisc.ReadOnly = True
        Me.txtTotalDisc.Size = New System.Drawing.Size(209, 20)
        Me.txtTotalDisc.TabIndex = 5
        Me.txtTotalDisc.TabStop = False
        Me.txtTotalDisc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(4, 259)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(63, 13)
        Me.Label13.TabIndex = 319
        Me.Label13.Text = "Grand Total"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(3, 227)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(80, 13)
        Me.Label14.TabIndex = 318
        Me.Label14.Text = "Pajak Restoran"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(4, 120)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(61, 13)
        Me.Label15.TabIndex = 317
        Me.Label15.Text = "Gross Total"
        '
        'txtTotalGrand
        '
        Me.txtTotalGrand.Location = New System.Drawing.Point(110, 256)
        Me.txtTotalGrand.Name = "txtTotalGrand"
        Me.txtTotalGrand.ReadOnly = True
        Me.txtTotalGrand.Size = New System.Drawing.Size(209, 20)
        Me.txtTotalGrand.TabIndex = 8
        Me.txtTotalGrand.TabStop = False
        Me.txtTotalGrand.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalTax
        '
        Me.txtTotalTax.Location = New System.Drawing.Point(110, 227)
        Me.txtTotalTax.Name = "txtTotalTax"
        Me.txtTotalTax.ReadOnly = True
        Me.txtTotalTax.Size = New System.Drawing.Size(209, 20)
        Me.txtTotalTax.TabIndex = 7
        Me.txtTotalTax.TabStop = False
        Me.txtTotalTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalGross
        '
        Me.txtTotalGross.Location = New System.Drawing.Point(110, 120)
        Me.txtTotalGross.Name = "txtTotalGross"
        Me.txtTotalGross.ReadOnly = True
        Me.txtTotalGross.Size = New System.Drawing.Size(209, 20)
        Me.txtTotalGross.TabIndex = 4
        Me.txtTotalGross.TabStop = False
        Me.txtTotalGross.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 328
        Me.Label1.Text = "Tanggal"
        '
        'dtpDate
        '
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDate.Location = New System.Drawing.Point(110, 37)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(96, 20)
        Me.dtpDate.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(4, 288)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 13)
        Me.Label4.TabIndex = 330
        Me.Label4.Text = "Jenis Pembayaran"
        '
        'cbReceipt
        '
        Me.cbReceipt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbReceipt.FormattingEnabled = True
        Me.cbReceipt.Location = New System.Drawing.Point(110, 285)
        Me.cbReceipt.Name = "cbReceipt"
        Me.cbReceipt.Size = New System.Drawing.Size(96, 21)
        Me.cbReceipt.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 318)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 13)
        Me.Label3.TabIndex = 332
        Me.Label3.Text = "Jumlah Pembayaran"
        '
        'txtTotalPembayaran
        '
        Me.txtTotalPembayaran.Location = New System.Drawing.Point(111, 315)
        Me.txtTotalPembayaran.Name = "txtTotalPembayaran"
        Me.txtTotalPembayaran.Size = New System.Drawing.Size(209, 20)
        Me.txtTotalPembayaran.TabIndex = 10
        Me.txtTotalPembayaran.TabStop = False
        Me.txtTotalPembayaran.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(5, 344)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 13)
        Me.Label7.TabIndex = 334
        Me.Label7.Text = "Pengembalian"
        '
        'txtTotalPengembalian
        '
        Me.txtTotalPengembalian.Location = New System.Drawing.Point(111, 341)
        Me.txtTotalPengembalian.Name = "txtTotalPengembalian"
        Me.txtTotalPengembalian.ReadOnly = True
        Me.txtTotalPengembalian.Size = New System.Drawing.Size(209, 20)
        Me.txtTotalPengembalian.TabIndex = 11
        Me.txtTotalPengembalian.TabStop = False
        Me.txtTotalPengembalian.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(243, 487)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 14
        Me.btnSave.Text = "Simpan"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Location = New System.Drawing.Point(162, 487)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 13
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(5, 373)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 13)
        Me.Label8.TabIndex = 339
        Me.Label8.Text = "Catatan"
        '
        'txtCatatan
        '
        Me.txtCatatan.Location = New System.Drawing.Point(109, 370)
        Me.txtCatatan.MaxLength = 255
        Me.txtCatatan.Multiline = True
        Me.txtCatatan.Name = "txtCatatan"
        Me.txtCatatan.Size = New System.Drawing.Size(211, 60)
        Me.txtCatatan.TabIndex = 12
        '
        'txtTableCode
        '
        Me.txtTableCode.Location = New System.Drawing.Point(109, 61)
        Me.txtTableCode.MaxLength = 50
        Me.txtTableCode.Name = "txtTableCode"
        Me.txtTableCode.ReadOnly = True
        Me.txtTableCode.Size = New System.Drawing.Size(209, 20)
        Me.txtTableCode.TabIndex = 2
        Me.txtTableCode.TabStop = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(4, 67)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(34, 13)
        Me.Label27.TabIndex = 341
        Me.Label27.Text = "Table"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(4, 174)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(103, 13)
        Me.Label9.TabIndex = 343
        Me.Label9.Text = "Tambahan Discount"
        '
        'txtTotalAddDisc
        '
        Me.txtTotalAddDisc.Location = New System.Drawing.Point(110, 174)
        Me.txtTotalAddDisc.Name = "txtTotalAddDisc"
        Me.txtTotalAddDisc.ReadOnly = True
        Me.txtTotalAddDisc.Size = New System.Drawing.Size(209, 20)
        Me.txtTotalAddDisc.TabIndex = 342
        Me.txtTotalAddDisc.TabStop = False
        Me.txtTotalAddDisc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'fdlSettle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(330, 522)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtTotalAddDisc)
        Me.Controls.Add(Me.txtTableCode)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtCatatan)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtTotalPengembalian)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtTotalPembayaran)
        Me.Controls.Add(Me.cbReceipt)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpDate)
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
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtBillNo)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "fdlSettle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Receipt"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtBillNo As System.Windows.Forms.TextBox
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbReceipt As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPembayaran As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPengembalian As System.Windows.Forms.TextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCatatan As System.Windows.Forms.TextBox
    Friend WithEvents txtTableCode As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTotalAddDisc As System.Windows.Forms.TextBox
End Class
