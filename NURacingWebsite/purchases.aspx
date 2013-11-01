<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="purchases.aspx.cs" Inherits="NURacingWebsite.purchase" MasterPageFile="~/LoggedIn.Master" %>

<asp:Content ContentPlaceHolderID="Title" ID="Title" runat="server">
    NURacing System - Purchase
</asp:Content>

<asp:Content ID="Body" ContentPlaceHolderID="Body" runat="server">
    <div class="colmask threecol">
        <div class="colmid">
            <div class="colleft">
                <div class="col1">
                    <form id="Form2" runat="server">
                        <br />
                        <br />
                        <asp:Button ID="btnEnquiry" runat="server" Text="?" CssClass="btnEnquiry" />
                        <p style="text-align: center; clear: both;"></p>
                        <h1>PURCHASE</h1>
                        <p>Please fill out the details of goods purchased below.</p>
                        <br />
                        <div class="taskDetail">
                            <p>Purchased Good:
                                <asp:TextBox runat="server" ID="goodTxtBx" CssClass="textareaPassword"></asp:TextBox></p>
                            <p>Project Section:
                                <asp:DropDownList runat="server" ID="workTypeDrpList"></asp:DropDownList></p>
                            <p>Price:
                                <asp:TextBox runat="server" ID="priceTxtBx" CssClass="textareaPassword"></asp:TextBox></p>
                            <p>Supplier:
                                <asp:TextBox runat="server" ID="suppTxtBx" CssClass="textareaPassword"></asp:TextBox></p>
                            <p>Date Purchased: <asp:Te
                            </p>
                            <asp:Button runat="server" ID="purchaseBtn" CssClass="takeFiveBtn" Text="SUBMIT" OnClick="purchaseBtn_Click" />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />



                        </div>
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
