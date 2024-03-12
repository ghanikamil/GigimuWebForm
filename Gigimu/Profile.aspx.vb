Imports Gigimu.BLL
Imports GigimuDTO

Public Class Profile
    Inherits System.Web.UI.Page
#Region "Binding Data"
    Sub LoadDataDokters()
        'Dim _dokterBLL As New Gigimu.BLL.DokterBLL
        'Dim results = _dokterBLL.GetAll()
        'lvDokter.DataSource = results
        'lvDokter.DataBind()
        Dim _user = CType(Session("User"), PasienDTO)

        Dim _userBLL As New PasienBLL()
        Dim results = _userBLL.GetById(_user.PasienID)
        txtAlamat.Text = results.Alamat
        txtemail.Text = results.Email
        txtNama.Text = results.Nama
        txtTelepon.Text = results.Telepon
    End Sub
    Private Sub SetFieldsEditMode(ByVal isEditMode As Boolean)
        txtNama.ReadOnly = Not isEditMode
        txtAlamat.ReadOnly = Not isEditMode
        txtTelepon.ReadOnly = Not isEditMode
        btnSave.Visible = isEditMode
        btnEdit.Visible = Not isEditMode
    End Sub
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("User") Is Nothing Then
            Response.Redirect("Login.aspx")
        Else
            If Not Page.IsPostBack Then
                LoadDataDokters()
            End If
        End If

        'If Not Page.IsPostBack Then
        '    LoadDataDokters()
        'End If
    End Sub

    Protected Sub btnEdit_Click(sender As Object, e As EventArgs)
        SetFieldsEditMode(True)
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs)
        Dim _user = CType(Session("User"), PasienDTO)
        Dim _userBLL As New PasienBLL()
        Dim updateProfil As New UpdateProfilePasienDTO
        updateProfil.PasienID = _user.PasienID
        updateProfil.Nama = txtNama.Text
        updateProfil.Alamat = txtAlamat.Text
        updateProfil.Telepon = txtTelepon.Text
        _userBLL.Update(updateProfil)
        SetFieldsEditMode(False)
    End Sub
End Class