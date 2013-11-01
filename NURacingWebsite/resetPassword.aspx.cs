using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BusinessLogicLayer;

namespace NURacingWebsite
{
    public partial class resetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            successDiv.Visible = false;
            failDiv.Visible = false;
        }

        protected void resetPasswordBtn_Click(object sender, EventArgs e)
        {
            if (BusinessLogicLayer.User.UsernameExists(usernameTxtBx.Text)) //Check if username exists
            {
                if (BusinessLogicLayer.User.getEmail(usernameTxtBx.Text) == emailTxtBx.Text) //Check if users email matches supplied email
                {
                    BusinessLogicLayer.User.resetPassword(usernameTxtBx.Text, emailTxtBx.Text); //Reset users password

                    passwordResetFrm.Visible = false;

                    successDiv.Visible = true;
                }

                else
                {
                    failDiv.Visible = true;
                }
            }

            else
            {
                failDiv.Visible = true;
            }
        }
    }
}