<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="task.aspx.cs" Inherits="NURacingWebsite.task" MasterPageFile="~/LoggedIn.Master" %>


<asp:Content ContentPlaceHolderID="Title" ID="Title" runat="server">
    NURacing System - Task
</asp:Content>

<asp:Content ID="Body" ContentPlaceHolderID="Body" runat="server">
         <div class="colmask threecol">
	<div class="colmid">
		<div class="colleft">
			<div class="col1">
                 <form id ="Form2" runat="server">    
                        <br />
                            <br />    
       <asp:Button ID="btnEnquiry" runat="server" Text="?"  CssClass="btnEnquiry" />         <p style="text-align: center; clear:both;"></p>
                     <div class="taskDetail">
  
         <asp:Label ID="taskTitleLbl" CssClass="taskTitleLbl" runat="server">Task title</asp:Label>
                                <p style="text-align: center; clear:both;"></p>
         <asp:Button ID="takeFiveBtn" CssClass="takeFiveBtn" Text="LOG WORK" runat="server" OnClick="takeFiveBtn_Click" />
         <asp:Label ID="dueDateLbl" CssClass="dueDateLbl" runat="server">Due date</asp:Label>
         <br />

         <br />
         <br />
         <br />
                          <span style="text-align:left;"><h2>TASK SUMMARY: </h2></span>
         <asp:Label runat="server" ID="taskDescLbl" CssClass="taskDescLbl"></asp:Label><br />  <br />  <br />
         <h2>TIME LOGGING</h2>
         <p>Please log details of the block of time you have spent on this task below.</p><br />

         <div id="timelogging" class="timeLogging">
                            <span>HOURS:&nbsp; </span>
                            <asp:TextBox ID="HoursTxtBx" runat="server" CssClass="taskHrMinTxtBx"></asp:TextBox>
                            <span>&nbsp;&nbsp;&nbsp;&nbsp;MINUTES:&nbsp; </span>
                            <asp:TextBox ID="MinTxtBx" runat="server" CssClass="taskHrMinTxtBx"></asp:TextBox>
              <br />
                            <span>DESCRIPTION: </span>
                            <asp:TextBox ID="descTxtBx" runat="server" CssClass="taskDescTxtBx" TextMode="MultiLine"></asp:TextBox>
             <asp:Button ID="btnSubmitLabour" CssClass="takeFiveBtn" Text="SUBMIT" runat="server" />
        </div> 
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
