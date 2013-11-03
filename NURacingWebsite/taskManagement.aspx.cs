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
        DropDownList taskStatDrpList = new DropDownList();

        protected void Pre_Init(object sender, EventArgs e)
        {
            createForm();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            workTypeID = Convert.ToInt32(Request.Params.Get("id"));
            createForm();
            updateTaskBtn.Visible = (TaskInfo.getWorkTypeTasks(workTypeID).Count != 0);

            if (Request.Params.Get("create") == "true")
            {
                submitTask.Text = "Task created.";
                submitTask.Visible = true;
            }

            if (Request.Params.Get("update") == "true")
            {
                submitTask.Text = "Task updated.";
                submitTask.Visible = true;
            }
        }

        protected void createTaskBtn_Click(object sender, EventArgs e)
        {
            submitTask.Visible = false;
            taskSub.Visible = false;
            lblTaskDrpList.Visible = false;
            taskDrpList.Visible = false;
            clearForm();
            taskFrm.Visible = true;
            createSubmitTaskBtn.Visible = true;
            updateSubmitBtn.Visible = false;
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

            submitTask.Visible = false;

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
            taskDrpList.BackColor = System.Drawing.ColorTranslator.FromHtml("#2D2D2D");
            taskDrpList.ForeColor = System.Drawing.ColorTranslator.FromHtml("#7E7E7E");
            taskDrpList.Font.Name = "Lucida Sans Unicode";
            taskDrpList.Font.Size = 11;
            taskDrpList.BorderStyle = BorderStyle.None;
            taskDrpList.Height = 25;
            taskFrm.Controls.Add(new LiteralControl("</p> <br />"));

            taskFrm.Controls.Add(new LiteralControl("<p>"));
            lblTaskName.Text = "Task Name: ";
            taskFrm.Controls.Add(lblTaskName);
            taskFrm.Controls.Add(taskNameTxtBx);
            taskNameTxtBx.CssClass = "textareaPassword";
            taskFrm.Controls.Add(new LiteralControl("</p> <br />"));

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
            workTypeDrpList.BackColor = System.Drawing.ColorTranslator.FromHtml("#2D2D2D");
            workTypeDrpList.ForeColor = System.Drawing.ColorTranslator.FromHtml("#7E7E7E");
            workTypeDrpList.Font.Name = "Lucida Sans Unicode";
            workTypeDrpList.Font.Size = 11;
            workTypeDrpList.BorderStyle = BorderStyle.None;
            workTypeDrpList.Height = 25;
            taskFrm.Controls.Add(new LiteralControl("</p> <br />"));

            taskFrm.Controls.Add(new LiteralControl("<p>"));
            lblTaskDesc.Text = "Task Description: ";
            taskFrm.Controls.Add(lblTaskDesc);
            taskFrm.Controls.Add(taskDescTxtBx);
            taskDescTxtBx.CssClass = "textareaPassword";
            taskDescTxtBx.TextMode = TextBoxMode.MultiLine;
            taskFrm.Controls.Add(new LiteralControl("</p> <br />"));

            taskFrm.Controls.Add(new LiteralControl("<p>"));
            lblDueDate.Text = "Due Date: ";
            taskFrm.Controls.Add(lblDueDate);
            dueDateCal.BackColor = System.Drawing.ColorTranslator.FromHtml("#2D2D2D");
            dueDateCal.ForeColor = System.Drawing.ColorTranslator.FromHtml("#7E7E7E");
            taskFrm.Controls.Add(dueDateCal);
            taskFrm.Controls.Add(new LiteralControl("</p> <br />"));

            taskFrm.Controls.Add(new LiteralControl("<p>"));
            lblTakeFiveNeeded.Text = "Take Five Needed: ";
            taskFrm.Controls.Add(lblTakeFiveNeeded);
            taskFrm.Controls.Add(takeFiveChkBx);
            taskFrm.Controls.Add(new LiteralControl("</p> <br />"));

            taskFrm.Controls.Add(new LiteralControl("<p>"));
            lblAssignTo.Text = "Assign To: ";
            taskFrm.Controls.Add(lblAssignTo);
            foreach (UserInfo user in BusinessLogicLayer.UserInfo.getAllUsers())
            {
                assignDrpList.Items.Add(user.UserName);
            }
            assignDrpList.SelectionMode = ListSelectionMode.Multiple;
            taskFrm.Controls.Add(assignDrpList);
            assignDrpList.BackColor = System.Drawing.ColorTranslator.FromHtml("#2D2D2D");
            assignDrpList.ForeColor = System.Drawing.ColorTranslator.FromHtml("#7E7E7E");
            assignDrpList.Font.Name = "Lucida Sans Unicode";
            assignDrpList.Font.Size = 11;
            assignDrpList.BorderStyle = BorderStyle.None;
            taskFrm.Controls.Add(new LiteralControl("</p> <br />"));

            taskStatDrpList.Items.Clear();
            taskStatDrpList.Items.Add("Not Started");
            taskStatDrpList.Items.Add("Planning");
            taskStatDrpList.Items.Add("Designing");
            taskStatDrpList.Items.Add("Design Completed");
            taskStatDrpList.Items.Add("Building Commenced");
            taskStatDrpList.Items.Add("Bulding Finished");
            taskStatDrpList.Items.Add("Completed");
            taskStatDrpList.Items.Add("Fit and Finish Completed");
            taskStatDrpList.Items.Add("Ready For Assembly");
            taskStatDrpList.Items.Add("Testing");
            taskStatDrpList.Items.Add("Complete");
            taskStatDrpList.Items.Add("Ongoing");
            taskStatDrpList.Items.Add("On Hold");

            taskFrm.Controls.Add(new LiteralControl("<p>"));
            lblTaskStatus.Text = "Set Project Status: ";
            taskFrm.Controls.Add(lblTaskStatus);
            taskFrm.Controls.Add(taskStatDrpList);
            taskStatDrpList.CssClass = "drpList";
            taskStatDrpList.BackColor = System.Drawing.ColorTranslator.FromHtml("#2D2D2D");
            taskStatDrpList.ForeColor = System.Drawing.ColorTranslator.FromHtml("#7E7E7E");
            taskStatDrpList.Font.Name = "Lucida Sans Unicode";
            taskStatDrpList.Font.Size = 11;
            taskStatDrpList.BorderStyle = BorderStyle.None;
            taskStatDrpList.Height = 25;
            taskFrm.Controls.Add(new LiteralControl("</p> "));
        }

        void taskDrpList_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillData();
        }

        protected void updateTaskBtn_Click(object sender, EventArgs e)
        {
            lblTaskStatus.Visible = true;
            taskStatDrpList.Visible = true;
            submitTask.Visible = false;
            taskSub.Visible = false;
            lblTaskDrpList.Visible = true;
            taskDrpList.Visible = true;
            taskFrm.Visible = true;
            updateSubmitBtn.Visible = true;
            createSubmitTaskBtn.Visible = false;
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

            editTask.TaskStatus = taskStatDrpList.SelectedItem.ToString();

            if (reasonTxtBx.Text != "")
            {
                editTask.TaskIncompleteReason = reasonTxtBx.Text;
            }

            editTask.updateDatabase();

            taskSub.ForeColor = System.Drawing.ColorTranslator.FromHtml("#7E7E7E");
            taskSub.Text = "Task updated.";
            taskSub.Visible = true;
            Response.Redirect("/taskmanagement.aspx?id=" + workTypeID.ToString() + "&update=true");
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

            Response.Redirect("/taskmanagement.aspx?id=" + workTypeID.ToString() + "&create=true");
        }
    }
}