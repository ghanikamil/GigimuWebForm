<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ListDokter.aspx.vb" Inherits="Gigimu.ListDokter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">Dokter</h1>
        </div>

        <div class="col-lg-12">
            <!-- Basic Card Example -->
            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary">List Dokter</h6>
                </div>
                <div class="card-body">
                    <asp:Literal ID="ltMessage" runat="server" EnableViewState="false" />
                    <div class="row">
                        <div class="col-lg-12">

                            <table class="table table-hover">
                                <thead>
                                    <tr>
                                        <td>DokterID</td>
                                        <td>Nama</td>
                                        <td>Spesialis</td>
                                        <td>Email</td>

                                        <td>isSpesialis</td>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:ListView ID="lvDokter" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%# Eval("DokterID") %></td>
                                                <td><%# Eval("Nama") %></td>
                                                <td><%# Eval("Spesialis") %></td>
                                                <td><%# Eval("Email") %></td>

                                                <td><%# Eval("isSpesialis") %></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:ListView>
                                </tbody>
                            </table>
                            <button type="button" class="btn btn-primary btn-sm" data-toggle="modal" data-target="#myModal">
                                Add Dokter
                            </button>
                            <!-- The Modal -->
                            <div class="modal" id="myModal">
                                <div class="modal-dialog">
                                    <div class="modal-content">

                                        <!-- Modal Header -->
                                        <div class="modal-header">
                                            <h4 class="modal-title">Add Dokter</h4>
                                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                                        </div>

                                        <!-- Modal body -->
                                        <div class="modal-body">
                                            <div class="form-group">
                                                <label for="txtNama">Nama :</label>
                                                <asp:TextBox ID="txtNama" runat="server" EnableViewState="false" CssClass="form-control" placeholder="Enter Nama" />
                                            </div>
                                            <div class="form-group">
                                                <label for="ddDokterSpesialis">Spesialis :</label>
                                                <asp:DropDownList ID="ddDokterSpesialis" CssClass="form-control" runat="server">
                                                    <asp:ListItem CssClass="dropdown-item-text" Text="Umum" Value="Umum"></asp:ListItem>
                                                    <asp:ListItem CssClass="dropdown-item-text" Text="Spesialis Ortodonti (SpOrt)" Value="Spesialis Ortodonti (SpOrt)"></asp:ListItem>
                                                    <asp:ListItem CssClass="dropdown-item-text" Text="Spesialis Periodonsia (SpPerio)" Value="Spesialis Periodonsia (SpPerio)"></asp:ListItem>
                                                    <asp:ListItem CssClass="dropdown-item-text" Text="Spesialis Konservasi Gigi (SpKG)" Value="Spesialis Konservasi Gigi (SpKG)"></asp:ListItem>
                                                    <asp:ListItem CssClass="dropdown-item-text" Text="Spesialis Bedah Mulut (SpBM)" Value="Spesialis Bedah Mulut (SpBM)"></asp:ListItem>
                                                    <asp:ListItem CssClass="dropdown-item-text" Text="Spesialis Prostodonsia (SpPros)" Value="Spesialis Prostodonsia (SpPros)"></asp:ListItem>
                                                    <asp:ListItem CssClass="dropdown-item-text" Text="Spesialis Kedokteran Gigi Anak (SpKGA)" Value="Spesialis Kedokteran Gigi Anak (SpKGA)"></asp:ListItem>
                                                    <asp:ListItem CssClass="dropdown-item-text" Text="Spesialis Penyakit Mulut (SpPM)" Value="Spesialis Penyakit Mulut (SpPM)"></asp:ListItem>
                                                    <asp:ListItem CssClass="dropdown-item-text" Text="Spesialis Radiologi Kedokteran Gigi (SpRKG)" Value="Spesialis Radiologi Kedokteran Gigi (SpRKG)"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="form-group">
                                                <label for="txtEmail">Email :</label>
                                                <asp:TextBox ID="txtEmail" runat="server" EnableViewState="false" CssClass="form-control" placeholder="Enter Email" />
                                            </div>
                                            <div class="form-group">
                                                <label for="txtPassword">Password :</label>
                                                <asp:TextBox ID="txtPassword" runat="server" EnableViewState="false" CssClass="form-control" placeholder="Enter Password" TextMode="Password" />
                                            </div>
                                        </div>

                                        <!-- Modal footer -->
                                        <div class="modal-footer">
                                            <asp:Button Text="Submit" ID="btnSubmit" CssClass="btn btn-primary btn-sm"
                                                OnClick="btnSubmit_Click" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>

    </div>
</asp:Content>
