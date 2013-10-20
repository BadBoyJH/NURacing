<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="todo.aspx.cs" Inherits="NURacingWebsite.todo" MasterPageFile="~/LoggedIn.Master" %>


<asp:Content ContentPlaceHolderID="Title" ID="Title" runat="server">
    NURacing System - To Do List
</asp:Content>

<asp:Content ID="Body" ContentPlaceHolderID="Body" runat="server">
     	<div class="colmask threecol">
	<div class="colmid">
		<div class="colleft">
			<div class="col1">

                    <br />
                    <br />
       <h1>TO DO LIST</h1>
                    <p style="text-align: center">Please click on a task below to review progress.</p>
                <br />
            <asp:GridView ID="todoTable" runat="server" CssClass="todoTable" AutoGenerateColumns="false" BorderWidth="1">
                <Columns>
                            <asp:HyperLinkField HeaderText="NAME" DataTextField="Task_Name" DataNavigateUrlFields="Task_ID" DataNavigateUrlFormatString="task.aspx?id={0:G}" />
                            <asp:BoundField HeaderText="DESCRIPTION" DataField="Task_Description" />
                            <asp:BoundField HeaderText="DUE DATE" DataField="duedate" />
                </Columns>

            </asp:GridView>
        
  </div>
			<div class="col2">
			</div>
			<div class="col3">
			</div>
 
		</div>
	</div>
 </div>
</asp:Content>
