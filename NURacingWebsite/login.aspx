<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="NURacingWebsite.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="css/style.css" type="text/css" media="screen" />	
<link href='http://fonts.googleapis.com/css?family=Cuprum' rel='stylesheet' type='text/css' />
<link href='http://fonts.googleapis.com/css?family=Oswald' rel='stylesheet' type='text/css' />
<link href='http://fonts.googleapis.com/css?family=Reenie+Beanie' rel='stylesheet' type='text/css' />

<!-- Javascripts -->
<script type="text/javascript" src="js/jquery.js"></script>

<!-- jQuery UI -->
<script type="text/javascript" src="js/jquery-ui-1.8.5.min.js"></script>


<!-- Google map -->
<script src="http://maps.google.com/maps/api/js?sensor=true" type="text/javascript"></script>

<!-- Scripts -->
<script type="text/javascript" src="js/scripts.js"></script>

<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.6.1/jquery.min.js"></script>
<script type="text/javascript" src="http://cdn.jquerytools.org/1.2.5/full/jquery.tools.min.js"></script>
</head>

<body>
    <asp:Panel HorizontalAlign="Center" runat="server">
        
            <asp:Image ID="logoHome" CssClass="logoHome" ImageUrl="Images/NURacingLogo_White.png" runat="server" ImageAlign="Middle" Width="400" />
        </asp:Panel>

    <form id="login" runat="server">
    <p style="text-align:center">Welcome to the NURacing System. Please enter your login details below.</p>
     <asp:Panel runat="server" HorizontalAlign="Center">
    <div id ="loginForm" class="loginForm">
        <table border="0" style="margin-left:auto; margin-right:auto; text-align:right;">
        <tr><td><asp:Label runat="server" ID="UsernameLbl">Username: </asp:Label></td><td><asp:TextBox runat="server" Width="110px" ID="UsernameTxtBx" /></td></tr>
        <tr><td><asp:Label runat="server" ID="PassLbl">Password: </asp:Label></td><td><asp:TextBox runat="server" TextMode="Password" Width="110px" ID="PassTxtBx" /></td></tr>
            <tr>
                <td>
                    <asp:CheckBox runat="server" ID ="rememberChkBx" />
                </td>
                <td style="text-align:left;">
                    <asp:Label runat="server">Remember Me</asp:Label>
                </td>
            </tr>
        </table>
        <asp:Button BackColor="#cc0000" runat="server" Text="Submit"  CssClass="input-submitLogin"  UseSubmitBehavior="true" />
         <asp:Button ID="recover" BackColor="#cc0000" runat="server" Text="?"  CssClass="input-submitLoginRecover" />

    </div>
        </asp:Panel>
    </form>
</body>
</html>
