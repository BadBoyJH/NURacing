<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sectionmanagement.aspx.cs" Inherits="NURacingWebsite.sectionmanagement" MasterPageFile="~/LoggedIn.Master" %>

    <asp:Content ContentPlaceHolderID="Title" ID="Title" runat="server">
    NURacing System - Section Management
</asp:Content>
<asp:Content ID="Body" ContentPlaceHolderID="Body" runat="server">
	<div class="colmask threecol">
	<div class="colmid">
		<div class="colleft">
			<div class="col1">
                <form id ="Form1" runat="server">
                       <br />
                            <br />
                 <asp:Button ID="btnEnquiry" runat="server" Text="?"  CssClass="btnEnquiry" />       <p style="text-align: center; clear:both;"></p>  
       


                <h1>SECTION MANAGEMENT</h1>
                     <p style="text-align: center">Please click an action below.</p>
           <br />

                       <div class="taskDetail">
                   
                         
                <div class="taskMngement">
        
                <asp:PlaceHolder runat="server" ID="createProjFrm"></asp:PlaceHolder>
                   
                    <asp:Button runat="server" ID="updateSubmitBtn" Text="SUBMIT"  CssClass="takeFiveBtn" OnClick="updateSubmitBtn_Click"/>
                    </div>
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

