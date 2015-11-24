Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class fdlMenu
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_FrmCallerId As String

    Public Property FrmCallerId() As String
        Get
            Return m_FrmCallerId
        End Get
        Set(ByVal Value As String)
            m_FrmCallerId = Value
        End Set
    End Property
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        'Me.DialogResult = System.Windows.Forms.DialogResult.OK
        'Me.Close()
        If ListView1.SelectedItems.Count > 0 Then
            ListView1_DoubleClick(sender, e)
        Else
            MessageBox.Show("Silahkan pilih departemen terlebih dahulu", Me.Text)
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        'Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub fdlMenu_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Add item cmbPRStatus
        cmd = New SqlCommand("select menu_category_code from mt_menu_category where active = 1", cn)

        cn.Open()
        Dim myReader = cmd.ExecuteReader

        cbKategori.Items.Add("Semua")
        While myReader.Read
            cbKategori.Items.Add(myReader.GetString(0))
        End While

        myReader.Close()
        cn.Close()

        cbKategori.SelectedIndex = 0

        clear_lvw()
    End Sub

    Sub clear_lvw()
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Kode Menu", 150)
            .Columns.Add("Nama", 200)
            .Columns.Add("Kategori", 100)
            .Columns.Add("Satuan", 80)
            .Columns.Add("Harga Satuan", 200, HorizontalAlignment.Right)
        End With

        cmd = New SqlCommand("sp_mt_menu_list_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@menu_name", SqlDbType.NVarChar, 100)
        prm1.Value = IIf(txtFilter.Text = "", DBNull.Value, txtFilter.Text)
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@menu_category_code", SqlDbType.NVarChar, 20)
        prm2.Value = IIf(cbKategori.SelectedIndex = 0, DBNull.Value, cbKategori.SelectedItem.ToString)


        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        Dim lvItem As ListViewItem
        Dim intCurrRow As Integer

        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(0)))
            lvItem.Tag = intCurrRow 'ID

            For i = 1 To 3
                lvItem.SubItems.Add(myReader.Item(i))
            Next

            lvItem.SubItems.Add(FormatNumber(myReader.Item(4), 0))

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
        txtFilter.Focus()
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
        Select Case m_FrmCallerId
            Case "frmPOS"
                With frmPOS
                    Dim m_Qty, m_HargaSatuan, m_Disc As Integer
                    .MenuCode = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                    .Deskripsi = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                    .Qty = 1
                    m_Qty = 1
                    .Satuan = ListView1.SelectedItems.Item(0).SubItems.Item(3).Text
                    .HargaSatuan = FormatNumber(ListView1.SelectedItems.Item(0).SubItems.Item(4).Text, 0)
                    m_HargaSatuan = CInt(ListView1.SelectedItems.Item(0).SubItems.Item(4).Text)
                    .Disc = 0
                    m_Disc = CInt("0")
                    .m_SubTotalDtl = FormatNumber(CStr((m_Qty * m_HargaSatuan) - ((m_Qty * m_HargaSatuan) * (m_Disc / 100))), 0)

                    If ListView1.SelectedItems.Item(0).SubItems.Item(2).Text = "JASA" Then
                        .Type = 1
                    Else
                        .Type = 0
                    End If

                End With
        End Select
        Me.Close()

        '.Columns.Add("Kode Menu", 150)0
        '.Columns.Add("Nama", 200)1
        '.Columns.Add("Kategori", 100)2
        '.Columns.Add("Satuan", 80)3
        '.Columns.Add("Harga Satuan", 200, HorizontalAlignment.Right)4
        '.Columns.Add("Diskon", 50)5
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            fdlMenu_Load(sender, e)
        End If
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ListView1Sorter = New lvColumnSorter()
        ListView1.ListViewItemSorter = ListView1Sorter
    End Sub

    Private Sub cbKategori_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbKategori.SelectedIndexChanged
        clear_lvw()
    End Sub


    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        clear_lvw()
    End Sub
End Class