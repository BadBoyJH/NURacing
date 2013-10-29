<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reporttakefives.aspx.cs" Inherits="NURacingWebsite.reporttakefives" MasterPageFile ="~/Reporting.Master" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ContentPlaceHolderID="Title" ID="Title" runat="server">
    System - Workshop Report
</asp:Content>

<asp:Content ID ="Body" ContentPlaceHolderID ="Body" runat ="server">
    <form id="Report" runat="server">
        <div id="colmask threecol">
            <div id="col1">

                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%" Height="650px">
                    <LocalReport ReportPath="Reporting\TakeFiveReport.rdlc" ReportEmbeddedResource="NURacingWebsite.Reporting.TakeFiveReport.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource6" Name="dsTAKEFIVES" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>
                <asp:ObjectDataSource ID="ObjectDataSource6" runat="server" SelectMethod="GetData" TypeName="DataAccessLayer.NuRacingDataSetTableAdapters.CompleteTaskInfoTableAdapter" OldValuesParameterFormatString="original_{0}">
                </asp:ObjectDataSource>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>

            </div>
        </div>
    </form>
</asp:Content>