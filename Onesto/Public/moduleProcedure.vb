Imports System.Data.SqlClient
Imports System.Data.OleDb

Module moduleProcedure
    Public str_user_name As String
    Public str_user_access As String
    Public p_Group As String
    Public p_CompanyName As String

    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand

    Public Sub UpdSysNumber(ByVal transType As String)
        cmd = New SqlCommand("sp_sys_autonumber_RUN", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@trans_type", SqlDbType.NVarChar, 20)
        prm1.Value = transType

        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub
End Module
