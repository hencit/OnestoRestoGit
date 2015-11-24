Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System
Imports System.Security.Cryptography
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging

Module ModuleFunction
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand

    Public Function ResizeImage(ByVal image As Image, ByVal size As Size, Optional ByVal preserveAspectRatio As Boolean = True) As Image
        Dim newWidth As Integer
        Dim newHeight As Integer
        If preserveAspectRatio Then
            Dim originalWidth As Integer = image.Width
            Dim originalHeight As Integer = image.Height
            Dim percentWidth As Single = CSng(size.Width) / CSng(originalWidth)
            Dim percentHeight As Single = CSng(size.Height) / CSng(originalHeight)
            Dim percent As Single = If(percentHeight < percentWidth,
        percentHeight, percentWidth)
            newWidth = CInt(originalWidth * percent)
            newHeight = CInt(originalHeight * percent)
        Else
            newWidth = size.Width
            newHeight = size.Height
        End If
        Dim newImage As Image = New Bitmap(newWidth, newHeight)
        Using graphicsHandle As Graphics = Graphics.FromImage(newImage)
            graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic
            graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight)
        End Using
        Return newImage
    End Function

    Function canDelete(ByVal form_name As String) As Boolean
        'Dim formDelete As Boolean
        'Try
        '    cmd = New SqlCommand("usp_mt_user_access_SEL", cn)
        '    cmd.CommandType = CommandType.StoredProcedure

        '    Dim prm1 As SqlParameter = cmd.Parameters.Add("@user_level_id", SqlDbType.Int, 50)
        '    prm1.Value = p_Role
        '    Dim prm2 As SqlParameter = cmd.Parameters.Add("@form_name", SqlDbType.NVarChar, 50)
        '    prm2.Value = form_name

        '    cn.Open()
        '    Dim myReader As SqlDataReader = cmd.ExecuteReader()
        '    While myReader.Read
        '        formDelete = myReader.GetBoolean(4)
        '    End While
        '    myReader.Close()
        '    cn.Close()
        '    If formDelete = True Then
        '        Return True
        '    Else
        '        Return False
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        '    If ConnectionState.Open = 1 Then cn.Close()
        '    Return False
        'End Try
    End Function

    Function GetSysInit(ByVal code As String) As String
        GetSysInit = ""
        cmd = New SqlCommand("select code,value from sys_init where code = '" + code + "' ", cn)

        cn.Open()
        Dim myReader As SqlDataReader = cmd.ExecuteReader()
        While myReader.Read()
            GetSysInit = myReader.GetString(1)
        End While
        myReader.Close()
        cn.Close()
    End Function

    'Function form_validation(ByVal action As String, ByVal form_code As String) As Boolean
    '    Dim validate As Boolean
    '    cmd = New SqlCommand("select top 1 " + action + " from mt_group_dtl where form_code = '" + form_code + "' ", cn)
    '    cn.Open()
    '    Dim myReader As SqlDataReader = cmd.ExecuteReader()
    '    While myReader.Read()
    '        validate = myReader.GetBoolean(0)
    '    End While
    '    myReader.Close()
    '    cn.Close()

    '    If validate = True Then
    '        Return True
    '    Else
    '        Return False
    '    End If
    'End Function

    Function otorisasi(ByVal role_code As String) As Boolean
        Dim validate As Boolean
        Dim user_code As String = My.Settings.UserName
        cmd = New SqlCommand("SELECT TOP 1 * FROM mt_user_otorisasi_dtl WHERE role_code = '" + role_code + "' AND user_code = '" + user_code + "' ", cn)
        cn.Open()
        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        If myReader.HasRows Then
            validate = True
        Else
            validate = False
        End If

        myReader.Close()
        cn.Close()

        If validate = True Then
            Return True
        Else
            Return False
        End If
    End Function

    Function GetSysNumber(ByVal transType As String) As String
        Dim trans_code, year, month, running_no As String

        GetSysNumber = ""
        cmd = New SqlCommand("sp_sys_autonumber_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@trans_type", SqlDbType.NVarChar, 20)
        prm1.Value = transType

        cn.Open()
        Dim myReader As SqlDataReader = cmd.ExecuteReader()
        While myReader.Read()
            trans_code = myReader.GetString(0)
            year = myReader.GetString(1)
            month = myReader.GetString(2)
            running_no = CStr(myReader.GetInt32(4))

            For i = 1 To myReader.GetInt32(3)
                If Len(running_no) < myReader.GetInt32(3) Then
                    running_no = "0" + running_no
                End If
            Next i

            If myReader.GetBoolean(5) = True Then 'with month
                GetSysNumber = trans_code + year + month + running_no
            Else
                GetSysNumber = trans_code + year + running_no
            End If

        End While
        myReader.Close()
        cn.Close()

        UpdSysNumber(transType)
    End Function
End Module
