<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reportlabourlog.aspx.cs" Inherits="NURacingWebsite.reportlabourlog" MasterPageFile ="~/LoggedIn.Master" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ContentPlaceHolderID="Title" ID="Title" runat="server">
    System - Labour Log Report
</asp:Content>

<asp:Content ID ="Body" ContentPlaceHolderID ="Body" runat ="server">
    <form id="Report" runat="server">
        <div id="colmask threecol">
            <div id="col1">

                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%" Height="650px">
                    <LocalReport ReportPath="Reporting\LabourReport.rdlc" ReportEmbeddedResource="NURacingWebsite.Reporting.LabourReport.rdlc">
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

            </div>
        </div>
    </form>
</asp:Content>