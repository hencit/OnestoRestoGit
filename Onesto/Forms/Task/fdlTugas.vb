Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class fdlTugas
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
            MessageBox.Show("Silahkan pilih tugas terlebih dahulu!", Me.Text)
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        'Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub fdlTugas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Kode Tugas", 150)
            .Columns.Add("Tugas Deskripsi", 200)
            .Columns.Add("Kode Dept.", 150)
            .Columns.Add("Repeater", 100)
            .Columns.Add("link_standard", 0)
            .Columns.Add("val_before", 80)
            .Columns.Add("val_after1", 80)
            .Columns.Add("val_after2", 80)

        End With

        cmd = New SqlCommand("sp_mt_tugas_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm2 As SqlParameter = cmd.Parameters.Add("@tugas_description", SqlDbType.NVarChar, 50)
        prm2.Value = IIf(txtTugas.Text = "", DBNull.Value, txtTugas.Text)
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@dept_code", SqlDbType.NVarChar, 50)
        prm3.Value = IIf(txtDept.Text = "", DBNull.Value, txtDept.Text)

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        Dim lvItem As ListViewItem
        Dim intCurrRow As Integer

        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(0)))
            lvItem.Tag = intCurrRow 'ID

            lvItem.SubItems.Add(myReader.Item(1))
            lvItem.SubItems.Add(myReader.Item(2))
            lvItem.SubItems.Add(myReader.Item(3))

            If myReader.IsDBNull(myReader.GetOrdinal("link_standard")) Then
                lvItem.SubItems.Add("")
            Else
                lvItem.SubItems.Add(myReader.Item(4))
            End If
            lvItem.SubItems.Add(myReader.Item(5))
            lvItem.SubItems.Add(myReader.Item(6))
            lvItem.SubItems.Add(myReader.Item(7))
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
        Select Case m_FrmCallerId
            Case "frmTugas"
                With frmTugas
                    .TugasCode = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                    .m_Flag = 1
                End With
                autoRefreshMasterTugas()
            Case "frmTemplateTugas"
                With frmTemplateTugas
                    .TugasCode = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                    .TugasDeskripsi = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                End With
            Case "frmDelegasiTugas"
                With frmDelegasiTugas
                    .TugasCode = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                    .TugasDeskripsi = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                    .DeptCode = ListView1.SelectedItems.Item(0).SubItems.Item(2).Text
                    .Repeater = ListView1.SelectedItems.Item(0).SubItems.Item(3).Text
                    .LinkStandard = ListView1.SelectedItems.Item(0).SubItems.Item(4).Text
                    .ValBefore = ListView1.SelectedItems.Item(0).SubItems.Item(5).Text
                    .ValAfter1 = ListView1.SelectedItems.Item(0).SubItems.Item(6).Text
                    .ValAfter2 = ListView1.SelectedItems.Item(0).SubItems.Item(7).Text
                    autoShowDelegasiTugas()
                End With
                'tugas_code,0
                'tugas_description,1
                'dept_code,2
                'repeater,3
                'link_standard,4
                'val_before,5
                'val_after1,6
                'val_after2,7
        End Select
        Me.Close()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ListView1Sorter = New lvColumnSorter()
        ListView1.ListViewItemSorter = ListView1Sorter
    End Sub

    'Set autorefresh list---hendra
    Sub autoRefreshMasterTugas()
        If Application.OpenForms().OfType(Of frmTugas).Any Then
            Call frmTugas.frmTugasRefresh(Nothing, EventArgs.Empty)
        End If
    End Sub

    'Set autorefresh list---hendra
    Sub autoShowDelegasiTugas()
        If Application.OpenForms().OfType(Of frmDelegasiTugas).Any Then
            Call frmDelegasiTugas.frmDelegasiTugasShow(Nothing, EventArgs.Empty)
        End If
    End Sub

    Private Sub txtDept_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDept.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            fdlTugas_Load(sender, e)
        End If
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTugas.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            fdlTugas_Load(sender, e)
        End If
    End Sub

End Class