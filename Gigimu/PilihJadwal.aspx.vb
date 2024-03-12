Imports Gigimu.BLL
Imports Gigimu.InterfaceBLL
Imports GigimuDTO

Public Class PilihJadwal
    Inherits System.Web.UI.Page

#Region "Binding Data"
    Sub LoadDataJadwals(jadwalID As Integer)
        Dim _jadwalBLL As New Gigimu.BLL.JadwalBLL
        Dim results = _jadwalBLL.GetJadwalByDokter(jadwalID)
        lvJadwals.DataSource = results
        lvJadwals.DataBind()
    End Sub

#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("User") Is Nothing Then
            Response.Redirect("Login.aspx")
        Else
            If Not IsPostBack Then
                Dim id As Integer = If(Request.QueryString("id") IsNot Nothing, Convert.ToInt32(Request.QueryString("id")), -1)
                ' Use the id as needed
                LoadDataJadwals(id)
            End If
        End If

        'If Not IsPostBack Then
        '    Dim id As Integer = If(Request.QueryString("id") IsNot Nothing, Convert.ToInt32(Request.QueryString("id")), -1)
        '    ' Use the id as needed
        '    LoadDataJadwals(id)
        'End If
    End Sub

    Protected Sub lvJadwals_ItemDataBound(ByVal sender As Object, ByVal e As ListViewItemEventArgs) Handles lvJadwals.ItemDataBound
        If e.Item.ItemType = ListViewItemType.DataItem Then
            Dim dataItem As ListViewDataItem = CType(e.Item, ListViewDataItem)
            Dim statusLabel As Label = CType(dataItem.FindControl("StatusLabel"), Label)
            Dim btnBook As Button = CType(dataItem.FindControl("btnBook"), Button)

            If statusLabel.Text = "Kosong" Then
                btnBook.Visible = True
            Else
                btnBook.Visible = False
            End If
        End If
    End Sub

    Protected Sub btnBook_Click(sender As Object, e As EventArgs)
        Dim _user = CType(Session("User"), PasienDTO)
        Dim _bookBLL As New BookingBLL()
        Dim _bookDTO As New AddBookingDTO
        _bookDTO.PasienID = _user.PasienID
    End Sub

    Protected Sub lvJadwals_ItemCommand(sender As Object, e As ListViewCommandEventArgs)
        Dim _user = CType(Session("User"), PasienDTO)
        Dim _bookBLL As New BookingBLL()
        Dim _bookDTO As New AddBookingDTO
        Dim _jadwalID As Integer = e.CommandArgument
        _bookDTO.PasienID = _user.PasienID
        _bookDTO.JadwalDokterID = _jadwalID
        _bookDTO.JamBooking = DateTime.Now
        _bookBLL.Insert(_bookDTO)
        Response.Redirect("~/ListBooking.aspx")
    End Sub
End Class