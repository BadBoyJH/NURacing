<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="taskManagement.aspx.cs" Inherits="NURacingWebsite.taskManagement" MasterPageFile="~/LoggedIn.Master" %>


<asp:Content ContentPlaceHolderID="Title" ID="Title" runat="server">
    NURacing System - Account
</asp:Content>

<asp:Content ID="Body" ContentPlaceHolderID="Body" runat="server">
	<div class="colmask threecol">
	<div class="colmid">
		<div class="colleft">
			<div class="col1">

                    <br />
                    <br />
       <h1>TASK MANAGEMENT</h1>
                    <p style="text-align: center">Please click an action below</p>
                <br />
                    <div class="taskDetail">
                     <asp:Button ID="updateTaskBtn" CssClass="takeFiveBtn" Text="Update task" runat="server" OnClick="updateTaskBtn_Click" />
                     <asp:Button ID="createTaskBtn" CssClass="takeFiveBtn" Text="Create task" runat="server" OnClick="createTaskBtn_Click" />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="createTaskFrm" runat="server" CssClass="taskMngement"></asp:Label>
                    </div>
    </div>
			<div class="col2">
			</div>
			<div class="col3">
			</div>
 
		</div>
	</div>
 </div>
</asp:Content>
