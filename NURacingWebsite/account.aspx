<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="account.aspx.cs" Inherits="NURacingWebsite.account" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>NU Racing - Account</title>
    <link rel="stylesheet" href="css/style.css" type="text/css" media="screen" />	
<link href='http://fonts.googleapis.com/css?family=Cuprum' rel='stylesheet' type='text/css' />
<link href='http://fonts.googleapis.com/css?family=Oswald' rel='stylesheet' type='text/css' />
<link href='http://fonts.googleapis.com/css?family=Reenie+Beanie' rel='stylesheet' type='text/css' />

<!-- Javascripts -->
<script type="text/javascript" src="js/jquery.js"></script>
    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
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

<!-- jQuery UI -->
<script type="text/javascript" src="js/jquery-ui-1.8.5.min.js"></script>


<!-- Google map -->
<script src="http://maps.google.com/maps/api/js?sensor=true" type="text/javascript"></script>

<!-- Scripts -->
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

<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.6.1/jquery.min.js"></script>
<script type="text/javascript" src="http://cdn.jquerytools.org/1.2.5/full/jquery.tools.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="topContentSection">
		
			<div id="topBarMenu">
							
				<div id="topMenu">
					<ul>
						<li><a href="#" style="TEXT-DECORATION: NONE;"><span>Welcome: <asp:Label runat="server" ID="userLbl"></asp:Label> &nbsp; &#149;&nbsp;</span></a></li>
<!-- 
    today = new Date();
    document.write(today.getDate(), "/", today.getMonth() + 1, "/", today.getYear());
    document.write("&nbsp;&nbsp;", today.getHours(), ":", today.getMinutes());
    //--> 
</script> &nbsp; &#149;&nbsp; Log out </span></a></li>
					</ul>
				</div>
								
			</div>
		
			<div id="topContent">
				
				<div id="logo" >
					<a href="index.html">
						<img src="images/logo.png" alt="Logo" />
					</a>
				</div>
				
				<div id="menu">			
					<ul id="nav" class="menu" style="padding-top:10px;">
<li><a href="\index.aspx"><span><span>Projects</span></span></a></li> <li><a href="\todo.aspx"><span><span>Tasks</span></span></a></li> <li><a href="#"><span><span>Purchase</span></span></a></li> <li><a href="\account.aspx"><span><span>Account</span></span></a></li> <li><a href="\reports.aspx"><span><span>Reporting</span></span></a></li>

                    </ul>

<div class="accountOptions">
                    <br /> <br /> <br />
    <p id="userRoleYouAre" style="font-size:medium"><asp:Label runat="server" ID="userRoleYouLbl">You are a: </asp:Label> <asp:Label runat="server" CssClass="userRole" ID="userRoleLbl">USER.</asp:Label></p>
	<select><option value="option1">Option 1</option> 
    <option value="option2">Option 2</option>
    </select>
    <br />
    	<select><option value="option1">Option 1</option> 
    <option value="option2">Option 2</option>
    </select>
    <br />
    <div id ="passwordChangeForm">

        <asp:TextBox runat="server" ID="oldPasswordTxtBx" CssClass="input-textareaPassword" TextMode="Password">Old password</asp:TextBox> <br />
        <asp:TextBox runat="server" ID="newPasswordTxtBx" CssClass="input-textareaPassword" TextMode="Password">New password</asp:TextBox> <br />
        <asp:TextBox runat="server" ID="newPasswordConfTxtBx" CssClass="input-textareaPassword" TextMode="Password">New password confirm</asp:TextBox>

    </div>
    <asp:Button runat="server" ID="passSubmitBtn" CssClass="takeFiveBtn" Text="Submit" OnClick="passSubmitBtn_Click" />
    </div>
    </div>


                    </div>
			</div>
		</div>
    </form>
      <div id="footer"><h5><a href="http://www.newcastle.edu.au/"><img id="Img1" src="Images/logo2.png" alt="University of Newcastle" style="margin-right:30px; vertical-align:middle;"/></a>© NURacing, 2013 &nbsp;&#149;&nbsp; 
        <a href="http://www.eng.newcastle.edu.au/~fsae/">Website</a> &nbsp;&#149;&nbsp; <a href="https://www.facebook.com/groups/403657373086331/">Discussion Board</a> &nbsp;&#149;&nbsp; 
         <a href="http://www.saea.com.au/formula-sae-a/">FSAE</a> &nbsp;&#149;&nbsp; <a href="">Support</a></h5></div>


</body>
</html>
