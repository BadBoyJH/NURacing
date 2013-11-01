<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="resetPassword.aspx.cs" Inherits="NURacingWebsite.resetPassword"  MasterPageFile="~/LoggedIn.Master" %>

<asp:Content ID="Title" ContentPlaceHolderID="Title" runat="server">
    NU Racing - Password Reset
</asp:Content>

<asp:Content ID = "Body" ContentPlaceHolderID = "Body" runat ="server">
    <div id="successDiv" runat="server">
        <p>Success!!</p>
    </div>

    <div id="failDiv" runat="server">
        <p>Fail!!</p>
    </div>

    <form id="passwordResetFrm" runat="server">
        <div id="resetPasswordFrm">
            <asp:Label runat="server" ID="usernameLbl" CssClass="userRole">Username: </asp:Label>
            <asp:TextBox runat="server" ID="usernameTxtBx" CssClass="textareaPassword"></asp:TextBox>
            <br />
            <asp:Label runat="server" ID="emailLbl" CssClass="userRole">Email: </asp:Label>
            <asp:TextBox runat="server" ID="emailTxtBx" CssClass="textareaPassword"></asp:TextBox>
            <br />
            <asp:Button runat="server" ID="resetPasswordBtn" CssClass="takeFiveBtn" Text="RESET" OnClick="resetPasswordBtn_Click" />
        </div>
    </form>
</asp:Content>