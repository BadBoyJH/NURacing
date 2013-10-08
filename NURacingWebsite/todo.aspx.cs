using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.Web.Security;

using BusinessLogicLayer;

namespace NURacingWebsite
{
    public partial class todo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.getData("SELECT assignedtask.Task_Name, assignedtask.duedate FROM assignedtask, [work] WHERE work.User_Username = assignedtask.User_Username_AssignedTo");
        }

        public DataSet getData(String query)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Task_Name");
            dataTable.Columns.Add("duedate");
            dataTable.Columns.Add("Task_ID");

            List<TaskInfo> tasks = TaskInfo.getUserTasks(Membership.GetUser().ToString());

            foreach (TaskInfo task in tasks)
            {
                DataRow newRow = dataTable.NewRow();

                newRow["Task_Name"] = task.TaskName;
                newRow["duedate"] = task.TaskDueDate;
                newRow["Task_ID"] = task.TaskID;

                dataTable.Rows.Add(newRow);
            }

            todoTable.DataSource = dataTable;
            todoTable.DataBind();

            return dataTable.DataSet;
        }

    }
}