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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<ProjectInfo> projects = ProjectInfo.getUserProjects(Membership.GetUser(false).UserName, true);

            TableRow row = new TableRow();
            Label cell = new Label();

            cell.Text = "<div class = \"tblProjects\">";

            foreach (ProjectInfo info in projects)
            {
                cell.Text = "<img src=\"images\\tools_white.png\"/><a href =\"section.aspx?id=" + info.ProjectID + "\"><div class = projName>" + info.Name + "</div></a>"
                    + "<div class = projDesc>" + info.Description + "</div>";
                TableCell cell1 = new TableCell();
                cell1.Text = cell.Text.ToString();
                row.Cells.Add(cell1);
            }
            tblProjects.Rows.Add(row);
            cell.Text += "</div>";
        }
    }
}