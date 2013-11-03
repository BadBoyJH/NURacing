using System;
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
        Label lblPassword = new Label();
        TextBox passwordTxtBx = new TextBox();
        Label lblPasswordNew = new Label();
        TextBox passwordNewTxtBx = new TextBox();
        Label lblPasswordConf = new Label();
        TextBox passwordConfTxtBx = new TextBox();
        Label lblPasswordConfChange = new Label();
        CheckBox passwordConfChangeChkBx = new CheckBox();
        Label lblUserRole = new Label();
        DropDownList userRoleDrpLst = new DropDownList();
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
            fillForm();

            if (!IsPostBack)
            {
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
            }
        }

        private void showUpdateUser(bool submit)
        {
            lblWhichUser.Visible = true;
            userDrpList.Visible = true;
            LblUserName.Visible = false;
            userNameTxtBx.Visible = false;

            if (submit)
            {
                lblSubmit.Visible = true;
            }
            else
            {
                lblSubmit.Visible = false;
            }
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

            passwordTxtBx.Visible = false;
            passwordNewTxtBx.Visible = false;
            passwordConfTxtBx.Visible = false;
            passwordConfChangeChkBx.Visible = false;
            lblPassword.Visible = false;
            lblPasswordConf.Visible = false;
            lblPasswordConfChange.Visible = false;
            lblPasswordNew.Visible = false;
        }

        protected void btnUpdateUser_Click(object sender, EventArgs e)
        {
            showUpdateUser(false);
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
            createUserFrm.Controls.Add(lblSubmit);
            createUserFrm.Controls.Add(new LiteralControl("</p> <br />"));

            userDrpList.Items.Clear();

            userDrpList.Items.Add(Membership.GetUser().UserName);
            userDrpList.SelectedIndex = 0;
            userDrpList.SelectedIndexChanged += chooseUserDrpLst_SelectedIndexChanged;
            userDrpList.AutoPostBack = true;

            foreach (UserInfo user in BusinessLogicLayer.UserInfo.getAllUsers())
            {
                if (Role.greaterRole(Roles.GetRolesForUser()[0], user.UserRole))
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

            createUserFrm.Controls.Add(new LiteralControl("<p>"));
            lblPassword.Text = "Old Password: ";
            createUserFrm.Controls.Add(lblPassword);
            createUserFrm.Controls.Add(passwordTxtBx);
            passwordTxtBx.CssClass = "textareaPassword";
            passwordTxtBx.TextMode = TextBoxMode.Password;
            createUserFrm.Controls.Add(new LiteralControl("</p> <br />"));

            createUserFrm.Controls.Add(new LiteralControl("<p>"));
            lblPasswordNew.Text = "New Password: ";
            lblTooltip.Text = " i";
            lblTooltip.CssClass = "lblTooltip";
            lblTooltip.ToolTip = "Password must contain at least 8 characters, 1 number, and 1 symbol (i.e. !).";
            createUserFrm.Controls.Add(lblPasswordNew);
            createUserFrm.Controls.Add(passwordNewTxtBx);
            createUserFrm.Controls.Add(lblTooltip);
            passwordNewTxtBx.CssClass = "textareaPassword";
            passwordNewTxtBx.TextMode = TextBoxMode.Password;
            createUserFrm.Controls.Add(new LiteralControl("</p> <br />"));

            createUserFrm.Controls.Add(new LiteralControl("<p>"));
            lblPasswordConf.Text = "New Password Confirm: ";
            createUserFrm.Controls.Add(lblPasswordConf);
            createUserFrm.Controls.Add(passwordConfTxtBx);
            passwordConfTxtBx.CssClass = "textareaPassword";
            passwordConfTxtBx.TextMode = TextBoxMode.Password;
            createUserFrm.Controls.Add(new LiteralControl("</p> <br />"));

            createUserFrm.Controls.Add(new LiteralControl("<p>"));
            lblPasswordConfChange.Text = "Confirm Password Change:";
            createUserFrm.Controls.Add(lblPasswordConfChange);
            createUserFrm.Controls.Add(passwordConfChangeChkBx);
            createUserFrm.Controls.Add(new LiteralControl("</p> <br />"));


            createUserFrm.Controls.Add(new LiteralControl("<p>"));
            lblUserRole.Text = "User Role: ";
            createUserFrm.Controls.Add(lblUserRole);
            userRoleDrpLst.BackColor = System.Drawing.ColorTranslator.FromHtml("#2D2D2D");
            userRoleDrpLst.ForeColor = System.Drawing.ColorTranslator.FromHtml("#7E7E7E");
            userRoleDrpLst.Font.Name = "Lucida Sans Unicode";
            userRoleDrpLst.Font.Size = 11;
            userRoleDrpLst.BorderStyle = BorderStyle.None;
            userRoleDrpLst.Height = 25;
            foreach (String role in BusinessLogicLayer.Role.UserRoles)
            {
                if (Role.greaterRole(Roles.GetRolesForUser()[0], role))
                {
                    userRoleDrpLst.Items.Add(role);
                }
            }
            createUserFrm.Controls.Add(userRoleDrpLst);
            createUserFrm.Controls.Add(new LiteralControl("</p> <br />"));

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

            createUserFrm.Controls.Add(new LiteralControl("<p>"));
            lblStdNum.Text = "Student Number: ";
            createUserFrm.Controls.Add(lblStdNum);
            createUserFrm.Controls.Add(stdNumTxtBx);
            stdNumTxtBx.CssClass = "textareaPassword";
            createUserFrm.Controls.Add(new LiteralControl("</p> <br />"));

            createUserFrm.Controls.Add(new LiteralControl("<p>"));
            lblGradYear.Text = "Graduation Year: ";
            createUserFrm.Controls.Add(lblGradYear);
            createUserFrm.Controls.Add(gradYearTxtBx);
            gradYearTxtBx.CssClass = "textareaPassword";
            createUserFrm.Controls.Add(new LiteralControl("</p> <br />"));

            createUserFrm.Controls.Add(new LiteralControl("<p>"));
            lblDegreeName.Text = "Degree Name: ";
            createUserFrm.Controls.Add(lblDegreeName);
            createUserFrm.Controls.Add(degreeNameTxtBx);
            degreeNameTxtBx.CssClass = "textareaPassword";
            createUserFrm.Controls.Add(new LiteralControl("</p> <br />"));

            createUserFrm.Controls.Add(new LiteralControl("<p>"));
            lblMedicareNum.Text = "Medicare Number: ";
            createUserFrm.Controls.Add(lblMedicareNum);
            createUserFrm.Controls.Add(medicareNumTxtBx);
            medicareNumTxtBx.CssClass = "textareaPassword";
            createUserFrm.Controls.Add(new LiteralControl("</p> <br />"));

            createUserFrm.Controls.Add(new LiteralControl("<p>"));
            lblAllergies.Text = "Allergies: ";
            createUserFrm.Controls.Add(lblAllergies);
            createUserFrm.Controls.Add(allergiesTxtBx);
            allergiesTxtBx.CssClass = "textareaPassword";
            createUserFrm.Controls.Add(new LiteralControl("</p> <br />"));

            createUserFrm.Controls.Add(new LiteralControl("<p>"));
            lblMedicalCond.Text = "Medical Conditions: ";
            createUserFrm.Controls.Add(lblMedicalCond);
            createUserFrm.Controls.Add(medicalCondTxtBx);
            medicalCondTxtBx.CssClass = "textareaPassword";
            createUserFrm.Controls.Add(new LiteralControl("</p> <br />"));

            createUserFrm.Controls.Add(new LiteralControl("<p>"));
            lbldietryReq.Text = "Dietary Requirements: ";
            createUserFrm.Controls.Add(lbldietryReq);
            createUserFrm.Controls.Add(dietryReqTxtBx);
            dietryReqTxtBx.CssClass = "textareaPassword";
            createUserFrm.Controls.Add(new LiteralControl("</p> <br />"));

            createUserFrm.Controls.Add(new LiteralControl("<p>"));
            lblindemSign.Text = "Indemnity Form Signed: ";
            createUserFrm.Controls.Add(lblindemSign);
            createUserFrm.Controls.Add(indemSignChkBx);
            createUserFrm.Controls.Add(new LiteralControl("</p>"));

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

            createUserFrm.Controls.Add(new LiteralControl("<p>"));
            lblSAEExpDat.Text = "SAE Membership Expiry Date: ";
            SAEExpDatDtPckr.BackColor = System.Drawing.ColorTranslator.FromHtml("#2D2D2D");
            SAEExpDatDtPckr.ForeColor = System.Drawing.ColorTranslator.FromHtml("#7E7E7E");
            createUserFrm.Controls.Add(lblSAEExpDat);
            createUserFrm.Controls.Add(SAEExpDatDtPckr);
            createUserFrm.Controls.Add(new LiteralControl("</p><br />"));

            createUserFrm.Controls.Add(new LiteralControl("<p>"));
            lblSAEMemshpNum.Text = "SAE Membership Number: ";
            createUserFrm.Controls.Add(lblSAEMemshpNum);
            createUserFrm.Controls.Add(SAEMemshpTxtBx);
            SAEMemshpTxtBx.CssClass = "textareaPassword";
            createUserFrm.Controls.Add(new LiteralControl("</p> <br />"));

            createUserFrm.Controls.Add(new LiteralControl("<p>"));
            lblCAMSMbrshpNum.Text = "CAMS Membership Number: ";
            createUserFrm.Controls.Add(lblCAMSMbrshpNum);
            createUserFrm.Controls.Add(CAMSMbrshpNum);
            CAMSMbrshpNum.CssClass = "textareaPassword";
            createUserFrm.Controls.Add(new LiteralControl("</p> <br />"));

            createUserFrm.Controls.Add(new LiteralControl("<p>"));
            lblCAMSLicType.Text = "CAMS License Type: ";
            createUserFrm.Controls.Add(lblCAMSLicType);
            createUserFrm.Controls.Add(CAMSLicTypeTxtBx);
            CAMSLicTypeTxtBx.CssClass = "textareaPassword";
            createUserFrm.Controls.Add(new LiteralControl("</p> <br />"));

            createUserFrm.Controls.Add(new LiteralControl("<p>"));
            lblDrivLicNum.Text = "Driver's License Number: ";
            createUserFrm.Controls.Add(lblDrivLicNum);
            createUserFrm.Controls.Add(drivLicNumTxtBx);
            drivLicNumTxtBx.CssClass = "textareaPassword";
            createUserFrm.Controls.Add(new LiteralControl("</p> <br />"));

            createUserFrm.Controls.Add(new LiteralControl("<p>"));
            lblDrivLicState.Text = "Driver's License State: ";
            createUserFrm.Controls.Add(lblDrivLicState);
            createUserFrm.Controls.Add(drivLicStateTxtBx);
            drivLicStateTxtBx.CssClass = "textareaPassword";
            createUserFrm.Controls.Add(new LiteralControl("</p> <br />"));

            createUserFrm.Controls.Add(new LiteralControl("<p>"));
            lblemerContName.Text = "Emergency Contact Name: ";
            createUserFrm.Controls.Add(lblemerContName);
            createUserFrm.Controls.Add(emerContNameTxtBx);
            emerContNameTxtBx.CssClass = "textareaPassword";
            createUserFrm.Controls.Add(new LiteralControl("</p> <br />"));

            createUserFrm.Controls.Add(new LiteralControl("<p>"));
            lblemerContNum.Text = "Emergency Contact Phone Number: ";
            createUserFrm.Controls.Add(lblemerContNum);
            createUserFrm.Controls.Add(emerContNumTxtBx);
            emerContNumTxtBx.CssClass = "textareaPassword";
            createUserFrm.Controls.Add(new LiteralControl("</p> <br />"));

            if (!pageLoad)
            {
                createUserSubmitBtn.Visible = true;
            }
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

            bool showPassword = user.UserName == Membership.GetUser().UserName;

            lblPassword.Visible = showPassword;
            lblPasswordConf.Visible = showPassword;
            lblPasswordNew.Visible = showPassword;
            lblPasswordConf.Visible = showPassword;
            passwordConfTxtBx.Visible = showPassword;
            passwordNewTxtBx.Visible = showPassword;
            passwordTxtBx.Visible = showPassword;
            passwordConfChangeChkBx.Visible = showPassword;
        }

        private void clearForm()
        {

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
        }

        protected void btnCreateUser_Click(object sender, EventArgs e)
        {
            clearForm();
            createUserFrm.Visible = true;
            createUserSubmitBtn.Visible = true;
            updateUserSubmitBtn.Visible = false;
            update = false;

            lblPassword.Visible = false;
            lblPasswordConf.Visible = false;
            lblPasswordNew.Visible = false;
            lblPasswordConf.Visible = false;
            passwordConfTxtBx.Visible = false;
            passwordNewTxtBx.Visible = false;
            passwordTxtBx.Visible = false;
            passwordConfChangeChkBx.Visible = false;
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
                    BusinessLogicLayer.User.addUser(userNameTxtBx.Text, "", userRoleDrpLst.SelectedItem.ToString(), givenNameTxtBx.Text, surnameTxtBx.Text, emailTxtBx.Text, stdNumTxtBx.Text, gradYearTxtBx.Text, degreeNameTxtBx.Text, medicareNumTxtBx.Text, allergiesTxtBx.Text, medicalCondTxtBx.Text, dietryReqTxtBx.Text, indemSignChkBx.Checked,
                        SAEMemshpTxtBx.Text, SAEExpDatDtPckr.SelectedDate, CAMSMbrshpNum.Text, CAMSLicTypeTxtBx.Text, drivLicNumTxtBx.Text, drivLicStateTxtBx.Text, emerContNameTxtBx.Text, emerContNumTxtBx.Text);
                    //Response.Redirect("UserManagement.aspx");
                    lblSubmit.Text = "User submitted.";
                    lblSubmit.Visible = true;
                    clearForm();
                    showCreateUser(true);
                }
            }
            catch (ArgumentException ex)
            {
                if (ex.Message == "Username already exists")
                {
                    lblSubmit.Text = "Username already exists.";
                }

                else if (ex.Message == "Email isn't in a valid format")
                {
                    lblSubmit.Text = "Invalid email.";
                }

                else if (ex.Message == "Email already exists")
                {
                    lblSubmit.Text = "Email already exists.";
                }

                else if (ex.Message == "Invalid Password")
                {
                    lblSubmit.Text = "Invalid password.";
                }

                lblSubmit.Visible = true;
            }

        }

        protected void submitUpdateUserBtn_Click(object sender, EventArgs e)
        {
            UserInfo editUser = BusinessLogicLayer.UserInfo.getUser(userDrpList.SelectedItem.ToString());
            
            if (editUser.UserName == Membership.GetUser().UserName ||
                Role.greaterRole(Roles.GetRolesForUser()[0], editUser.UserRole))
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

                editUser.updateDatabase();
                lblSubmit.Text = "User updated.";
                lblSubmit.ForeColor = System.Drawing.ColorTranslator.FromHtml("#7E7E7E");
                lblSubmit.Visible = true;
                showUpdateUser(true);

                if (editUser.UserName == Membership.GetUser().UserName)
                {
                    if (passwordConfChangeChkBx.Checked)
                    {
                        if (passwordNewTxtBx.Text == passwordConfTxtBx.Text)
                        {
                            try
                            {
                                BusinessLogicLayer.User.setPassword(editUser.UserName, passwordTxtBx.Text, passwordNewTxtBx.Text);
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
            }
        }


        protected void chooseUserDrpLst_SelectedIndexChanged(object sender, EventArgs e)
        {
            showUpdateUser(false);
            createUserFrm.Visible = true;
            createUserSubmitBtn.Visible = true;
            fillForm();
        }
    }
}