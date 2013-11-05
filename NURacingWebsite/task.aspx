<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="task.aspx.cs" Inherits="NURacingWebsite.task" MasterPageFile="~/LoggedIn.Master" %>


<asp:Content ContentPlaceHolderID="Title" ID="Title" runat="server">
    NURacing System - Task
</asp:Content>

<asp:Content ContentPlaceHolderID="Scripts" ID="Scripts" runat="server">
    <script type="text/javascript">
        function showHelp() {
            alert("You can view a task in more detail here, as well as logging work. Click Log Work to begin logging work.");
            return false;
        }
    </script>
</asp:Content>

<asp:Content ID="Body" ContentPlaceHolderID="Body" runat="server">
         <div class="colmask threecol">
	<div class="colmid">
		<div class="colleft">
			<div class="col1">
                 <form id ="Form2" runat="server">    
                        <br />
                            <br />    
       <asp:Button ID="btnEnquiry" runat="server" Text="?"  CssClass="btnEnquiry" OnClientClick="return showHelp()" />         <p style="text-align: center; clear:both;"></p>
                     <div class="taskDetail">
  
         <asp:Label ID="taskTitleLbl" CssClass="taskTitleLbl" runat="server">Task title</asp:Label>
                                <p style="text-align: center; clear:both;"></p><br />
         <asp:Button ID="takeFiveBtn" CssClass="takeFiveBtn" Text="LOG WORK" runat="server" OnClick="takeFiveBtn_Click" />
         <asp:Label ID="sectionProjLbl" CssClass="dueDateLbl" runat="server">Project Section</asp:Label>
                         <p style="text-align: center; clear:both;"></p>
         <asp:Label ID="dueDateLbl" CssClass="dueDateLbl" runat="server">Due date</asp:Label>
         <br />

         <br />
         <br />
         <br />
                          <span style="text-align:left;"><h2>TASK SUMMARY: </h2></span>
         <asp:TextBox runat="server" ID="taskDescTxtBx" CssClass="taskDescTxtBx" Enabled="False"></asp:TextBox><br /> <br /> <br />
        
        </div> </form>
        </div>
               

                   </div>
			<div class="col2">
			</div>
			<div class="col3">
			</div>
 
		</div>
	</div>
 
</asp:Content>
