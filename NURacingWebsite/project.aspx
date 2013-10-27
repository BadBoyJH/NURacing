<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="project.aspx.cs" Inherits="NURacingWebsite.project" MasterPageFile="~/LoggedIn.Master" %>

    <asp:Content ContentPlaceHolderID="Title" ID="Title" runat="server">
    NURacing System - Create Project
</asp:Content>
<asp:Content ID="Body" ContentPlaceHolderID="Body" runat="server">
	<div class="colmask threecol">
	<div class="colmid">
		<div class="colleft">
			<div class="col1">
                <form id ="Form1" runat="server">
                       <br />
                            <br />
                 <asp:Button ID="btnEnquiry" runat="server" Text="?"  CssClass="btnEnquiry" />  
                <h1>CREATE A PROJECT</h1>
           
                <div class="taskMngement">
        
                <asp:PlaceHolder runat="server" ID="createProjFrm"></asp:PlaceHolder>
                    <asp:Button runat="server" ID="submitProjBtn" CssClass="takeFiveBtn" Text="SUBMIT" OnClick="submitProjBtn_Click"/>
                    </div>
              
			<div class="col2">
			</div>
			<div class="col3">
			</div>
 </form>
		</div>
	</div>
 </div>
        </div>
    </asp:Content>

