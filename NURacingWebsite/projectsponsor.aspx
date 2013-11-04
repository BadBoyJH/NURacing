<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="projectsponsor.aspx.cs" Inherits="NURacingWebsite.projectsponsors" MasterPageFile="~/LoggedIn.Master" %>

<asp:Content ContentPlaceHolderID="Title" ID="Title" runat="server">
    NURacing System - Sponsor Management
</asp:Content>

<asp:Content ContentPlaceHolderID="Body" ID="Body" runat="server">
    <div class="colmask threecol">
        <div class="colmid">
            <div class="colleft">
                <div class="col1">

                    <form id="Form1" runat="server">
                        <br />
                        <br />
                        <asp:Button ID="btnEnquiry" runat="server" Text="?" CssClass="btnEnquiry" />

                        <p style="text-align: center; clear: both;"></p>

                        <h1>SPONSOR MANAGEMENT</h1>
                        <h2 id="ProjectName" runat="server"></h2>

                        <div id="hasSponsors" runat="server">
                            <p>These are the sponsors for your project:</p>
                            <asp:BulletedList ID="SponsorList" runat="server" />
                        </div>
                        <div id="noSponsors" runat="server">
                            <p>Your Project currently has no sponsors.</p>
                        </div>
                        <br />
                        <asp:Button ID="btnAddSponsor" CssClass="takeFiveBtn" Text="ADD SPONSOR" runat="server" OnClick="btnAddSponsor_Click" />
                        <asp:Button ID="btnRemoveSponsor" CssClass="takeFiveBtn" Text="REMOVE SPONSOR" runat="server" OnClick="btnRemoveSponsor_Click" />
                        <br />

                        <div id="divAddSponsor" runat="server" visible ="false">
                            <p>
                                <asp:DropDownList runat="server" ID="ddlAddSponsor" BackColor = "#2D2D2D" ForeColor = "#7E7E7E" Font-Names = "Lucida Sans Unicode" Font-Size = "11" Height = "25px" Width="200px" />
                            </p>
                            <p>
                                <asp:Button ID="btnSubmitAdd" CssClass="takeFiveBtn" Text="SUBMIT" runat="server" OnClick="btnSubmitAdd_Click" />
                            </p>
                        </div>
                        
                        <div id="divRemoveSponsor" runat="server" visible ="false">
                            <p>
                                <asp:DropDownList runat="server" ID="ddlRemoveSponsor" BackColor = "#2D2D2D" ForeColor = "#7E7E7E" Font-Names = "Lucida Sans Unicode" Font-Size = "11" Height = "25px" Width="200px" />
                            </p>
                            <p>                            
                                <asp:Button ID="btnSubmitRemove" CssClass="takeFiveBtn" Text="SUBMIT" runat="server" OnClick="btnSubmitRemove_Click" />
                            </p>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
