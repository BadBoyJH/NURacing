<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="resetPassword.aspx.cs" Inherits="NURacingWebsite.resetPassword"  MasterPageFile="~/LoggedIn.Master" %>

<asp:Content ID="Title" ContentPlaceHolderID="Title" runat="server">
    NU Racing - Password Reset
</asp:Content>

<asp:Content ID = "Body" ContentPlaceHolderID = "Body" runat ="server">
    <div class="colmask threecol">
	    <div class="colmid">
		    <div class="colleft">
			    <div class="col1">
                    <br />
                    <br />
                    <div id="resetSuccess" runat="server">
                        <h2>Please check your email for password reset confirmation.</h2>
                    </div>

                    <div id="resetFail" runat="server">
                        <h2>Supplied username and email don't match, please try again.</h2>
                    </div>

                    <form id="passwordResetFrm" runat="server">
                        <div id="resetPassword">
                            <asp:Label runat="server" ID="usernameLbl" CssClass="userRole">Username: </asp:Label>
                            <asp:TextBox runat="server" ID="usernameTxtBx" CssClass="textareaPassword"></asp:TextBox>
                            <br />
                            <asp:Label runat="server" ID="emailLbl" CssClass="userRole">Email: </asp:Label>
                            <asp:TextBox runat="server" ID="emailTxtBx" CssClass="textareaPassword"></asp:TextBox>
                            <br />
                            <asp:Button runat="server" ID="resetPasswordBtn" CssClass="takeFiveBtn" Text="RESET" OnClick="resetPasswordBtn_Click" />
                        </div>
                    </form>
                </div>
		    </div>
        </div>
    </div>
</asp:Content>