using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer;
using DataAccessLayer.NuRacingDataSetTableAdapters;

//Written By Simon Davis

namespace BusinessLogicLayer
{
    public static class AssignedTask
    {
        /// <summary>
        /// Adds a task for the specified user and send them an email notification.
        /// </summary>
        /// <param name="assigningUser">User assigning the task</param>
        /// <param name="assignedToUser">User task was assigned to</param>
        /// <param name="workType">Work task belongs to</param>
        /// <param name="name">Name of the task</param>
        /// <param name="description">Description of task</param>
        /// <param name="takeFiveNeeded">Requires a take five</param>
        
        static public void addTask(string assigningUser, string assignedToUser, int workType, DateTime dueDate, string name, string description, bool takeFiveNeeded)
        {
            AssignedTaskTableAdapter assignedTaskAdapter = new AssignedTaskTableAdapter();

            NuRacingDataSet.AssignedTaskDataTable assignedTaskTable = assignedTaskAdapter.GetData();

            NuRacingDataSet.AssignedTaskRow assignedTaskRow = assignedTaskTable.NewAssignedTaskRow();

            assignedTaskRow.User_Username_AssignedBy = assigningUser;

            assignedTaskRow.User_Username_AssignedTo = assignedToUser;

            assignedTaskRow.WorkType_UID = workType;

            assignedTaskRow.Task_Name = name;

            assignedTaskRow.Task_Description = description;

            assignedTaskRow.Task_TakeFiveNeeded = takeFiveNeeded;

            assignedTaskRow.Task_DueDate = dueDate;

            assignedTaskTable.AddAssignedTaskRow(assignedTaskRow);

            assignedTaskAdapter.Update(assignedTaskTable);

            EmailManager.taskNotification(assignedToUser, assigningUser, name, description, User.getEmail(assignedToUser));
        }

        /// <summary>
        /// Sets the specified task to complete if it exists
        /// </summary>
        /// <param name="taskID">ID of task</param>

        static public void taskComplete(int taskID)
        {
            if (taskExists(taskID))
            {
                AssignedTaskTableAdapter assignedTaskAdapter = new AssignedTaskTableAdapter();

                NuRacingDataSet.AssignedTaskDataTable assignedTaskTable = assignedTaskAdapter.GetDataByWorkTypeID(taskID);

                NuRacingDataSet.AssignedTaskRow assignedTaskRow = (NuRacingDataSet.AssignedTaskRow)assignedTaskTable.Rows[0];

                assignedTaskRow.Task_Status = "Complete";

                assignedTaskAdapter.Update(assignedTaskTable);
            }

            else
            {
                throw new ArgumentException("Assigned Task Doesn't Exist");
            }
        }

        /// <summary>
        /// Sets the reason for a task being incomplete.
        /// </summary>
        /// <param name="taskID">ID of the task</param>
        /// <param name="reason">Reason for incomplete task</param>

        static public void taskIncomplete(int taskID, string reason)
        {
            if (taskExists(taskID))
            {
                AssignedTaskTableAdapter assignedTaskAdapter = new AssignedTaskTableAdapter();

                NuRacingDataSet.AssignedTaskDataTable assignedTaskTable = assignedTaskAdapter.GetDataByWorkTypeID(taskID);

                NuRacingDataSet.AssignedTaskRow assignedTaskRow = (NuRacingDataSet.AssignedTaskRow)assignedTaskTable.Rows[0];

                assignedTaskRow.Task_Status = "Incomplete";

                assignedTaskRow.Task_IncompleteReason = reason;

                assignedTaskAdapter.Update(assignedTaskTable);
            }

            else
            {
                throw new ArgumentException("Assigned Task Doesn't Exist");
            }
        }

        /// <summary>
        /// See if specified task exists
        /// </summary>
        /// <param name="taskID">ID of task</param>
        /// <returns></returns>

        static public bool taskExists(int taskID)
        {
            AssignedTaskTableAdapter assignedTaskAdapter = new AssignedTaskTableAdapter();

            NuRacingDataSet.AssignedTaskDataTable assignedTaskTable = assignedTaskAdapter.GetDataByWorkTypeID(taskID);

            return assignedTaskTable.Rows.Count != 0;
        }
    }
}
