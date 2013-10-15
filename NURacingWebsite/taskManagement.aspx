<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="taskManagement.aspx.cs" Inherits="NURacingWebsite.taskManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>NU Racing - To do</title>
            <link rel="stylesheet" href="css/style.css" type="text/css" media="screen" />	
<link href='http://fonts.googleapis.com/css?family=Cuprum' rel='stylesheet' type='text/css' />
<link href='http://fonts.googleapis.com/css?family=Oswald' rel='stylesheet' type='text/css' />
<link href='http://fonts.googleapis.com/css?family=Reenie+Beanie' rel='stylesheet' type='text/css' />

<!-- Javascripts -->
<script type="text/javascript" src="js/jquery.js"></script>

<!-- jQuery UI -->
<script type="text/javascript" src="js/jquery-ui-1.8.5.min.js"></script>


<!-- Google map -->
<script src="http://maps.google.com/maps/api/js?sensor=true" type="text/javascript"></script>

<!-- Scripts -->
<script type="text/javascript" src="js/scripts.js"></script>

<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.6.1/jquery.min.js"></script>
<script type="text/javascript" src="http://cdn.jquerytools.org/1.2.5/full/jquery.tools.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div id="topContentSection">
		
			<div id="topBarMenu">
							
				<div id="topMenu">
					<ul>
						<li><a href="#" style="TEXT-DECORATION: NONE;"><span>Welcome, Test User&nbsp; &#149; &nbsp;<script language="javascript"> 
<!-- 
    today = new Date();
    document.write(today.getDate(), "/", today.getMonth() + 1, "/", today.getYear());
    document.write("&nbsp;&nbsp;", today.getHours(), ":", today.getMinutes());
    //--> 
</script> &nbsp; &#149;&nbsp; Log out </span></a></li>
					</ul>
				</div>
								
			</div>
		
			<div id="topContent">
				
				<div id="logo" >
					<a href="index.aspx">
						<img src="images/logo.png" alt="Logo" />
					</a>
				</div>
				
				<div id="menu">			
					<ul id="nav" class="menu" style="padding-top:10px;">
<li><a href="\index.aspx"><span><span>Projects</span></span></a></li> <li><a href="\todo.aspx"><span><span>Tasks</span></span></a></li> <li><a href="#"><span><span>Purchase</span></span></a></li> <li><a href="\account.aspx"><span><span>Account</span></span></a></li> <li><a href="\reporting.aspx"><span><span>Reporting</span></span></a></li>

                    </ul>
                    <div class="taskDetail">
                     <asp:Button ID="updateTaskBtn" CssClass="takeFiveBtn" Text="Update task" runat="server" OnClick="updateTaskBtn_Click" />
                     <asp:Button ID="createTaskBtn" CssClass="takeFiveBtn" Text="Create task" runat="server" OnClick="createTaskBtn_Click" />
                        <br /><br /><br /><br /><br />
                        <asp:Label id="createTaskFrm" runat="server" CssClass="taskMngement"></asp:Label>
                    </div>
    </div>
    </form>
</body>
</html>
