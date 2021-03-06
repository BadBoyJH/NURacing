﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="accountmanagement.aspx.cs" Inherits="NURacingWebsite.UserManagement" MasterPageFile="~/LoggedIn.Master" MaintainScrollPositionOnPostback="true" %>

<asp:Content ContentPlaceHolderID="Title" runat="server">
    NURacing System - User Management
</asp:Content>

<asp:Content ContentPlaceHolderID="Scripts" ID="Scripts" runat="server">
    <script type="text/javascript">
        function showHelp() {
            alert("Edit your account information here. If you're an admin, you can update a user's account information for them. Click Create User or Update User to continue.");
            return false;
        }
    </script>
</asp:Content>

<asp:Content ContentPlaceHolderID="Body" runat="server">
    <div class="colmask threecol">
        <div class="colmid">
            <div class="colleft">
                <div class="col1">
                    <form id="Form1" runat="server">
                        <br />
                        <br />
                        <asp:Button ID="btnEnquiry" runat="server" Text="?" CssClass="btnEnquiry" OnClientClick="return showHelp()" />
                        <p style="text-align: center; clear: both;"></p>

                        <h1>ACCOUNT MANAGEMENT</h1>
                        <p id="userRoleYouAre" style="font-size: medium">
            <asp:Label runat="server" ID="userRoleYouLbl">You are a </asp:Label>
            <asp:Label runat="server" CssClass="userRole" ID="userRoleLbl">USER.</asp:Label>
        </p>

                        <p style="text-align: center">Please click an action below.</p>

                        <br />
                        <div class="taskDetail" id="RandomDiv" runat="server">


                            <asp:Button ID="btnUpdateUser" CssClass="takeFiveBtn" Text="UPDATE USER" runat="server" OnClick="btnUpdateUser_Click" />
                            <asp:Button ID="btnCreateUser" CssClass="takeFiveBtn" Text="CREATE USER" runat="server" OnClick="btnCreateUser_Click" />
                            <br />
                            <div class="taskMngement">
                                <asp:PlaceHolder runat="server" ID="createUserFrm" Visible="false"></asp:PlaceHolder>
                                <asp:Button runat="server" ID="createUserSubmitBtn" Visible="false" OnClick="submitCreateUserBtn_Click" CssClass="takeFiveBtn" Text="SUBMIT" />
                                <asp:Button runat="server" ID="updateUserSubmitBtn" Visible="false" OnClick="submitUpdateUserBtn_Click" CssClass="takeFiveBtn" Text="SUBMIT" />

                            </div>
                        </div>
                    </form>
                </div>
                <div class="col2">
                </div>
                <div class="col3">
                </div>

            </div>
        </div>
    </div>
</asp:Content>
