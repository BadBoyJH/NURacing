using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace NURacingWebsite
{
    public partial class LoggedIn : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            MembershipUser user = Membership.GetUser(false);

            if (user == null)
            {
                Response.Redirect("/login.aspx");
            }

            Page.Error += Page_Error;
        }

        void Page_Error(object sender, EventArgs e)
        {
            Exception exec = Server.GetLastError();

            if (exec is MySql.Data.MySqlClient.MySqlException)
            {
                if (exec.Message.Contains("Timeout"))
                {
                    Response.Redirect("/error.aspx");
                    Server.ClearError();
                }
            }
            else if (exec is System.TimeoutException)
            {
                Response.Redirect("/error.aspx");
                Server.ClearError();
            }
            else
            {
                Response.Redirect("errorgeneric.aspx");
            }
        }

        public void hideFooter()
        {
            footer.Visible = false;
        }
    }
}