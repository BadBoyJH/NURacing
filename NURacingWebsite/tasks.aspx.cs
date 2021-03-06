﻿using System;
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
            verifyParameters();
            if (TaskInfo.getWorkTypeTasks(Convert.ToInt32(Request.QueryString["id"])).Count != 0)
            {
                this.fillData();
            }
            else
            {
                instructTasks.InnerText = "No tasks scheduled. Create some to begin.";
            }

            WorkTypeInfo workTypeInfo = WorkTypeInfo.getWorkType(Convert.ToInt32(Request.QueryString["id"]));

            if (workTypeInfo.Project.Name == workTypeInfo.Name)
            {
                lblSectionTitle.Text = workTypeInfo.Project.Name;
            }
            else
            {
                lblSectionTitle.Text = workTypeInfo.Project.Name + " " + workTypeInfo.Name;
            }
        }


        public DataSet fillData()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Task_Name");
            dataTable.Columns.Add("Task_Description");
            dataTable.Columns.Add("duedate");
            dataTable.Columns.Add("Task_ID");
            dataTable.Columns.Add("Status");
            dataTable.Columns.Add("StatusIndexNumber");

            List<TaskInfo> tasks = TaskInfo.getWorkTypeTasks(Convert.ToInt32(Request.QueryString["id"]));

            foreach (TaskInfo task in tasks)
            {

                if (task.TaskStatus != "Complete")
                {
                    DataRow newRow = dataTable.NewRow();

                    newRow["Task_Name"] = task.TaskName;
                    newRow["Task_Description"] = task.TaskDescription;
                    newRow["duedate"] = task.TaskDueDate.ToShortDateString();
                    newRow["Task_ID"] = task.TaskID;
                    newRow["Status"] = task.TaskStatus;
                    newRow["StatusIndexNumber"] = task.TaskStatus == "Completed" ? 3 : task.TaskStatus == "Incomplete" ? 1 : 2;

                    dataTable.Rows.Add(newRow);
                }
            }

            dataTable.DefaultView.Sort = "StatusIndexNumber ASC, duedate DESC";

            todoTable.DataSource = dataTable;
            todoTable.DataBind();

            return dataTable.DataSet;
        }

        protected void createProjBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/taskmanagement.aspx?id=" + Request.Params.Get("id"));
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

        private void verifyParameters()
        {
            try
            {
                int ID = Convert.ToInt32(Request.Params.Get("id"));
                if (!WorkType.WorkTypeExists(ID))
                {
                    Response.Clear();
                    Response.StatusCode = 400;
                    Response.End();
                }
            }
            catch (Exception)
            {
                Response.Clear();
                Response.StatusCode = 400;
                Response.End();
            }
        }

        protected void todoTable_DataBound(object sender, EventArgs e)
        {
            SetBkColor();
        }
    }
}