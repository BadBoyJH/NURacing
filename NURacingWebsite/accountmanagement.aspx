<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="accountmanagement.aspx.cs" Inherits="NURacingWebsite.UserManagement" MasterPageFile="~/LoggedIn.Master" %>

<asp:Content ContentPlaceHolderID="Title" runat="server">
    NURacing System - User Management
</asp:Content>

<asp:Content ContentPlaceHolderID="Body" runat="server">
    <div class="colmask threecol">
        <div class="colmid">
            <div class="colleft">
                <div class="col1">
                    <form id="Form1" runat="server">
                        <br />
                        <br />
                        <asp:Button ID="btnEnquiry" runat="server" Text="?" CssClass="btnEnquiry" />
                        <p style="text-align: center; clear: both;"></p>

                        <h1>ACCOUNT MANAGEMENT</h1>
                        <p style="text-align: center">Please click an action below.</p>

                        <br />
                        <div class="taskDetail" id="RandomDiv" runat="server">


                            <asp:Button ID="btnUpdateUser" CssClass="takeFiveBtn" Text="UPDATE USER" runat="server" OnClick="btnUpdateUser_Click" />
                            <asp:Button ID="btnCreateUser" CssClass="takeFiveBtn" Text="CREATE USER" runat="server" OnClick="btnCreateUser_Click" />
                            <br />
                            <br />
                            <br />
                            <div class="taskMngement">
                                <asp:PlaceHolder runat="server" ID="createUserFrm" Visible="false"></asp:PlaceHolder>
                                <asp:Button runat="server" ID="createUserSubmitBtn" Visible="false" OnClick="submitCreateUserBtn_Click" CssClass="takeFiveBtn" Text="SUBMIT" />
                                <asp:Button runat="server" ID="updateUserSubmitBtn" Visible="false" OnClick="submitUpdateUserBtn_Click" CssClass="takeFiveBtn" Text="SUBMIT" />

                            </div>
                            <%-- <asp:Label id="createUserFrm" runat="server" CssClass="taskMngement"></asp:Label>--%>
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
