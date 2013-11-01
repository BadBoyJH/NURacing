<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="confirmPasswordReset.aspx.cs" Inherits="NURacingWebsite.createNewPassword"  MasterPageFile="~/LoggedIn.Master" %>

<asp:Content ID="Title" ContentPlaceHolderID="Title" runat="server">
    NU Racing - New Password
</asp:Content>

<asp:Content ID = "Body" ContentPlaceHolderID = "Body" runat ="server">
    <div id="confirmResetSuccess" runat="server">
        <p>Password has been reset, please check your email.</p>
    </div>

    <div id="confirmResetFail" runat="server">
        <p>Password reset has failed, please try again.</p>
    </div>
</asp:Content>