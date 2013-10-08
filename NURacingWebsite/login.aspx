﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="NURacingWebsite.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" dir="ltr" lang="en-US">

<head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
		<title>NURacing System - Login</title>
		<link rel="icon" type="image/png" href="NURacing_Favicon.ico"/>

		<link rel="stylesheet" media="all" href="css/style.css"/>
		<link href='http://fonts.googleapis.com/css?family=Cuprum' rel='stylesheet' type='text/css' />
		<link href='http://fonts.googleapis.com/css?family=Oswald' rel='stylesheet' type='text/css' />
		<meta name="viewport" content="width=device-width, initial-scale=1"/>
	    <style type="text/css">
            .auto-style1 {
                height: 27px;
            }
        </style>
	</head>

<body lang="en" runat="server">
   
	<div id="header" style="height:auto;">
		<div id="topBarMenu">	
				<div id="topMenu">
					<ul>
						<li><a href="#" style="TEXT-DECORATION: NONE;"><span>Text goes here &nbsp; &#149;&nbsp; More text goes here</span></a></li>
					</ul>
				</div>
			</div>	
        </div>

            
     
<div class="colmask threecol">
	<div class="colmid">
		<div class="colleft">
			<div class="col1">
    <form id="login" runat="server">
        <br /><br />
        <asp:Image ID="logoHome" CssClass="logoHome" ImageUrl="Images/NURacingLogo_White.png" runat="server" ImageAlign="Middle"  />
        <br /><br />
    <p style="text-align:center">Welcome to the NURacing System. Please enter your login credentials below.</p>
    <div id ="loginForm" class="loginForm">
        <table border="0" style="margin-left:auto; margin-right:auto; text-align:right;">
        <tr><td class="auto-style1"><asp:Label runat="server" ID="lblUsername" CssClass="lblUsername">Username: </asp:Label></td><td class="auto-style1"><asp:TextBox runat="server" Width="110px" ID="UsernameTxtBx" /></td></tr>
        <tr><td><asp:Label runat="server" ID="lblPassword" CssClass="p">Password: </asp:Label></td><td><asp:TextBox runat="server" TextMode="Password" Width="110px" ID="PassTxtBx" /></td></tr>
            <tr>
                <td>
                    <asp:CheckBox runat="server" ID ="chkbxRemember" CssClass="p" />
                </td>
                <td style="text-align:left;">
                    <asp:Label runat="server" ID="lblRemember" CssClass="p">Remember Me</asp:Label>
                </td>
            </tr>
        </table>
        <table border="0" style="margin-left:auto; margin-right:auto; text-align:right;">
            <tr>
                <td>
        <asp:Button runat="server" Text="SUBMIT"  CssClass="btnSubmit"  UseSubmitBehavior="true" ID="btnSubmit" OnClick="btnSubmit_Click" />
         <asp:Button ID="btnRecover" runat="server" Text="?"  CssClass="btnSubmit" />
            </td>
            </tr>
            </table>
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
</body>	
</html>