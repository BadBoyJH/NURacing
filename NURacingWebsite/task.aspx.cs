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

        private void verifyParameters()
        {
            try
            {
                int ID = Convert.ToInt32(Request.Params.Get("id"));
                TaskInfo task = TaskInfo.getAssignedTask(ID);
                
                string role = Roles.GetRolesForUser()[0];
                if (role != "Administrator" || role != "Staff" || role != "Team Leader" || role != "Section Manager")
                {
                    bool found = false;

                    string Username = Membership.GetUser().UserName;

                    foreach (UserInfo user in task.UserAssignedInfo)
                    {
                        if (user.UserName == Username)  
                        {
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        Response.Clear();
                        Response.StatusCode = 400;
                        Response.End();
                    }
                }
            }
            catch (Exception)
            {
                Response.Clear();
                Response.StatusCode = 400;
                Response.End();
            }
        }
    }
}