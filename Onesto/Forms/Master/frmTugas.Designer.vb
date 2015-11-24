<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTugas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTugas))
        Me.OFDLampiran = New System.Windows.Forms.OpenFileDialog()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.lblStandard = New System.Windows.Forms.LinkLabel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnStandard = New System.Windows.Forms.Button()
        Me.btnDept = New System.Windows.Forms.Button()
        Me.txtKodeDept = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDeskripsi = New System.Windows.Forms.TextBox()
        Me.txtKodeTugas = New System.Windows.Forms.TextBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnTugas = New System.Windows.Forms.Button()
        Me.btnPrevious = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.lblImage = New System.Windows.Forms.Label()
        Me.txtRepeat = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbValBefore = New System.Windows.Forms.CheckBox()
        Me.cbValAfter1 = New System.Windows.Forms.CheckBox()
        Me.cbValAfter2 = New System.Windows.Forms.CheckBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OFDLampiran
        '
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Location = New System.Drawing.Point(440, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(550, 378)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 262
        Me.PictureBox1.TabStop = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(610, 402)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(380, 23)
        Me.ProgressBar1.TabIndex = 261
        Me.ProgressBar1.Visible = False
        '
        'lblStandard
        '
        Me.lblStandard.AutoSize = True
        Me.lblStandard.Location = New System.Drawing.Point(187, 148)
        Me.lblStandard.Name = "lblStandard"
        Me.lblStandard.Size = New System.Drawing.Size(0, 13)
        Me.lblStandard.TabIndex = 254
        Me.lblStandard.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(27, 148)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 253
        Me.Label4.Text = "Standard"
        '
        'btnStandard
        '
        Me.btnStandard.Location = New System.Drawing.Point(150, 143)
        Me.btnStandard.Name = "btnStandard"
        Me.btnStandard.Size = New System.Drawing.Size(29, 25)
        Me.btnStandard.TabIndex = 9
        Me.btnStandard.Text = "..."
        Me.btnStandard.UseVisualStyleBackColor = True
        '
        'btnDept
        '
        Me.btnDept.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDept.ImageIndex = 0
        Me.btnDept.Location = New System.Drawing.Point(380, 88)
        Me.btnDept.Name = "btnDept"
        Me.btnDept.Size = New System.Drawing.Size(29, 25)
        Me.btnDept.TabIndex = 6
        Me.btnDept.Text = "..."
        Me.btnDept.UseVisualStyleBackColor = True
        '
        'txtKodeDept
        '
        Me.txtKodeDept.Location = New System.Drawing.Point(151, 91)
        Me.txtKodeDept.MaxLength = 50
        Me.txtKodeDept.Name = "txtKodeDept"
        Me.txtKodeDept.ReadOnly = True
        Me.txtKodeDept.Size = New System.Drawing.Size(223, 20)
        Me.txtKodeDept.TabIndex = 5
        Me.txtKodeDept.TabStop = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(27, 94)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(93, 13)
        Me.Label27.TabIndex = 247
        Me.Label27.Text = "Kode Departemen"
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(347, 366)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(104, 366)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 23)
        Me.btnEdit.TabIndex = 13
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(185, 366)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 14
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(27, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 246
        Me.Label2.Text = "Deskripsi *"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(26, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 245
        Me.Label1.Text = "Kode Tugas *"
        '
        'txtDeskripsi
        '
        Me.txtDeskripsi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeskripsi.Location = New System.Drawing.Point(150, 38)
        Me.txtDeskripsi.MaxLength = 255
        Me.txtDeskripsi.Multiline = True
        Me.txtDeskripsi.Name = "txtDeskripsi"
        Me.txtDeskripsi.Size = New System.Drawing.Size(259, 47)
        Me.txtDeskripsi.TabIndex = 2
        '
        'txtKodeTugas
        '
        Me.txtKodeTugas.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtKodeTugas.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKodeTugas.Location = New System.Drawing.Point(150, 11)
        Me.txtKodeTugas.MaxLength = 50
        Me.txtKodeTugas.Name = "txtKodeTugas"
        Me.txtKodeTugas.Size = New System.Drawing.Size(224, 21)
        Me.txtKodeTugas.TabIndex = 0
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(23, 366)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 12
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(266, 366)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 15
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnTugas
        '
        Me.btnTugas.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTugas.ImageIndex = 0
        Me.btnTugas.Location = New System.Drawing.Point(380, 10)
        Me.btnTugas.Name = "btnTugas"
        Me.btnTugas.Size = New System.Drawing.Size(29, 25)
        Me.btnTugas.TabIndex = 1
        Me.btnTugas.Text = "..."
        Me.btnTugas.UseVisualStyleBackColor = True
        '
        'btnPrevious
        '
        Me.btnPrevious.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnPrevious.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrevious.ImageIndex = 0
        Me.btnPrevious.Location = New System.Drawing.Point(407, 148)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New System.Drawing.Size(29, 91)
        Me.btnPrevious.TabIndex = 17
        Me.btnPrevious.Text = "<"
        Me.btnPrevious.UseVisualStyleBackColor = True
        Me.btnPrevious.Visible = False
        '
        'btnNext
        '
        Me.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnNext.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNext.ImageIndex = 0
        Me.btnNext.Location = New System.Drawing.Point(998, 148)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(29, 91)
        Me.btnNext.TabIndex = 18
        Me.btnNext.Text = ">"
        Me.btnNext.UseVisualStyleBackColor = True
        Me.btnNext.Visible = False
        '
        'btnFilter
        '
        Me.btnFilter.Location = New System.Drawing.Point(459, 400)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(29, 25)
        Me.btnFilter.TabIndex = 266
        Me.btnFilter.Text = "..."
        Me.btnFilter.UseVisualStyleBackColor = True
        Me.btnFilter.Visible = False
        '
        'lblImage
        '
        Me.lblImage.AutoSize = True
        Me.lblImage.Location = New System.Drawing.Point(459, 442)
        Me.lblImage.Name = "lblImage"
        Me.lblImage.Size = New System.Drawing.Size(0, 13)
        Me.lblImage.TabIndex = 267
        Me.lblImage.Visible = False
        '
        'txtRepeat
        '
        Me.txtRepeat.Location = New System.Drawing.Point(151, 117)
        Me.txtRepeat.MaxLength = 3
        Me.txtRepeat.Name = "txtRepeat"
        Me.txtRepeat.Size = New System.Drawing.Size(55, 20)
        Me.txtRepeat.TabIndex = 7
        Me.txtRepeat.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 13)
        Me.Label3.TabIndex = 251
        Me.Label3.Text = "Repeat Setiap"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(212, 120)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(26, 13)
        Me.Label6.TabIndex = 268
        Me.Label6.Text = "Hari"
        '
        'cbValBefore
        '
        Me.cbValBefore.AutoSize = True
        Me.cbValBefore.Location = New System.Drawing.Point(30, 186)
        Me.cbValBefore.Name = "cbValBefore"
        Me.cbValBefore.Size = New System.Drawing.Size(96, 17)
        Me.cbValBefore.TabIndex = 269
        Me.cbValBefore.Text = "Validasi Before"
        Me.cbValBefore.UseVisualStyleBackColor = True
        '
        'cbValAfter1
        '
        Me.cbValAfter1.AutoSize = True
        Me.cbValAfter1.Location = New System.Drawing.Point(30, 209)
        Me.cbValAfter1.Name = "cbValAfter1"
        Me.cbValAfter1.Size = New System.Drawing.Size(96, 17)
        Me.cbValAfter1.TabIndex = 270
        Me.cbValAfter1.Text = "Validasi After 1"
        Me.cbValAfter1.UseVisualStyleBackColor = True
        '
        'cbValAfter2
        '
        Me.cbValAfter2.AutoSize = True
        Me.cbValAfter2.Location = New System.Drawing.Point(30, 232)
        Me.cbValAfter2.Name = "cbValAfter2"
        Me.cbValAfter2.Size = New System.Drawing.Size(96, 17)
        Me.cbValAfter2.TabIndex = 271
        Me.cbValAfter2.Text = "Validasi After 2"
        Me.cbValAfter2.UseVisualStyleBackColor = True
        '
        'frmTugas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1028, 473)
        Me.Controls.Add(Me.cbValAfter2)
        Me.Controls.Add(Me.cbValAfter1)
        Me.Controls.Add(Me.cbValBefore)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblImage)
        Me.Controls.Add(Me.btnFilter)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnPrevious)
        Me.Controls.Add(Me.btnTugas)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.lblStandard)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnStandard)
        Me.Controls.Add(Me.txtRepeat)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnDept)
        Me.Controls.Add(Me.txtKodeDept)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDeskripsi)
        Me.Controls.Add(Me.txtKodeTugas)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmTugas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Master Tugas"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OFDLampiran As System.Windows.Forms.OpenFileDialog
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents lblStandard As System.Windows.Forms.LinkLabel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnStandard As System.Windows.Forms.Button
    Friend WithEvents btnDept As System.Windows.Forms.Button
    Friend WithEvents txtKodeDept As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDeskripsi As System.Windows.Forms.TextBox
    Friend WithEvents txtKodeTugas As System.Windows.Forms.TextBox
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnTugas As System.Windows.Forms.Button
    Friend WithEvents btnPrevious As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnFilter As System.Windows.Forms.Button
    Friend WithEvents lblImage As System.Windows.Forms.Label
    Friend WithEvents txtRepeat As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbValBefore As System.Windows.Forms.CheckBox
    Friend WithEvents cbValAfter1 As System.Windows.Forms.CheckBox
    Friend WithEvents cbValAfter2 As System.Windows.Forms.CheckBox
End Class
