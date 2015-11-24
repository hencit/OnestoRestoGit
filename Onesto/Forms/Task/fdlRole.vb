Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class fdlRole
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_FrmCallerId As String
    Dim m_user_code, m_role_code As String
    Dim val1, val2 As String

    Public Property FrmCallerId() As String
        Get
            Return m_FrmCallerId
        End Get
        Set(ByVal Value As String)
            m_FrmCallerId = Value
        End Set
    End Property

    Public Property UserCode() As String
        Get
            Return m_user_code
        End Get
        Set(ByVal Value As String)
            m_user_code = Value
        End Set
    End Property
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        val1 = "mt_otorisasi_"
        val2 = "simpan"
        If otorisasi(val1 + val2) = False Then
            MsgBox("Anda tidak mempunyai otorisasi " + val2 + " modul ini!,Silahkan hubungi administrator anda untuk diberikan otorisasi", vbCritical)
            Exit Sub
        End If

        If ListView1.CheckedItems.Count > 0 Then
            Try
                For i = 1 To ListView1.Items.Count
                    If ListView1.Items(i - 1).Checked = True Then
                        m_role_code = ListView1.Items(i - 1).SubItems.Item(0).Text

                        cmd = New SqlCommand("sp_mt_user_otorisasi_dtl_INS", cn)
                        cmd.CommandType = CommandType.StoredProcedure

                        Dim prm11 As SqlParameter = cmd.Parameters.Add("@user_code", SqlDbType.NVarChar, 50)
                        prm11.Value = m_user_code
                        Dim prm12 As SqlParameter = cmd.Parameters.Add("@role_code", SqlDbType.NVarChar, 50)
                        prm12.Value = m_role_code
                        Dim prm14 As SqlParameter = cmd.Parameters.Add("@row_count", SqlDbType.Int)
                        prm14.Direction = ParameterDirection.Output

                        cn.Open()
                        cmd.ExecuteReader()
                        cn.Close()
                    End If
                Next
            Catch ex As Exception
                MsgBox("Error Message: " + ex.Message)
                If ConnectionState.Open = True Then cn.Close()
            End Try
            autoRefresh()
            Me.Close()
        Else
            MessageBox.Show("Silahkan pilih detail terlebih dahulu!", Me.Text)
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        'Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub fdlRole_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("", 20)
            .Columns.Add("Deskripsi", 300)
            .Columns.Add("Kategori", 200)
        End With
       
        cmd = New SqlCommand("sp_mt_role_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm2 As SqlParameter = cmd.Parameters.Add("@role_description", SqlDbType.NVarChar, 50)
        prm2.Value = IIf(txtDeskripsi.Text = "", DBNull.Value, txtDeskripsi.Text)
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@role_category", SqlDbType.NVarChar, 50)
        prm3.Value = IIf(txtKategori.Text = "", DBNull.Value, txtKategori.Text)

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        Dim lvItem As ListViewItem
        Dim intCurrRow As Integer

        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(0)))
            lvItem.Tag = intCurrRow 'ID

            lvItem.SubItems.Add(myReader.Item(1))
            lvItem.SubItems.Add(myReader.Item(2))

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
        'Select Case m_FrmCallerId
        '    Case "frmOtorisasi"
        '        With frmOtorisasi
        '            .RoleCode = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
        '            .Detail = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
        '            .Category = ListView1.SelectedItems.Item(0).SubItems.Item(2).Text
        '        End With
        'End Select
        'Me.Close()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ListView1Sorter = New lvColumnSorter()
        ListView1.ListViewItemSorter = ListView1Sorter
    End Sub

    Private Sub txtKategori_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKategori.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            fdlRole_Load(sender, e)
        End If
    End Sub

    Private Sub txtDeskripsi_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDeskripsi.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            fdlRole_Load(sender, e)
        End If
    End Sub

    'Set autorefresh list---hendra
    Sub autoRefresh()
        If Application.OpenForms().OfType(Of frmOtorisasi).Any Then
            Call frmOtorisasi.frmOtorisasiRefresh(Nothing, EventArgs.Empty)
        End If
    End Sub

    Private Sub chbSelectAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbSelectAll.CheckedChanged
        If chbSelectAll.Checked = True Then
            With ListView1
                For i = 1 To .Items.Count
                    .Items.Item(i - 1).Checked = True
                Next
            End With
        Else
            With ListView1
                For i = 1 To .Items.Count
                    .Items.Item(i - 1).Checked = False
                Next
            End With
        End If
    End Sub
End Class