<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="task.aspx.cs" Inherits="NURacingWebsite.task" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
						<li><a href="#" style="TEXT-DECORATION: NONE;"><span>Welcome: <asp:Label runat="server" ID="userLbl"></asp:Label> &nbsp; &#149;&nbsp;</span></a></li>
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
         <asp:Label ID="taskTitleLbl" CssClass="taskTitleLbl" runat="server">Task title</asp:Label>
         <asp:Button ID="takeFiveBtn" CssClass="takeFiveBtn" Text="Take five" runat="server" />
         <asp:Label ID="dueDateLbl" CssClass="dueDateLbl" runat="server">Due date</asp:Label>
         <br />
         <br />
         <br />
         <br />
         <asp:Label runat="server" ID="taskDescLbl" CssClass="taskDescLbl"></asp:Label>
         <p>Time logging</p>

         <div id="timelogging" class="timeLogging">
             <span>Hours: </span><asp:TextBox ID="HoursTxtBx" runat="server" CssClass="taskHrMinTxtBx"></asp:TextBox>
              <span>Minutes: </span><asp:TextBox ID="MinTxtBx" runat="server" CssClass="taskHrMinTxtBx"></asp:TextBox>
              <br />
             <span>Description: </span><asp:TextBox ID="descTxtBx" runat="server" CssClass="taskDescTxtBx"></asp:TextBox>

        </div>
        </div>


                    </div>
			</div>
		</div>
    </div>

    </form>
</body>
</html>
