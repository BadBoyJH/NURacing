<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="NURacingWebsite.WebForm1" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" dir="ltr">


<head id="Head1" runat="server">
    <title>NURacing System - Projects</title>
        <link rel="icon" type="image/png" href="NURacing_Favicon.ico"/>
		<link rel="stylesheet" media="all" href="css/style.css"/>
		<link href='http://fonts.googleapis.com/css?family=Cuprum' rel='stylesheet' type='text/css' />
		<link href='http://fonts.googleapis.com/css?family=Oswald' rel='stylesheet' type='text/css' />
		<meta name="viewport" content="width=device-width, initial-scale=1"/>

</head>
<body>
  
      <form id="form1" runat="server">
  
      <div id="header">
			<div id="topBarMenu">	
				<div id="topMenu">
					<ul>
						<li><a href="#" style="TEXT-DECORATION: NONE;"><span>Text goes here &nbsp; &#149;&nbsp; More text goes here</span></a></li>
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
						<li><a href="#"><span><span>Projects</span></span></a></li>
						<li><a href="#"><span><span>Tasks</span></span></a></li>
						<li><a href="#"><span><span>Purchase</span></span></a></li>
						<li><a href="#"><span><span>Account</span></span></a></li>
						<li><a href="#"><span><span>Reporting</span></span></a></li>
						<li><a href="#"><span><span>Idek Heading</span></span></a></li>
					</ul>
				</div>
		</div>
	
<div class="colmask threecol">
	<div class="colmid">
		<div class="colleft">
			<div class="col1">

        <br /><br />
       
    <p style="text-align:center">Please click on a project below to review progress.</p>
    	<asp:Table ID="tblProjects" runat="server" GridLines="Horizontal" CssClass="projectTable" HorizontalAlign="Center">
            <asp:TableRow >
            <asp:TableCell BorderColor="Black" BorderStyle="None"><a href="">
                       <asp:Label runat="server" ID="Label1" CssClass="projName">Epic car #1 <br /> <br /></asp:Label>
                <asp:Label ID="Label6" runat="server" CssClass="projDesc">This description is better than the previous one.</asp:Label>
            </a></asp:TableCell>
            <asp:TableCell BorderColor="Black" BorderStyle="None"><a href="">
                <asp:Label runat="server" ID="Label2" CssClass="projName">Epic car #2 <br /> <br /></asp:Label>
                <asp:Label ID="Label3" runat="server" CssClass="projDesc">This description is better than the previous one.</asp:Label>
            </a></asp:TableCell>
            <asp:TableCell BorderColor="Black" BorderStyle="None"><a href="">
               <asp:Label runat="server" ID="Label4" CssClass="projName">Epic car #3 <br /> <br /></asp:Label>
                <asp:Label ID="Label5" runat="server" CssClass="projDesc">This description is better than the previous one.</asp:Label>
            </a></asp:TableCell>
            </asp:TableRow>       
            </asp:Table>
                <br />
                <rsweb:ReportViewer ID="reportViewerUsers" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
                    
                    <LocalReport ReportPath="Reporting\UserReport.rdlc" ReportEmbeddedResource="NURacingWebsite.Reporting.UserReport.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="dsUSERS" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="DataAccessLayer.NuRacingDataSetTableAdapters.userTableAdapter">
                </asp:ObjectDataSource>

    
		    <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
 
    
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
