﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using BusinessLogicLayer;
using System.Web.Security;

namespace NURacingWebsite
{
    public partial class UserManagement : System.Web.UI.Page
    {
        Label LblUserName = new Label();
        TextBox userNameTxtBx = new TextBox();
        HtmlGenericControl passwordDiv = new HtmlGenericControl();
        HtmlGenericControl studentInfoDiv = new HtmlGenericControl();
        HtmlGenericControl membershipInfoDiv = new HtmlGenericControl();
        HtmlGenericControl memberStatusDiv = new HtmlGenericControl();
        Label lblPassword = new Label();
        TextBox passwordTxtBx = new TextBox();
        Label lblPasswordNew = new Label();
        TextBox passwordNewTxtBx = new TextBox();
        Label lblPasswordConf = new Label();
        TextBox passwordConfTxtBx = new TextBox();
        Label lblUserRole = new Label();
        DropDownList userRoleDrpLst = new DropDownList();
        Label lblIsActive = new Label();
        CheckBox isActiveChkBx = new CheckBox();
        Label lblgivenName = new Label();
        TextBox givenNameTxtBx = new TextBox();
        Label lblsurname = new Label();
        TextBox surnameTxtBx = new TextBox();
        Label lblEmail = new Label();
        TextBox emailTxtBx = new TextBox();
        Label lblStdNum = new Label();
        TextBox stdNumTxtBx = new TextBox();
        Label lblGradYear = new Label();
        TextBox gradYearTxtBx = new TextBox();
        Label lblDegreeName = new Label();
        TextBox degreeNameTxtBx = new TextBox();
        Label lblMedicareNum = new Label();
        TextBox medicareNumTxtBx = new TextBox();
        Label lblAllergies = new Label();
        TextBox allergiesTxtBx = new TextBox();
        Label lblMedicalCond = new Label();
        TextBox medicalCondTxtBx = new TextBox();
        Label lbldietryReq = new Label();
        TextBox dietryReqTxtBx = new TextBox();
        Label lblindemSign = new Label();
        CheckBox indemSignChkBx = new CheckBox();
        Label lblSAEMemshpNum = new Label();
        TextBox SAEMemshpTxtBx = new TextBox();
        Label lblSAEExpDat = new Label();
        Calendar SAEExpDatDtPckr = new Calendar();
        Label lblCAMSMbrshpNum = new Label();
        TextBox CAMSMbrshpNum = new TextBox();
        Label lblCAMSLicType = new Label();
        TextBox CAMSLicTypeTxtBx = new TextBox();
        Label lblDrivLicNum = new Label();
        TextBox drivLicNumTxtBx = new TextBox();
        Label lblDrivLicState = new Label();
        TextBox drivLicStateTxtBx = new TextBox();
        Label lblemerContName = new Label();
        TextBox emerContNameTxtBx = new TextBox();
        Label lblemerContNum = new Label();
        TextBox emerContNumTxtBx = new TextBox();
        DropDownList userDrpList = new DropDownList();
        Label lblWhichUser = new Label();
        Label lblChange = new Label();
        Label lblSubmit = new Label();
        Label lblPasswordChangeResult = new Label();
        Label lblTooltip = new Label();

        bool update;

        protected void Page_Init(object sender, EventArgs e)
        {
            createForm(true);
            }

        protected void Page_Load(object sender, EventArgs e)
        {
            userRoleLbl.Text = Roles.GetRolesForUser()[0];

            if (!IsPostBack)
            {
                fillForm();
                lblWhichUser.Visible = true;
                userDrpList.Visible = true;
                LblUserName.Visible = false;
                userNameTxtBx.Visible = false;

                createUserFrm.Visible = true;
                updateUserSubmitBtn.Visible = true;
                update = true;
                createUserSubmitBtn.Visible = false;
            }

            string userRole = Roles.GetRolesForUser()[0];
            if (!(userRole == "Administrator" ||
                userRole == "Staff" ||
                userRole == "Team Leader"))
            {
                btnUpdateUser.Visible = false;
                btnCreateUser.Visible = false;
                memberStatusDiv.Visible = false;
            }
        }

        private void showUpdateUser(bool submit, bool passChanged)
        {
            lblWhichUser.Visible = true;
            userDrpList.Visible = true;
            LblUserName.Visible = false;
            userNameTxtBx.Visible = false;

            lblSubmit.Visible = submit;

            lblPasswordChangeResult.Visible = passChanged;

            createUserFrm.Visible = true;
            updateUserSubmitBtn.Visible = true;
            update = true;
            createUserSubmitBtn.Visible = false;
        }

        private void showCreateUser(bool submit)
        {
            lblWhichUser.Visible = false;
            userDrpList.Visible = false;
            LblUserName.Visible = true;
            userNameTxtBx.Visible = true;

            if (submit)
            {
                lblSubmit.Visible = true;
            }
            else
            {
                lblSubmit.Visible = false;
            }

            createUserFrm.Visible = true;
            updateUserSubmitBtn.Visible = false;
            update = false;
            createUserSubmitBtn.Visible = true;

            passwordDiv.Visible = false;
            isActiveChkBx.Checked = true;
        }

        protected void btnUpdateUser_Click(object sender, EventArgs e)
        {
            showUpdateUser(false, false);
            fillForm();
        }

        private void createForm(bool pageLoad)
        {
            createUserFrm.Controls.Add(new LiteralControl("<p>"));
            lblSubmit.Visible = false;
            lblSubmit.CssClass = "submitLbl";
            createUserFrm.Controls.Add(lblSubmit);
            createUserFrm.Controls.Add(new LiteralControl("</p> <br />"));

            createUserFrm.Controls.Add(new LiteralControl("<p>"));
            lblPasswordChangeResult.Visible = false;
            createUserFrm.Controls.Add(lblPasswordChangeResult);
            createUserFrm.Controls.Add(new LiteralControl("</p> <br />"));

            userDrpList.Items.Clear();

            userDrpList.Items.Add(Membership.GetUser().UserName);
            userDrpList.SelectedIndex = 0;
            userDrpList.SelectedIndexChanged += chooseUserDrpLst_SelectedIndexChanged;
            userDrpList.AutoPostBack = true;

            foreach (UserInfo user in BusinessLogicLayer.UserInfo.getAllUsers(false))
            {
                if (Role.CanChange(Roles.GetRolesForUser()[0], user.UserRole))
                {
                    if (user.UserName != Membership.GetUser().UserName)
                    {
                        userDrpList.Items.Add(user.UserName);
                    }
                }
            }

            createUserFrm.Controls.Add(new LiteralControl("<p>"));
            lblWhichUser.Text = "Username: ";
            createUserFrm.Controls.Add(lblWhichUser);
            createUserFrm.Controls.Add(userDrpList);
            userDrpList.BackColor = System.Drawing.ColorTranslator.FromHtml("#2D2D2D");
            userDrpList.ForeColor = System.Drawing.ColorTranslator.FromHtml("#7E7E7E");
            userDrpList.Font.Name = "Lucida Sans Unicode";
            userDrpList.Font.Size = 11;
            userDrpList.BorderStyle = BorderStyle.None;
            userDrpList.Height = 25;
            createUserFrm.Controls.Add(new LiteralControl("</p> <br />"));
            if (update)
            {
                lblWhichUser.Visible = true;
                userDrpList.Visible = true;
            }
            else
            {
                lblWhichUser.Visible = false;
                userDrpList.Visible = false;
            }

            createUserFrm.Controls.Add(new LiteralControl("<p>"));
            LblUserName.Text = "Username: ";
            userNameTxtBx.ID = "userNameTxtBx";
            createUserFrm.Controls.Add(LblUserName);
            createUserFrm.Controls.Add(userNameTxtBx);
            userNameTxtBx.CssClass = "textareaPassword";
            createUserFrm.Controls.Add(new LiteralControl("</p> <br />"));
            if (update)
            {
                LblUserName.Visible = false;
                userNameTxtBx.Visible = false;
            }
            else
            {
                LblUserName.Visible = true;
                userNameTxtBx.Visible = true;
            }

            passwordDiv.Controls.Add(new LiteralControl("<p>"));
            lblPassword.Text = "Old Password: ";
            passwordDiv.Controls.Add(lblPassword);
            passwordDiv.Controls.Add(passwordTxtBx);
            passwordTxtBx.CssClass = "textareaPassword";
            passwordTxtBx.TextMode = TextBoxMode.Password;
            passwordDiv.Controls.Add(new LiteralControl("</p> <br />"));

            passwordDiv.Controls.Add(new LiteralControl("<p>"));
            lblPasswordNew.Text = "New Password: ";
            lblTooltip.Text = " i";
            lblTooltip.CssClass = "lblTooltip";
            lblTooltip.ToolTip = "Password must contain at least 8 characters, 1 number, and 1 symbol (i.e. !).";
            passwordDiv.Controls.Add(lblPasswordNew);
            passwordDiv.Controls.Add(passwordNewTxtBx);
            passwordDiv.Controls.Add(lblTooltip);
            passwordNewTxtBx.CssClass = "textareaPassword";
            passwordNewTxtBx.TextMode = TextBoxMode.Password;
            passwordDiv.Controls.Add(new LiteralControl("</p> <br />"));

            passwordDiv.Controls.Add(new LiteralControl("<p>"));
            lblPasswordConf.Text = "New Password Confirm: ";
            passwordDiv.Controls.Add(lblPasswordConf);
            passwordDiv.Controls.Add(passwordConfTxtBx);
            passwordConfTxtBx.CssClass = "textareaPassword";
            passwordConfTxtBx.TextMode = TextBoxMode.Password;
            passwordDiv.Controls.Add(new LiteralControl("</p> <br />"));

            createUserFrm.Controls.Add(passwordDiv);


            memberStatusDiv.Controls.Add(new LiteralControl("<p>"));
            lblUserRole.Text = "User Role: ";
            memberStatusDiv.Controls.Add(lblUserRole);
            userRoleDrpLst.BackColor = System.Drawing.ColorTranslator.FromHtml("#2D2D2D");
            userRoleDrpLst.ForeColor = System.Drawing.ColorTranslator.FromHtml("#7E7E7E");
            userRoleDrpLst.Font.Name = "Lucida Sans Unicode";
            userRoleDrpLst.Font.Size = 11;
            userRoleDrpLst.BorderStyle = BorderStyle.None;
            userRoleDrpLst.Height = 25;
            userRoleDrpLst.SelectedIndexChanged += userRoleDrpLst_SelectedIndexChanged;
            userRoleDrpLst.AutoPostBack = true;

            foreach (String role in BusinessLogicLayer.Role.UserRoles)
            {
                if (Role.CanElevateTo(Roles.GetRolesForUser()[0], role))
                {
                    userRoleDrpLst.Items.Add(role);
                }
            }
            memberStatusDiv.Controls.Add(userRoleDrpLst);
            memberStatusDiv.Controls.Add(new LiteralControl("</p> <br />"));


            memberStatusDiv.Controls.Add(new LiteralControl("<p>"));
            lblIsActive.Text = "User is active: ";
            memberStatusDiv.Controls.Add(lblIsActive);
            memberStatusDiv.Controls.Add(isActiveChkBx);
            memberStatusDiv.Controls.Add(new LiteralControl("</p> <br />"));

            createUserFrm.Controls.Add(memberStatusDiv);

            createUserFrm.Controls.Add(new LiteralControl("<p>"));
            lblgivenName.Text = "Given Name: ";
            createUserFrm.Controls.Add(lblgivenName);
            createUserFrm.Controls.Add(givenNameTxtBx);
            givenNameTxtBx.CssClass = "textareaPassword";
            createUserFrm.Controls.Add(new LiteralControl("</p> <br />"));

            createUserFrm.Controls.Add(new LiteralControl("<p>"));
            lblsurname.Text = "Surname: ";
            createUserFrm.Controls.Add(lblsurname);
            createUserFrm.Controls.Add(surnameTxtBx);
            surnameTxtBx.CssClass = "textareaPassword";
            createUserFrm.Controls.Add(new LiteralControl("</p> <br />"));

            createUserFrm.Controls.Add(new LiteralControl("<p>"));
            lblEmail.Text = "Email: ";
            createUserFrm.Controls.Add(lblEmail);
            createUserFrm.Controls.Add(emailTxtBx);
            emailTxtBx.CssClass = "textareaPassword";
            createUserFrm.Controls.Add(new LiteralControl("</p><br />"));

            studentInfoDiv.Controls.Add(new LiteralControl("<p>"));
            lblStdNum.Text = "Student Number: ";
            studentInfoDiv.Controls.Add(lblStdNum);
            studentInfoDiv.Controls.Add(stdNumTxtBx);
            stdNumTxtBx.CssClass = "textareaPassword";
            studentInfoDiv.Controls.Add(new LiteralControl("</p> <br />"));

            studentInfoDiv.Controls.Add(new LiteralControl("<p>"));
            lblGradYear.Text = "Graduation Year: ";
            studentInfoDiv.Controls.Add(lblGradYear);
            studentInfoDiv.Controls.Add(gradYearTxtBx);
            gradYearTxtBx.CssClass = "textareaPassword";
            studentInfoDiv.Controls.Add(new LiteralControl("</p> <br />"));

            studentInfoDiv.Controls.Add(new LiteralControl("<p>"));
            lblDegreeName.Text = "Degree Name: ";
            studentInfoDiv.Controls.Add(lblDegreeName);
            studentInfoDiv.Controls.Add(degreeNameTxtBx);
            degreeNameTxtBx.CssClass = "textareaPassword";
            studentInfoDiv.Controls.Add(new LiteralControl("</p> <br />"));

            studentInfoDiv.Controls.Add(new LiteralControl("<p>"));
            lblMedicareNum.Text = "Medicare Number: ";
            studentInfoDiv.Controls.Add(lblMedicareNum);
            studentInfoDiv.Controls.Add(medicareNumTxtBx);
            medicareNumTxtBx.CssClass = "textareaPassword";
            studentInfoDiv.Controls.Add(new LiteralControl("</p> <br />"));

            studentInfoDiv.Controls.Add(new LiteralControl("<p>"));
            lblAllergies.Text = "Allergies: ";
            studentInfoDiv.Controls.Add(lblAllergies);
            studentInfoDiv.Controls.Add(allergiesTxtBx);
            allergiesTxtBx.CssClass = "textareaPassword";
            studentInfoDiv.Controls.Add(new LiteralControl("</p> <br />"));

            studentInfoDiv.Controls.Add(new LiteralControl("<p>"));
            lblMedicalCond.Text = "Medical Conditions: ";
            studentInfoDiv.Controls.Add(lblMedicalCond);
            studentInfoDiv.Controls.Add(medicalCondTxtBx);
            medicalCondTxtBx.CssClass = "textareaPassword";
            studentInfoDiv.Controls.Add(new LiteralControl("</p> <br />"));

            studentInfoDiv.Controls.Add(new LiteralControl("<p>"));
            lbldietryReq.Text = "Dietary Requirements: ";
            studentInfoDiv.Controls.Add(lbldietryReq);
            studentInfoDiv.Controls.Add(dietryReqTxtBx);
            dietryReqTxtBx.CssClass = "textareaPassword";
            studentInfoDiv.Controls.Add(new LiteralControl("</p> <br />"));

            studentInfoDiv.Controls.Add(new LiteralControl("<p>"));
            lblindemSign.Text = "Indemnity Form Signed: ";
            studentInfoDiv.Controls.Add(lblindemSign);
            studentInfoDiv.Controls.Add(indemSignChkBx);
            studentInfoDiv.Controls.Add(new LiteralControl("</p>"));

            createUserFrm.Controls.Add(studentInfoDiv);

            createUserFrm.Controls.Add(new LiteralControl("<p>"));
            lblSAEMemshpNum.Text = "SAE Membership Number: ";
            createUserFrm.Controls.Add(lblSAEMemshpNum);
            createUserFrm.Controls.Add(SAEMemshpTxtBx);
            SAEMemshpTxtBx.CssClass = "textareaPassword";
            createUserFrm.Controls.Add(new LiteralControl("</p> <br />"));

            createUserFrm.Controls.Add(new LiteralControl("<p>"));
            lblSAEMemshpNum.Text = "SAE Membership Number: ";
            createUserFrm.Controls.Add(lblSAEMemshpNum);
            createUserFrm.Controls.Add(SAEMemshpTxtBx);
            SAEMemshpTxtBx.CssClass = "textareaPassword";
            createUserFrm.Controls.Add(new LiteralControl("</p> <br />"));

            createUserFrm.Controls.Add(new LiteralControl("<table><tr><td style='vertical-align: top;'><p>"));
            lblSAEExpDat.Text = "SAE Membership Expiry Date: ";
            createUserFrm.Controls.Add(lblSAEExpDat);
            createUserFrm.Controls.Add(new LiteralControl("</p></td><td style='background-color:#2D2D2D;'>"));
            SAEExpDatDtPckr.CssClass = "dtTmPckrFormat";
            createUserFrm.Controls.Add(SAEExpDatDtPckr);
            createUserFrm.Controls.Add(new LiteralControl("</td></tr></table></center><br />"));

            createUserFrm.Controls.Add(new LiteralControl("<p>"));
            lblSAEMemshpNum.Text = "SAE Membership Number: ";
            createUserFrm.Controls.Add(lblSAEMemshpNum);
            createUserFrm.Controls.Add(SAEMemshpTxtBx);
            SAEMemshpTxtBx.CssClass = "textareaPassword";
            createUserFrm.Controls.Add(new LiteralControl("</p> <br />"));

            membershipInfoDiv.Controls.Add(new LiteralControl("<p>"));
            lblCAMSMbrshpNum.Text = "CAMS Membership Number: ";
            membershipInfoDiv.Controls.Add(lblCAMSMbrshpNum);
            membershipInfoDiv.Controls.Add(CAMSMbrshpNum);
            CAMSMbrshpNum.CssClass = "textareaPassword";
            membershipInfoDiv.Controls.Add(new LiteralControl("</p> <br />"));

            membershipInfoDiv.Controls.Add(new LiteralControl("<p>"));
            lblCAMSLicType.Text = "CAMS License Type: ";
            membershipInfoDiv.Controls.Add(lblCAMSLicType);
            membershipInfoDiv.Controls.Add(CAMSLicTypeTxtBx);
            CAMSLicTypeTxtBx.CssClass = "textareaPassword";
            membershipInfoDiv.Controls.Add(new LiteralControl("</p> <br />"));

            membershipInfoDiv.Controls.Add(new LiteralControl("<p>"));
            lblDrivLicNum.Text = "Driver's License Number: ";
            membershipInfoDiv.Controls.Add(lblDrivLicNum);
            membershipInfoDiv.Controls.Add(drivLicNumTxtBx);
            drivLicNumTxtBx.CssClass = "textareaPassword";
            membershipInfoDiv.Controls.Add(new LiteralControl("</p> <br />"));

            membershipInfoDiv.Controls.Add(new LiteralControl("<p>"));
            lblDrivLicState.Text = "Driver's License State: ";
            membershipInfoDiv.Controls.Add(lblDrivLicState);
            membershipInfoDiv.Controls.Add(drivLicStateTxtBx);
            drivLicStateTxtBx.CssClass = "textareaPassword";
            membershipInfoDiv.Controls.Add(new LiteralControl("</p> <br />"));

            membershipInfoDiv.Controls.Add(new LiteralControl("<p>"));
            lblemerContName.Text = "Emergency Contact Name: ";
            membershipInfoDiv.Controls.Add(lblemerContName);
            membershipInfoDiv.Controls.Add(emerContNameTxtBx);
            emerContNameTxtBx.CssClass = "textareaPassword";
            membershipInfoDiv.Controls.Add(new LiteralControl("</p> <br />"));

            membershipInfoDiv.Controls.Add(new LiteralControl("<p>"));
            lblemerContNum.Text = "Emergency Contact Phone Number: ";
            membershipInfoDiv.Controls.Add(lblemerContNum);
            membershipInfoDiv.Controls.Add(emerContNumTxtBx);
            emerContNumTxtBx.CssClass = "textareaPassword";
            membershipInfoDiv.Controls.Add(new LiteralControl("</p> <br />"));

            createUserFrm.Controls.Add(membershipInfoDiv);
        }

        void userRoleDrpLst_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkRole();
        }

        private void fillForm()
        {
            UserInfo user = UserInfo.getUser(userDrpList.SelectedItem.Text);

            givenNameTxtBx.Text = user.GivenName;
            surnameTxtBx.Text = user.Surname;
            stdNumTxtBx.Text = user.StudentNumber;
            gradYearTxtBx.Text = user.EstimatedGraduationYear;
            degreeNameTxtBx.Text = user.Degree;
            medicareNumTxtBx.Text = user.MedicareNumber;
            allergiesTxtBx.Text = user.Allergies;
            medicalCondTxtBx.Text = user.MedicalConditions;
            dietryReqTxtBx.Text = user.DietaryRequirements;
            indemSignChkBx.Checked = user.IndemnityFormSigned;
            SAEMemshpTxtBx.Text = user.SAEMembershipNumber;
            SAEExpDatDtPckr.SelectedDate = user.SAEMembershipExpiry;
            CAMSMbrshpNum.Text = user.CAMSMembershipNumber;
            CAMSLicTypeTxtBx.Text = user.CAMSLicenseType;
            drivLicNumTxtBx.Text = user.DriversLicenseNumber;
            drivLicStateTxtBx.Text = user.DriversLicenseState;
            emerContNameTxtBx.Text = user.EmergencyContactName;
            emerContNumTxtBx.Text = user.EmergencyContactPhoneNumber;
            emailTxtBx.Text = user.Email;
            userRoleDrpLst.SelectedValue = user.UserRole;
            isActiveChkBx.Checked = user.IsActive;

            bool showPassword = user.UserName == Membership.GetUser().UserName;

            passwordDiv.Visible = showPassword;

            checkRole();
        }

        private void checkRole()
        {
            bool isSponsor = userRoleDrpLst.SelectedValue == "Sponsor";
            studentInfoDiv.Visible = !isSponsor;
            membershipInfoDiv.Visible = !isSponsor;
        }

        private void clearForm()
        {
            userNameTxtBx.Text = "";
            givenNameTxtBx.Text = "";
            surnameTxtBx.Text = "";
            stdNumTxtBx.Text = "";
            gradYearTxtBx.Text = "";
            degreeNameTxtBx.Text = "";
            medicareNumTxtBx.Text = "";
            allergiesTxtBx.Text = "";
            medicalCondTxtBx.Text = "";
            dietryReqTxtBx.Text = "";
            indemSignChkBx.Checked = false;
            SAEMemshpTxtBx.Text = "";
            SAEExpDatDtPckr.SelectedDate = DateTime.Now;
            CAMSMbrshpNum.Text = "";
            CAMSLicTypeTxtBx.Text = "";
            drivLicNumTxtBx.Text = "";
            drivLicStateTxtBx.Text = "";
            emerContNameTxtBx.Text = "";
            emerContNumTxtBx.Text = "";
            emailTxtBx.Text = "";
            isActiveChkBx.Checked = true;
        }

        protected void btnCreateUser_Click(object sender, EventArgs e)
        {
            clearForm();
            createUserFrm.Visible = true;
            createUserSubmitBtn.Visible = true;
            updateUserSubmitBtn.Visible = false;
            update = false;

            lblWhichUser.Visible = false;
            userDrpList.Visible = false;
            LblUserName.Visible = true;
            userNameTxtBx.Visible = true;
            userRoleDrpLst.SelectedValue = "User";
            studentInfoDiv.Visible = true;
            membershipInfoDiv.Visible = true;

            passwordDiv.Visible = false;
            memberStatusDiv.Visible = true;
        }

        protected void submitCreateUserBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string userRole = Roles.GetRolesForUser()[0];
                if (userRole == "Administrator" ||
                    userRole == "Staff" ||
                    userRole == "Team Leader")
                {
                    bool notFilledIn;
                    if (userRoleDrpLst.SelectedValue == "Sponsor")
                    {
                        notFilledIn = userNameTxtBx.Text == "" || givenNameTxtBx.Text == "" || surnameTxtBx.Text == "" || emailTxtBx.Text == "" || SAEMemshpTxtBx.Text == "" ||  SAEExpDatDtPckr.SelectedDate == null;
                    }
                    else
                    {
                        notFilledIn = userNameTxtBx.Text == "" || givenNameTxtBx.Text == "" || surnameTxtBx.Text == "" || emailTxtBx.Text == "" || stdNumTxtBx.Text == "" || gradYearTxtBx.Text == "" || degreeNameTxtBx.Text == "" || medicareNumTxtBx.Text == "" || allergiesTxtBx.Text == "" || medicalCondTxtBx.Text == "" || dietryReqTxtBx.Text == "" ||
                            SAEMemshpTxtBx.Text == "" ||  SAEExpDatDtPckr.SelectedDate == null || CAMSMbrshpNum.Text == "" || CAMSLicTypeTxtBx.Text == "" || drivLicNumTxtBx.Text == "" ||  drivLicStateTxtBx.Text == "" ||  emerContNameTxtBx.Text == "" ||  emerContNumTxtBx.Text == "";
                    }

                    if (notFilledIn)
                    {
                        lblSubmit.Text = "Please enter information in all fields";
                        lblSubmit.CssClass = "pUserFeedbackFail";
                        lblSubmit.Visible = true;
                    }
                    else
                    {
                    BusinessLogicLayer.User.addUser(userNameTxtBx.Text, "", userRoleDrpLst.SelectedItem.ToString(), givenNameTxtBx.Text, surnameTxtBx.Text, emailTxtBx.Text, stdNumTxtBx.Text, gradYearTxtBx.Text, degreeNameTxtBx.Text, medicareNumTxtBx.Text, allergiesTxtBx.Text, medicalCondTxtBx.Text, dietryReqTxtBx.Text, indemSignChkBx.Checked,
                        SAEMemshpTxtBx.Text, SAEExpDatDtPckr.SelectedDate, CAMSMbrshpNum.Text, CAMSLicTypeTxtBx.Text, drivLicNumTxtBx.Text, drivLicStateTxtBx.Text, emerContNameTxtBx.Text, emerContNumTxtBx.Text);
                    //Response.Redirect("UserManagement.aspx");
                    lblSubmit.Text = "User submitted.";
                    lblSubmit.CssClass = "pUserFeedbackPass";
                    lblSubmit.Visible = true;
                    clearForm();
                    showCreateUser(true);
                }
            }
            }
            catch (ArgumentException ex)
            {
                if (ex.Message == "Username already exists")
                {
                    lblSubmit.Text = "Username already exists.";
                    lblSubmit.CssClass = "pUserFeedbackFail";
                }

                else if (ex.Message == "Email isn't in a valid format")
                {
                    lblSubmit.Text = "Invalid email.";
                    lblSubmit.CssClass = "pUserFeedbackFail";
                }

                else if (ex.Message == "Email already exists")
                {
                    lblSubmit.Text = "Email already exists.";
                    lblSubmit.CssClass = "pUserFeedbackFail";
                }

                else if (ex.Message == "Invalid Password")
                {
                    lblSubmit.Text = "Invalid password.";
                    lblSubmit.CssClass = "pUserFeedbackFail";
                }

                lblSubmit.Visible = true;
            }

        }

        protected void submitUpdateUserBtn_Click(object sender, EventArgs e)
        {
            UserInfo editUser = BusinessLogicLayer.UserInfo.getUser(userDrpList.SelectedItem.ToString());
            
            if (editUser.UserName == Membership.GetUser().UserName ||
                Role.CanChange(Roles.GetRolesForUser()[0], editUser.UserRole))
            {
                if (givenNameTxtBx.Text != "")
                {
                    editUser.GivenName = givenNameTxtBx.Text;
                }

                if (surnameTxtBx.Text != "")
                {
                    editUser.Surname = surnameTxtBx.Text;
                }

                if (stdNumTxtBx.Text != "")
                {
                    editUser.StudentNumber = stdNumTxtBx.Text;
                }

                if (gradYearTxtBx.Text != "")
                {
                    editUser.EstimatedGraduationYear = gradYearTxtBx.Text;
                }

                if (degreeNameTxtBx.Text != "")
                {
                    editUser.Degree = degreeNameTxtBx.Text;
                }

                if (medicareNumTxtBx.Text != "")
                {
                    editUser.MedicareNumber = medicareNumTxtBx.Text;
                }

                if (allergiesTxtBx.Text != "")
                {
                    editUser.Allergies = allergiesTxtBx.Text;
                }

                if (medicalCondTxtBx.Text != "")
                {
                    editUser.MedicalConditions = medicalCondTxtBx.Text;
                }

                if (dietryReqTxtBx.Text != "")
                {
                    editUser.DietaryRequirements = dietryReqTxtBx.Text;
                }

                if (indemSignChkBx.Checked || !indemSignChkBx.Checked)
                {
                    editUser.IndemnityFormSigned = indemSignChkBx.Checked;
                }

                if (SAEMemshpTxtBx.Text != "")
                {
                    editUser.SAEMembershipNumber = SAEMemshpTxtBx.Text;
                }

                editUser.SAEMembershipExpiry = SAEExpDatDtPckr.SelectedDate;

                if (CAMSMbrshpNum.Text != "")
                {
                    editUser.CAMSMembershipNumber = CAMSMbrshpNum.Text;
                }

                if (CAMSLicTypeTxtBx.Text != "")
                {
                    editUser.CAMSLicenseType = CAMSLicTypeTxtBx.Text;
                }

                if (drivLicNumTxtBx.Text != "")
                {
                    editUser.DriversLicenseNumber = drivLicNumTxtBx.Text;
                }

                if (drivLicStateTxtBx.Text != "")
                {
                    editUser.DriversLicenseState = drivLicStateTxtBx.Text;
                }

                if (emerContNameTxtBx.Text != "")
                {
                    editUser.EmergencyContactName = emerContNameTxtBx.Text;
                }

                if (emerContNumTxtBx.Text != "")
                {
                    editUser.EmergencyContactPhoneNumber = emerContNumTxtBx.Text;
                }

                if (emailTxtBx.Text != "")
                {
                    editUser.Email = emailTxtBx.Text;
                }

                editUser.IsActive = isActiveChkBx.Checked;
                editUser.UserRole = userRoleDrpLst.SelectedValue;

                editUser.updateDatabase();
                lblSubmit.Text = "User updated.";
                lblSubmit.CssClass = "pUserFeedbackPass";
                lblSubmit.Visible = true;

                if (editUser.UserName == Membership.GetUser().UserName)
                {
                    if (passwordNewTxtBx.Text != "" && passwordConfTxtBx.Text != "" && passwordTxtBx.Text != "")
                    {
                        if (passwordNewTxtBx.Text == passwordConfTxtBx.Text)
                        {
                            try
                            {
                                BusinessLogicLayer.User.setPassword(editUser.UserName, passwordNewTxtBx.Text, passwordTxtBx.Text);
                                lblPasswordChangeResult.Text = "Password Changed";
                                lblPasswordChangeResult.CssClass = "pUserFeedbackPass";
                                lblPasswordChangeResult.Visible = true;
                            }
                            catch (ArgumentException exc)
                            {
                                if (exc.Message == "Old Password was incorrect")
                                {
                                    lblPasswordChangeResult.Text = "Password was not correct";
                                    lblPasswordChangeResult.CssClass = "pUserFeedbackFail";
                                    lblPasswordChangeResult.Visible = true;
                                }
                                else if (exc.Message == "Password wasn't valid")
                                {
                                    lblPasswordChangeResult.Text = "Password did not meet our minimum standards";
                                    lblPasswordChangeResult.CssClass = "pUserFeedbackFail";
                                    lblPasswordChangeResult.Visible = true;
                                }
                            }
                        }
                        else
                        {
                            lblPasswordChangeResult.Text = "Emails did not match";
                            lblPasswordChangeResult.CssClass = "pUserFeedbackFail";
                            lblPasswordChangeResult.Visible = true;
                        }
                    }
                }
                showUpdateUser(true, lblPasswordChangeResult.Visible);
            }
        }


        protected void chooseUserDrpLst_SelectedIndexChanged(object sender, EventArgs e)
        {
            showUpdateUser(false, false);
            createUserFrm.Visible = true;
            updateUserSubmitBtn.Visible = true;
            fillForm();
        }
    }
}