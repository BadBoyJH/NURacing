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
    public partial class section : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String user = Membership.GetUser().UserName;

            List<WorkTypeInfo> sections = WorkTypeInfo.getProjectWorkTypes(Convert.ToInt32(Request.QueryString["id"]));

            TableRow row = new TableRow();
            Label cell = new Label();

            cell.Text = "<div class = \"tblProjects\">";

            int i = 0;
            foreach (WorkTypeInfo info in sections)
            {
                if (i != 2)
                {
                    cell.Text = "<img src=\"images\\tools_white.png\"/><a href =\"tasks.aspx?id=" + info.WorkTypeID + "\"><div class = projName>" + info.Name + "</div></a>"
                        + "<div class = projDesc>" + info.Status + "</div>";
                    TableCell cell1 = new TableCell();
                    cell1.Text = cell.Text.ToString();
                    row.Cells.Add(cell1);
                    i++;
                }
                else
                {
                    cell.Text = "<img src=\"images\\tools_white.png\"/><a href =\"tasks.aspx?id=" + info.WorkTypeID + "\"><div class = projName>" + info.Name + "</div></a>"
                    + "<div class = projDesc>" + info.Status + "</div></tr><tr>";
                    TableCell cell1 = new TableCell();
                    cell1.Text = cell.Text.ToString();
                    row.Cells.Add(cell1);
                    i = 0;
                }
            }

            tblProjects.Rows.Add(row);
            cell.Text += "</div>";
        }
    }
}