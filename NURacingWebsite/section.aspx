<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="section.aspx.cs" Inherits="NURacingWebsite.section" MasterPageFile="~/LoggedIn.Master" %>


<asp:Content ContentPlaceHolderID="Title" ID="Title" runat="server">
    NURacing System - Sections
</asp:Content>

<asp:Content ID ="Body" ContentPlaceHolderID ="Body" runat ="server">
	<div class="colmask threecol">
	<div class="colmid">
		<div class="colleft">
			<div class="col1">

                    <br />
                    <br />
       <h1>SECTIONS</h1>         
                <form id ="Form1" runat="server">
                    <p style="text-align: center">Please click on a section below to review progress.</p>
                  <asp:Button ID="btnRecover" runat="server" Text="?"  CssClass="btnSubmit" />
                <br />
    	<asp:Table ID="tblProjects" runat="server" GridLines="Horizontal" CssClass="tblProjects" class="tblProjects" HorizontalAlign="Center">
            </asp:Table>

                <br /></form>
</div>
			<div class="col2">
			</div>
			<div class="col3">
			</div>
 
		</div>
	</div>
 </div>
</asp:Content>
