<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="takefive.aspx.cs" Inherits="NURacingWebsite.takefive" MasterPageFile="~/LoggedIn.Master" %>

<asp:Content ContentPlaceHolderID="Title" ID="Title" runat="server">
    NURacing System - Take Five
</asp:Content>

<asp:Content ContentPlaceHolderID="Scripts" ID="Scripts" runat="server">
    <script type="text/javascript">
        var startHeight;

        function showTakeFive()
        {
            document.getElementById("TakeFiveDiv").style.visibility = "visible";
            document.getElementById("TakeFiveDiv").style.height = startHeight;
        }
 
        function hideTakeFive()
        {
            document.getElementById("TakeFiveDiv").style.visibility = "hidden";
            document.getElementById("TakeFiveDiv").style.height = 0;
        }

        window.onload = function ()
        {
            if (!document.getElementById("Body_takeFiveYes").checked)
            {
                document.getElementById("TakeFiveDiv").style.visibility = "hidden";
                startHeight = document.getElementById("TakeFiveDiv").style.height;
                document.getElementById("TakeFiveDiv").style.height = 0;
            }
            else
            {
                document.getElementById("TakeFiveDiv").style.visibility = "visible";
            }
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
       <h1>TAKE FIVE</h1>
                    <p style="text-align: center"></p>
                <br />
                    <div class="taskDetail">
                     <form id ="Form1" runat="server" onsubmit="">

                         <p runat="server" id="takeFiveSubmit" class="pUserFeedbackPass" visible="false">Take five submitted.</p>

                         <p runat="server" id="taskInfo" visible="false"></p><br />

                         <p>Minutes Worked: 
                             <asp:TextBox runat="server" ID="minWordTxtBx" CssClass="textareaPassword" Width="50px" ></asp:TextBox>
                         </p>

                          <center><table><tr><td width="125px" style="vertical-align: top;"><p>Details of Work:  </p></td><td ><asp:TextBox runat="server" ID="descTxtBx" CssClass="textareaPassword" TextMode="MultiLine" Width="400px" Height="100px"></asp:TextBox></td></tr></table></center>
                        

                         <center><table><tr><td style="vertical-align: top;"><p>Date Completed: </p></td><td style="background-color:#2D2D2D;" ><asp:Calendar runat="server" ID="takeFiveCal" CssClass="dtTmPckrFormat"></asp:Calendar></td></tr></table></center>
                 <br />
                          <p>Other Users Involved (optional): <br />
                             <asp:ListBox runat="server" ID="takeFiveUserLstBx" CssClass="textareaPassword" Width="200px"></asp:ListBox>
                         </p>

                         


                         
                         <p>

                             <br />
                             Take Five Completed: 
                             <br />
                             <asp:RadioButton onclick="showTakeFive()" ID ="takeFiveYes" runat ="server" GroupName="TakeFiveControl" Text="Yes" />
                             <asp:RadioButton onclick="hideTakeFive()" ID ="takeFiveNo" runat ="server" GroupName="TakeFiveControl" Text="No" />

                             <br />
                             <br />
                         </p>

                         <div id="TakeFiveDiv" style="visibility:collapse">
                         <p>Has the equipment/energy been isolated? <br />
                         <asp:RadioButton runat="server" ID="a1" GroupName="1" Text="Yes" />
                         <asp:RadioButton runat="server" ID="b1" GroupName="1" Text="No" OnCheckedChanged="b1_CheckedChanged"/>
                         <asp:RadioButton runat="server" ID="c1" GroupName="1" Text="N/A" checked="true"/>
                         <asp:TextBox runat="server" ID="reason1TxtBx" CssClass="textareaPassword"></asp:TextBox>    
                         <br />
                         </p>
                         <br />

                         <p>Have you checked that tools and equipment are in good order and tagged appropriately?<br />
                         <asp:RadioButton runat="server" ID="a2" GroupName="2" Text="Yes" />
                         <asp:RadioButton runat="server" ID="b2" GroupName="2" Text="No" OnCheckedChanged="b1_CheckedChanged"/>
                         <asp:RadioButton runat="server" ID="c2" GroupName="2" Text="N/A" checked="true"/>
                         <asp:TextBox runat="server" ID="reason2TxtBx" CssClass="textareaPassword"></asp:TextBox>
                         <br />
                         </p>
                         <br />

                         <p>Is housekeeping in the area acceptable for the task?<br />
                         <asp:RadioButton runat="server" ID="a3" GroupName="3" Text="Yes" />
                         <asp:RadioButton runat="server" ID="b3" GroupName="3" Text="No" OnCheckedChanged="b1_CheckedChanged"/>
                         <asp:RadioButton runat="server" ID="c3" GroupName="3" Text="N/A" checked="true"/> 
                         <asp:TextBox runat="server" ID="reason3TxtBx" CssClass="textareaPassword"></asp:TextBox>    
                         <br />
                         </p>
                         <br />

                         <p>Is the appropriate barricading for the task in place?<br />
                         <asp:RadioButton runat="server" ID="a4" GroupName="4" Text="Yes" />
                         <asp:RadioButton runat="server" ID="b4" GroupName="4" Text="No" OnCheckedChanged="b1_CheckedChanged"/>
                         <asp:RadioButton runat="server" ID="c4" GroupName="4" Text="N/A" checked="true"/> 
                         <asp:TextBox runat="server" ID="reason4TxtBx" CssClass="textareaPassword"></asp:TextBox>                                 
                         <br />
                         </p>
                         <br />

                         <p>Have you communicated with other workgroups in the area?<br />
                         <asp:RadioButton runat="server" ID="a5" GroupName="5" Text="Yes" />
                         <asp:RadioButton runat="server" ID="b5" GroupName="5" Text="No" OnCheckedChanged="b1_CheckedChanged"/>
                         <asp:RadioButton runat="server" ID="c5" GroupName="5" Text="N/A" checked="true"/> 
                         <asp:TextBox runat="server" ID="reason5TxtBx" CssClass="textareaPassword"></asp:TextBox>                                                          
                         <br />
                         </p>
                         <br />

                         <p>Are you fatigued or unfit for this task?<br />
                         <asp:RadioButton runat="server" ID="a6" GroupName="6" Text="Yes"  OnCheckedChanged="b1_CheckedChanged"/>
                         <asp:RadioButton runat="server" ID="b6" GroupName="6" Text="No" />
                         <asp:RadioButton runat="server" ID="c6" GroupName="6" Text="N/A" checked="true"/> 
                         <asp:TextBox runat="server" ID="reason6TxtBx" CssClass="textareaPassword"></asp:TextBox>                                 
                         <br />
                         </p>
                         <br />

                         <p>Does this task involve manual handling?<br />
                         <asp:RadioButton runat="server" ID="a7" GroupName="7" Text="Yes" OnCheckedChanged="b1_CheckedChanged" />
                         <asp:RadioButton runat="server" ID="b7" GroupName="7" Text="No" />
                         <asp:RadioButton runat="server" ID="c7" GroupName="7" Text="N/A" checked="true"/> 
                         <asp:TextBox runat="server" ID="reason7TxtBx" CssClass="textareaPassword"></asp:TextBox>                                 
                         <br />
                         </p>
                         <br />

                         <p>Are you using the correct PPE for the task?<br />
                         <asp:RadioButton runat="server" ID="a8" GroupName="8" Text="Yes" />
                         <asp:RadioButton runat="server" ID="b8" GroupName="8" Text="No" OnCheckedChanged="b1_CheckedChanged"/>
                         <asp:RadioButton runat="server" ID="c8" GroupName="8" Text="N/A" checked="true"/> 
                         <asp:TextBox runat="server" ID="reason8TxtBx" CssClass="textareaPassword"></asp:TextBox> 
                         <br />
                         </p>
                         <br />

                         <p>Are extreme weather conditions going to affect you or the job?<br />
                         <asp:RadioButton runat="server" ID="a9" GroupName="9" Text="Yes" OnCheckedChanged="b1_CheckedChanged" />
                         <asp:RadioButton runat="server" ID="b9" GroupName="9" Text="No" />
                         <asp:RadioButton runat="server" ID="c9" GroupName="9" Text="N/A" checked="true"/> 
                         <asp:TextBox runat="server" ID="reason9TxtBx" CssClass="textareaPassword"></asp:TextBox> 
                         <br />
                         </p>
                         <br />

                         <p>Are you familiar with the equipment?<br />
                         <asp:RadioButton runat="server" ID="a10" GroupName="10" Text="Yes" />
                         <asp:RadioButton runat="server" ID="b10" GroupName="10" Text="No" OnCheckedChanged="b1_CheckedChanged"/>
                         <asp:RadioButton runat="server" ID="c10" GroupName="10" Text="N/A" checked="true"/> 
                         <asp:TextBox runat="server" ID="reason10TxtBx" CssClass="textareaPassword"></asp:TextBox> 
                         <br />
                         </p>
                         <br />

                         <p>Is your workgroup familiar with the task?<br />
                         <asp:RadioButton runat="server" ID="a11" GroupName="11" Text="Yes" />
                         <asp:RadioButton runat="server" ID="b11" GroupName="11" Text="No" OnCheckedChanged="b1_CheckedChanged"/>
                         <asp:RadioButton runat="server" ID="c11" GroupName="11" Text="N/A" checked="true"/> 
                         <asp:TextBox runat="server" ID="reason11TxtBx" CssClass="textareaPassword"></asp:TextBox> 
                         <br />
                         </p>
                         <br />

                         <p>Have any conditions changed (i.e. plant, weather, etc)?<br />
                         <asp:RadioButton runat="server" ID="a12" GroupName="12" Text="Yes"  OnCheckedChanged="b1_CheckedChanged" />
                         <asp:RadioButton runat="server" ID="b12" GroupName="12" Text="No" />
                         <asp:RadioButton runat="server" ID="c12" GroupName="12" Text="N/A" checked="true"/> 
                         <asp:TextBox runat="server" ID="reason12TxtBx" CssClass="textareaPassword"></asp:TextBox> 
                         <br />
                         </p>
                         <br />

                         <p>If generating excessive noise, dust, dirty water or waste, are the appropriate environmental controls in place?<br />
                         <asp:RadioButton runat="server" ID="a13" GroupName="13" Text="Yes" />
                         <asp:RadioButton runat="server" ID="b13" GroupName="13" Text="No" OnCheckedChanged="b1_CheckedChanged"/>
                         <asp:RadioButton runat="server" ID="c13" GroupName="13" Text="N/A" checked="true"/> 
                         <asp:TextBox runat="server" ID="reason13TxtBx" CssClass="textareaPassword"></asp:TextBox> 
                         <br />
                         </p>
                         <br />
                         </div>

                         
                         <asp:Button runat="server" ID="submitTakefiveBtn" CssClass="takeFiveBtn" Text="SUBMIT" OnClientClick="return checkTakeFive();" OnClick="submitTakefiveBtn_Click" />
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

