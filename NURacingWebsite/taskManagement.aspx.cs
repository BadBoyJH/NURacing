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
        Label lblTaskName = new Label();
        TextBox taskNameTxtBx = new TextBox();
        Label lblworkType = new Label();
        DropDownList workTypeDrpList = new DropDownList();
        Label lblTaskDesc = new Label();
        TextBox taskDescTxtBx = new TextBox();
        Label lblDueDate = new Label();
        //DateTimePicker due date;
        Label lblAssignTo = new Label();
        DropDownList assignDrpList = new DropDownList();
        Label lblTakeFiveNeeded = new Label();
        CheckBox takeFiveChkBx = new CheckBox();
        Label lblTaskStatus = new Label();
        TextBox taskStatusTxtBx = new TextBox();

        protected void Page_Load(object sender, EventArgs e)
        {
            createForm();
        }

        protected void createTaskBtn_Click(object sender, EventArgs e)
        {
            taskFrm.Visible = true;
            createSubmitTaskBtn.Visible = true;
            //HtmlGenericControl NewControl = new HtmlGenericControl("div");
            //NewControl.InnerHtml = "";
            //createTaskFrm.Controls.Add(NewControl);
            //NewControl.ID = "createTaskFrm";
            //NewControl.InnerHtml = "<form class=\"taskMngement\">"
            //+"<p>Task name: <input type=\"text\" name=\"taskName\"></p>"
            //+ "<p>Task description: <input type=\"text\" name=\"taskDesc\"></p>"
            //+ "<p>Due date: <input type=\"text\" name=\"dueDate\"></p>"
            //+ "<p>Assign to: <input type=\"text\" name=\"assignTo\"></p>"
            //+ "<p>Task status: <input type=\"text\" name=\"taskStatus\"></p>"
            //+ "<input type=\"submit\" value=\"Submit\" class=\"taskManBtn\">"
            //+"</form>";
            //createTaskFrm.Controls.Add(NewControl);
        }

        private void createForm()
        {
            taskFrm.Controls.Add(new LiteralControl("<p>"));
            lblTaskName.Text = "Task Name: ";
            taskFrm.Controls.Add(lblTaskName);
            taskFrm.Controls.Add(taskNameTxtBx);
            taskNameTxtBx.CssClass = "textareaPassword";
            taskFrm.Controls.Add(new LiteralControl("</p>"));

            taskFrm.Controls.Add(new LiteralControl("<p>"));
            lblworkType.Text = "Project Type: ";
            taskFrm.Controls.Add(lblworkType);
            workTypeDrpList.Items.Clear();

            foreach (WorkTypeInfo type in BusinessLogicLayer.WorkTypeInfo.getAllWorkTypes())
            {
                if (type.Project.Name == type.Name)
                {
                    workTypeDrpList.Items.Add(type.Project.Name);
                }
                else
                {
                    workTypeDrpList.Items.Add(type.Project.Name + " - " + type.Name);
                }
            }
            taskFrm.Controls.Add(workTypeDrpList);
            taskFrm.Controls.Add(new LiteralControl("</p>"));

            taskFrm.Controls.Add(new LiteralControl("<p>"));
            lblTaskDesc.Text = "Task Description: ";
            taskFrm.Controls.Add(lblTaskDesc);
            taskFrm.Controls.Add(taskDescTxtBx);
            taskDescTxtBx.CssClass = "textareaPassword";
            taskDescTxtBx.TextMode = TextBoxMode.MultiLine;
            taskFrm.Controls.Add(new LiteralControl("</p>"));

            taskFrm.Controls.Add(new LiteralControl("<p>"));
            lblDueDate.Text = "Due Date: ";
            taskFrm.Controls.Add(lblDueDate);
            //taskFrm.Controls.Add(taskNaTxtBx);
            taskFrm.Controls.Add(new LiteralControl("</p>"));

            taskFrm.Controls.Add(new LiteralControl("<p>"));
            lblTakeFiveNeeded.Text = "Take Five Needed: ";
            taskFrm.Controls.Add(lblTakeFiveNeeded);
            taskFrm.Controls.Add(takeFiveChkBx);
            taskFrm.Controls.Add(new LiteralControl("</p>"));

            taskFrm.Controls.Add(new LiteralControl("<p>"));
            lblAssignTo.Text = "Assign To: ";
            taskFrm.Controls.Add(lblAssignTo);
            foreach (UserInfo user in BusinessLogicLayer.UserInfo.getAllUsers())
            {
                assignDrpList.Items.Add(user.UserName);
            }
            taskFrm.Controls.Add(assignDrpList);
            taskFrm.Controls.Add(new LiteralControl("</p>"));

            taskFrm.Controls.Add(new LiteralControl("<p>"));
            lblTaskStatus.Text = "Task Status: ";
            taskFrm.Controls.Add(lblTaskStatus);
            taskFrm.Controls.Add(taskStatusTxtBx);
            taskStatusTxtBx.CssClass = "textareaPassword";
            taskFrm.Controls.Add(new LiteralControl("</p>"));
        }

        protected void updateTaskBtn_Click(object sender, EventArgs e)
        {

        }

        protected void updateSubmitBtn_Click(object sender, EventArgs e)
        {

        }

        protected void createSubmitTaskBtn_Click(object sender, EventArgs e)
        {
            int workID = 0;

            foreach (WorkTypeInfo type in BusinessLogicLayer.WorkTypeInfo.getAllWorkTypes())
            {
                if (type.Project.Name == type.Name)
                {
                    if (type.Project.Name == workTypeDrpList.SelectedItem.ToString())
                    {
                        workID = type.WorkTypeID;
                        break;
                    }
                }
                else if(type.Project.Name + " - " + type.Name == workTypeDrpList.SelectedItem.ToString())
                {
                    workID = type.WorkTypeID;
                    break;
                }
            }

            BusinessLogicLayer.AssignedTask.addTask(Membership.GetUser().ToString(), assignDrpList.SelectedItem.ToString(), 
                workID, DateTime.Now, taskNameTxtBx.Text, taskDescTxtBx.Text, takeFiveChkBx.Checked);
        }
    }
}