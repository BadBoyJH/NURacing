<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tasks.aspx.cs" Inherits="NURacingWebsite.tasks" MasterPageFile="~/LoggedIn.Master" %>


<asp:Content ContentPlaceHolderID="Title" ID="Title" runat="server">
    NURacing System - Tasks
</asp:Content>

<asp:Content ID="Body" ContentPlaceHolderID="Body" runat="server">
     	<div class="colmask threecol">
	<div class="colmid">
		<div class="colleft">
			<div class="col1">

                    <br />
                    <br />
            <form id="tasks" runat="server">
       <h1>TASKS -
           <asp:Label ID="lblSectionTitle" runat="server" Text="Label"></asp:Label>
                </h1>
                    <p style="text-align: center">Please click on a task below to review progress.</p>
                <br />
            <asp:GridView ID="todoTable" runat="server" CssClass="todoTable" AutoGenerateColumns="false" BorderWidth="1">
                <Columns>
                            <asp:HyperLinkField HeaderText="NAME" DataTextField="Task_Name" DataNavigateUrlFields="Task_ID" DataNavigateUrlFormatString="task.aspx?id={0:G}" />
                            <asp:BoundField HeaderText="DESCRIPTION" DataField="Task_Description" />
                            <asp:BoundField HeaderText="DUE DATE" DataField="duedate" />
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

