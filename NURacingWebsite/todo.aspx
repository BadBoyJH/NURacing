﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="todo.aspx.cs" Inherits="NURacingWebsite.todo" %>

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
					<a href="index.html">
						<img src="images/logo.png" alt="Logo" />
					</a>
				</div>
				
				<div id="menu">			
					<ul id="nav" class="menu" style="padding-top:10px;">
						<li><a href="#"><span><span>Projects</span></span></a></li>
						<li><a href="#"><span><span>Tasks</span></span></a></li>
						<li><a href="#"><span><span>Purchase</span></span></a></li>
						<li><a href="#"><span><span>Account</span></span></a></li>
						<li><a href="#"><span><span>Reporting</span></span></a></li>
						<li><a href="#"><span><span>Idek Heading</span></span></a></li>
					</ul>
				</div>
			</div>
		</div>
        <br />		
         <%-- <asp:SqlDataSource ID="taskDB" 
             Runat="server" 
             SelectCommand="SELECT a.Task_Name a.duedate FROM work w, assignedtask a WHERE w.User_Username = a.User_Username_AssignedTo"
            ProviderName="System.Data.OleDb"
             ConnectionString="Data Source=C:\Users\Callan\Source\Repos\NURacing\NURacingWebsite\testDB.accdb;" 
         DataSourceMode="DataReader">
        </asp:SqlDataSource>--%>
            <asp:GridView ID="todoTable" runat="server" CssClass="todoTable" AutoGenerateColumns="false" BorderWidth="1">
                <Columns>
                    <asp:HyperLinkField HeaderText="Test" DataTextField="Task_Name" />
                    <asp:HyperLinkField HeaderText="Due date" DataTextField="duedate" />
                </Columns>

            </asp:GridView>
        </div>
    </div>
    </form>
</body>
</html>
