<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="account.aspx.cs" Inherits="NURacingWebsite.account" MasterPageFile="~/LoggedIn.Master" %>

<asp:Content ID="Title" ContentPlaceHolderID="Title" runat="server">
    NU Racing - Account
</asp:Content>

<asp:Content ID="Scripts" ContentPlaceHolderID="Scripts" runat="server">

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
		
</asp:Content>
							
<asp:Content ID="Body" ContentPlaceHolderID="Body" runat="server">
<div class="accountOptions">
        <br />
        <br />
        <br />
        <p id="userRoleYouAre" style="font-size: medium">
            <asp:Label runat="server" ID="userRoleYouLbl">You are a: </asp:Label>
            <asp:Label runat="server" CssClass="userRole" ID="userRoleLbl">USER.</asp:Label>
        </p>
        <form id="form1" runat="server">
            <select>
                <option value="option1">Option 1</option>
    <option value="option2">Option 2</option>
    </select>
    <br />
            <select>
                <option value="option1">Option 1</option>
    <option value="option2">Option 2</option>
    </select>
    <br />
            <div id="passwordChangeForm">

                <asp:TextBox runat="server" ID="oldPasswordTxtBx" CssClass="input-textareaPassword" TextMode="Password">Old password</asp:TextBox>
                <br />
                <asp:TextBox runat="server" ID="newPasswordTxtBx" CssClass="input-textareaPassword" TextMode="Password">New password</asp:TextBox>
                <br />
        <asp:TextBox runat="server" ID="newPasswordConfTxtBx" CssClass="input-textareaPassword" TextMode="Password">New password confirm</asp:TextBox>

    </div>
    <asp:Button runat="server" ID="passSubmitBtn" CssClass="takeFiveBtn" Text="Submit" OnClick="passSubmitBtn_Click" />
        </form>
		</div>
</asp:Content>
