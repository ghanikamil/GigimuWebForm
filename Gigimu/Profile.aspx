<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Profile.aspx.vb" Inherits="Gigimu.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-lg-12">
        <!-- Basic Card Example -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">Profile Page</h6>
            </div>
            <div class="card-body">
                Ayo edit profil kamu disini
               <asp:Panel ID="pnlAboutMeForm" runat="server" Visible="true">
                   <div class="form-group">
                       <asp:Literal ID="ltMessage" runat="server" /><br />
                   </div>
                   <div class="form-group">
                       <label for="txtNama">Nama</label>
                       <asp:TextBox runat="server" CssClass="form-control" ID="txtNama" placeholder="Masukkan nama kamu" ReadOnly="true" />
                       <asp:RequiredFieldValidator ID="RequiredFieldValidatorNama" runat="server" ControlToValidate="txtNama" ErrorMessage="Nama harus diisi" CssClass="validation-error" />
                   </div>
                   <div class="form-group">
                       <label for="txtAlamat">Alamat</label>
                       <asp:TextBox runat="server" CssClass="form-control" ID="txtAlamat" placeholder="Enter your middle name" ReadOnly="true" />
                   </div>
                   <div class="form-group">
                       <label for="txtTelepon">Telepon</label>
                       <asp:TextBox runat="server" CssClass="form-control" ID="txtTelepon" placeholder="Enter your middle name" ReadOnly="true" />
                   </div>
                   <div class="form-group">
                       <label for="txtemail">Email Address</label>
                       <asp:TextBox runat="server" CssClass="form-control" ID="txtemail" TextMode="Email" placeholder="Enter your email address" ReadOnly="true" />
                       <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ControlToValidate="txtemail" ErrorMessage="Email address is required." CssClass="validation-error" />
                       <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" ControlToValidate="txtemail" ErrorMessage="Invalid email address format." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="validation-error" />
                   </div>

               </asp:Panel>
                <asp:Button ID="btnEdit" runat="server" CssClass="btn btn-secondary mt-2" Text="Edit" OnClick="btnEdit_Click" />
                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary mt-2" Text="Save" OnClick="btnSave_Click" Visible="false" />
            </div>
        </div>

    </div>

</asp:Content>
