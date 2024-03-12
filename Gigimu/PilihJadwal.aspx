<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="PilihJadwal.aspx.vb" Inherits="Gigimu.PilihJadwal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">

        <div class="col-lg-12">
            <!-- Basic Card Example -->
            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary">Pilih Jadwal</h6>
                </div>
                <div class="card-body">
                    <table class="table table-hover">
                        <asp:ListView ID="lvJadwals" runat="server" OnItemCommand="lvJadwals_ItemCommand">
                            <LayoutTemplate>
                                <thead>
                                    <tr>
                                        <th>JadwalID</th>
                                        <th>Tanggal</th>
                                        <th>Status</th>
                                        <th>Banyak Orang</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr id="itemPlaceholder" runat="server"></tr>
                                </tbody>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%# Eval("JadwalDokterID") %>

                                    </td>
                                    <td>
                                        <%# Convert.ToDateTime(Eval("Tanggal")).ToString("yyyy-MM-dd") %>
                                    </td>
                                    <td>
                                        <asp:Label ID="StatusLabel" Text='<%# Eval("Status") %>' runat="server" />
                                    </td>
                                    <td><%# Eval("PasienTerdaftar") %></td>
                                    <td>
                                        <asp:Button ID="btnBook" Text="Booking" runat="server" CommandName="Book" CommandArgument='<%# Eval("JadwalDokterID") %>' CssClass="btn btn-primary btn-user btn-bloc" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <EmptyItemTemplate>
                                <tr>
                                    <td colspan="7">No records found</td>
                                </tr>
                            </EmptyItemTemplate>
                        </asp:ListView>
                    </table>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
