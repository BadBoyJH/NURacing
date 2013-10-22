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
    public partial class taskManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void createTaskBtn_Click(object sender, EventArgs e)
        {
            HtmlGenericControl NewControl = new HtmlGenericControl("div");
            NewControl.InnerHtml = "";
            createTaskFrm.Controls.Add(NewControl);
            NewControl.ID = "createTaskFrm";
            NewControl.InnerHtml = "<form class=\"taskMngement\">"
            +"<p>Task name: <input type=\"text\" name=\"taskName\"></p>"
            + "<p>Task description: <input type=\"text\" name=\"taskDesc\"></p>"
            + "<p>Due date: <input type=\"text\" name=\"dueDate\"></p>"
            + "<p>Assign to: <input type=\"text\" name=\"assignTo\"></p>"
            + "<p>Task status: <input type=\"text\" name=\"taskStatus\"></p>"
            + "<input type=\"submit\" value=\"Submit\" class=\"taskManBtn\">"
            +"</form>";
            createTaskFrm.Controls.Add(NewControl);
        }

        protected void updateTaskBtn_Click(object sender, EventArgs e)
        {
            HtmlGenericControl NewControl = new HtmlGenericControl("div");
            NewControl.InnerHtml = "";
            createTaskFrm.Controls.Add(NewControl);
            NewControl.ID = "createTaskFrm";
            NewControl.InnerHtml = "<form class=\"taskMngement\">"
            + "<p>Task: <select value=\"taskSltBx\"><option value=\"task\">TASK NAME</option></select></p>"
            + "<p>Task description: <input type=\"text\" name=\"taskDesc\"></p>"
            + "<p>Due date: <input type=\"text\" name=\"dueDate\"></p>"
            + "<p>Assign to: <input type=\"text\" name=\"assignTo\"></p>"
            + "<p>Task status: <input type=\"text\" name=\"taskStatus\"></p>"
            + "<input type=\"submit\" value=\"Submit\" class=\"taskManBtn\">"
            + "</form>";
            createTaskFrm.Controls.Add(NewControl);
        }
    }
}