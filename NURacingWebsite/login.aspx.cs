using System;
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
            FormsAuthentication.SignOut();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            String role = "";
            if (BusinessLogicLayer.User.authenticateUser(UsernameTxtBx.Text, PassTxtBx.Text, out role))
            {
                FormsAuthentication.SetAuthCookie(UsernameTxtBx.Text, true);
                Response.Redirect("index.aspx");
            }
        }
    }
}