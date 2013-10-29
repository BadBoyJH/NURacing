<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reportuserdetails.aspx.cs" Inherits="NURacingWebsite.WebForm2" MasterPageFile="~/Reporting.Master" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ContentPlaceHolderID="Title" ID="Title" runat="server">
    NURacing System - User Details Report
</asp:Content>

<asp:Content ID ="Body" ContentPlaceHolderID ="Body" runat ="server">
    <form id="Report" runat ="server">
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
</asp:Content>
