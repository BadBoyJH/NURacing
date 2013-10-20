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
    public partial class tasks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.fillData();
        }

        public DataSet fillData()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Task_Name");
            dataTable.Columns.Add("Task_Description");
            dataTable.Columns.Add("duedate");
            dataTable.Columns.Add("Task_ID");

            List<TaskInfo> tasks = TaskInfo.getWorkTypeTasks(Convert.ToInt32(Request.QueryString["id"]));

            foreach (TaskInfo task in tasks)
            {
                DataRow newRow = dataTable.NewRow();

                newRow["Task_Name"] = task.TaskName;
                newRow["Task_Description"] = task.TaskName;
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