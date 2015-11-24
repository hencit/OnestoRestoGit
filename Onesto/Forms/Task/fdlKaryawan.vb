Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Odbc

Public Class fdlKaryawan
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim sqlReader As SqlDataReader
    Dim m_FrmCallerId As String

    Dim strConnection2 As String = My.Settings.ConnStr2
    Dim cn2 As New OdbcConnection(strConnection2)
    Dim strSQL As String
    Dim comm As OdbcCommand
    Dim myReader As OdbcDataReader

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
            MessageBox.Show("Silahkan pilih karyawan terlebih dahulu!", Me.Text)
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        'Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub fdlKaryawan_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("ID", 50)
            .Columns.Add("Nama Karyawan", 150)
            '.Columns.Add("Jabatan Name", 200)
        End With

        strSQL = "SELECT ID,[DESC] FROM im_karyawan "

        cn.Open()
        cmd = New SqlCommand(strSQL, cn)
        sqlReader = cmd.ExecuteReader()

        Dim lvItem As ListViewItem
        Dim intCurrRow As Integer

        While sqlReader.Read
            lvItem = New ListViewItem(CStr(sqlReader.Item(0)))
            lvItem.Tag = intCurrRow 'ID
            lvItem.SubItems.Add(sqlReader.Item(1))

            If intCurrRow Mod 2 = 0 Then
                lvItem.BackColor = Color.Lavender
            Else
                lvItem.BackColor = Color.White
            End If
            lvItem.UseItemStyleForSubItems = True

            ListView1.Items.Add(lvItem)
            intCurrRow += 1
        End While

        sqlReader.Close()
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
            Case "frmDelegasiTugas"
                With frmDelegasiTugas
                    .KodeKaryawan = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                    .NamaKaryawan = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                End With
            Case "rptGaji"
                With rptGaji
                    .KodeKaryawan = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "rptTugas"
                With rptTugas
                    .KodeKaryawan = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
        End Select
        Me.Close()
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            fdlKaryawan_Load(sender, e)
        End If
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ListView1Sorter = New lvColumnSorter()
        ListView1.ListViewItemSorter = ListView1Sorter
    End Sub
End Class