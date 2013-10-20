<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reporting.aspx.cs" Inherits="NURacingWebsite.reporting" MasterPageFile ="~/LoggedIn.Master"%>

<asp:Content ID ="Title" ContentPlaceHolderID = "Title" runat = "server">
    NURacing System - Account
</asp:Content>

<asp:Content ID="Body" ContentPlaceHolderID="Body" runat="server">

    <div class="colmask threecol">
        <div class="colmid">
            <div class="colleft">
                <div class="col1">

                    <br />
                    <br />
                    <h1>REPORTS</h1>

                    <p style="text-align: center">Please click on a report title to view.</p>
                    <asp:Table ID="projectTable" runat="server" GridLines="Horizontal" CssClass="tblProjects" HorizontalAlign="Center" Height="10px" Width="250px">
                        <asp:TableRow>
                            <asp:TableCell BorderColor="Black" BorderStyle="None">
                                <a href="\reportuserdetails.aspx">
                                    <asp:Label runat="server" ID="Label1" CssClass="projectName">User Details Report <br /> <br /></asp:Label>
                                </a>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell BorderColor="Black" BorderStyle="None">
                                <a href="\reportprojectstatus.aspx">
                                    <asp:Label runat="server" ID="Label2" CssClass="projectName">Project Status Report <br /> <br /></asp:Label>
                                </a>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell BorderColor="Black" BorderStyle="None">
                                <a href="\reportlabourlog.aspx">
                                    <asp:Label runat="server" ID="Label4" CssClass="projectName">Labour Logging Report <br /> <br /></asp:Label>
                                </a>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <br />


                </div>
                <div class="col2">
                </div>
                <div class="col3">
                </div>

            </div>
        </div>
    </div>
</asp:Content>
