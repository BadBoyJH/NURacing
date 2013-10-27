<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="NURacingWebsite.login" %>

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
	</head>

<body lang="en" runat="server">
   
	
		<div id="topBarMenu">	
				<div id="topMenu">
					<ul>
						<li><a href="#" style="TEXT-DECORATION: NONE;"><span>TA Building, School of Engineering, University of Newcastle, Callaghan NSW 2308 &nbsp; &#149;&nbsp; (02) 4925 4937 &nbsp; &#149;&nbsp; <%= DateTime.Now.ToString() %></span></a></li>
					</ul>
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
        <tr><td><asp:Label runat="server" ID="lblUsername" CssClass="p">Username: </asp:Label></td><td><asp:TextBox runat="server" Width="100%" ID="UsernameTxtBx" CssClass="textareaPassword" BackColor="#2D2D2D" Font-Names="Lucida Sans Unicode" Font-Size="11pt" ForeColor="#7E7E7E" /></td></tr>
        <tr><td class="auto-style1"><asp:Label runat="server" ID="lblPassword" CssClass="p">Password: </asp:Label></td><td class="auto-style1"><asp:TextBox runat="server" TextMode="Password" Width="100%" ID="PassTxtBx" CssClass="textareaPassword" BackColor="#2D2D2D" Font-Names="Lucida Sans Unicode" Font-Size="11pt" ForeColor="#7E7E7E" /></td></tr>
        
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
       
      <div id="footer"><h5><a href="http://www.newcastle.edu.au/"><img id="Img1" src="Images/logo2.png" alt="University of Newcastle" style="margin-right:30px; vertical-align:middle;"/></a>© NURacing, 2013 &nbsp;&#149;&nbsp; 
        <a href="http://www.eng.newcastle.edu.au/~fsae/">Website</a> &nbsp;&#149;&nbsp; <a href="https://www.facebook.com/groups/403657373086331/">Discussion Board</a> &nbsp;&#149;&nbsp; 
         <a href="http://www.saea.com.au/formula-sae-a/">FSAE</a> &nbsp;&#149;&nbsp; <a href="">Support</a></h5></div>


</body>	
</html>