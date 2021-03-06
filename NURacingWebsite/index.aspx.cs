﻿using System;
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
        bool activeProjectsOnly = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showProjects();
            }

            string UserRole = BusinessLogicLayer.Role.GetUserRole(Membership.GetUser().UserName);
            if (UserRole != "Team Leader" && UserRole != "Staff" && UserRole != "Administrator")
            {
                createProjBtn.Visible = false;
            }
        }

        private void showProjects()
        {
            List<ProjectInfo> projects = ProjectInfo.getUserProjects(Membership.GetUser(false).UserName, activeProjectsOnly);

            TableRow row = new TableRow();
            Label cell = new Label();

            cell.Text = "<div class = \"tblProjects\">";

            int i = 0;
            foreach (ProjectInfo info in projects)
            {
                if (i != 2)
                {
                    cell.Text = "<img src=\"images\\tools_white.png\"/><a href =\"section.aspx?id=" + info.ProjectID + "\"><div class = projName>" + info.Name + "</div></a>"
                    + "<div class = projDesc>" + info.Description + "</div>";
                    TableCell cell1 = new TableCell();
                    cell1.Text = cell.Text.ToString();
                    row.Cells.Add(cell1);
                    i++;
                }
                else
                {
                    cell.Text = "<img src=\"images\\tools_white.png\"/><a href =\"section.aspx?id=" + info.ProjectID + "\"><div class = projName>" + info.Name + "</div></a>"
                     + "<div class = projDesc>" + info.Description + "</div></tr><tr>";
                    TableCell cell1 = new TableCell();
                    cell1.Text = cell.Text.ToString();
                    row.Cells.Add(cell1);
                    i = 0;
                }
            }
            tblProjects.Rows.Add(row);
            cell.Text += "</div>";
        }

        protected void createProjBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/projectmanagement.aspx");
        }

        protected void showInactiveProjBtn_Click(object sender, EventArgs e)
        {
            activeProjectsOnly = false;
            showInactiveProjBtn.Visible = false;
            showProjects();
        }

        protected void btnEnquiry_Click(object sender, EventArgs e)
        {

        }
    }
}