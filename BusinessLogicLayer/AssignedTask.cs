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
        private static int getTaskID(string assigningUser, int workType, DateTime dueDate, string name, string description, bool takeFiveNeeded)
        {
            AssignedTaskTableAdapter assignedTaskAdapter = new AssignedTaskTableAdapter();

            NuRacingDataSet.AssignedTaskDataTable assignedTaskTable = assignedTaskAdapter.GetData();

            foreach (NuRacingDataSet.AssignedTaskRow assignedTaskRow in assignedTaskTable.Rows)
            {
                if (assignedTaskRow.User_Username_AssignedBy == assigningUser &&
                    assignedTaskRow.WorkType_UID == workType &&
                    assignedTaskRow.Task_Name == name &&
                    assignedTaskRow.Task_Description == description &&
                    assignedTaskRow.Task_TakeFiveNeeded == takeFiveNeeded &&
                    assignedTaskRow.Task_DueDate.Date == dueDate.Date)
                {
                    return assignedTaskRow.Task_UID;
                }
            }

            throw new ArgumentException("Unknown error connecting adding work to database");
        }

        /// <summary>
        /// Adds a task for the specified user and send them an email notification.
        /// </summary>
        /// <param name="assigningUser">User assigning the task</param>
        /// <param name="assignedToUser">User task was assigned to</param>
        /// <param name="workType">Work task belongs to</param>
        /// <param name="name">Name of the task</param>
        /// <param name="description">Description of task</param>
        /// <param name="takeFiveNeeded">Requires a take five</param>
        
        static public void addTask(string assigningUser, List<string> assignedToUsers, int workType, DateTime dueDate, string name, string description, bool takeFiveNeeded)
        {
            AssignedTaskTableAdapter assignedTaskAdapter = new AssignedTaskTableAdapter();

            NuRacingDataSet.AssignedTaskDataTable assignedTaskTable = assignedTaskAdapter.GetData();

            NuRacingDataSet.AssignedTaskRow assignedTaskRow = assignedTaskTable.NewAssignedTaskRow();

            assignedTaskRow.User_Username_AssignedBy = assigningUser;

            assignedTaskRow.WorkType_UID = workType;

            assignedTaskRow.Task_Name = name;

            assignedTaskRow.Task_Description = description;

            assignedTaskRow.Task_TakeFiveNeeded = takeFiveNeeded;

            assignedTaskRow.Task_DueDate = dueDate;

            assignedTaskTable.AddAssignedTaskRow(assignedTaskRow);

            assignedTaskAdapter.Update(assignedTaskTable);


            AssignedUserTableAdapter assignedUserAdapter = new AssignedUserTableAdapter();
            NuRacingDataSet.AssignedUserDataTable assignedUserTable = assignedUserAdapter.GetData();

            int TaskID = getTaskID(assigningUser, workType, dueDate, name, description, takeFiveNeeded);

            foreach (string assignedToUser in assignedToUsers)
            {
                NuRacingDataSet.AssignedUserRow assignedUserRow = assignedUserTable.NewAssignedUserRow();

                assignedUserRow.User_Username = assignedToUser;
                assignedUserRow.Task_UID = TaskID;

                assignedUserTable.AddAssignedUserRow(assignedUserRow);

                EmailManager.taskNotification(assignedToUser, assigningUser, name, description, User.getEmail(assignedToUser));
            }

            assignedUserAdapter.Update(assignedUserTable);
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

        static public void changeTaskStatus(int taskID, string status, string reason)
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
