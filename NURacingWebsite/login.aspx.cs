﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace NURacingWebsite
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Membership.GetUser() != null)
            {
                if (Request.Params.Get("ReturnUrl") == null)
                {
                    FormsAuthentication.SignOut();
                }
                else
                {
                    Response.Redirect("AccessDenied.aspx?RequestURL=" + Request.Params.Get("ReturnURL"));
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            String role = "";
            if (BusinessLogicLayer.User.authenticateUser(UsernameTxtBx.Text, PassTxtBx.Text, out role))
            {
                FormsAuthentication.SetAuthCookie(UsernameTxtBx.Text, true);

                if (Request.Params.Get("ReturnUrl") == null)
                {
                    Response.Redirect("index.aspx");
                }
            }
        }
    }
}