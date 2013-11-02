<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="NURacingWebsite.WebForm1" MasterPageFile="~/LoggedIn.Master" %>

<asp:Content ID="Title" ContentPlaceHolderID="Title" runat="server">
    NURacing System - Projects
</asp:Content>

<asp:Content ID="Body" ContentPlaceHolderID="Body" runat="server">

    <div class="colmask threecol">
        <div class="colmid">
            <div class="colleft">
                <div class="col1">
                    <form id="Form1" runat="server">
                        <br />
                        <br />
                        <asp:Button ID="btnEnquiry" runat="server" Text="?" CssClass="btnEnquiry" />
                        <p style="text-align: center; clear: both;"></p>
                        <h1>PROJECTS</h1>

                        <p style="text-align: center;">Please click on a project below to review progress.</p>
                        <br />
                        
                        <asp:Button runat="server" ID="createProjBtn" Text="MANAGE PROJECTS" CssClass="takeFiveBtn" OnClick="createProjBtn_Click" />
                        <p style="text-align: center; clear: both;"></p>
                        <asp:Table ID="tblProjects" runat="server" GridLines="Horizontal" CssClass="tblProjects" class="tblProjects" HorizontalAlign="Center">
                        </asp:Table>
                        <asp:Button runat="server" ID="showInactiveProjBtn" Text ="SHOW INACTIVE PROJECTS" CssClass="takeFiveBtn" OnClick="showInactiveProjBtn_Click" />
                    </form>
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
