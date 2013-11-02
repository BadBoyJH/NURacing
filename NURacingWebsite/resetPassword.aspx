<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="resetPassword.aspx.cs" Inherits="NURacingWebsite.resetPassword"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" dir="ltr" lang="en-US">

<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>NURacing System - Password Reset</title>
    <link rel="icon" type="image/png" href="NURacing_Favicon.ico" />

    <link rel="stylesheet" media="all" href="css/style.css" />
    <link href='http://fonts.googleapis.com/css?family=Cuprum' rel='stylesheet' type='text/css' />
    <link href='http://fonts.googleapis.com/css?family=Oswald' rel='stylesheet' type='text/css' />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
</head>

<body id="Body1" lang="en" runat="server">


    <div id="topBarMenu">
        <div id="topMenu">
            <ul>
                <li><a href="#" style="TEXT-DECORATION: NONE;"><span>TA Building, School of Engineering, University of Newcastle, Callaghan NSW 2308 &nbsp; &#149;&nbsp; (02) 4925 4937 &nbsp; &#149;&nbsp; <%= DateTime.Now.ToString() %></span></a></li>
            </ul>
        </div>
    </div>

    <div class="colmask threecol">
        <div class="colmid">
            <div class="colleft">
                <div class="col1">
                    <br />
                    <br />
                    <div id="resetHeader" runat="server">
                        <h1>Reset Password</h1>
                    </div>

                    <div id="resetSuccess" runat="server">
                        <h2>Please check your email for password reset confirmation.</h2>
                        <br />
                        <h2>Redirecting to login in 5 seconds...</h2>
                    </div>

                    <div id="resetFail" runat="server">
                        <h2>Supplied username and email don't match, please try again.</h2>
                    </div>

                    <form id="passwordResetFrm" runat="server">
                        <div id="resetPassword">
                            <asp:Label runat="server" ID="usernameLbl" CssClass="userRole">Username: </asp:Label>
                            <asp:TextBox runat="server" ID="usernameTxtBx" CssClass="textareaPassword"></asp:TextBox>
                            <br />
                            <asp:Label runat="server" ID="emailLbl" CssClass="userRole">Email: </asp:Label>
                            <asp:TextBox runat="server" ID="emailTxtBx" CssClass="textareaPassword"></asp:TextBox>
                            <br />
                            <asp:Button runat="server" ID="resetPasswordBtn" CssClass="takeFiveBtn" Text="RESET" OnClick="resetPasswordBtn_Click" />
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

    <div id="footer">
        <h5><a href="http://www.newcastle.edu.au/">
            <img id="Img1" src="Images/logo2.png" alt="University of Newcastle" style="margin-right: 30px; vertical-align: middle;" /></a>© NURacing, 2013 &nbsp;&#149;&nbsp; 
        <a href="http://www.eng.newcastle.edu.au/~fsae/">Website</a> &nbsp;&#149;&nbsp; <a href="https://www.facebook.com/groups/403657373086331/">Discussion Board</a> &nbsp;&#149;&nbsp; 
         <a href="http://www.saea.com.au/formula-sae-a/">FSAE</a> &nbsp;&#149;&nbsp; <a href="mailto:nuracinghelpdesk@gmail.com?Subject=NURacing%20Application%20Support%20Request">Support</a></h5>
    </div>


</body>
</html>
