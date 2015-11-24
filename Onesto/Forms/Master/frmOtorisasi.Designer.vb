<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOtorisasi
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOtorisasi))
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.btnAddD = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtDetail = New System.Windows.Forms.TextBox()
        Me.txtCategory = New System.Windows.Forms.TextBox()
        Me.btnRole = New System.Windows.Forms.Button()
        Me.btnDeleteD = New System.Windows.Forms.Button()
        Me.btnSaveD = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.txtUserCode = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnFilter
        '
        Me.btnFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnFilter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFilter.ImageIndex = 0
        Me.btnFilter.Location = New System.Drawing.Point(14, 476)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(29, 25)
        Me.btnFilter.TabIndex = 277
        Me.btnFilter.Text = "..."
        Me.btnFilter.UseVisualStyleBackColor = True
        Me.btnFilter.Visible = False
        '
        'btnAddD
        '
        Me.btnAddD.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddD.ImageIndex = 1
        Me.btnAddD.ImageList = Me.ImageList1
        Me.btnAddD.Location = New System.Drawing.Point(745, 53)
        Me.btnAddD.Name = "btnAddD"
        Me.btnAddD.Size = New System.Drawing.Size(29, 25)
        Me.btnAddD.TabIndex = 262
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
        Me.Label19.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(46, 40)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(34, 13)
        Me.Label19.TabIndex = 275
        Me.Label19.Text = "Detail"
        '
        'Label18
        '
        Me.Label18.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(478, 40)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(49, 13)
        Me.Label18.TabIndex = 274
        Me.Label18.Text = "Category"
        '
        'txtDetail
        '
        Me.txtDetail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDetail.Location = New System.Drawing.Point(46, 56)
        Me.txtDetail.MaxLength = 100
        Me.txtDetail.Name = "txtDetail"
        Me.txtDetail.ReadOnly = True
        Me.txtDetail.Size = New System.Drawing.Size(429, 20)
        Me.txtDetail.TabIndex = 258
        '
        'txtCategory
        '
        Me.txtCategory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCategory.Location = New System.Drawing.Point(481, 56)
        Me.txtCategory.MaxLength = 50
        Me.txtCategory.Name = "txtCategory"
        Me.txtCategory.ReadOnly = True
        Me.txtCategory.Size = New System.Drawing.Size(198, 20)
        Me.txtCategory.TabIndex = 270
        '
        'btnRole
        '
        Me.btnRole.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRole.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRole.ImageIndex = 0
        Me.btnRole.ImageList = Me.ImageList1
        Me.btnRole.Location = New System.Drawing.Point(11, 53)
        Me.btnRole.Name = "btnRole"
        Me.btnRole.Size = New System.Drawing.Size(29, 25)
        Me.btnRole.TabIndex = 257
        Me.btnRole.UseVisualStyleBackColor = True
        '
        'btnDeleteD
        '
        Me.btnDeleteD.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteD.ImageIndex = 3
        Me.btnDeleteD.ImageList = Me.ImageList1
        Me.btnDeleteD.Location = New System.Drawing.Point(715, 53)
        Me.btnDeleteD.Name = "btnDeleteD"
        Me.btnDeleteD.Size = New System.Drawing.Size(29, 25)
        Me.btnDeleteD.TabIndex = 261
        Me.btnDeleteD.UseVisualStyleBackColor = True
        '
        'btnSaveD
        '
        Me.btnSaveD.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveD.ImageIndex = 2
        Me.btnSaveD.ImageList = Me.ImageList1
        Me.btnSaveD.Location = New System.Drawing.Point(685, 53)
        Me.btnSaveD.Name = "btnSaveD"
        Me.btnSaveD.Size = New System.Drawing.Size(29, 25)
        Me.btnSaveD.TabIndex = 259
        Me.btnSaveD.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(14, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 13)
        Me.Label6.TabIndex = 271
        Me.Label6.Text = "Kode User*"
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(14, 84)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(762, 386)
        Me.ListView1.TabIndex = 260
        Me.ListView1.TabStop = False
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.List
        '
        'txtUserCode
        '
        Me.txtUserCode.Location = New System.Drawing.Point(91, 9)
        Me.txtUserCode.MaxLength = 50
        Me.txtUserCode.Name = "txtUserCode"
        Me.txtUserCode.ReadOnly = True
        Me.txtUserCode.Size = New System.Drawing.Size(266, 20)
        Me.txtUserCode.TabIndex = 252
        '
        'frmOtorisasi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(795, 510)
        Me.Controls.Add(Me.btnFilter)
        Me.Controls.Add(Me.btnAddD)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtDetail)
        Me.Controls.Add(Me.txtCategory)
        Me.Controls.Add(Me.btnRole)
        Me.Controls.Add(Me.btnDeleteD)
        Me.Controls.Add(Me.btnSaveD)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.txtUserCode)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmOtorisasi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Otorisasi User"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnFilter As System.Windows.Forms.Button
    Friend WithEvents btnAddD As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtDetail As System.Windows.Forms.TextBox
    Friend WithEvents txtCategory As System.Windows.Forms.TextBox
    Friend WithEvents btnRole As System.Windows.Forms.Button
    Friend WithEvents btnDeleteD As System.Windows.Forms.Button
    Friend WithEvents btnSaveD As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents txtUserCode As System.Windows.Forms.TextBox
End Class
