﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tasks.aspx.cs" Inherits="NURacingWebsite.tasks" MasterPageFile="~/LoggedIn.Master" %>


<asp:Content ContentPlaceHolderID="Title" ID="Title" runat="server">
    NURacing System - Tasks
</asp:Content>

<asp:Content ContentPlaceHolderID="Scripts" ID="Scripts" runat="server">
    <script type="text/javascript">
        function showHelp() {
            alert("Here are the active tasks for a specific project. Click Details to find out more about a task, or click Manage Tasks to manage them.");
            return false;
        }
    </script>
</asp:Content>

<asp:Content ID="Body" ContentPlaceHolderID="Body" runat="server">
    <div class="colmask threecol">
        <div class="colmid">
            <div class="colleft">
                <div class="col1">

                    <form id="Form1" runat="server">
                        <br />
                        <br />
                        <asp:Button ID="btnEnquiry" runat="server" Text="?" CssClass="btnEnquiry" OnClientClick=" return showHelp()" />
                        <p style="text-align: center; clear: both;"></p>
                        <h1>TASKS -
           <asp:Label ID="lblSectionTitle" runat="server" Text="Label"></asp:Label>
                        </h1>
                        <p style="text-align: center" runat="server" id="instructTasks">Please click on a task button below to review a task and log time spent.</p><p style="text-align: center; clear: both;"></p><br />
                        <asp:Button runat="server" ID="createProjBtn" Text="MANAGE AND ASSIGN TASKS" CssClass="takeFiveBtn" OnClick="createProjBtn_Click" />
                        <p style="text-align: center; clear: both;"></p>
                        <br />
                        <asp:GridView ID="todoTable" runat="server" CssClass="todoTable" AutoGenerateColumns="false" BorderWidth="0" GridLines="None" OnDataBound="todoTable_DataBound">
                            <Columns>
                                <asp:BoundField HeaderText="NAME" DataField="Task_Name" />
                                <asp:BoundField HeaderText="DESCRIPTION" DataField="Task_Description" />
                                <asp:BoundField HeaderText="DUE DATE" DataField="duedate"/>
                                <asp:HyperLinkField HeaderText="&nbsp;" Text="DETAILS" DataNavigateUrlFields="Task_ID" DataNavigateUrlFormatString="task.aspx?id={0:G}"/>
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

