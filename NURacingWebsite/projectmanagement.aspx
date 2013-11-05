<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="projectmanagement.aspx.cs" Inherits="NURacingWebsite.project" MasterPageFile="~/LoggedIn.Master" %>

    <asp:Content ContentPlaceHolderID="Title" ID="Title" runat="server">
    NURacing System - Project Management
</asp:Content>

<asp:Content ContentPlaceHolderID="Scripts" ID="Scripts" runat="server">
    <script type="text/javascript">
        function showHelp() {
            alert("You can manage projects here. Click Create Project to fill out the project creation form. Click Update Project to update an existing project. Click Submit to save changes.");
            return false;
        }
    </script>
</asp:Content>

<asp:Content ID="Body" ContentPlaceHolderID="Body" runat="server">
	<div class="colmask threecol">
	<div class="colmid">
		<div class="colleft">
			<div class="col1">
                <form id ="Form1" runat="server">
                       <br />
                            <br />
                 <asp:Button ID="btnEnquiry" runat="server" Text="?"  CssClass="btnEnquiry" OnClientClick="return showHelp()" />       <p style="text-align: center; clear:both;"></p>  
       


                <h1>PROJECT MANAGEMENT</h1>
                     <p style="text-align: center">Please click an action below.</p>
           <br />
                      <asp:Label runat="server" id="submitProj" class="submitLbl" visible="False" CssClass="pUserFeedbackPass">Project submitted.</asp:Label>
                      <div class="taskDetail">
                     <asp:Button ID="updateProjBtn" CssClass="takeFiveBtn" Text="UPDATE PROJECT" runat="server" OnClick="updateProjBtn_Click" />
                     <asp:Button ID="createProjBtn" CssClass="takeFiveBtn" Text="CREATE PROJECT" runat="server" OnClick="createProjBtn_Click" />
                        <br />
                         
                <div class="taskMngement">
                <asp:PlaceHolder runat="server" ID="createProjFrm" Visible="false"></asp:PlaceHolder>
                    <asp:Button runat="server" ID="submitProjBtn" Visible="false" CssClass="takeFiveBtn" Text="SUBMIT" OnClick="submitProjBtn_Click"/>
                    <asp:Button runat="server" ID="updateSubmitBtn" Visible="false" Text="SUBMIT"  CssClass="takeFiveBtn" OnClick="updateSubmitBtn_Click"/>
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

