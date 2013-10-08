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
    public partial class task : System.Web.UI.Page
    {
        String user = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            user = Membership.GetUser().ToString();
            userLbl.Text = user;
            HtmlGenericControl NewControl = new HtmlGenericControl("span");
            NewControl.ID = "taskDescLbl";
            NewControl.InnerHtml = "<b>" + "</b>";
            taskDescLbl.Controls.Add(NewControl);
        }
    }
}