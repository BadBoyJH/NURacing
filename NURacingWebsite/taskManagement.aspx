﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="taskmanagement.aspx.cs" Inherits="NURacingWebsite.taskManagement" MasterPageFile="~/LoggedIn.Master" %>


<asp:Content ContentPlaceHolderID="Title" ID="Title" runat="server">
    NURacing System - Task Management
</asp:Content>

<asp:Content ContentPlaceHolderID="Scripts" ID="Scripts" runat="server">
    <script type="text/javascript">
        function showHelp() {
            alert("Here, you can manage tasks. Clicking Create Task will present you with a form that will allow you to create a task. Update Task will allow you to choose a task to update. Once the form is complete, click Submit.");
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
                      <asp:Button ID="btnEnquiry" runat="server" Text="?"  CssClass="btnEnquiry" OnClientClick="return showHelp()" />         <p style="text-align: center; clear:both;"></p>
       <h1>TASK MANAGEMENT</h1>
                 <p style="text-align: center">Please click an action below.</p>
                <br />
                    <asp:Label runat="server" id="submitTask" class="submitLbl" visible="False" CssClass="pUserFeedbackPass">Submission successful.</asp:Label>
                    <asp:Label runat="server" id="submitFail" class="submitLbl" visible="False" CssClass="pUserFeedbackFail">An error has occured.</asp:Label>

                    <div class="taskDetail">
                    
                     <asp:Button ID="updateTaskBtn" CssClass="takeFiveBtn" Text="UPDATE TASK" runat="server" OnClick="updateTaskBtn_Click" />
                     <asp:Button ID="createTaskBtn" CssClass="takeFiveBtn" Text="CREATE TASK" runat="server" OnClick="createTaskBtn_Click" />
                        <br />
                       
                         
                        <div class="taskMngement">
                            
                        <asp:PlaceHolder ID="taskFrm" runat="server" Visible="false" />
                            <asp:Button runat="server" ID="createSubmitTaskBtn" Visible="false" Text="SUBMIT"  OnClick="createSubmitTaskBtn_Click" CssClass="takeFiveBtn"/>
                            <asp:Button runat="server" ID="updateSubmitBtn" Visible="false" Text="SUBMIT"  OnClick="updateSubmitBtn_Click" CssClass="takeFiveBtn"/>
                        </div>
                    
                        <asp:Label ID="createTaskFrm" runat="server" CssClass="taskMngement" />
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
