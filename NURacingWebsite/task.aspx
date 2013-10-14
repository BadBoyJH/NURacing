<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="task.aspx.cs" Inherits="NURacingWebsite.task" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" dir="ltr">


<head id="Head1" runat="server">
    <title>NURacing System - Tasks</title>
        <link rel="icon" type="image/png" href="NURacing_Favicon.ico"/>
		<link rel="stylesheet" media="all" href="css/style.css"/>
		<link href='http://fonts.googleapis.com/css?family=Cuprum' rel='stylesheet' type='text/css' />
		<link href='http://fonts.googleapis.com/css?family=Oswald' rel='stylesheet' type='text/css' />
		<meta name="viewport" content="width=device-width, initial-scale=1"/>

</head>
<body>
    <form id="frmLayout" runat="server">
            <div id="header">
			<div id="topBarMenu">	
				<div id="topMenu">
					<ul>
						<li><a href="#" style="TEXT-DECORATION: NONE;"><span>Welcome, <asp:Label runat="server" ID="userLbl"></asp:Label> &nbsp; &#149;&nbsp;
<script  type="text/javascript" > 
<!-- 
    today = new Date();
    document.write(today.getDate(), "/", today.getMonth() + 1, "/", today.getYear());
    document.write("&nbsp;&nbsp;", today.getHours(), ":", today.getMinutes(), ":", today.getSeconds());
    //--> 
</script> &nbsp; &#149;&nbsp; Log out </span></a></li>
					</ul>
			</div>	
        </div>
          <div id="logo" >
					<a href="index.html">
						<img src="images/logo.png" alt="Logo" />
					</a>
				</div>
				<div id="menu">			
					<ul id="nav" class="menu" style="padding-top:10px;">
<li><a href="\index.aspx"><span><span>Projects</span></span></a></li> <li><a href="\todo.aspx"><span><span>Tasks</span></span></a></li> <li><a href="purchases.aspx"><span><span>Purchase</span></span></a></li> <li><a href="\account.aspx"><span><span>Account</span></span></a></li> <li><a href="\reporting.aspx"><span><span>Reporting</span></span></a></li>
					</ul>
				</div>
		</div>
         <div class="colmask threecol">
	<div class="colmid">
		<div class="colleft">
			<div class="col1">
                <br /><br />
                 
                     <div class="taskDetail">
                    
         <asp:Label ID="taskTitleLbl" CssClass="taskTitleLbl" runat="server">Task title</asp:Label>
         <asp:Label ID="dueDateLbl" CssClass="dueDateLbl" runat="server">Due date</asp:Label>
         <br />
         <asp:Button ID="takeFiveBtn" CssClass="takeFiveBtn" Text="TAKE FIVE" runat="server" />
         <br />
         <br />
         <br />
         <asp:Label runat="server" ID="taskDescLbl" CssClass="taskDescLbl"></asp:Label>
         <h2>TIME LOGGING</h2>

         <div id="timelogging" class="timeLogging">
             <span>HOURS: </span><asp:TextBox ID="HoursTxtBx" runat="server" CssClass="taskHrMinTxtBx"></asp:TextBox>
              <span>MINUTES: </span><asp:TextBox ID="MinTxtBx" runat="server" CssClass="taskHrMinTxtBx"></asp:TextBox>
              <br />
             <span>DESCRIPTION: </span><asp:TextBox ID="descTxtBx" runat="server" CssClass="taskDescTxtBx"></asp:TextBox>
             <asp:Button ID="btnSubmitLabour" CssClass="takeFiveBtn" Text="SUBMIT" runat="server" />
        </div>
        </div>


                   </div>
			<div class="col2">
			</div>
			<div class="col3">
			</div>
 
		</div>
	</div>
 </div>
 

      </form>

</body>
</html>
