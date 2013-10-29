<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="section.aspx.cs" Inherits="NURacingWebsite.section" MasterPageFile="~/LoggedIn.Master" %>


<asp:Content ContentPlaceHolderID="Title" ID="Title" runat="server">
    NURacing System - Sections
</asp:Content>

<asp:Content ID ="Body" ContentPlaceHolderID ="Body" runat ="server">
	<div class="colmask threecol">
	<div class="colmid">
		<div class="colleft">
			<div class="col1">
         <form id ="Form1" runat="server">        
                <br />
                            <br />
       <asp:Button ID="btnEnquiry" runat="server" Text="?"  CssClass="btnEnquiry" />         <p style="text-align: center; clear:both;"></p>
       <h1>SECTIONS</h1>         
                    <p style="text-align: center">Please click on a section below to review progress.</p>        
                <br />
             <asp:Button runat="server" ID="createProjBtn" Text="MANAGE SECTIONS" CssClass="takeFiveBtn" OnClick="createProjBtn_Click" />
                <p style="text-align: center; clear:both;"></p>
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
