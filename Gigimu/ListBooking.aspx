<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ListBooking.aspx.vb" Inherits="Gigimu.ListBooking" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">


        <div class="col-lg-12">
            <!-- Basic Card Example -->
            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary">My All Booking</h6>
                </div>
                <div class="card-body">
                    <asp:Literal ID="ltMessage" runat="server" />
                    <table class="table table-hover">
                        <thead class="thead-dark">
                            <tr>
                                <td>Booking id</td>
                                <td>Tanggal</td>
                                <td>Nama</td>
                                <td>Spesialis</td>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:ListView ID="lvBooking" runat="server" OnItemCommand="lvBooking_ItemCommand" OnItemDeleting="lvBooking_ItemDeleting">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("BookingID") %></td>
                                        <td>
                                            <%# Convert.ToDateTime(Eval("Jadwal.Tanggal")).ToString("yyyy-MM-dd") %>
                                        </td>
                                        <td><%# Eval("Dokter.Nama") %></td>
                                        <td><%# Eval("Dokter.Spesialis") %></td>
                                        <td>
                                            <asp:LinkButton ID="btnDelete" Text="Delete" runat="server" CommandName="Delete" CommandArgument='<%# Eval("BookingID") %>' CssClass="btn btn-primary btn-user btn-bloc" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:ListView>
                        </tbody>
                    </table>
                </div>
            </div>

        </div>

    </div>
</asp:Content>
