<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGroup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGroup))
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtSubmit = New System.Windows.Forms.TextBox()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.btnGroup = New System.Windows.Forms.Button()
        Me.btnAddD = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtFormName = New System.Windows.Forms.TextBox()
        Me.btnDeleteD = New System.Windows.Forms.Button()
        Me.btnSaveD = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.txtGroupDeskripsi = New System.Windows.Forms.TextBox()
        Me.txtKodeGroup = New System.Windows.Forms.TextBox()
        Me.chbBuka = New System.Windows.Forms.CheckBox()
        Me.chbTambah = New System.Windows.Forms.CheckBox()
        Me.chbBatal = New System.Windows.Forms.CheckBox()
        Me.chbHapus = New System.Windows.Forms.CheckBox()
        Me.chbSimpan = New System.Windows.Forms.CheckBox()
        Me.chbCetak = New System.Windows.Forms.CheckBox()
        Me.chbSelesai = New System.Windows.Forms.CheckBox()
        Me.chbApprove1 = New System.Windows.Forms.CheckBox()
        Me.chbApprove2 = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Label31
        '
        Me.Label31.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(652, 11)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(104, 13)
        Me.Label31.TabIndex = 385
        Me.Label31.Text = "Terakhir diubah oleh"
        '
        'txtSubmit
        '
        Me.txtSubmit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSubmit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSubmit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubmit.Location = New System.Drawing.Point(761, 8)
        Me.txtSubmit.MaxLength = 50
        Me.txtSubmit.Name = "txtSubmit"
        Me.txtSubmit.ReadOnly = True
        Me.txtSubmit.Size = New System.Drawing.Size(131, 21)
        Me.txtSubmit.TabIndex = 384
        '
        'btnFilter
        '
        Me.btnFilter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFilter.ImageIndex = 0
        Me.btnFilter.Location = New System.Drawing.Point(18, 500)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(29, 25)
        Me.btnFilter.TabIndex = 409
        Me.btnFilter.Text = "..."
        Me.btnFilter.UseVisualStyleBackColor = True
        Me.btnFilter.Visible = False
        '
        'btnGroup
        '
        Me.btnGroup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGroup.ImageIndex = 0
        Me.btnGroup.Location = New System.Drawing.Point(430, 6)
        Me.btnGroup.Name = "btnGroup"
        Me.btnGroup.Size = New System.Drawing.Size(29, 25)
        Me.btnGroup.TabIndex = 387
        Me.btnGroup.Text = "..."
        Me.btnGroup.UseVisualStyleBackColor = True
        '
        'btnAddD
        '
        Me.btnAddD.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddD.ImageIndex = 1
        Me.btnAddD.ImageList = Me.ImageList1
        Me.btnAddD.Location = New System.Drawing.Point(860, 32)
        Me.btnAddD.Name = "btnAddD"
        Me.btnAddD.Size = New System.Drawing.Size(29, 25)
        Me.btnAddD.TabIndex = 396
        Me.btnAddD.UseVisualStyleBackColor = True
        Me.btnAddD.Visible = False
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
        Me.Label19.Location = New System.Drawing.Point(19, 71)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(61, 13)
        Me.Label19.TabIndex = 407
        Me.Label19.Text = "Nama Form"
        '
        'txtFormName
        '
        Me.txtFormName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFormName.Location = New System.Drawing.Point(19, 87)
        Me.txtFormName.MaxLength = 50
        Me.txtFormName.Name = "txtFormName"
        Me.txtFormName.ReadOnly = True
        Me.txtFormName.Size = New System.Drawing.Size(221, 20)
        Me.txtFormName.TabIndex = 392
        '
        'btnDeleteD
        '
        Me.btnDeleteD.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteD.ImageIndex = 3
        Me.btnDeleteD.ImageList = Me.ImageList1
        Me.btnDeleteD.Location = New System.Drawing.Point(830, 32)
        Me.btnDeleteD.Name = "btnDeleteD"
        Me.btnDeleteD.Size = New System.Drawing.Size(29, 25)
        Me.btnDeleteD.TabIndex = 394
        Me.btnDeleteD.UseVisualStyleBackColor = True
        Me.btnDeleteD.Visible = False
        '
        'btnSaveD
        '
        Me.btnSaveD.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveD.ImageIndex = 2
        Me.btnSaveD.ImageList = Me.ImageList1
        Me.btnSaveD.Location = New System.Drawing.Point(860, 83)
        Me.btnSaveD.Name = "btnSaveD"
        Me.btnSaveD.Size = New System.Drawing.Size(29, 25)
        Me.btnSaveD.TabIndex = 393
        Me.btnSaveD.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(17, 40)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 13)
        Me.Label10.TabIndex = 405
        Me.Label10.Text = "Group Deskripsi"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(18, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 13)
        Me.Label6.TabIndex = 404
        Me.Label6.Text = "Kode Group *"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(804, 499)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(83, 26)
        Me.btnCancel.TabIndex = 401
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(534, 499)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(83, 26)
        Me.btnEdit.TabIndex = 398
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(624, 499)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(83, 26)
        Me.btnAdd.TabIndex = 399
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(444, 499)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(83, 26)
        Me.btnDelete.TabIndex = 397
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(714, 499)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(83, 26)
        Me.btnSave.TabIndex = 400
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
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(18, 114)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(871, 380)
        Me.ListView1.TabIndex = 395
        Me.ListView1.TabStop = False
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.List
        '
        'txtGroupDeskripsi
        '
        Me.txtGroupDeskripsi.Location = New System.Drawing.Point(156, 35)
        Me.txtGroupDeskripsi.MaxLength = 100
        Me.txtGroupDeskripsi.Name = "txtGroupDeskripsi"
        Me.txtGroupDeskripsi.Size = New System.Drawing.Size(267, 20)
        Me.txtGroupDeskripsi.TabIndex = 388
        '
        'txtKodeGroup
        '
        Me.txtKodeGroup.Location = New System.Drawing.Point(157, 9)
        Me.txtKodeGroup.MaxLength = 50
        Me.txtKodeGroup.Name = "txtKodeGroup"
        Me.txtKodeGroup.Size = New System.Drawing.Size(266, 20)
        Me.txtKodeGroup.TabIndex = 386
        '
        'chbBuka
        '
        Me.chbBuka.AutoSize = True
        Me.chbBuka.Location = New System.Drawing.Point(249, 89)
        Me.chbBuka.Name = "chbBuka"
        Me.chbBuka.Size = New System.Drawing.Size(51, 17)
        Me.chbBuka.TabIndex = 410
        Me.chbBuka.Text = "Buka"
        Me.chbBuka.UseVisualStyleBackColor = True
        '
        'chbTambah
        '
        Me.chbTambah.AutoSize = True
        Me.chbTambah.Location = New System.Drawing.Point(306, 89)
        Me.chbTambah.Name = "chbTambah"
        Me.chbTambah.Size = New System.Drawing.Size(65, 17)
        Me.chbTambah.TabIndex = 411
        Me.chbTambah.Text = "Tambah"
        Me.chbTambah.UseVisualStyleBackColor = True
        '
        'chbBatal
        '
        Me.chbBatal.AutoSize = True
        Me.chbBatal.Location = New System.Drawing.Point(377, 89)
        Me.chbBatal.Name = "chbBatal"
        Me.chbBatal.Size = New System.Drawing.Size(50, 17)
        Me.chbBatal.TabIndex = 412
        Me.chbBatal.Text = "Batal"
        Me.chbBatal.UseVisualStyleBackColor = True
        '
        'chbHapus
        '
        Me.chbHapus.AutoSize = True
        Me.chbHapus.Location = New System.Drawing.Point(437, 89)
        Me.chbHapus.Name = "chbHapus"
        Me.chbHapus.Size = New System.Drawing.Size(57, 17)
        Me.chbHapus.TabIndex = 413
        Me.chbHapus.Text = "Hapus"
        Me.chbHapus.UseVisualStyleBackColor = True
        '
        'chbSimpan
        '
        Me.chbSimpan.AutoSize = True
        Me.chbSimpan.Location = New System.Drawing.Point(500, 89)
        Me.chbSimpan.Name = "chbSimpan"
        Me.chbSimpan.Size = New System.Drawing.Size(61, 17)
        Me.chbSimpan.TabIndex = 414
        Me.chbSimpan.Text = "Simpan"
        Me.chbSimpan.UseVisualStyleBackColor = True
        '
        'chbCetak
        '
        Me.chbCetak.AutoSize = True
        Me.chbCetak.Location = New System.Drawing.Point(567, 89)
        Me.chbCetak.Name = "chbCetak"
        Me.chbCetak.Size = New System.Drawing.Size(54, 17)
        Me.chbCetak.TabIndex = 415
        Me.chbCetak.Text = "Cetak"
        Me.chbCetak.UseVisualStyleBackColor = True
        '
        'chbSelesai
        '
        Me.chbSelesai.AutoSize = True
        Me.chbSelesai.Location = New System.Drawing.Point(627, 89)
        Me.chbSelesai.Name = "chbSelesai"
        Me.chbSelesai.Size = New System.Drawing.Size(60, 17)
        Me.chbSelesai.TabIndex = 416
        Me.chbSelesai.Text = "Selesai"
        Me.chbSelesai.UseVisualStyleBackColor = True
        '
        'chbApprove1
        '
        Me.chbApprove1.AutoSize = True
        Me.chbApprove1.Location = New System.Drawing.Point(695, 89)
        Me.chbApprove1.Name = "chbApprove1"
        Me.chbApprove1.Size = New System.Drawing.Size(75, 17)
        Me.chbApprove1.TabIndex = 417
        Me.chbApprove1.Text = "Approve 1"
        Me.chbApprove1.UseVisualStyleBackColor = True
        '
        'chbApprove2
        '
        Me.chbApprove2.AutoSize = True
        Me.chbApprove2.Location = New System.Drawing.Point(775, 89)
        Me.chbApprove2.Name = "chbApprove2"
        Me.chbApprove2.Size = New System.Drawing.Size(75, 17)
        Me.chbApprove2.TabIndex = 418
        Me.chbApprove2.Text = "Approve 2"
        Me.chbApprove2.UseVisualStyleBackColor = True
        '
        'frmGroup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(904, 531)
        Me.Controls.Add(Me.chbApprove2)
        Me.Controls.Add(Me.chbApprove1)
        Me.Controls.Add(Me.chbSelesai)
        Me.Controls.Add(Me.chbCetak)
        Me.Controls.Add(Me.chbSimpan)
        Me.Controls.Add(Me.chbHapus)
        Me.Controls.Add(Me.chbBatal)
        Me.Controls.Add(Me.chbTambah)
        Me.Controls.Add(Me.chbBuka)
        Me.Controls.Add(Me.btnFilter)
        Me.Controls.Add(Me.btnGroup)
        Me.Controls.Add(Me.btnAddD)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtFormName)
        Me.Controls.Add(Me.btnDeleteD)
        Me.Controls.Add(Me.btnSaveD)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.txtGroupDeskripsi)
        Me.Controls.Add(Me.txtKodeGroup)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.txtSubmit)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmGroup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Master Group"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtSubmit As System.Windows.Forms.TextBox
    Friend WithEvents btnFilter As System.Windows.Forms.Button
    Friend WithEvents btnGroup As System.Windows.Forms.Button
    Friend WithEvents btnAddD As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtFormName As System.Windows.Forms.TextBox
    Friend WithEvents btnDeleteD As System.Windows.Forms.Button
    Friend WithEvents btnSaveD As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents txtGroupDeskripsi As System.Windows.Forms.TextBox
    Friend WithEvents txtKodeGroup As System.Windows.Forms.TextBox
    Friend WithEvents chbBuka As System.Windows.Forms.CheckBox
    Friend WithEvents chbTambah As System.Windows.Forms.CheckBox
    Friend WithEvents chbBatal As System.Windows.Forms.CheckBox
    Friend WithEvents chbHapus As System.Windows.Forms.CheckBox
    Friend WithEvents chbSimpan As System.Windows.Forms.CheckBox
    Friend WithEvents chbCetak As System.Windows.Forms.CheckBox
    Friend WithEvents chbSelesai As System.Windows.Forms.CheckBox
    Friend WithEvents chbApprove1 As System.Windows.Forms.CheckBox
    Friend WithEvents chbApprove2 As System.Windows.Forms.CheckBox
End Class
