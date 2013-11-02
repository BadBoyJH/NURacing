<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="taskmanagement.aspx.cs" Inherits="NURacingWebsite.taskManagement" MasterPageFile="~/LoggedIn.Master" %>


<asp:Content ContentPlaceHolderID="Title" ID="Title" runat="server">
    NURacing System - Task Management
</asp:Content>

<asp:Content ID="Body" ContentPlaceHolderID="Body" runat="server">
	<div class="colmask threecol">
	<div class="colmid">
		<div class="colleft">
			<div class="col1">

                 <form id ="Form1" runat="server">
                        <br />
                            <br />
                      <asp:Button ID="btnEnquiry" runat="server" Text="?"  CssClass="btnEnquiry" />         <p style="text-align: center; clear:both;"></p>
       <h1>TASK MANAGEMENT</h1>
                 <p style="text-align: center">Please click an action below.</p>
                <br />
                    <div class="taskDetail">
                    
                     <asp:Button ID="updateTaskBtn" CssClass="takeFiveBtn" Text="UPDATE TASK" runat="server" OnClick="updateTaskBtn_Click" />
                     <asp:Button ID="createTaskBtn" CssClass="takeFiveBtn" Text="CREATE TASK" runat="server" OnClick="createTaskBtn_Click" />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                         
                        <div class="taskMngement">
                            
                        <asp:PlaceHolder ID="taskFrm" runat="server" Visible="false"></asp:PlaceHolder>
                            <asp:Button runat="server" ID="createSubmitTaskBtn" Visible="false" Text="SUBMIT"  OnClick="createSubmitTaskBtn_Click" CssClass="takeFiveBtn"/>
                            <asp:Button runat="server" ID="updateSubmitBtn" Visible="false" Text="SUBMIT"  OnClick="updateSubmitBtn_Click" CssClass="takeFiveBtn"/>
                            </div>
                        <asp:Label ID="createTaskFrm" runat="server" CssClass="taskMngement"></asp:Label>
                    
                    </div></form>
    </div>
			<div class="col2">
			</div>
			<div class="col3">
			</div>
 
		</div>
	</div>
 </div>
</asp:Content>
