﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace NURacingWebsite
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MembershipUser user = Membership.GetUser(false);
            if (user == null)
            {
                Response.Redirect("login.aspx");
            }            
        }

        protected string getUsername()
        {
            MembershipUser user = Membership.GetUser(false);
            return user.UserName;
        }
    }
}