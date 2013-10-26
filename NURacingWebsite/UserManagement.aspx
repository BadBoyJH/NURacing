<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserManagement.aspx.cs" Inherits="NURacingWebsite.UserManagement" MasterPageFile="~/LoggedIn.Master" %>

<asp:Content ContentPlaceHolderID="Body" runat ="server">
	<div class="colmask threecol">
	<div class="colmid">
		<div class="colleft">
			<div class="col1">

                    <br />
                    <br />

       <h1>USER MANAGEMENT</h1>
                    <p style="text-align: center">Please click an action below</p>
                <br />
                    <div class="taskDetail">
                        <form id="frmLayout" runat="server">
                            <asp:Button ID="btnUpdateUser" CssClass="takeFiveBtn" Text="Update User" runat="server" OnClick="btnUpdateUser_Click" />
                            <asp:Button ID="btnCreateUser" CssClass="takeFiveBtn" Text="Create User" runat="server" OnClick="btnCreateUser_Click" />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                        <div class="taskMngement">
                        <asp:PlaceHolder runat="server" ID="createUserFrm" Visible="false"></asp:PlaceHolder>
                            <asp:Button runat="server" ID="createUserSubmitBtn" Visible="false" OnClick="submitCreateUserBtn_Click" CssClass="takeFiveBtn" Text="SUBMIT"/>
                            <asp:Button runat="server" ID="updateUserSubmitBtn" Visible="false" OnClick="submitUpdateUserBtn_Click" CssClass="takeFiveBtn" Text="TEST"/>

                            </div>
                        <%-- <asp:Label id="createUserFrm" runat="server" CssClass="taskMngement"></asp:Label>--%>

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
