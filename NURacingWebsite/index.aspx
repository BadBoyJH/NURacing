<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="NURacingWebsite.WebForm1" MasterPageFile="~/LoggedIn.Master" %>

<asp:Content ID="Title" ContentPlaceHolderID="Title" runat="server">
    NURacing System - Account
</asp:Content>

<asp:Content ID = "Body" ContentPlaceHolderID = "Body" runat ="server">
	
	<div class="colmask threecol">
	<div class="colmid">
		<div class="colleft">
			<div class="col1">

                    <br />
                    <br />
       <h1>PROJECTS</h1>
                    <p style="text-align: center">Please click on a project below to review progress.</p>
                <br />
    	<asp:Table ID="tblProjects" runat="server" GridLines="Horizontal" CssClass="tblProjects" class="tblProjects" HorizontalAlign="Center">
            </asp:Table>

                <br />
</div>
			<div class="col2">
			</div>
			<div class="col3">
			</div>
 
		</div>
	</div>
 </div>

</asp:Content>