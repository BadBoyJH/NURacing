<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="takefive.aspx.cs" Inherits="NURacingWebsite.takefive" MasterPageFile="~/LoggedIn.Master" %>

<asp:Content ContentPlaceHolderID="Title" ID="Title" runat="server">
    NURacing System - Purchase
</asp:Content>

<asp:Content ID="Body" ContentPlaceHolderID="Body" runat="server">
	<div class="colmask threecol">
	<div class="colmid">
		<div class="colleft">
			<div class="col1">

                    <br />
                    <br />
       <h1>TAKE FIVE</h1>
                    <p style="text-align: center"></p>
                <br />
                    <div class="taskDetail">
                     <form id ="Form1" runat="server" onsubmit="">

                         <p runat="server" id="takeFiveSubmit" class="submitLbl" visible="false">Take five submitted.</p>

                         <p>Which users? <br />
                             <asp:ListBox runat="server" ID="takeFiveUserLstBx"></asp:ListBox>
                         </p>

                         <p>Date completed: 
                             <asp:Calendar runat="server" ID="takeFiveCal"></asp:Calendar>
                         </p>

                         <p>Description: 
                             <asp:TextBox runat="server" ID="descTxtBx"></asp:TextBox>
                         </p>

                         <p>Minutes worked: 
                             <asp:TextBox runat="server" ID="minWordTxtBx"></asp:TextBox>
                         </p>

                         <p>Which work type? 
                             <asp:DropDownList runat="server" ID="tkfvWorktypeDrpList"></asp:DropDownList>
                         </p>

                         <p>Has the equipment/energy been isolated? <br />
                         <asp:RadioButton runat="server" ID="a1" GroupName="1" Text="Yes" />
                         <asp:RadioButton runat="server" ID="b1" GroupName="1" Text="No" OnCheckedChanged="b1_CheckedChanged"/>
                         <asp:RadioButton runat="server" ID="c1" GroupName="1" Text="N/A" />
                         <asp:TextBox runat="server" ID="reason1TxtBx"></asp:TextBox>    
                         <br />
                         </p>
                         <br />

                         <p>Have I checked that tools and equipment are in good order and tagged appropriately?<br />
                         <asp:RadioButton runat="server" ID="a2" GroupName="2" Text="Yes" />
                         <asp:RadioButton runat="server" ID="b2" GroupName="2" Text="No" OnCheckedChanged="b1_CheckedChanged"/>
                         <asp:RadioButton runat="server" ID="c2" GroupName="2" Text="N/A" />
                         <asp:TextBox runat="server" ID="reason2TxtBx"></asp:TextBox>
                         <br />
                         </p>
                         <br />

                         <p>Is housekeeping in the area acceptable for the task?<br />
                         <asp:RadioButton runat="server" ID="a3" GroupName="3" Text="Yes" />
                         <asp:RadioButton runat="server" ID="b3" GroupName="3" Text="No" OnCheckedChanged="b1_CheckedChanged"/>
                         <asp:RadioButton runat="server" ID="c3" GroupName="3" Text="N/A" /> 
                         <asp:TextBox runat="server" ID="reason3TxtBx"></asp:TextBox>    
                         <br />
                         </p>
                         <br />

                         <p>Is the appropriate barricading for the task in place?<br />
                         <asp:RadioButton runat="server" ID="a4" GroupName="4" Text="Yes" />
                         <asp:RadioButton runat="server" ID="b4" GroupName="4" Text="No" OnCheckedChanged="b1_CheckedChanged"/>
                         <asp:RadioButton runat="server" ID="c4" GroupName="4" Text="N/A" /> 
                         <asp:TextBox runat="server" ID="reason4TxtBx"></asp:TextBox>                                 
                         <br />
                         </p>
                         <br />

                         <p>Have I communicated with other workgroups in the area?<br />
                         <asp:RadioButton runat="server" ID="a5" GroupName="5" Text="Yes" />
                         <asp:RadioButton runat="server" ID="b5" GroupName="5" Text="No" OnCheckedChanged="b1_CheckedChanged"/>
                         <asp:RadioButton runat="server" ID="c5" GroupName="5" Text="N/A" /> 
                         <asp:TextBox runat="server" ID="reason5TxtBx"></asp:TextBox>                                                          
                         <br />
                         </p>
                         <br />

                         <p>Am I fatigued or unfit for this task?<br />
                         <asp:RadioButton runat="server" ID="a6" GroupName="6" Text="Yes"  OnCheckedChanged="b1_CheckedChanged"/>
                         <asp:RadioButton runat="server" ID="b6" GroupName="6" Text="No" />
                         <asp:RadioButton runat="server" ID="c6" GroupName="6" Text="N/A" /> 
                         <asp:TextBox runat="server" ID="reason6TxtBx"></asp:TextBox>                                 
                         <br />
                         </p>
                         <br />

                         <p>Does this task involve manual handling?<br />
                         <asp:RadioButton runat="server" ID="a7" GroupName="7" Text="Yes" OnCheckedChanged="b1_CheckedChanged" />
                         <asp:RadioButton runat="server" ID="b7" GroupName="7" Text="No" />
                         <asp:RadioButton runat="server" ID="c7" GroupName="7" Text="N/A" /> 
                         <asp:TextBox runat="server" ID="reason7TxtBx"></asp:TextBox>                                 
                         <br />
                         </p>
                         <br />

                         <p>Am I using the correct PPE for the task?<br />
                         <asp:RadioButton runat="server" ID="a8" GroupName="8" Text="Yes" />
                         <asp:RadioButton runat="server" ID="b8" GroupName="8" Text="No" OnCheckedChanged="b1_CheckedChanged"/>
                         <asp:RadioButton runat="server" ID="c8" GroupName="8" Text="N/A" /> 
                         <asp:TextBox runat="server" ID="reason8TxtBx"></asp:TextBox> 
                         <br />
                         </p>
                         <br />

                         <p>Are extreme weather conditions going to affect me or the job?<br />
                         <asp:RadioButton runat="server" ID="a9" GroupName="9" Text="Yes" OnCheckedChanged="b1_CheckedChanged" />
                         <asp:RadioButton runat="server" ID="b9" GroupName="9" Text="No" />
                         <asp:RadioButton runat="server" ID="c9" GroupName="9" Text="N/A" /> 
                         <asp:TextBox runat="server" ID="reason9TxtBx"></asp:TextBox> 
                         <br />
                         </p>
                         <br />

                         <p>Am I familiar with the equipment?<br />
                         <asp:RadioButton runat="server" ID="a10" GroupName="10" Text="Yes" />
                         <asp:RadioButton runat="server" ID="b10" GroupName="10" Text="No" OnCheckedChanged="b1_CheckedChanged"/>
                         <asp:RadioButton runat="server" ID="c10" GroupName="10" Text="N/A" /> 
                         <asp:TextBox runat="server" ID="reason10TxtBx"></asp:TextBox> 
                         <br />
                         </p>
                         <br />

                         <p>Is my workgroup familiar with the task?<br />
                         <asp:RadioButton runat="server" ID="a11" GroupName="11" Text="Yes" />
                         <asp:RadioButton runat="server" ID="b11" GroupName="11" Text="No" OnCheckedChanged="b1_CheckedChanged"/>
                         <asp:RadioButton runat="server" ID="c11" GroupName="11" Text="N/A" /> 
                         <asp:TextBox runat="server" ID="reason11TxtBx"></asp:TextBox> 
                         <br />
                         </p>
                         <br />

                         <p>Have any conditions changed eg plant, weather?<br />
                         <asp:RadioButton runat="server" ID="a12" GroupName="12" Text="Yes"  OnCheckedChanged="b1_CheckedChanged" />
                         <asp:RadioButton runat="server" ID="b12" GroupName="12" Text="No" />
                         <asp:RadioButton runat="server" ID="c12" GroupName="12" Text="N/A" /> 
                         <asp:TextBox runat="server" ID="reason12TxtBx"></asp:TextBox> 
                         <br />
                         </p>
                         <br />

                         <p>If generating excessive noise, dust, dirty water or waste, are the appropriate environmental controls in place?<br />
                         <asp:RadioButton runat="server" ID="a13" GroupName="13" Text="Yes" />
                         <asp:RadioButton runat="server" ID="b13" GroupName="13" Text="No" OnCheckedChanged="b1_CheckedChanged"/>
                         <asp:RadioButton runat="server" ID="c13" GroupName="13" Text="N/A" /> 
                         <asp:TextBox runat="server" ID="reason13TxtBx"></asp:TextBox> 
                         <br />
                         </p>
                         <br />

                         <!--<p>Purchase good: <asp:TextBox runat="server" ID="goodTxtBx"></asp:TextBox></p>
                         <p>Work type: <asp:DropDownList runat="server" ID="workTypeDrpList"></asp:DropDownList></p>
                         <p>Price: <asp:TextBox runat="server" ID="priceTxtBx"></asp:TextBox></p>
                         <p>Supplier: <asp:TextBox runat="server" ID="suppTxtBx"></asp:TextBox></p>-->
                         <asp:Button runat="server" ID="submitTakefiveBtn" CssClass="takeFiveBtn" Text="SUBMIT" OnClientClick="return checkTakeFive();" OnClick="submitTakefiveBtn_Click" />
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

