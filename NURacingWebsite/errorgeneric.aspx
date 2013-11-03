<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="errorgeneric.aspx.cs" Inherits="NURacingWebsite.errorgeneric" MasterPageFile="~/LoggedIn.Master" %>

<asp:Content ID="Title" ContentPlaceHolderID="Title" runat="server">
    NURacing - INVALID REQUEST 400
</asp:Content>

<asp:Content ID = "Body" ContentPlaceHolderID = "Body" runat ="server">
 <div class="colmask threecol">
	<div class="colmid">
		<div class="colleft">
			<div class="col1">
                  <br />
                            <br />
    <h1>UNKNOWN ERROR</h1>
           <h2>Unknown Error</h2>
                  <p>We have no idea what went wrong with that one, the server could be a teapot for all we know. Please <a href="index.aspx">return to home</a> to try again.</p>

           </div>
			<div class="col2">
			</div>
			<div class="col3">
			</div>
             
		</div>
	</div>
 </div>

</asp:Content>