﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer;
using DataAccessLayer.NuRacingDataSetTableAdapters;

//Written By Simon Davis

namespace BusinessLogicLayer
{
    class TaskInfo
    {
        //Task Details
        private UserInfo assigningUserInfo;

        private UserInfo userAssignedInfo;

        private int workTypeID;

        private string taskName;

        private string taskDescription;

        private bool takeFiveNeeded;

        private string taskStatus;

        private string taskIncompleteReason;

        public UserInfo AssigningUserInfo
        { 
            get
            {
                return assigningUserInfo;
            }
        }

        public UserInfo UserAssignedInfo
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
        }

        public string TaskName
        {
            get
            {
                return taskName;
            }
        }

        public string TaskDescription
        {
            get
            {
                return taskDescription;
            }
        }

        public bool TakeFiveNeeded
        {
            get
            {
                return takeFiveNeeded;
            }
        }

        public string TaskStatus
        {
            get
            {
                return taskStatus;
            }
        }

        public string TaskIncompleteReason
        {
            get
            {
                return taskIncompleteReason;
            }
        }

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="taskRow">A row from the assigned tasks table</param>

        private TaskInfo(NuRacingDataSet.assignedtaskRow taskRow)
        {
            assigningUserInfo = UserInfo.getUser(taskRow.User_Username_AssignedBy);

            userAssignedInfo = UserInfo.getUser(taskRow.User_Username_AssignedTo);

            workTypeID = taskRow.WorkType_UID;

            taskName = taskRow.Task_Name;

            taskDescription = taskRow.Task_Description;

            takeFiveNeeded = taskRow.Task_TakeFiveNeeded;

            taskStatus = taskRow.Task_Status;

            taskIncompleteReason = taskRow.Task_IncompleteReason;
        }

        static TaskInfo getAssignedTask(int assignedTaskID)
        {
            assignedtaskTableAdapter assignedTaskAdapter = new assignedtaskTableAdapter();

            NuRacingDataSet.assignedtaskDataTable assignedTaskTable = assignedTaskAdapter.GetAssignedTask(assignedTaskID);

            if (assignedTaskTable.Rows.Count == 0)
            {
                throw new ArgumentException("Assigned Task Doesn't Exist");
            }

            return new TaskInfo((NuRacingDataSet.assignedtaskRow)assignedTaskTable.Rows[0]);
        }

        static List<TaskInfo> getWorkTypeTasks(int workID)
        {
            assignedtaskTableAdapter assignedTaskAdapter = new assignedtaskTableAdapter();

            NuRacingDataSet.assignedtaskDataTable assignedTaskTable = assignedTaskAdapter.GetDataByWorkTypeID(workID);

            List<TaskInfo> result = new List<TaskInfo>();

            foreach (NuRacingDataSet.assignedtaskRow AssignedTaskRow in assignedTaskTable.Rows)
            {
                result.Add(new TaskInfo(AssignedTaskRow));
            }

            return result;
        }

        static List<TaskInfo> getProjectTasks(int ProjectID)
        {
            worktypeTableAdapter workTypeAdapter = new worktypeTableAdapter();
            NuRacingDataSet.worktypeDataTable workTypeTable = workTypeAdapter.GetDataByProjectID(ProjectID);

            List<TaskInfo> result = new List<TaskInfo>();

            foreach (NuRacingDataSet.worktypeRow workTypeRow in workTypeTable)
            {
                result.AddRange(getWorkTypeTasks(workTypeRow.WorkType_UID));
            }

            return result;
        }
    }
}
