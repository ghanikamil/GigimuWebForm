Imports GigimuDTO

Public Class _Default
    Inherits Page

    Dim _dokterBLL As New Gigimu.BLL.DokterBLL
#Region "Binding Data"
    Sub LoadDataDokters()
        Dim results = _dokterBLL.GetAll()
        lvDokter.DataSource = results
        lvDokter.DataBind()
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim _user = CType(Session("User"), PasienDTO)
        'txtPasienID.Text = _user.PasienID
        'txtNama.Text = _user.Nama
        'txtAlamat.Text = _user.Alamat
        'txtTelepon.Text = _user.Telepon
        'txtEmail.Text = _user.Email
        LoadDataDokters()
    End Sub

    'Protected Sub btnPilih_Click(sender As Object, e As EventArgs)
    '    Dim results = _dokterBLL.GetAll()
    '    Dim id As Integer = CInt(DirectCast(results.FindControl("DokterID"), Label).Text) ' Replace with your actual ID value
    '    Response.Redirect("~/PilihJadwal.aspx?id=" & id.ToString())
    'End Sub

    Protected Sub lvDokter_ItemCommand(sender As Object, e As ListViewCommandEventArgs)
        'If e.CommandName = "pilihBtn" Then
        Dim id As Integer = CInt(DirectCast(e.Item.FindControl("DokterID"), Label).Text)
        Response.Redirect("~/PilihJadwal.aspx?id=" & id.ToString())
        'End If
    End Sub
End Class