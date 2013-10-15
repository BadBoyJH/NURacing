﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reportprojectstatus.aspx.cs" Inherits="NURacingWebsite.reportprojectstatus" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" dir="ltr">


<head id="Head1" runat="server">
    <title>NURacing System - Project Status Report</title>
        <link rel="icon" type="image/png" href="NURacing_Favicon.ico"/>
		<link rel="stylesheet" media="all" href="css/style.css"/>
		<link href='http://fonts.googleapis.com/css?family=Cuprum' rel='stylesheet' type='text/css' />
		<link href='http://fonts.googleapis.com/css?family=Oswald' rel='stylesheet' type='text/css' />
		<meta name="viewport" content="width=device-width, initial-scale=1"/>

</head>
    <body>
 <form id="form1" runat="server">
 <div id="header" style="-webkit-box-shadow: 0px 0px 0px rgba(0, 0, 0, 1);
	-moz-box-shadow:    0px 0px 0px rgba(0, 0, 0, 1);
	box-shadow:         0px 0px 0px rgba(0, 0, 0, 1);">
			<div id="topBarMenu">	
				<div id="topMenu">
					<ul>
						<li><a href="#" style="TEXT-DECORATION: NONE;"><span>Text goes here &nbsp; &#149;&nbsp; More text goes here</span></a></li>
					</ul>
			</div>	

        </div>
          <div id="logo" >
					<a href="index.aspx">
						<img src="images/logo.png" alt="Logo" />
					</a>
				</div>
				
				<div id="menu">			
					<ul id="nav" class="menu" style="padding-top:10px;">
<li><a href="\index.aspx"><span><span>Projects</span></span></a></li> <li><a href="\todo.aspx"><span><span>Tasks</span></span></a></li> <li><a href="#"><span><span>Purchase</span></span></a></li> <li><a href="\account.aspx"><span><span>Account</span></span></a></li> <li><a href="\reporting.aspx"><span><span>Reporting</span></span></a></li>

					</ul>
				</div>
		</div>
        <div id="colmask threecol">
        <div id ="col1">
    
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%" Height="650px">
            <LocalReport ReportPath="Reporting\ProjectStatusReport.rdlc" reportembeddedresource="NURacingWebsite.Reporting.ProjectStatusReport.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="dsPROJECTS" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetData" TypeName="DataAccessLayer.NuRacingDataSetTableAdapters.ProjectTableAdapter, DataAccessLayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"></asp:ObjectDataSource>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    
    </div></div>
    </form>
</body>
</html>
