<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="purchase.aspx.cs" Inherits="NURacingWebsite.purchase" MasterPageFile="~/LoggedIn.Master" %>

<asp:Content ContentPlaceHolderID="Title" ID="Title" runat="server">
    NURacing System - Account
</asp:Content>

<asp:Content ID="Body" ContentPlaceHolderID="Body" runat="server">
	<div class="colmask threecol">
	<div class="colmid">
		<div class="colleft">
			<div class="col1">

                    <br />
                    <br />
       <h1>PURCHASE</h1>
                    <p style="text-align: center"></p>
                <br />
                    <div class="taskDetail">
                     <form id ="Form1" runat="server">
                         <p>Purchase good: <asp:TextBox runat="server" ID="goodTxtBx"></asp:TextBox></p>
                         <p>Work type: <asp:DropDownList runat="server" ID="workTypeDrpList"></asp:DropDownList></p>
                         <p>Price: <asp:TextBox runat="server" ID="priceTxtBx"></asp:TextBox></p>
                         <p>Supplier: <asp:TextBox runat="server" ID="suppTxtBx"></asp:TextBox></p>
                         <asp:Button runat="server" ID="purchaseBtn" CssClass="takeFiveBtn" Text="SUBMIT" OnClick="purchaseBtn_Click"/>
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                         

                         </form>
                    </div>
    </div>
			<div class="col2">
			</div>
			<div class="col3">
			</div>
 
		</div>
	</div>
 </div>
</asp:Content>
