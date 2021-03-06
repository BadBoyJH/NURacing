﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="todo.aspx.cs" Inherits="NURacingWebsite.todo" MasterPageFile="~/LoggedIn.Master" %>


<asp:Content ContentPlaceHolderID="Title" ID="Title" runat="server">
    NURacing System - To Do List
</asp:Content>

<asp:Content ContentPlaceHolderID="Scripts" ID="Scripts" runat="server">
    <script type="text/javascript">
        function showHelp() {
            alert("Here, you can view tasks that are available for you to complete. Click on Details to view more information about them, or click Logging to complete a take five.");
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
       <h1>TO DO LIST</h1>
                    <p style="text-align: center" id="instructTodo" runat="server">Please click on a task button below to update a task or review a task and log time spent.</p>
                 
                <br />
            <asp:GridView ID="todoTable" runat="server" CssClass="todoTable" AutoGenerateColumns="false" BorderWidth="0" GridLines="None" OnDataBound="todoTable_DataBound">
                <Columns>
                            <asp:BoundField HeaderText="PROJECT SECTION" DataField="Section_Name" />
                            <asp:BoundField HeaderText="NAME" DataField="Task_Name"/>
                            <asp:BoundField HeaderText="DESCRIPTION" DataField="Task_Description" />
                            <asp:BoundField HeaderText="DUE DATE" DataField="duedate" />
                            <asp:HyperLinkField HeaderText="&nbsp;" Text="DETAILS"  DataNavigateUrlFields="Task_ID" DataNavigateUrlFormatString="task.aspx?id={0:G}" />
                            <asp:HyperlinkField HeaderText="&nbsp;" Text="LOGGING" DataNavigateURLFields="Task_ID" DataNavigateUrlFormatString="takefive.aspx?taskID={0:d}" />
                </Columns>

            </asp:GridView>
                </form>
        
  </div>
			<div class="col2">
			</div>
			<div class="col3">
			</div>
 
		</div>
	</div>
 </div>
</asp:Content>
