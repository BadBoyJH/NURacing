<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="error503.aspx.cs" Inherits="NURacingWebsite.Error" MasterPageFile="~/LoggedIn.Master" %>

<asp:Content ID="Title" ContentPlaceHolderID="Title" runat="server">
    NURacing - Service Unavailable 503
</asp:Content>

<asp:Content ID = "Body" ContentPlaceHolderID = "Body" runat ="server">
 <div class="colmask threecol">
	<div class="colmid">
		<div class="colleft">
			<div class="col1">
                  <br />
                            <br />
    <h1>SERVICE UNAVAILABLE 503</h1>
           <h2>How embarassing</h2>
                  <p>A database error has occured. Please <a href="mailto:nuracinghelpdesk@gmail.com?Subject=NURacing%20Application%20Support%20Request">contact your System Administrator</a> or try again later.</p>

           </div>
			<div class="col2">
			</div>
			<div class="col3">
			</div>
             
		</div>
	</div>
 </div>

</asp:Content>