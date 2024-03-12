Imports GigimuDTO

Public Class ListDokter
    Inherits System.Web.UI.Page

#Region "Binding Data"
    Sub LoadDataDokters()
        Dim _dokterBLL As New Gigimu.BLL.DokterBLL
        Dim results = _dokterBLL.GetAll()
        lvDokter.DataSource = results
        lvDokter.DataBind()
    End Sub
#End Region
#Region "Initialize"
    Sub InitializeFormAddArticle()
        txtNama.Text = String.Empty
        txtEmail.Text = String.Empty
        txtPassword.Text = String.Empty
    End Sub
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LoadDataDokters()
        End If
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs)
        Try
            Dim _dokterBLL As New Gigimu.BLL.DokterBLL
            Dim _dokter As New AddDokterDTO
            _dokter.Nama = txtNama.Text
            _dokter.Spesialis = ddDokterSpesialis.SelectedValue
            _dokter.Email = txtEmail.Text
            _dokter.Password = txtPassword.Text
            _dokterBLL.Insert(_dokter)
            ltMessage.Text = "<span class='alert alert-success'>Dokter " & txtNama.Text & " added successfully</span><br/><br/>"
            InitializeFormAddArticle()
            LoadDataDokters()
        Catch ex As Exception
            ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span><br/><br/>"
        End Try
    End Sub
End Class