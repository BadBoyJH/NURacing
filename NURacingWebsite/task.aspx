<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="task.aspx.cs" Inherits="NURacingWebsite.task" MasterPageFile="~/LoggedIn.Master" %>


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
                 
                     <div class="taskDetail">
                             <form id ="Form1" runat="server">
         <asp:Label ID="taskTitleLbl" CssClass="taskTitleLbl" runat="server">Task title</asp:Label>
         <asp:Label ID="dueDateLbl" CssClass="dueDateLbl" runat="server">Due date</asp:Label>
         <br />
                           <asp:Button ID="btnRecover" runat="server" Text="?"  CssClass="btnSubmit" />
         <asp:Button ID="takeFiveBtn" CssClass="takeFiveBtn" Text="TAKE FIVE" runat="server" />
         <br />
         <br />
         <br />
         <asp:Label runat="server" ID="taskDescLbl" CssClass="taskDescLbl"></asp:Label>
         <h2>TIME LOGGING</h2>

         <div id="timelogging" class="timeLogging">
                            <span>HOURS: </span>
                            <asp:TextBox ID="HoursTxtBx" runat="server" CssClass="taskHrMinTxtBx"></asp:TextBox>
                            <span>MINUTES: </span>
                            <asp:TextBox ID="MinTxtBx" runat="server" CssClass="taskHrMinTxtBx"></asp:TextBox>
              <br />
                            <span>DESCRIPTION: </span>
                            <asp:TextBox ID="descTxtBx" runat="server" CssClass="taskDescTxtBx"></asp:TextBox>
             <asp:Button ID="btnSubmitLabour" CssClass="takeFiveBtn" Text="SUBMIT" runat="server" />
        </div> </form>
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
