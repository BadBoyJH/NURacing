<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reportlabourlog.aspx.cs" Inherits="NURacingWebsite.reportlabourlog" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" dir="ltr">
<head runat="server">
    <title>NURacing System - Labour Log Report</title>
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
					<a href="index.html">
						<img src="images/logo.png" alt="Logo" />
					</a>
				</div>
				
				<div id="menu">			
						<ul id="nav" class="menu" style="padding-top:10px;">
						<li><a href="\index.aspx"><span><span>Projects</span></span></a></li>
						<li><a href="\task.aspx"><span><span>Tasks</span></span></a></li>
						<li><a href="\purchase.aspx"><span><span>Purchase</span></span></a></li>
						<li><a href="\account.aspx"><span><span>Account</span></span></a></li>
						<li><a href="\reporting.aspx"><span><span>Reporting</span></span></a></li>
					</ul>
				</div>
		</div>
        <div id="colmask threecol">
        <div id ="col1">
    
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%" Height="650px">
            <LocalReport ReportPath="Reporting\LabourReport.rdlc" reportembeddedresource="NURacingWebsite.Reporting.LabourReport.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="dsWORK" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetData" TypeName="DataAccessLayer.NuRacingDataSetTableAdapters.WorkTableAdapter" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" UpdateMethod="Update">
                <DeleteParameters>
                    <asp:Parameter Name="Original_Work_UID" Type="Int32" />
                    <asp:Parameter Name="Original_Work_DateCompleted" Type="DateTime" />
                    <asp:Parameter Name="Original_Work_Description" Type="String" />
                    <asp:Parameter Name="Original_WorkType_UID" Type="Int32" />
                    <asp:Parameter Name="Original_Work_TimeWorkedMins" Type="Int32" />
                    <asp:Parameter Name="Original_User_Username" Type="String" />
                    <asp:Parameter Name="Original_Task_UID" Type="Int32" />
                    <asp:Parameter Name="Original_Work_TakeFiveTaken" Type="Byte" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Work_DateCompleted" Type="DateTime" />
                    <asp:Parameter Name="Work_Description" Type="String" />
                    <asp:Parameter Name="WorkType_UID" Type="Int32" />
                    <asp:Parameter Name="Work_TimeWorkedMins" Type="Int32" />
                    <asp:Parameter Name="User_Username" Type="String" />
                    <asp:Parameter Name="Task_UID" Type="Int32" />
                    <asp:Parameter Name="Work_TakeFiveTaken" Type="Byte" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Work_DateCompleted" Type="DateTime" />
                    <asp:Parameter Name="Work_Description" Type="String" />
                    <asp:Parameter Name="WorkType_UID" Type="Int32" />
                    <asp:Parameter Name="Work_TimeWorkedMins" Type="Int32" />
                    <asp:Parameter Name="User_Username" Type="String" />
                    <asp:Parameter Name="Task_UID" Type="Int32" />
                    <asp:Parameter Name="Work_TakeFiveTaken" Type="Byte" />
                    <asp:Parameter Name="Original_Work_UID" Type="Int32" />
                    <asp:Parameter Name="Original_Work_DateCompleted" Type="DateTime" />
                    <asp:Parameter Name="Original_Work_Description" Type="String" />
                    <asp:Parameter Name="Original_WorkType_UID" Type="Int32" />
                    <asp:Parameter Name="Original_Work_TimeWorkedMins" Type="Int32" />
                    <asp:Parameter Name="Original_User_Username" Type="String" />
                    <asp:Parameter Name="Original_Task_UID" Type="Int32" />
                    <asp:Parameter Name="Original_Work_TakeFiveTaken" Type="Byte" />
                </UpdateParameters>
            </asp:ObjectDataSource>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    
    </div></div>
    </form>
</body>

</html>
