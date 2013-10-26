<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="account.aspx.cs" Inherits="NURacingWebsite.account" MasterPageFile="~/LoggedIn.Master" %>

<asp:Content ID="Title" ContentPlaceHolderID="Title" runat="server">
    NU Racing - Account
</asp:Content>

<asp:Content ID="Scripts" ContentPlaceHolderID="Scripts" runat="server">
    <!-- Scripts -->
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
</asp:Content>
							
<asp:Content ID="Body" ContentPlaceHolderID="Body" runat="server">


        	<div class="colmask threecol">
	<div class="colmid">
		<div class="colleft">
			<div class="col1">
                <br />
                    <br />
                    <form id="form1" runat="server">
                        <h1>ACCOUNT</h1>
<div class="accountOptions">
      <asp:Button ID="btnRecover" runat="server" Text="?"  CssClass="btnSubmit" />
        <p id="userRoleYouAre" style="font-size: medium">
            <asp:Label runat="server" ID="userRoleYouLbl">You are a: </asp:Label>
            <asp:Label runat="server" CssClass="userRole" ID="userRoleLbl">USER.</asp:Label>
        </p>
    
    <br />
            <div id="passwordChangeForm">

            <asp:Label runat="server" ID="lblPasswordOld" CssClass="userRole">Old Password: </asp:Label>

                <asp:TextBox runat="server" ID="oldPasswordTxtBx" CssClass="textareaPassword" TextMode="Password">Old password</asp:TextBox>
                <br />
            <asp:Label runat="server" ID="lblPasswordNew" CssClass="userRole">New Password: </asp:Label>
                <asp:TextBox runat="server" ID="newPasswordTxtBx" CssClass="textareaPassword" TextMode="Password">New password</asp:TextBox>
                <br />
            <asp:Label runat="server" ID="lblPasswordNewConfirm" CssClass="userRole">Confirm New Password: </asp:Label>
        <asp:TextBox runat="server" ID="newPasswordConfTxtBx" CssClass="textareaPassword" TextMode="Password">New password confirm</asp:TextBox>

    </div>
    <asp:Button runat="server" ID="passSubmitBtn" CssClass="takeFiveBtn" Text="SUBMIT" OnClick="passSubmitBtn_Click" />
       
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
