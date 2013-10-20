using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using BusinessLogicLayer;

namespace NURacingWebsite
{
    public partial class UserManagement : System.Web.UI.Page
    {
                  //Man the battle stations, boys! Because we're about to unleash...
          //THE LABEL-TEXTBOX-POCALYPSE.
          Label LblUserName = new Label();
          TextBox userNameTxtBx = new TextBox();
          Label lblPassword = new Label();
          TextBox passwordTxtBx = new TextBox();
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

          //*HUFF* *HUFF* Sarge, I don't think I can take much longer!
          //Man up, sonny! Didn't the doctors prescribe you enough purses???

          Label lblindemSign = new Label();
          CheckBox indemSignChkBx = new CheckBox();
          Label lblSAEMemshpNum = new Label();
          TextBox SAEMemshpTxtBx = new TextBox();
          Label lblSAEExpDat = new Label();
          //DateTimePicker SAEExpDatDtPckr = new DateTimePicker();
          Label lblCAMSMbrshpNum = new Label();
          TextBox CAMSMbrshpNum = new TextBox();

          //I'm out of bullets, Sarge!
          //Here you go, you can borrow mine!
          //  /-\______________
          //  |                |
          //  \-----------------
          //   /    /)  /
          //  /    /----
          // /    /
          ///____/ 
          ///

          Label lblCAMSLicType = new Label();
          TextBox CAMSLicTypeTxtBx = new TextBox();
          Label lblDrivLicNum = new Label();
          TextBox drivLicNumTxtBx = new TextBox();
          Label lblDrivLicState = new Label();
          TextBox drivLicStateTxtBx = new TextBox();

          //SARGE! DON'T DIE ON ME!!! That's it, prepare to eat lead, YOU FILTHY CASUALS!!!
          //                       _________
          //         /'        /|
          //        /         / |_
          //       /         /  //|
          //      /_________/  ////|
          //     |   _ _    | 8o////|
          //     | /'// )_  |   8///|
          //     |/ // // ) |   8o///|
          //     / // // //,|  /  8//|
          //    / // // /// | /   8//|
          //   / // // ///__|/    8//|
          //  /.(_)// /// |       8///|
          // (_)' `(_)//| |       8////|___________
          //(_) /_\ (_)'| |        8///////////////
          //(_) \"/ (_)'|_|         8/////////////
          // (_)._.(_) d' Hb         8oooooooopb'
          //   `(_)'  d'  H`b
          //         d'   `b`b
          //        d'     H `b
          //       d'      `b `b
          //      d'           `b
          //     d'             `b

          Label lblemerContName = new Label();
          TextBox emerContNameTxtBx = new TextBox();
          Label lblemerContNum = new Label();
          TextBox emerContNumTxtBx = new TextBox();
          Button submitBtn;
          DropDownList chooseUserDrpLst = new DropDownList();
          Label lblWhichUser = new Label();
    
        protected void Page_Load(object sender, EventArgs e)
        {
           createForm(true);
        }

        protected void btnUpdateUser_Click(object sender, EventArgs e)
        {
          chooseUserDrpLst.Visible = true;
          createUserSubmitBtn.Visible = true;
          lblWhichUser.Visible = true;
        }

        private void createForm(bool pageLoad)
        {
         foreach (UserInfo user in BusinessLogicLayer.UserInfo.getAllUsers())
         {
             chooseUserDrpLst.Items.Add(user.GivenName);
         }
         createUserFrm.Controls.Add(new LiteralControl("<p>"));
         lblWhichUser.Text = "Which user? ";
         createUserFrm.Controls.Add(lblWhichUser);
         createUserFrm.Controls.Add(chooseUserDrpLst);
         createUserFrm.Controls.Add(new LiteralControl("</p>"));
         lblWhichUser.Visible = false;
         chooseUserDrpLst.Visible = false;

         createUserFrm.Controls.Add(new LiteralControl("<p>"));
         LblUserName.Text = "Username: ";
         createUserFrm.Controls.Add(LblUserName);
         userNameTxtBx.ID = "userNameTxtBx";
         createUserFrm.Controls.Add(userNameTxtBx);
         createUserFrm.Controls.Add(new LiteralControl("</p>"));

         createUserFrm.Controls.Add(new LiteralControl("<p>"));
         lblPassword.Text = "Password: ";
         createUserFrm.Controls.Add(lblPassword);
         createUserFrm.Controls.Add(passwordTxtBx);
         createUserFrm.Controls.Add(new LiteralControl("</p>"));

         createUserFrm.Controls.Add(new LiteralControl("<p>"));
         lblUserRole.Text = "User role: ";
         createUserFrm.Controls.Add(lblUserRole);
         foreach (String role in BusinessLogicLayer.Role.UserRoles)
         {
             userRoleDrpLst.Items.Add(role);
         }
         createUserFrm.Controls.Add(userRoleDrpLst);
         createUserFrm.Controls.Add(new LiteralControl("</p>"));

         createUserFrm.Controls.Add(new LiteralControl("<p>"));
         lblgivenName.Text = "Given name: ";
         createUserFrm.Controls.Add(lblgivenName);
         createUserFrm.Controls.Add(givenNameTxtBx);
         createUserFrm.Controls.Add(new LiteralControl("</p>"));

         createUserFrm.Controls.Add(new LiteralControl("<p>"));
         lblsurname.Text = "Surname: ";
         createUserFrm.Controls.Add(lblsurname);
         createUserFrm.Controls.Add(surnameTxtBx);
         createUserFrm.Controls.Add(new LiteralControl("</p>"));

         createUserFrm.Controls.Add(new LiteralControl("<p>"));
         lblEmail.Text = "Email: ";
         createUserFrm.Controls.Add(lblEmail);
         createUserFrm.Controls.Add(emailTxtBx);
         createUserFrm.Controls.Add(new LiteralControl("</p>"));

         createUserFrm.Controls.Add(new LiteralControl("<p>"));
         lblStdNum.Text = "Student number: ";
         createUserFrm.Controls.Add(lblStdNum);
         createUserFrm.Controls.Add(stdNumTxtBx);
         createUserFrm.Controls.Add(new LiteralControl("</p>"));

         createUserFrm.Controls.Add(new LiteralControl("<p>"));
         lblGradYear.Text = "Graduation year: ";
         createUserFrm.Controls.Add(lblGradYear);
         createUserFrm.Controls.Add(gradYearTxtBx);
         createUserFrm.Controls.Add(new LiteralControl("</p>"));

         createUserFrm.Controls.Add(new LiteralControl("<p>"));
         lblDegreeName.Text = "Degree name: ";
         createUserFrm.Controls.Add(lblDegreeName);
         createUserFrm.Controls.Add(degreeNameTxtBx);
         createUserFrm.Controls.Add(new LiteralControl("</p>"));

         createUserFrm.Controls.Add(new LiteralControl("<p>"));
         lblMedicareNum.Text = "Medicare number: ";
         createUserFrm.Controls.Add(lblMedicareNum);
         createUserFrm.Controls.Add(medicareNumTxtBx);
         createUserFrm.Controls.Add(new LiteralControl("</p>"));

         createUserFrm.Controls.Add(new LiteralControl("<p>"));
         lblAllergies.Text = "Allergies: ";
         createUserFrm.Controls.Add(lblAllergies);
         createUserFrm.Controls.Add(allergiesTxtBx);
         createUserFrm.Controls.Add(new LiteralControl("</p>"));

         createUserFrm.Controls.Add(new LiteralControl("<p>"));
         lblMedicalCond.Text = "Medical conditions: ";
         createUserFrm.Controls.Add(lblMedicalCond);
         createUserFrm.Controls.Add(medicalCondTxtBx);
         createUserFrm.Controls.Add(new LiteralControl("</p>"));

         createUserFrm.Controls.Add(new LiteralControl("<p>"));
         lbldietryReq.Text = "Dietry requirements: ";
         createUserFrm.Controls.Add(lbldietryReq);
         createUserFrm.Controls.Add(dietryReqTxtBx);
         createUserFrm.Controls.Add(new LiteralControl("</p>"));

         createUserFrm.Controls.Add(new LiteralControl("<p>"));
         lblindemSign.Text = "Indemnity form signed: ";
         createUserFrm.Controls.Add(lblindemSign);
         createUserFrm.Controls.Add(indemSignChkBx);
         createUserFrm.Controls.Add(new LiteralControl("</p>"));

         createUserFrm.Controls.Add(new LiteralControl("<p>"));
         lblSAEMemshpNum.Text = "SAE Membership number: ";
         createUserFrm.Controls.Add(lblSAEMemshpNum);
         createUserFrm.Controls.Add(SAEMemshpTxtBx);
         createUserFrm.Controls.Add(new LiteralControl("</p>"));

         createUserFrm.Controls.Add(new LiteralControl("<p>"));
         lblSAEMemshpNum.Text = "SAE Membership number: ";
         createUserFrm.Controls.Add(lblSAEMemshpNum);
         createUserFrm.Controls.Add(SAEMemshpTxtBx);
         createUserFrm.Controls.Add(new LiteralControl("</p>"));

         createUserFrm.Controls.Add(new LiteralControl("<p>"));
         lblSAEExpDat.Text = "SAE Membership expiry date: ";
         createUserFrm.Controls.Add(lblSAEExpDat);
         //createUserFrm.Controls.Add();
         createUserFrm.Controls.Add(new LiteralControl("</p>"));

         createUserFrm.Controls.Add(new LiteralControl("<p>"));
         lblSAEMemshpNum.Text = "SAE Membership number: ";
         createUserFrm.Controls.Add(lblSAEMemshpNum);
         createUserFrm.Controls.Add(SAEMemshpTxtBx);
         createUserFrm.Controls.Add(new LiteralControl("</p>"));

         createUserFrm.Controls.Add(new LiteralControl("<p>"));
         lblCAMSMbrshpNum.Text = "CAMS Membership number: ";
         createUserFrm.Controls.Add(lblCAMSMbrshpNum);
         createUserFrm.Controls.Add(CAMSMbrshpNum);
         createUserFrm.Controls.Add(new LiteralControl("</p>"));

         createUserFrm.Controls.Add(new LiteralControl("<p>"));
         lblCAMSLicType.Text = "CAMS License type: ";
         createUserFrm.Controls.Add(lblCAMSLicType);
         createUserFrm.Controls.Add(CAMSLicTypeTxtBx);
         createUserFrm.Controls.Add(new LiteralControl("</p>"));

         createUserFrm.Controls.Add(new LiteralControl("<p>"));
         lblDrivLicNum.Text = "Driver's license number: ";
         createUserFrm.Controls.Add(lblDrivLicNum);
         createUserFrm.Controls.Add(drivLicNumTxtBx);
         createUserFrm.Controls.Add(new LiteralControl("</p>"));

         createUserFrm.Controls.Add(new LiteralControl("<p>"));
         lblDrivLicState.Text = "Driver's license state: ";
         createUserFrm.Controls.Add(lblDrivLicState);
         createUserFrm.Controls.Add(drivLicStateTxtBx);
         createUserFrm.Controls.Add(new LiteralControl("</p>"));

         createUserFrm.Controls.Add(new LiteralControl("<p>"));
         lblemerContName.Text = "Emergency contact name: ";
         createUserFrm.Controls.Add(lblemerContName);
         createUserFrm.Controls.Add(emerContNameTxtBx);
         createUserFrm.Controls.Add(new LiteralControl("</p>"));

         createUserFrm.Controls.Add(new LiteralControl("<p>"));
         lblemerContNum.Text = "Emergency contact phone number: ";
         createUserFrm.Controls.Add(lblemerContNum);
         createUserFrm.Controls.Add(emerContNumTxtBx);
         createUserFrm.Controls.Add(new LiteralControl("</p>"));

         if (!pageLoad)
         {
           createUserSubmitBtn.Visible = true;
         }
        }

        protected void btnCreateUser_Click(object sender, EventArgs e)
        {
         createUserFrm.Visible = true;
         createUserSubmitBtn.Visible = true;
        }

        protected void submitCreateUserBtn_Click(object sender, EventArgs e)
        {
        BusinessLogicLayer.User.addUser(userNameTxtBx.Text, passwordTxtBx.Text, userRoleDrpLst.SelectedItem.ToString(), givenNameTxtBx.Text, surnameTxtBx.Text, emailTxtBx.Text, stdNumTxtBx.Text, gradYearTxtBx.Text, degreeNameTxtBx.Text, medicareNumTxtBx.Text, allergiesTxtBx.Text, medicalCondTxtBx.Text, dietryReqTxtBx.Text, indemSignChkBx.Checked,
            SAEMemshpTxtBx.Text, DateTime.Now, CAMSMbrshpNum.Text, CAMSLicTypeTxtBx.Text, drivLicNumTxtBx.Text, drivLicStateTxtBx.Text, emerContNameTxtBx.Text, emerContNumTxtBx.Text);
        Response.Redirect("UserManagement.aspx");
        }
    }
}