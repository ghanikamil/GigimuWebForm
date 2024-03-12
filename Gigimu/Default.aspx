<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="Gigimu._Default" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">


        <div class="col-lg-12">
            <!-- Basic Card Example -->
            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary">Temukan Dokter Gigimu</h6>
                </div>
                <div class="card-body">
                    <table class="table table-hover">
                        <thead class="thead-dark">
                            <tr>
                                <td>id</td>
                                <td>Nama</td>
                                <td>Spesialis</td>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:ListView ID="lvDokter" runat="server" OnItemCommand="lvDokter_ItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("DokterID") %></td>
                                        <td><%# Eval("Nama") %></td>
                                        <td><%# Eval("Spesialis") %></td>
                                        <td>
                                            <a href='<%# "PilihJadwal.aspx?ID=" + Server.UrlEncode(Eval("DokterID").ToString()) %>' class="btn btn-primary">
                                                pilih
                                            </a>
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
