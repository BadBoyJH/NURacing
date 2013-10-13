<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="account.aspx.cs" Inherits="NURacingWebsite.account" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" dir="ltr">

<head  runat="server">
    <title>NURacing System - Account</title>
        <link rel="icon" type="image/png" href="NURacing_Favicon.ico"/>
		<link rel="stylesheet" media="all" href="css/style.css"/>
		<link href='http://fonts.googleapis.com/css?family=Cuprum' rel='stylesheet' type='text/css' />
		<link href='http://fonts.googleapis.com/css?family=Oswald' rel='stylesheet' type='text/css' />
		<meta name="viewport" content="width=device-width, initial-scale=1"/>

<!-- Javascripts -->
<script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.9.1.js"></script>
     <script type="text/javascript">
         function makeItPasswordOld() {
             document.getElementById("passwordChangeForm")
                .innerHTML = "<input id=\"bOldPassword\" name=\"oldPassword\" class=\"input-textareaPassword\" type=\"password\" />" +
                "<input id=\"passwordNew\" name=\"passwordNew\" type=\"password\" class=\"input-textareaPassword\"/>" +
                "<input id=\"passwordNewConf\" name=\"passwordNewConf\" class=\"input-textareaPassword\" type=\"password\"/>";
             // document.getElementById("bOldPassword").focus();
         }
         function makeItPasswordNew() {
             document.getElementById("passwordChangeForm")
                .innerHTML = "<input id=\"passwordNew\" name=\"passwordNew\" type=\"password\"/>";
             document.getElementById("password").focus();
         }
         function makeItPasswordNewConf() {
             document.getElementById("passwordChangeForm")
                .innerHTML = "<input id=\"passwordNewConf\" name=\"passwordNewConf\" type=\"password\"/>";
             document.getElementById("password").focus();
         }
   </script>

<script type="text/javascript" src="js/scripts.js"></script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.6.1/jquery.min.js">jQuery(document).ready(function(){
    jQuery('#hideshow').live('click', function(event) {        
         jQuery('#passwordChange').toggle('show');
    });
});</script>
<script type="text/javascript" src="http://cdn.jquerytools.org/1.2.5/full/jquery.tools.min.js"></script>
<script type="text/javascript">
    $(function () {
        $("#scroller .item").css("width", $(document).width());
        $("#scroller").scrollable({
            circular: true,
            speed: 1200
        }).autoscroll({ interval: 5000 }).navigator();
        api = $('#scroller').data("scrollable");
        $(window).resize(function () {
            if ($('#scroller .items:animated').length == 0) {
                $("#scroller .item").css("width", $(document).width());
                nleft = $(document).width() * (api.getIndex() + 1);
                $("#scroller .items").css("left", "-" + nleft + "px");
            }
        });
    });

    function pageLoad() {
        jQuery('#hideshow').live('click', function (event) {
            jQuery('#passwordChange').toggle('show');
        });
    };
    /*jQuery(document).ready(function () {
        jQuery('#hideshow').live('click', function (event) {
            jQuery('#passwordChange').toggle('show');
        });
    });*/
</script>

</head>
<body>
   <form id="frmLayout" runat="server">
            <div id="header">
			<div id="topBarMenu">	
				<div id="topMenu">
					<ul>
						<li><a href="#" style="TEXT-DECORATION: NONE;"><span>Welcome, <asp:Label runat="server" ID="userLbl"></asp:Label> &nbsp; &#149;&nbsp;
<script  type="text/javascript" > 
<!-- 
    today = new Date();
    document.write(today.getDate(), "/", today.getMonth() + 1, "/", today.getYear());
    document.write("&nbsp;&nbsp;", today.getHours(), ":", today.getMinutes(), ":", today.getSeconds());
    //--> 
</script> &nbsp; &#149;&nbsp; Log out </span></a></li>
					</ul>
			</div>	
        </div>
          <div id="logo" >
					<a href="index.html">
						<img src="images/logo.png" alt="Logo" />
					</a>
				</div>
				<div id="menu">			
					<ul id="nav" class="menu" style="padding-top:10px;">
<li><a href="\index.aspx"><span><span>Projects</span></span></a></li> <li><a href="\todo.aspx"><span><span>Tasks</span></span></a></li> <li><a href="purchases.aspx"><span><span>Purchase</span></span></a></li> <li><a href="\account.aspx"><span><span>Account</span></span></a></li> <li><a href="\reporting.aspx"><span><span>Reporting</span></span></a></li>
					</ul>
				</div>
		</div>
	<div class="colmask threecol">
	<div class="colmid">
		<div class="colleft">
			<div class="col1">
                <br /><br />
                <h1>ACCOUNT SETTINGS</h1>
                <div class="accountOptions">
    <p id="userRoleYouAre">You are a: <asp:Label runat="server" CssClass="userRole" ID="userRoleLbl">USER</asp:Label></p>
	<select><option value="option1">Option 1</option> 
    <option value="option2">Option 2</option>
    </select>
    <br />
    	<select><option value="option1">Option 1</option> 
    <option value="option2">Option 2</option>
    </select>
    <br />
    <div id ="passwordChangeForm">
        <table border="0" style="margin-left:auto; margin-right:auto; text-align:right;">
            <tr><td>
                <asp:Label ID="lblOldPassword" runat="server" Text="Old Password: " CssClass="p"></asp:Label></td>
                <td><asp:TextBox runat="server" ID="oldPasswordTxtBx" CssClass="input-textareaPassword" Width="160px">Old password</asp:TextBox> <br /></td></tr>
            <tr>
       <td><asp:Label ID="lblNewPassword" runat="server" Text="New Password: " CssClass="p"></asp:Label></td><td><asp:TextBox runat="server" ID="newPasswordTxtBx" CssClass="input-textareaPassword" Width="160px">New password</asp:TextBox> <br /></td></tr>
       <tr><td><asp:Label ID="lblNewPasswordConfirm" runat="server" Text="Confirm New Password: " CssClass="p"></asp:Label></td> <td><asp:TextBox runat="server" ID="newPasswordConfTxtBx" CssClass="input-textareaPassword" Width="160px">Confirm new password</asp:TextBox></td></tr>
            </table>
    </div>
    <asp:Button runat="server" ID="passSubmitBtn" CssClass="takeFiveBtn" Text="Submit" OnClick="passSubmitBtn_Click" />
    </div>
   </div>
			<div class="col2">
			</div>
			<div class="col3">
			</div>
 
		</div>
	</div>
 </div>

      </form>


    </body>
</html>
