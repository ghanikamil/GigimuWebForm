Imports Gigimu.BLL
Imports GigimuDTO

Public Class Register
    Inherits System.Web.UI.Page

#Region "Initialize"
    Sub InitializeFormAddArticle()
        txtNama.Text = String.Empty
        txtAlamat.Text = String.Empty
        txtTelepon.Text = String.Empty
        txtEmail.Text = String.Empty
        txtPassword.Text = String.Empty
    End Sub
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnRegistration_Click(sender As Object, e As EventArgs)
        Try
            Dim _pasienBLL As New PasienBLL()
            Dim _pasienDTO As New AddPasienDTO
            _pasienDTO.Nama = txtNama.Text
            _pasienDTO.Alamat = txtAlamat.Text
            _pasienDTO.Telepon = txtTelepon.Text
            _pasienDTO.Email = txtEmail.Text
            _pasienDTO.Password = txtPassword.Text
            _pasienDTO.Repassword = txtRepassword.Text
            _pasienBLL.Insert(_pasienDTO)
            ltMessage.Text = "<span class='alert alert-success'>User Registration Success</span><br/><br/>"
            InitializeFormAddArticle()
        Catch ex As Exception
            ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span><br/><br/>"
        End Try
    End Sub
End Class