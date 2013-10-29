<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="NURacingWebsite.WebForm1" MasterPageFile="~/LoggedIn.Master" %>

<asp:Content ID="Title" ContentPlaceHolderID="Title" runat="server">
    NURacing System - Projects
</asp:Content>

<asp:Content ID = "Body" ContentPlaceHolderID = "Body" runat ="server">
	
	<div class="colmask threecol">
	<div class="colmid">
		<div class="colleft">
			<div class="col1">
                                           <form id ="Form1" runat="server">
                                                  <br />
                            <br />
                                                                    <asp:Button ID="btnEnquiry" runat="server" Text="?"  CssClass="btnEnquiry" />  
       <h1>PROJECTS</h1>

                    <p style="text-align: center">Please click on a project below to review progress.</p>

                <br />
          
                <asp:Button runat="server" ID="createProjBtn" Text="CREATE PROJECT" CssClass="takeFiveBtn" OnClick="createProjBtn_Click"/>
    	<asp:Table ID="tblProjects" runat="server" GridLines="Horizontal" CssClass="tblProjects" class="tblProjects" HorizontalAlign="Center">
            </asp:Table>
                </form>
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