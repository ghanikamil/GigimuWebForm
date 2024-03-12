Imports Gigimu.BLL
Imports GigimuDTO

Public Class ListBooking
    Inherits System.Web.UI.Page

#Region "Binding Data"
    Sub LoadDataBooks(pasienID As Integer)
        Dim _bookBLL As New Gigimu.BLL.BookingBLL
        Dim results = _bookBLL.GetBookingByPasien(pasienID)
        lvBooking.DataSource = results
        lvBooking.DataBind()

        'Dim _jadwalBLL As New Gigimu.BLL.JadwalBLL
        'Dim results = _jadwalBLL.GetJadwalByDokter(jadwalID)
        'lvJadwals.DataSource = results
        'lvJadwals.DataBind()
    End Sub

#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("User") Is Nothing Then
            Response.Redirect("Login.aspx")
        Else
            Dim _user = CType(Session("User"), PasienDTO)
            LoadDataBooks(_user.PasienID)
        End If
    End Sub

    Protected Sub lvBooking_ItemCommand(sender As Object, e As ListViewCommandEventArgs)
        Dim _bookBLL As New BookingBLL()
        Try
            If e.CommandName = "Delete" Then
                Dim _bookingID As Integer = e.CommandArgument
                _bookBLL.Delete(_bookingID)
                Dim _user = CType(Session("User"), PasienDTO)
                LoadDataBooks(_user.PasienID)
                ltMessage.Text = "<span class='alert alert-success'>Booking deleted successfully</span><br/><br/>"
            End If
        Catch ex As Exception
            ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span><br/><br/>"
        End Try



    End Sub

    Protected Sub lvBooking_ItemDeleting(sender As Object, e As ListViewDeleteEventArgs)

    End Sub
End Class