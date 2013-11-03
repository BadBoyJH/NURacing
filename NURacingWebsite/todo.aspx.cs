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
            if (TaskInfo.getUserTasks(Membership.GetUser().ToString()).Count != 0)
            {
                fillData();
            }

            else
            {
                instructTodo.InnerText = "No tasks scheduled. You're free!";
            }
        }

        public DataSet fillData()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Task_Name");
            dataTable.Columns.Add("Task_Description");
            dataTable.Columns.Add("duedate");
            dataTable.Columns.Add("Task_ID");

            List<TaskInfo> tasks = TaskInfo.getUserTasks(Membership.GetUser().ToString());

            foreach (TaskInfo task in tasks)
            {
                DataRow newRow = dataTable.NewRow();

                newRow["Task_Name"] = task.TaskName;
                newRow["Task_Description"] = task.TaskDescription;
                newRow["duedate"] = task.TaskDueDate;
                newRow["Task_ID"] = task.TaskID;

                dataTable.Rows.Add(newRow);
            }

            todoTable.DataSource = dataTable;
            todoTable.DataBind();

            return dataTable.DataSet;
        }

        //control the background color for the Gridview
        private void SetBkColor()
        {
            GridViewRowCollection rows = todoTable.Rows;
            for (int i = 0; i < rows.Count; i++)
            {
                //set the background color for every second row of Gridview
                if (i % 2 == 0)
                {
                    rows[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#141414");
                }
            }
        }
        protected void todoTable_DataBound(object sender, EventArgs e)
        {
            SetBkColor();
        }

    }
}