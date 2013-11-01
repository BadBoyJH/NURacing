<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createNewPassword.aspx.cs" Inherits="NURacingWebsite.resetPassword"  MasterPageFile="~/LoggedIn.Master" %>

<asp:Content ID="Title" ContentPlaceHolderID="Title" runat="server">
    NU Racing - New Password
</asp:Content>

<asp:Content ID = "Body" ContentPlaceHolderID = "Body" runat ="server">
    <div id="newPasswordSuccess" runat="server">
        <p>Success!!</p>
    </div>

    <div id="newPasswordFail" runat="server">
        <p>Fail!!</p>
    </div>

    <form id="setPasswordFrm" runat="server">
        <div id="setPassword">
            <asp:Label runat="server" ID="passwordLbl" CssClass="userRole">New Password: </asp:Label>
            <asp:TextBox runat="server" ID="passwordTxtBx" CssClass="textareaPassword" TextMode="Password"></asp:TextBox>
            <br />
            <asp:Label runat="server" ID="confirmLbl" CssClass="userRole">Confirm Password: </asp:Label>
            <asp:TextBox runat="server" ID="confirmTxtBx" CssClass="textareaPassword" TextMode="Password"></asp:TextBox>
            <br />
            <asp:Button runat="server" ID="createNewPasswordBtn" CssClass="takeFiveBtn" Text="SUBMIT" OnClick="createNewPasswordBtn_Click" />
        </div>
    </form>
</asp:Content>