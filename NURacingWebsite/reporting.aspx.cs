using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using BusinessLogicLayer;
using System.Web.UI.HtmlControls;

namespace NURacingWebsite
{
    public partial class reporting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userRole = Roles.GetRolesForUser()[0];
            PurchasingReport.Visible = userRole == "Team Leader" || userRole == "Staff" || userRole == "Administrator";
            SponsorDetailsReport.Visible = userRole == "Team Leader" || userRole == "Staff" || userRole == "Administrator";
            TakeFiveReport.Visible = userRole == "Team Leader" || userRole == "Staff" || userRole == "Administrator";
            UserDetailsReport.Visible = userRole == "Team Leader" || userRole == "Staff" || userRole == "Administrator";

            ProjectStatusReport.Visible = userRole== "Team Leader" || userRole == "Staff" || userRole == "Administrator" || userRole == "Sponsor";

            WorkshopReport.Visible = userRole != "Sponsor";
            LabourLogReport.Visible = userRole != "Sponsor";
        }
    }
}