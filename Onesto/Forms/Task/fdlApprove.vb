Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO
Public Class fdlApprove
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand

    Dim val1, val2 As String

    Private Sub fdlApprove_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        view_record()
    End Sub

    Public Property m_TugasNo() As String
        Get
            Return txtNoTugas.Text
        End Get
        Set(ByVal Value As String)
            txtNoTugas.Text = Value
        End Set
    End Property

    Sub view_record()
        'a.tugas_no,0
        'a.tugas_code,1
        'a.tugas_description,2
        'a.tugas_date,3
        'a.karyawan_code,4
        'a.karyawan_name,5
        'a.dept_code,6
        'a.tugas_status,7
        'a.ref_no,8
        'a.effective_date_from,9
        'a.effective_date_to,10
        'a.due_date,11
        'a.link_before,12
        'a.link_after1,13
        'a.link_after2,14
        'a.repeater,15
        'a.finish_flag,16
        'a.finish_percent,17
        'a.finish_date,18
        'a.finish_notes,19
        'a.approve1_flag,20
        'a.approve1_percent,21
        'a.approve1_date,22
        'a.approve1_notes,23
        'a.approve2_flag,24
        'a.approve2_percent,25
        'a.approve2_date,26
        'a.approve2_notes,27
        'a.submit,28
        'b.link_standard,29
        'b.val_before,30
        'b.val_after1,31
        'b.val_after2,32
        Try
            cmd = New SqlCommand("sp_tr_tugas_SEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@tugas_no", SqlDbType.NVarChar, 50)
            prm1.Value = txtNoTugas.Text

            cn.Open()

            Dim myReader As SqlDataReader = cmd.ExecuteReader()

            While myReader.Read
                txtTugasStatus.Text = myReader.GetString(7)

                'Approve 1
                cbApprove1.Checked = myReader.GetBoolean(20)

                txtApprove1Persentase.Text = CStr(myReader.GetInt32(21))
                If myReader.IsDBNull(myReader.GetOrdinal("approve1_date")) Then
                    dtpApprove1.Value = System.DateTime.Now
                Else
                    dtpApprove1.Value = myReader.GetDateTime(22)
                End If
                txtApprove1Notes.Text = myReader.GetString(23)

                'Approve 2
                cbApprove2.Checked = myReader.GetBoolean(24)
                txtApprove2Persentase.Text = CStr(myReader.GetInt32(25))
                If myReader.IsDBNull(myReader.GetOrdinal("approve2_date")) Then
                    dtpApprove2.Value = System.DateTime.Now
                Else
                    dtpApprove2.Value = myReader.GetDateTime(26)
                End If
                txtApprove2Notes.Text = myReader.GetString(27)


            End While

            myReader.Close()
            cn.Close()

            lock_obj()
        Catch ex As Exception
            If ConnectionState.Open = True Then cn.Close()
            MsgBox("Error code: " + ex.Message)
        End Try
    End Sub

    Sub lock_obj()
        If txtTugasStatus.Text = "Selesai" Then
            gbApprove1.Enabled = True
            gbApprove2.Enabled = False
        ElseIf txtTugasStatus.Text = "Approve1" Then
            gbApprove1.Enabled = False
            gbApprove2.Enabled = True
        Else
            gbApprove1.Enabled = False
            gbApprove2.Enabled = False
        End If
    End Sub

    Private Sub btnApprove1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprove1.Click
        val1 = "tr_tugas_"
        val2 = "approve1"
        If otorisasi(val1 + val2) = False Then
            MsgBox("Anda tidak mempunyai otorisasi " + val2 + " modul ini!,Silahkan hubungi administrator anda untuk diberikan otorisasi", vbCritical)
            Exit Sub
        End If

        If CInt(txtApprove1Persentase.Text) = 0 Then
            MsgBox("Approval Persentase tugas tidak boleh kosong!", vbCritical + vbOKOnly, Me.Text)
            txtApprove1Persentase.Focus()
            Exit Sub
        End If

        dtpApprove1.CustomFormat = "yyyy-MM-dd HH:mm:ss"

        If MsgBox("Anda yakin approve tugas ini?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            Try
                cmd = New SqlCommand("sp_tr_tugas_APPROVE1", cn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim prm1 As SqlParameter = cmd.Parameters.Add("@tugas_no", SqlDbType.Int)
                prm1.Value = CInt(txtNoTugas.Text)
                Dim prm12 As SqlParameter = cmd.Parameters.Add("@approve1_flag", SqlDbType.Bit)
                prm12.Value = True
                Dim prm3 As SqlParameter = cmd.Parameters.Add("@approve1_percent", SqlDbType.Int)
                prm3.Value = CInt(txtApprove1Persentase.Text)
                Dim prm4 As SqlParameter = cmd.Parameters.Add("@approve1_date", SqlDbType.NVarChar, 30)
                prm4.Value = dtpApprove1.Text
                Dim prm8 As SqlParameter = cmd.Parameters.Add("@tugas_status", SqlDbType.NVarChar, 25)
                prm8.Value = "Approve1"
                Dim prm9 As SqlParameter = cmd.Parameters.Add("@approve1_notes", SqlDbType.NVarChar, 255)
                prm9.Value = txtApprove1Notes.Text

                Dim prm22 As SqlParameter = cmd.Parameters.Add("@user_code", SqlDbType.NVarChar, 50)
                prm22.Value = My.Settings.UserName

                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()

                view_record()
                lock_obj()
            Catch ex As Exception
                If ConnectionState.Open = True Then cn.Close()
                MsgBox(ex.Message)
            End Try
        End If

        dtpApprove1.CustomFormat = "dd-MM-yyyy HH:mm:ss"
        autoRefresh()
    End Sub

    Private Sub btnApprove2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprove2.Click
        val1 = "tr_tugas_"
        val2 = "approve2"
        If otorisasi(val1 + val2) = False Then
            MsgBox("Anda tidak mempunyai otorisasi " + val2 + " modul ini!,Silahkan hubungi administrator anda untuk diberikan otorisasi", vbCritical)
            Exit Sub
        End If

        If CInt(txtApprove2Persentase.Text) = 0 Then
            MsgBox("Approval Persentase tugas tidak boleh kosong!", vbCritical + vbOKOnly, Me.Text)
            txtApprove2Persentase.Focus()
            Exit Sub
        End If

        dtpApprove2.CustomFormat = "yyyy-MM-dd HH:mm:ss"

        If MsgBox("Anda yakin approve tugas ini?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            Try
                cmd = New SqlCommand("sp_tr_tugas_approve2", cn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim prm1 As SqlParameter = cmd.Parameters.Add("@tugas_no", SqlDbType.Int)
                prm1.Value = CInt(txtNoTugas.Text)
                Dim prm12 As SqlParameter = cmd.Parameters.Add("@approve2_flag", SqlDbType.Bit)
                prm12.Value = True
                Dim prm3 As SqlParameter = cmd.Parameters.Add("@approve2_percent", SqlDbType.Int)
                prm3.Value = CInt(txtApprove2Persentase.Text)
                Dim prm4 As SqlParameter = cmd.Parameters.Add("@approve2_date", SqlDbType.NVarChar, 30)
                prm4.Value = dtpApprove2.Text
                Dim prm8 As SqlParameter = cmd.Parameters.Add("@tugas_status", SqlDbType.NVarChar, 25)
                prm8.Value = "Complete"
                Dim prm9 As SqlParameter = cmd.Parameters.Add("@approve2_notes", SqlDbType.NVarChar, 255)
                prm9.Value = txtApprove2Notes.Text

                Dim prm22 As SqlParameter = cmd.Parameters.Add("@user_code", SqlDbType.NVarChar, 50)
                prm22.Value = My.Settings.UserName

                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()

                view_record()
                lock_obj()

            Catch ex As Exception
                If ConnectionState.Open = True Then cn.Close()
                MsgBox(ex.Message)
            End Try
        End If

        dtpApprove2.CustomFormat = "dd-MM-yyyy HH:mm:ss"
        autoRefresh()
    End Sub

    Sub autoRefresh()
        If Application.OpenForms().OfType(Of frmDelegasiTugasList).Any Then
            Call frmDelegasiTugasList.frmDelegasiTugasListShow(Nothing, EventArgs.Empty)
        End If

        If Application.OpenForms().OfType(Of frmDelegasiTugas).Any Then
            Call frmDelegasiTugas.frmKasihTugasRefresh(Nothing, EventArgs.Empty)
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class