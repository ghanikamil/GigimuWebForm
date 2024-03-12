Imports GigimuDTO

Public Class SiteMaster
    Inherits MasterPage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("User") IsNot Nothing Then
                Dim _userDto As PasienDTO = CType(Session("User"), PasienDTO)
                ltUsername.Text = _userDto.Nama
                pnlAnonymous.Visible = False
                pnlLoggedIn.Visible = True
            Else
                ltUsername.Text = "Guest"
                pnlAnonymous.Visible = True
                pnlLoggedIn.Visible = False
            End If
        End If
    End Sub
End Class