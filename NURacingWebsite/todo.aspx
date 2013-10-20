<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="todo.aspx.cs" Inherits="NURacingWebsite.todo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" dir="ltr">

<head id="Head1"  runat="server">
    <title>NURacing System - To Do List</title>
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
       <h1>TO DO LIST</h1>
                    <p style="text-align:center">Please click on a task below to review progress.</p>
                <br />
            <asp:GridView ID="todoTable" runat="server" CssClass="todoTable" AutoGenerateColumns="false" BorderWidth="1">
                <Columns>
                    <asp:HyperLinkField HeaderText="NAME" DataTextField="Task_Name" DataNavigateUrlFields ="Task_ID" DataNavigateUrlFormatString ="task.aspx?id={0:G}" />
                    <asp:BoundField HeaderText="DESCRIPTION" DataField="Task_Description"/>
                    <asp:BoundField HeaderText="DUE DATE" DataField="duedate"/>
                </Columns>

            </asp:GridView>
        
  </div>
			<div class="col2">
			</div>
			<div class="col3">
			</div>
 
		</div>
	</div>
 </div>

      </form>
      <div id="footer"><h5><a href="http://www.newcastle.edu.au/"><img id="Img1" src="Images/logo2.png" alt="University of Newcastle" style="margin-right:30px; vertical-align:middle;"/></a>© NURacing, 2013 &nbsp;&#149;&nbsp; 
        <a href="http://www.eng.newcastle.edu.au/~fsae/">Website</a> &nbsp;&#149;&nbsp; <a href="https://www.facebook.com/groups/403657373086331/">Discussion Board</a> &nbsp;&#149;&nbsp; 
         <a href="http://www.saea.com.au/formula-sae-a/">FSAE</a> &nbsp;&#149;&nbsp; <a href="">Support</a></h5></div>


</body>
</html>
