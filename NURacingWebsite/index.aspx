<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="NURacingWebsite.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Home</title>
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
		
<div id="innerPageBottom">
<div id="middlestrip"></div>
<div class="innerContent">
			<div id="pageFull" style="text-align:center;">
								<br/><br/><br/>
				<div style="width:100%;text-align:center;"></div>
				<p>Select a project:</p>
<br/><br/>
				</div>	
                        <asp:Table ID="Table1" runat="server" GridLines="Horizontal" CssClass="projectTable" HorizontalAlign="Center">
            <asp:TableRow >
            <asp:TableCell BorderColor="Black" BorderStyle="Solid"><a href="">
                <asp:Label runat="server" ID="projNameLbl" CssClass="projName">Epic car #1 <br /> <br /></asp:Label>
                <asp:Label ID="Label1" runat="server" CssClass="projDesc">This is a nice project description that I thought I'd write. This is a nice project description that I thought I'd write This is a nice project description that I thought I'd write This is a nice project description that I thought I'd write This is a nice project description that I thought I'd write This is a nice project description that I thought I'd write This is a nice project description that I thought I'd writeThis is a nice project description that I thought I'd writeThis is a nice project description that I thought I'd write</asp:Label>
            </a></asp:TableCell>
            <asp:TableCell BorderColor="Black" BorderStyle="Solid"><a href="">
                <asp:Label runat="server" ID="Label2" CssClass="projName">Epic car #2 <br /> <br /></asp:Label>
                <asp:Label ID="Label3" runat="server" CssClass="projDesc">This description is better than the previous one.</asp:Label>
            </a></asp:TableCell>
            <asp:TableCell BorderColor="Black" BorderStyle="Solid"><a href="">
                <asp:Label runat="server" ID="Label4" CssClass="projName">No U Mobile <br /> <br /></asp:Label>
                <asp:Label ID="Label5" runat="server" CssClass="projDesc">ffffffffffffffffffffffffffffffffffffffffffffffffffffff</asp:Label>
            </a></asp:TableCell>
            </asp:TableRow>       
            </asp:Table>
	</div>
			</div>
    <div>
    
    </div>
    </form>
</body>
</html>
