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
    public class TaskInfo
    {
        //Task Details
        private int taskID;

        private UserInfo assigningUserInfo;

        private List<UserInfo> userAssignedInfo;

        private int workTypeID;

        private string taskName;

        private string taskDescription;

        private bool takeFiveNeeded;

        private string taskStatus;

        private string taskIncompleteReason;

        private DateTime dueDate;

        private bool beenChanged;

        public int TaskID
        {
            get
            {
                return taskID;
            }
        }

        public UserInfo AssigningUserInfo
        { 
            get
            {
                return assigningUserInfo;
            }
        }

        public List<UserInfo> UserAssignedInfo
        {
            get
            {
                return userAssignedInfo;
            }
        }

        public int WorkTypeID
        {
            get
            {
                return workTypeID;
            }
            set
            {
                workTypeID = value;
                beenChanged = true;
            }
        }

        public string TaskName
        {
            get
            {
                return taskName;
            }
            set
            {
                taskName = value;
                beenChanged = true;
            }
        }

        public string TaskDescription
        {
            get
            {
                return taskDescription;
            }
            set
            {
                taskDescription = value;
                beenChanged = true;
            }
        }

        public bool TakeFiveNeeded
        {
            get
            {
                return takeFiveNeeded;
            }
            set
            {
                takeFiveNeeded = value;
                beenChanged = true;
            }
        }

        public string TaskStatus
        {
            get
            {
                return taskStatus;
            }
            set
            {
                taskStatus = value;
                beenChanged = true;
            }
        }

        public string TaskIncompleteReason
        {
            get
            {
                return taskIncompleteReason;
            }
            set
            {
                taskIncompleteReason = value;
                beenChanged = true;
            }
        }

        public DateTime TaskDueDate
        {
            get
            {
                return dueDate;
            }
            set
            {
                dueDate = value;
                beenChanged = true;
            }
        }

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="taskRow">A row from the assigned tasks table</param>

        private TaskInfo(NuRacingDataSet.AssignedTaskRow taskRow)
        {
            assigningUserInfo = UserInfo.getUser(taskRow.User_Username_AssignedBy);

            taskID = taskRow.Task_UID;

            workTypeID = taskRow.WorkType_UID;

            taskName = taskRow.Task_Name;

            taskDescription = taskRow.Task_Description;

            takeFiveNeeded = taskRow.Task_TakeFiveNeeded;

            if (!taskRow.IsTask_StatusNull())
            {
                taskStatus = taskRow.Task_Status;

                if (!taskRow.IsTask_IncompleteReasonNull())
                {
                    taskIncompleteReason = taskRow.Task_IncompleteReason;
                }
            }

            dueDate = taskRow.Task_DueDate;

            AssignedUserTableAdapter assignedUserAdapter = new AssignedUserTableAdapter();
            NuRacingDataSet.AssignedUserDataTable assignedUserTable = assignedUserAdapter.GetDataByTaskID(TaskID);

            userAssignedInfo = new List<UserInfo>(assignedUserTable.Rows.Count);

            foreach (NuRacingDataSet.AssignedUserRow assignedUserRow in assignedUserTable.Rows)
            {
                userAssignedInfo.Add(UserInfo.getUser(assignedUserRow.User_Username));
            }
        }

        /// <summary>
        /// Return a TaskInfo object via specified assignedTaskID
        /// </summary>
        /// <param name="assignedTaskID"></param>
        /// <returns></returns>

        public static TaskInfo getAssignedTask(int assignedTaskID)
        {
            AssignedTaskTableAdapter assignedTaskAdapter = new AssignedTaskTableAdapter();

            NuRacingDataSet.AssignedTaskDataTable assignedTaskTable = assignedTaskAdapter.GetAssignedTask(assignedTaskID);

            if (assignedTaskTable.Rows.Count == 0)
            {
                throw new ArgumentException("Assigned Task Doesn't Exist");
            }

            return new TaskInfo((NuRacingDataSet.AssignedTaskRow)assignedTaskTable.Rows[0]);
        }

        /// <summary>
        /// Returns a list of assigned tasks for given workType
        /// </summary>
        /// <param name="workID"></param>
        /// <returns></returns>

        public static List<TaskInfo> getWorkTypeTasks(int workID)
        {
            AssignedTaskTableAdapter assignedTaskAdapter = new AssignedTaskTableAdapter();

            NuRacingDataSet.AssignedTaskDataTable assignedTaskTable = assignedTaskAdapter.GetDataByWorkTypeID(workID);

            List<TaskInfo> result = new List<TaskInfo>();

            foreach (NuRacingDataSet.AssignedTaskRow AssignedTaskRow in assignedTaskTable.Rows)
            {
                result.Add(new TaskInfo(AssignedTaskRow));
            }

            return result;
        }

        /// <summary>
        /// Return a list of assigned tasks for a project
        /// </summary>
        /// <param name="ProjectID"></param>
        /// <returns></returns>

        public static List<TaskInfo> getProjectTasks(int ProjectID)
        {
            WorkTypeTableAdapter workTypeAdapter = new WorkTypeTableAdapter();
            NuRacingDataSet.WorkTypeDataTable workTypeTable = workTypeAdapter.GetDataByProjectID(ProjectID);

            List<TaskInfo> result = new List<TaskInfo>();

            foreach (NuRacingDataSet.WorkTypeRow workTypeRow in workTypeTable)
            {
                result.AddRange(getWorkTypeTasks(workTypeRow.WorkType_UID));
            }

            return result;
        }

        /// <summary>
        /// Return a list of all assigned tasks for the specified user
        /// </summary>
        /// <param name="username">Username of assigned user</param>
        /// <returns></returns>

        public static List<TaskInfo> getUserTasks(string username)
        {
            AssignedTaskTableAdapter assignedTaskAdapter = new AssignedTaskTableAdapter();

            NuRacingDataSet.AssignedTaskDataTable assignedTaskTable = assignedTaskAdapter.GetDataByAssignedUser(username);

            List<TaskInfo> result = new List<TaskInfo>();

            foreach (NuRacingDataSet.AssignedTaskRow AssignedTaskRow in assignedTaskTable.Rows)
            {
                result.Add(new TaskInfo(AssignedTaskRow));
            }

            return result; 
        }

        /// <summary>
        /// Returns a list of all assigned tasks with their information
        /// </summary>
        /// <returns></returns>

        public static List<TaskInfo> getTasks()
        {
            AssignedTaskTableAdapter assignedTaskAdapter = new AssignedTaskTableAdapter();

            NuRacingDataSet.AssignedTaskDataTable assignedTaskTable = assignedTaskAdapter.GetData();

            List<TaskInfo> result = new List<TaskInfo>();

            foreach (NuRacingDataSet.AssignedTaskRow AssignedTaskRow in assignedTaskTable.Rows)
            {
                result.Add(new TaskInfo(AssignedTaskRow));
            }

            return result;         
        }

        public List<TaskInfo> getUserProjectTasks(int ProjectID, string Username)
        {
            List<TaskInfo> ProjectTasks = getProjectTasks(ProjectID);
            List<TaskInfo> UserTasks = getUserTasks(Username);

            return (List<TaskInfo>)UserTasks.Intersect<TaskInfo>(ProjectTasks);
        }

        public List<TaskInfo> getUserWorkTypeTasks(int WorkTypeID, string Username)
        {
            List<TaskInfo> WorkTypeTasks = getWorkTypeTasks(WorkTypeID);
            List<TaskInfo> UserTasks = getUserTasks(Username);

            return (List<TaskInfo>) UserTasks.Intersect<TaskInfo>(WorkTypeTasks);
        }

        public void updateDatabase()
        {
            AssignedTaskTableAdapter taskAdapter = new AssignedTaskTableAdapter();
            NuRacingDataSet.AssignedTaskDataTable taskTable = taskAdapter.GetAssignedTask(taskID);
            NuRacingDataSet.AssignedTaskRow taskRow = (NuRacingDataSet.AssignedTaskRow) taskTable.Rows[0];
            taskRow.WorkType_UID = workTypeID;
            taskRow.Task_Name = taskName;
            taskRow.Task_Description = taskDescription;
            taskRow.Task_TakeFiveNeeded = takeFiveNeeded;
            taskRow.Task_DueDate = dueDate;

            taskAdapter.Update(taskTable);
        }

        public void resetData()
        {
            AssignedTaskTableAdapter assignedTaskAdapter = new AssignedTaskTableAdapter();
            NuRacingDataSet.AssignedTaskDataTable assignedTaskTable = assignedTaskAdapter.GetAssignedTask(taskID);
            NuRacingDataSet.AssignedTaskRow taskRow = (NuRacingDataSet.AssignedTaskRow)assignedTaskTable.Rows[0];

            assigningUserInfo = UserInfo.getUser(taskRow.User_Username_AssignedBy);

            userAssignedInfo = UserInfo.getUser(taskRow.User_Username_AssignedTo);

            taskID = taskRow.Task_UID;

            workTypeID = taskRow.WorkType_UID;

            taskName = taskRow.Task_Name;

            taskDescription = taskRow.Task_Description;

            takeFiveNeeded = taskRow.Task_TakeFiveNeeded;

            if (!taskRow.IsTask_StatusNull())
            {
                taskStatus = taskRow.Task_Status;

                if (!taskRow.IsTask_IncompleteReasonNull())
                {
                    taskIncompleteReason = taskRow.Task_IncompleteReason;
                }
            }

            dueDate = taskRow.Task_DueDate;
        }
    }
}
