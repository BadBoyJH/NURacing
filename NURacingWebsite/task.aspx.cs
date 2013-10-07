using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace NURacingWebsite
{
    public partial class task : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlGenericControl NewControl = new HtmlGenericControl("span");
            NewControl.ID = "taskDescLbl";
            NewControl.InnerHtml = "<b>DESCRIPTION</b>";
            taskDescLbl.Controls.Add(NewControl);
        }
    }
}