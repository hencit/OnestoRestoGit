<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTemplateTugas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTemplateTugas))
        Me.btnAddD = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtTugasDeskripsi = New System.Windows.Forms.TextBox()
        Me.txtKodeTugas = New System.Windows.Forms.TextBox()
        Me.btnTugas = New System.Windows.Forms.Button()
        Me.btnDeleteD = New System.Windows.Forms.Button()
        Me.btnSaveD = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.txtTemplateDeskripsi = New System.Windows.Forms.TextBox()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.txtKodeTemplateTugas = New System.Windows.Forms.TextBox()
        Me.bankadjno = New System.Windows.Forms.TextBox()
        Me.btnDept = New System.Windows.Forms.Button()
        Me.txtKodeDept = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.btnTemplate = New System.Windows.Forms.Button()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnAddD
        '
        Me.btnAddD.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddD.ImageIndex = 1
        Me.btnAddD.ImageList = Me.ImageList1
        Me.btnAddD.Location = New System.Drawing.Point(570, 114)
        Me.btnAddD.Name = "btnAddD"
        Me.btnAddD.Size = New System.Drawing.Size(29, 25)
        Me.btnAddD.TabIndex = 9
        Me.btnAddD.UseVisualStyleBackColor = True
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
        Me.Label19.Location = New System.Drawing.Point(130, 101)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(80, 13)
        Me.Label19.TabIndex = 154
        Me.Label19.Text = "TugasDeskripsi"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(9, 101)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(65, 13)
        Me.Label18.TabIndex = 153
        Me.Label18.Text = "Kode Tugas"
        '
        'txtTugasDeskripsi
        '
        Me.txtTugasDeskripsi.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTugasDeskripsi.Location = New System.Drawing.Point(130, 117)
        Me.txtTugasDeskripsi.MaxLength = 100
        Me.txtTugasDeskripsi.Name = "txtTugasDeskripsi"
        Me.txtTugasDeskripsi.ReadOnly = True
        Me.txtTugasDeskripsi.Size = New System.Drawing.Size(370, 20)
        Me.txtTugasDeskripsi.TabIndex = 6
        '
        'txtKodeTugas
        '
        Me.txtKodeTugas.Location = New System.Drawing.Point(12, 117)
        Me.txtKodeTugas.MaxLength = 50
        Me.txtKodeTugas.Name = "txtKodeTugas"
        Me.txtKodeTugas.ReadOnly = True
        Me.txtKodeTugas.Size = New System.Drawing.Size(80, 20)
        Me.txtKodeTugas.TabIndex = 135
        '
        'btnTugas
        '
        Me.btnTugas.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTugas.ImageIndex = 0
        Me.btnTugas.ImageList = Me.ImageList1
        Me.btnTugas.Location = New System.Drawing.Point(95, 114)
        Me.btnTugas.Name = "btnTugas"
        Me.btnTugas.Size = New System.Drawing.Size(29, 25)
        Me.btnTugas.TabIndex = 5
        Me.btnTugas.UseVisualStyleBackColor = True
        '
        'btnDeleteD
        '
        Me.btnDeleteD.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteD.ImageIndex = 3
        Me.btnDeleteD.ImageList = Me.ImageList1
        Me.btnDeleteD.Location = New System.Drawing.Point(540, 114)
        Me.btnDeleteD.Name = "btnDeleteD"
        Me.btnDeleteD.Size = New System.Drawing.Size(29, 25)
        Me.btnDeleteD.TabIndex = 8
        Me.btnDeleteD.UseVisualStyleBackColor = True
        '
        'btnSaveD
        '
        Me.btnSaveD.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveD.ImageIndex = 2
        Me.btnSaveD.ImageList = Me.ImageList1
        Me.btnSaveD.Location = New System.Drawing.Point(510, 114)
        Me.btnSaveD.Name = "btnSaveD"
        Me.btnSaveD.Size = New System.Drawing.Size(29, 25)
        Me.btnSaveD.TabIndex = 7
        Me.btnSaveD.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(11, 42)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(130, 13)
        Me.Label10.TabIndex = 152
        Me.Label10.Text = "Template Tugas Deskripsi"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(562, 35)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 151
        Me.Label7.Text = "Tanggal"
        Me.Label7.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(139, 13)
        Me.Label6.TabIndex = 150
        Me.Label6.Text = "Kode Template Tugas *"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(514, 501)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(83, 26)
        Me.btnCancel.TabIndex = 14
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(244, 501)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(83, 26)
        Me.btnEdit.TabIndex = 11
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(334, 501)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(83, 26)
        Me.btnAdd.TabIndex = 12
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(154, 501)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(83, 26)
        Me.btnDelete.TabIndex = 10
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(424, 501)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(83, 26)
        Me.btnSave.TabIndex = 13
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
        Me.ListView1.Location = New System.Drawing.Point(12, 144)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(587, 334)
        Me.ListView1.TabIndex = 8
        Me.ListView1.TabStop = False
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.List
        '
        'txtTemplateDeskripsi
        '
        Me.txtTemplateDeskripsi.Location = New System.Drawing.Point(150, 37)
        Me.txtTemplateDeskripsi.MaxLength = 50
        Me.txtTemplateDeskripsi.Name = "txtTemplateDeskripsi"
        Me.txtTemplateDeskripsi.Size = New System.Drawing.Size(267, 20)
        Me.txtTemplateDeskripsi.TabIndex = 2
        '
        'dtpDate
        '
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDate.Location = New System.Drawing.Point(511, 12)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(97, 20)
        Me.dtpDate.TabIndex = 133
        Me.dtpDate.Visible = False
        '
        'txtKodeTemplateTugas
        '
        Me.txtKodeTemplateTugas.Location = New System.Drawing.Point(151, 11)
        Me.txtKodeTemplateTugas.MaxLength = 50
        Me.txtKodeTemplateTugas.Name = "txtKodeTemplateTugas"
        Me.txtKodeTemplateTugas.Size = New System.Drawing.Size(266, 20)
        Me.txtKodeTemplateTugas.TabIndex = 0
        '
        'bankadjno
        '
        Me.bankadjno.Location = New System.Drawing.Point(100, 10)
        Me.bankadjno.MaxLength = 10
        Me.bankadjno.Name = "bankadjno"
        Me.bankadjno.Size = New System.Drawing.Size(153, 20)
        Me.bankadjno.TabIndex = 132
        '
        'btnDept
        '
        Me.btnDept.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDept.ImageIndex = 0
        Me.btnDept.Location = New System.Drawing.Point(422, 60)
        Me.btnDept.Name = "btnDept"
        Me.btnDept.Size = New System.Drawing.Size(29, 25)
        Me.btnDept.TabIndex = 4
        Me.btnDept.Text = "..."
        Me.btnDept.UseVisualStyleBackColor = True
        '
        'txtKodeDept
        '
        Me.txtKodeDept.Location = New System.Drawing.Point(150, 63)
        Me.txtKodeDept.MaxLength = 50
        Me.txtKodeDept.Name = "txtKodeDept"
        Me.txtKodeDept.ReadOnly = True
        Me.txtKodeDept.Size = New System.Drawing.Size(267, 20)
        Me.txtKodeDept.TabIndex = 3
        Me.txtKodeDept.TabStop = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(12, 66)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(93, 13)
        Me.Label27.TabIndex = 250
        Me.Label27.Text = "Kode Departemen"
        '
        'btnTemplate
        '
        Me.btnTemplate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTemplate.ImageIndex = 0
        Me.btnTemplate.Location = New System.Drawing.Point(424, 8)
        Me.btnTemplate.Name = "btnTemplate"
        Me.btnTemplate.Size = New System.Drawing.Size(29, 25)
        Me.btnTemplate.TabIndex = 1
        Me.btnTemplate.Text = "..."
        Me.btnTemplate.UseVisualStyleBackColor = True
        '
        'btnFilter
        '
        Me.btnFilter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFilter.ImageIndex = 0
        Me.btnFilter.Location = New System.Drawing.Point(12, 502)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(29, 25)
        Me.btnFilter.TabIndex = 251
        Me.btnFilter.Text = "..."
        Me.btnFilter.UseVisualStyleBackColor = True
        Me.btnFilter.Visible = False
        '
        'frmTemplateTugas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(620, 531)
        Me.Controls.Add(Me.btnFilter)
        Me.Controls.Add(Me.btnTemplate)
        Me.Controls.Add(Me.btnDept)
        Me.Controls.Add(Me.txtKodeDept)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.btnAddD)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtTugasDeskripsi)
        Me.Controls.Add(Me.txtKodeTugas)
        Me.Controls.Add(Me.btnTugas)
        Me.Controls.Add(Me.btnDeleteD)
        Me.Controls.Add(Me.btnSaveD)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.txtTemplateDeskripsi)
        Me.Controls.Add(Me.dtpDate)
        Me.Controls.Add(Me.txtKodeTemplateTugas)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmTemplateTugas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Template Tugas"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAddD As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtTugasDeskripsi As System.Windows.Forms.TextBox
    Friend WithEvents txtKodeTugas As System.Windows.Forms.TextBox
    Friend WithEvents btnTugas As System.Windows.Forms.Button
    Friend WithEvents btnDeleteD As System.Windows.Forms.Button
    Friend WithEvents btnSaveD As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents txtTemplateDeskripsi As System.Windows.Forms.TextBox
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtKodeTemplateTugas As System.Windows.Forms.TextBox
    Friend WithEvents bankadjno As System.Windows.Forms.TextBox
    Friend WithEvents btnDept As System.Windows.Forms.Button
    Friend WithEvents txtKodeDept As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents btnTemplate As System.Windows.Forms.Button
    Friend WithEvents btnFilter As System.Windows.Forms.Button
End Class
