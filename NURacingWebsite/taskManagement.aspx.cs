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
        ListBox assignDrpList = new ListBox();
        Label lblTakeFiveNeeded = new Label();
        Label lblReason = new Label();
        TextBox reasonTxtBx = new TextBox();
        CheckBox takeFiveChkBx = new CheckBox();
        Label lblTaskStatus = new Label();
        TextBox taskStatusTxtBx = new TextBox();
        Label lblTaskDrpList = new Label();
        DropDownList taskDrpList = new DropDownList();
        Calendar dueDateCal = new Calendar();
        int workTypeID = 0;
        Label taskSub = new Label();

        protected void Page_Load(object sender, EventArgs e)
        {
            workTypeID = Convert.ToInt32(Request.Params.Get("id"));
            createForm();
            updateTaskBtn.Visible = (TaskInfo.getWorkTypeTasks(workTypeID).Count != 0);
        }

        protected void createTaskBtn_Click(object sender, EventArgs e)
        {
            taskSub.Visible = false;
            taskFrm.Visible = true;
            createSubmitTaskBtn.Visible = true;
        }

        private void fillData()
        {
            int taskID = 0;

            foreach (TaskInfo info in BusinessLogicLayer.TaskInfo.getTasks())
            {
                if (info.TaskName == taskDrpList.SelectedItem.ToString())
                {
                    taskID = info.TaskID;
                    break;
                }
            }

            BusinessLogicLayer.TaskInfo task = TaskInfo.getAssignedTask(taskID);
            BusinessLogicLayer.WorkTypeInfo workTypeInfo = WorkTypeInfo.getWorkType(task.WorkTypeID);

            workTypeDrpList.SelectedValue = workTypeInfo.Name == workTypeInfo.Project.Name ? workTypeInfo.Name : workTypeInfo.Project.Name + " - " + workTypeInfo.Name;

            taskNameTxtBx.Text = task.TaskName;
            taskDescTxtBx.Text = task.TaskDescription;
            takeFiveChkBx.Checked = task.TakeFiveNeeded;
            taskStatusTxtBx.Text = task.TaskStatus;
            reasonTxtBx.Text = task.TaskIncompleteReason;

        }

        private void clearForm()
        {
            taskNameTxtBx.Text = "";
            taskDescTxtBx.Text = "";
            takeFiveChkBx.Checked = false;
            workTypeDrpList.SelectedIndex = 0;
            dueDateCal.SelectedDate = DateTime.Now;
            taskStatusTxtBx.Text = "";
            reasonTxtBx.Text = "";
        }

        private void createForm()
        {
            taskFrm.Controls.Add(new LiteralControl("<p>"));
            taskSub.Text = "Task created.";
            taskSub.Visible = false;
            taskSub.CssClass = "submitLbl";
            taskFrm.Controls.Add(taskSub);
            taskFrm.Controls.Add(new LiteralControl("</p>"));

            taskFrm.Controls.Add(new LiteralControl("<p>"));
            lblTaskDrpList.Text = "Which task? ";
            taskFrm.Controls.Add(lblTaskDrpList);
            taskDrpList.Items.Clear();

            foreach (TaskInfo info in BusinessLogicLayer.TaskInfo.getWorkTypeTasks(workTypeID))
            {
                taskDrpList.Items.Add(info.TaskName);
            }

            taskDrpList.SelectedIndexChanged += taskDrpList_SelectedIndexChanged;
            taskDrpList.AutoPostBack = true;

            lblTaskDrpList.Visible = false;
            taskDrpList.Visible = false;
            taskFrm.Controls.Add(taskDrpList);
            taskFrm.Controls.Add(new LiteralControl("</p>"));

            taskFrm.Controls.Add(new LiteralControl("<p>"));
            lblTaskName.Text = "Task Name: ";
            taskFrm.Controls.Add(lblTaskName);
            taskFrm.Controls.Add(taskNameTxtBx);
            taskNameTxtBx.CssClass = "textareaPassword";
            taskFrm.Controls.Add(new LiteralControl("</p>"));

            taskFrm.Controls.Add(new LiteralControl("<p>"));
            lblworkType.Text = "Project: ";
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
            //taskFrm.Controls.Add(new LiteralControl("<div id=\"datepicker\"></div>"));
            taskFrm.Controls.Add(dueDateCal);
            taskFrm.Controls.Add(new LiteralControl("</p>"));

            taskFrm.Controls.Add(new LiteralControl("<p>"));
            lblReason.Text = "Incomplete reason: ";
            taskFrm.Controls.Add(lblReason);
            taskFrm.Controls.Add(reasonTxtBx);
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
            assignDrpList.SelectionMode = ListSelectionMode.Multiple;
            taskFrm.Controls.Add(assignDrpList);
            taskFrm.Controls.Add(new LiteralControl("</p>"));

            taskFrm.Controls.Add(new LiteralControl("<p>"));
            lblTaskStatus.Text = "Task Status: ";
            taskFrm.Controls.Add(lblTaskStatus);
            taskFrm.Controls.Add(taskStatusTxtBx);
            taskStatusTxtBx.CssClass = "textareaPassword";
            taskFrm.Controls.Add(new LiteralControl("</p>"));
        }

        void taskDrpList_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillData();
        }

        protected void updateTaskBtn_Click(object sender, EventArgs e)
        {
            taskSub.Visible = false;
            lblTaskDrpList.Visible = true;
            taskDrpList.Visible = true;
            taskFrm.Visible = true;
            fillData();
        }

        protected void updateSubmitBtn_Click(object sender, EventArgs e)
        {
            int taskID = 0;

            foreach (TaskInfo info in BusinessLogicLayer.TaskInfo.getTasks())
            {
                if (info.TaskName == taskDrpList.SelectedItem.ToString())
                {
                    taskID = info.TaskID;
                    break;
                }
            }

            BusinessLogicLayer.TaskInfo editTask = TaskInfo.getAssignedTask(taskID);

            foreach (WorkTypeInfo type in BusinessLogicLayer.WorkTypeInfo.getAllWorkTypes())
            {
                if (type.Project.Name == type.Name)
                {
                    if (type.Project.Name == workTypeDrpList.SelectedItem.ToString())
                    {
                        editTask.WorkTypeID = type.WorkTypeID;
                        break;
                    }
                }
                else if (type.Project.Name + " - " + type.Name == workTypeDrpList.SelectedItem.ToString())
                {
                    editTask.WorkTypeID = type.WorkTypeID;
                    break;
                }
            }

            if (taskNameTxtBx.Text != "")
            {
                editTask.TaskName = taskNameTxtBx.Text;
            }

            if (taskDescTxtBx.Text != "")
            {
                editTask.TaskDescription = taskDescTxtBx.Text;
            }

            editTask.TakeFiveNeeded = takeFiveChkBx.Checked;

            if (taskStatusTxtBx.Text != "")
            {
                editTask.TaskStatus = taskStatusTxtBx.Text;
            }

            if (reasonTxtBx.Text != "")
            {
                editTask.TaskIncompleteReason = reasonTxtBx.Text;
            }

            editTask.updateDatabase();

            taskSub.Text = "Task updated.";
            taskSub.Visible = true;
        }

        protected void createSubmitTaskBtn_Click(object sender, EventArgs e)
        {
            int workID = 0;

            List<string> addedUsers = new List<string>();

            foreach (ListItem item in assignDrpList.Items)
            {
                if (item.Selected)
                {
                    addedUsers.Add(item.ToString());
                }
            }

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

            BusinessLogicLayer.AssignedTask.addTask(Membership.GetUser().UserName, addedUsers, 
                workID, dueDateCal.SelectedDate, taskNameTxtBx.Text, taskDescTxtBx.Text, takeFiveChkBx.Checked);

            taskSub.Visible = true;
        }
    }
}