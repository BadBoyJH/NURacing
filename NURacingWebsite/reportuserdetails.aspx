<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reportuserdetails.aspx.cs" Inherits="NURacingWebsite.WebForm2" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" dir="ltr">


<head runat="server">
    <title>NURacing System - User Details Report</title>
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
						<li><a href="#"><span><span>Projects</span></span></a></li>
						<li><a href="#"><span><span>Tasks</span></span></a></li>
						<li><a href="#"><span><span>Purchase</span></span></a></li>
						<li><a href="#"><span><span>Account</span></span></a></li>
						<li><a href="#"><span><span>Reporting</span></span></a></li>
						<li><a href="#"><span><span>Idek Heading</span></span></a></li>
					</ul>
				</div>
		</div>
        <div id="colmask threecol">
        <div id ="col1">
    
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%" Height="650px">
            <LocalReport ReportPath="Reporting\UserReport.rdlc" ReportEmbeddedResource="NURacingWebsite.Reporting.UserReport.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="dsUSERS" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="DataAccessLayer.NuRacingDataSetTableAdapters.UserTableAdapter, DataAccessLayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null" UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_User_Username" Type="String" />
                <asp:Parameter Name="Original_User_PasswordHash" Type="String" />
                <asp:Parameter Name="Original_User_PasswordSalt" Type="String" />
                <asp:Parameter Name="Original_User_Role" Type="String" />
                <asp:Parameter Name="Original_User_Active" Type="Byte" />
                <asp:Parameter Name="Original_User_Surname" Type="String" />
                <asp:Parameter Name="Original_User_GivenName" Type="String" />
                <asp:Parameter Name="Original_User_Email" Type="String" />
                <asp:Parameter Name="Original_User_StudentNumber" Type="String" />
                <asp:Parameter Name="Original_User_EstGraduationYear" Type="String" />
                <asp:Parameter Name="Original_User_Degree" Type="String" />
                <asp:Parameter Name="Original_User_SAE_MemberNo" Type="String" />
                <asp:Parameter Name="Original_User_SAE_Expiry" Type="DateTime" />
                <asp:Parameter Name="Original_User_CAMS_MemberNo" Type="String" />
                <asp:Parameter Name="Original_User_CAMS_LicenseType" Type="String" />
                <asp:Parameter Name="Original_User_LicenseNo" Type="String" />
                <asp:Parameter Name="Original_User_LicenseState" Type="String" />
                <asp:Parameter Name="Original_User_EmergencyContactName" Type="String" />
                <asp:Parameter Name="Original_User_EmergencyContactNumber" Type="String" />
                <asp:Parameter Name="Original_User_MedicareNo" Type="String" />
                <asp:Parameter Name="Original_User_Allergies" Type="String" />
                <asp:Parameter Name="Original_User_DietaryRequirements" Type="String" />
                <asp:Parameter Name="Original_User_MedicalConditions" Type="String" />
                <asp:Parameter Name="Original_User_IndemnityFormSigned" Type="Byte" />
                <asp:Parameter Name="Original_User_Created" Type="DateTime" />
                <asp:Parameter Name="Original_User_LastLogin" Type="DateTime" />
                <asp:Parameter Name="Original_User_LastActivity" Type="DateTime" />
                <asp:Parameter Name="Original_User_LastPasswordChanged" Type="DateTime" />
                <asp:Parameter Name="Original_User_LastLockoutDate" Type="DateTime" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="User_Username" Type="String" />
                <asp:Parameter Name="User_PasswordHash" Type="String" />
                <asp:Parameter Name="User_PasswordSalt" Type="String" />
                <asp:Parameter Name="User_Role" Type="String" />
                <asp:Parameter Name="User_Active" Type="Byte" />
                <asp:Parameter Name="User_Surname" Type="String" />
                <asp:Parameter Name="User_GivenName" Type="String" />
                <asp:Parameter Name="User_Email" Type="String" />
                <asp:Parameter Name="User_StudentNumber" Type="String" />
                <asp:Parameter Name="User_EstGraduationYear" Type="String" />
                <asp:Parameter Name="User_Degree" Type="String" />
                <asp:Parameter Name="User_SAE_MemberNo" Type="String" />
                <asp:Parameter Name="User_SAE_Expiry" Type="DateTime" />
                <asp:Parameter Name="User_CAMS_MemberNo" Type="String" />
                <asp:Parameter Name="User_CAMS_LicenseType" Type="String" />
                <asp:Parameter Name="User_LicenseNo" Type="String" />
                <asp:Parameter Name="User_LicenseState" Type="String" />
                <asp:Parameter Name="User_EmergencyContactName" Type="String" />
                <asp:Parameter Name="User_EmergencyContactNumber" Type="String" />
                <asp:Parameter Name="User_MedicareNo" Type="String" />
                <asp:Parameter Name="User_Allergies" Type="String" />
                <asp:Parameter Name="User_DietaryRequirements" Type="String" />
                <asp:Parameter Name="User_MedicalConditions" Type="String" />
                <asp:Parameter Name="User_IndemnityFormSigned" Type="Byte" />
                <asp:Parameter Name="User_Created" Type="DateTime" />
                <asp:Parameter Name="User_LastLogin" Type="DateTime" />
                <asp:Parameter Name="User_LastActivity" Type="DateTime" />
                <asp:Parameter Name="User_LastPasswordChanged" Type="DateTime" />
                <asp:Parameter Name="User_LastLockoutDate" Type="DateTime" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="User_PasswordHash" Type="String" />
                <asp:Parameter Name="User_PasswordSalt" Type="String" />
                <asp:Parameter Name="User_Role" Type="String" />
                <asp:Parameter Name="User_Active" Type="Byte" />
                <asp:Parameter Name="User_Surname" Type="String" />
                <asp:Parameter Name="User_GivenName" Type="String" />
                <asp:Parameter Name="User_Email" Type="String" />
                <asp:Parameter Name="User_StudentNumber" Type="String" />
                <asp:Parameter Name="User_EstGraduationYear" Type="String" />
                <asp:Parameter Name="User_Degree" Type="String" />
                <asp:Parameter Name="User_SAE_MemberNo" Type="String" />
                <asp:Parameter Name="User_SAE_Expiry" Type="DateTime" />
                <asp:Parameter Name="User_CAMS_MemberNo" Type="String" />
                <asp:Parameter Name="User_CAMS_LicenseType" Type="String" />
                <asp:Parameter Name="User_LicenseNo" Type="String" />
                <asp:Parameter Name="User_LicenseState" Type="String" />
                <asp:Parameter Name="User_EmergencyContactName" Type="String" />
                <asp:Parameter Name="User_EmergencyContactNumber" Type="String" />
                <asp:Parameter Name="User_MedicareNo" Type="String" />
                <asp:Parameter Name="User_Allergies" Type="String" />
                <asp:Parameter Name="User_DietaryRequirements" Type="String" />
                <asp:Parameter Name="User_MedicalConditions" Type="String" />
                <asp:Parameter Name="User_IndemnityFormSigned" Type="Byte" />
                <asp:Parameter Name="User_Created" Type="DateTime" />
                <asp:Parameter Name="User_LastLogin" Type="DateTime" />
                <asp:Parameter Name="User_LastActivity" Type="DateTime" />
                <asp:Parameter Name="User_LastPasswordChanged" Type="DateTime" />
                <asp:Parameter Name="User_LastLockoutDate" Type="DateTime" />
                <asp:Parameter Name="Original_User_Username" Type="String" />
                <asp:Parameter Name="Original_User_PasswordHash" Type="String" />
                <asp:Parameter Name="Original_User_PasswordSalt" Type="String" />
                <asp:Parameter Name="Original_User_Role" Type="String" />
                <asp:Parameter Name="Original_User_Active" Type="Byte" />
                <asp:Parameter Name="Original_User_Surname" Type="String" />
                <asp:Parameter Name="Original_User_GivenName" Type="String" />
                <asp:Parameter Name="Original_User_Email" Type="String" />
                <asp:Parameter Name="Original_User_StudentNumber" Type="String" />
                <asp:Parameter Name="Original_User_EstGraduationYear" Type="String" />
                <asp:Parameter Name="Original_User_Degree" Type="String" />
                <asp:Parameter Name="Original_User_SAE_MemberNo" Type="String" />
                <asp:Parameter Name="Original_User_SAE_Expiry" Type="DateTime" />
                <asp:Parameter Name="Original_User_CAMS_MemberNo" Type="String" />
                <asp:Parameter Name="Original_User_CAMS_LicenseType" Type="String" />
                <asp:Parameter Name="Original_User_LicenseNo" Type="String" />
                <asp:Parameter Name="Original_User_LicenseState" Type="String" />
                <asp:Parameter Name="Original_User_EmergencyContactName" Type="String" />
                <asp:Parameter Name="Original_User_EmergencyContactNumber" Type="String" />
                <asp:Parameter Name="Original_User_MedicareNo" Type="String" />
                <asp:Parameter Name="Original_User_Allergies" Type="String" />
                <asp:Parameter Name="Original_User_DietaryRequirements" Type="String" />
                <asp:Parameter Name="Original_User_MedicalConditions" Type="String" />
                <asp:Parameter Name="Original_User_IndemnityFormSigned" Type="Byte" />
                <asp:Parameter Name="Original_User_Created" Type="DateTime" />
                <asp:Parameter Name="Original_User_LastLogin" Type="DateTime" />
                <asp:Parameter Name="Original_User_LastActivity" Type="DateTime" />
                <asp:Parameter Name="Original_User_LastPasswordChanged" Type="DateTime" />
                <asp:Parameter Name="Original_User_LastLockoutDate" Type="DateTime" />
            </UpdateParameters>
        </asp:ObjectDataSource>
    
    </div></div>
    </form>
</body>
</html>
