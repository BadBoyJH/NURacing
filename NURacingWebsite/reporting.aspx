<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reporting.aspx.cs" Inherits="NURacingWebsite.reporting" MasterPageFile="~/LoggedIn.Master" %>

<asp:Content ID="Title" ContentPlaceHolderID="Title" runat="server">
    NURacing System - Reporting
</asp:Content>

<asp:Content ContentPlaceHolderID="Scripts" ID="Scripts" runat="server">
    <script type="text/javascript">
        function showHelp() {
            alert("Here, you can view the different reporting sections. Click on a section to view the report.");
            return false;
        }
    </script>
</asp:Content>

<asp:Content ID="Body" ContentPlaceHolderID="Body" runat="server">

    <div class="colmask threecol">
        <div class="colmid">
            <div class="colleft">
                <div class="col1">

                    <br />
                    <br />
                    <form id="Form1" runat="server" style="text-align: center;">
                        <asp:Button ID="btnEnquiry" runat="server" Text="?" CssClass="btnEnquiry" OnClientClick="return showHelp()" />
                        <p style="text-align: center; clear: both;"></p>
                        <h1 style="text-align: center;">REPORTS</h1>

                        <p style="text-align: center">Please click on a report title to view.</p>
                        <br />

                        <asp:Table ID="reportTable" runat="server" GridLines="Horizontal" CssClass="tblReports" HorizontalAlign="Center">
                            <asp:TableRow ID="UserDetailsReport" runat="server">
                                <asp:TableCell BorderColor="Black" BorderStyle="None">
                                    <a href="\Reporting\reportuserdetails.aspx">
                                        <asp:Label runat="server" ID="Label10" CssClass="projectIcon">2</asp:Label>
                                        <asp:Label runat="server" ID="Label1" CssClass="projectName">User Details Report</asp:Label>
                                    </a>
                                </asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow ID ="SponsorDetailsReport" runat ="server">
                                <asp:TableCell BorderColor="Black" BorderStyle="None">
                                    <a href="\Reporting\reportsponsordetails.aspx">
                                        <asp:Label runat="server" ID="Label11" CssClass="projectIcon">2</asp:Label>
                                        <asp:Label runat="server" ID="Label12" CssClass="projectName">Sponsor Details Report</asp:Label>
                                    </a>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow ID ="ProjectStatusReport" runat ="server">
                                <asp:TableCell BorderColor="Black" BorderStyle="None">
                                    <a href="\Reporting\reportprojectstatus.aspx">
                                        <asp:Label runat="server" ID="Label9" CssClass="projectIcon">2</asp:Label>
                                        <asp:Label runat="server" ID="Label2" CssClass="projectName">Project Status Report</asp:Label>
                                    </a>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow ID ="LabourLogReport" runat ="server">
                                <asp:TableCell BorderColor="Black" BorderStyle="None">
                                    <a href="\Reporting\reportlabourlog.aspx">
                                        <asp:Label runat="server" ID="Label8" CssClass="projectIcon">2</asp:Label>
                                        <asp:Label runat="server" ID="Label4" CssClass="projectName">Labour Logging Report</asp:Label>
                                    </a>
                                </asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow ID ="PurchasingReport" runat ="server">
                                <asp:TableCell BorderColor="Black" BorderStyle="None">
                                    <a href="\Reporting\reportpurchasing.aspx">
                                        <asp:Label runat="server" ID="Label13" CssClass="projectIcon">2</asp:Label>
                                        <asp:Label runat="server" ID="Label14" CssClass="projectName">Purchasing Report</asp:Label>
                                    </a>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow ID ="WorkshopReport" runat ="server">
                                <asp:TableCell BorderColor="Black" BorderStyle="None">
                                    <a href="\Reporting\reportworkshop.aspx">
                                        <asp:Label runat="server" ID="Label7" CssClass="projectIcon">2</asp:Label>
                                        <asp:Label runat="server" ID="Label3" CssClass="projectName">Workshop Report</asp:Label>
                                    </a>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow ID ="TakeFiveReport" runat ="server">
                                <asp:TableCell BorderColor="Black" BorderStyle="None">
                                    <a href="\Reporting\reporttakefives.aspx">
                                        <asp:Label runat="server" ID="Label6" CssClass="projectIcon">2</asp:Label>
                                        <asp:Label runat="server" ID="Label5" CssClass="projectName">Take Five Report</asp:Label>
                                    </a>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <br />
                    </form>

                </div>
                <div class="col2">
                </div>
                <div class="col3">
                </div>

            </div>
        </div>
    </div>
</asp:Content>
