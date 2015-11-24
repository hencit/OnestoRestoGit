Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class fdlTable
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_FrmCallerId, m_TableCode_before As String

    Public Property FrmCallerId() As String
        Get
            Return m_FrmCallerId
        End Get
        Set(ByVal Value As String)
            m_FrmCallerId = Value
        End Set
    End Property

    Public Property TableCode() As String
        Get
            Return m_TableCode_before
        End Get
        Set(ByVal Value As String)
            m_TableCode_before = Value
        End Set
    End Property
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        'Me.DialogResult = System.Windows.Forms.DialogResult.OK
        'Me.Close()
        If ListView1.SelectedItems.Count > 0 Then
            ListView1_DoubleClick(sender, e)
        Else
            MessageBox.Show("Silahkan pilih meja terlebih dahulu", Me.Text)
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        'Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub fdlTable_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("MEJA", 700)
        End With

        'cmd = New SqlCommand("select table_code from mt_table where table_status = 'OPEN' and active = 1 AND table_code <> 'TAKE-AWAY' ", cn)
        cmd = New SqlCommand("sp_mt_table_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        Dim lvItem As ListViewItem
        Dim intCurrRow As Integer

        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(0)))
            lvItem.Tag = intCurrRow 'ID
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
            Case "frmPOS"
                With frmPOS
                    .TableCode = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With

                autosaveHeader()
                tableStatus(ListView1.SelectedItems.Item(0).SubItems.Item(0).Text, m_TableCode_before)
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
    Sub autosaveHeader()
        If Application.OpenForms().OfType(Of frmPOS).Any Then
            Call frmPOS.frmPOSAutosaveHeader(Nothing, EventArgs.Empty)
        End If
    End Sub

    Sub tableStatus(ByVal TableCode As String, ByVal TableCodeBefore As String)
        Try
            cmd = New SqlCommand("sp_mt_table_STATUS", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@table_code", SqlDbType.NVarChar, 20)
            prm1.Value = TableCode
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@table_code_before", SqlDbType.NVarChar, 20)
            prm2.Value = IIf(TableCodeBefore <> "", TableCodeBefore, DBNull.Value)

            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            MsgBox("Error Message tableStatus() : " + ex.Message)
            If ConnectionState.Open = True Then cn.Close()
        End Try
    End Sub
End Class