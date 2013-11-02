<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="confirmPasswordReset.aspx.cs" Inherits="NURacingWebsite.createNewPassword"  MasterPageFile="~/LoggedIn.Master" %>

<asp:Content ID="Title" ContentPlaceHolderID="Title" runat="server">
    NU Racing - Confirm Password Reset
</asp:Content>

<asp:Content ID = "Body" ContentPlaceHolderID = "Body" runat ="server">
    <div class="colmask threecol">
	    <div class="colmid">
		    <div class="colleft">
			    <div class="col1">
                    <br />
                    <br />
                    <div id="confirmResetSuccess" runat="server">
                        <h2>Password has been reset, please check your email.</h2>
                    </div>

                    <div id="confirmResetFail" runat="server">
                        <h2>Password reset has failed, please try again.</h2>
                    </div>
                </div>
		    </div>
        </div>
    </div>
</asp:Content>