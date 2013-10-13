﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="taskManagement.aspx.cs" Inherits="NURacingWebsite.taskManagement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" dir="ltr">

<head id="Head1"  runat="server">
    <title>NURacing System - Account</title>
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
       <h1>TASK MANAGEMENT</h1>
                        <p style="text-align:center">Please click an action below</p>
                <br />
                    <div class="taskDetail">
                     <asp:Button ID="updateTaskBtn" CssClass="takeFiveBtn" Text="Update task" runat="server" OnClick="updateTaskBtn_Click" />
                     <asp:Button ID="createTaskBtn" CssClass="takeFiveBtn" Text="Create task" runat="server" OnClick="createTaskBtn_Click" />
                        <br /><br /><br /><br /><br />
                        <asp:Label id="createTaskFrm" runat="server" CssClass="taskMngement"></asp:Label>
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
