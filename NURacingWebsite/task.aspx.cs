﻿using System;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params.Get("id") == null)
            {
                Response.Redirect("todo.aspx");
            }

            BusinessLogicLayer.TaskInfo info = TaskInfo.getAssignedTask(Convert.ToInt32(Request.QueryString["id"]));
            HtmlGenericControl NewControl = new HtmlGenericControl("span");
            taskTitleLbl.Text = info.TaskName;
            dueDateLbl.Text = "DUE: " + info.TaskDueDate.ToShortDateString();
            NewControl.ID = "taskDescLbl";
            NewControl.InnerHtml = "<b>" + info.TaskDescription +  "</b>";
            taskDescLbl.Controls.Add(NewControl);
        }

        protected void takeFiveBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/takefive.aspx?taskID=" +Request.Params.Get("id"));
        }
    }
}