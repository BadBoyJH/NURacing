<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="todo.aspx.cs" Inherits="NURacingWebsite.todo" MasterPageFile="~/LoggedIn.Master" %>


<asp:Content ContentPlaceHolderID="Title" ID="Title" runat="server">
    NURacing System - To Do List
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
       <h1>TO DO LIST</h1>
                    <p style="text-align: center">Please click on a task button below to update a task or review a task and log time spent.</p>
                 
                <br />
            <asp:GridView ID="todoTable" runat="server" CssClass="todoTable" AutoGenerateColumns="false" BorderWidth="0" GridLines="None">
                <Columns>
                            <asp:BoundField HeaderText="NAME" DataField="Task_Name"/>
                            <asp:BoundField HeaderText="DESCRIPTION" DataField="Task_Description" />
                            <asp:BoundField HeaderText="DUE DATE" DataField="duedate" />
                            <asp:HyperLinkField HeaderText="&nbsp;" Text="DETAILS"  DataNavigateUrlFields="Task_ID" DataNavigateUrlFormatString="task.aspx?id={0:G}" />
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
