Imports Gigimu.BLL
Imports GigimuDTO

Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Session("User") IsNot Nothing Then
        '    Response.Redirect("~/Default.aspx")
        'Else
        '    Response.Redirect("~/Login.aspx")
        'End If
    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs)
        Try
            Dim _userBLL As New PasienBLL()
            Dim _userDto = _userBLL.Login(txtEmail.Text, txtPassword.Text)
            If _userDto IsNot Nothing Then
                Session("User") = _userDto
                Response.Redirect("~/Default.aspx")
            Else
                ltMessage.Text = "<br/><span class='alert alert-danger'>Error: Invalid Username / Password </span><br/><br/>"
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class