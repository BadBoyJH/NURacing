<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reportsponsordetails.aspx.cs" Inherits="NURacingWebsite.WebForm3" MasterPageFile="~/Reporting.Master" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ContentPlaceHolderID="Title" ID="Title" runat="server">
    NURacing System - Sponsor Details Report 
</asp:Content>

<asp:Content ID ="Body" ContentPlaceHolderID ="Body" runat ="server">
    <form id="Report" runat ="server">
        <div id="colmask threecol">
        <div id ="col1">
    
      
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%" Height="650px">
            <LocalReport ReportPath="Reporting\SponsorReport.rdlc" ReportEmbeddedResource="NURacingWebsite.Reporting.SponsorReport.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="dsUSERS" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="DataAccessLayer.NuRacingDataSetTableAdapters.SponsorsTableAdapter">
        </asp:ObjectDataSource>
    
    </div></div>
    </form>
</asp:Content>
