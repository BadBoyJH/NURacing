﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using System.Web.Security;

namespace NURacingWebsite
{
    public partial class account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void passSubmitBtn_Click(object sender, EventArgs e)
        {
            if (newPasswordTxtBx.Text == newPasswordConfTxtBx.Text)
            {
                BusinessLogicLayer.User.setPassword(Membership.GetUser().UserName, newPasswordTxtBx.Text, oldPasswordTxtBx.Text);
            }
        }
    }
}