﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer;
using DataAccessLayer.NuRacingDataSetTableAdapters;

namespace BusinessLogicLayer
{
    class WorkInfo
    {
        int workID;
        int timeWorkedMins;
        string username;
        DateTime dateCompleted;
        string description;
        bool takeFiveTaken;
        int workTypeID;
        int TaskID;

        /*
        WorkTypeInfo workType;
        TaskInfo task;
        */
        
        List<TakeFiveResponseInfo> responses;

        public int TimeWorkedMins
        {
            get
            {
                return timeWorkedMins;
            }
        }

        public string Username
        {
            get
            {
                return username;
            }
        }

        public DateTime DateCompleted
        {
            get
            {
                return dateCompleted;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
        }

        public bool TakeFiveTaken
        {
            get
            {
                return takeFiveTaken;
            }
        }

        /*
        public WorkTypeInfo WorkType
        {
            get
            {
                if (workType == null)
                {
                    workType = WorkTypeInfo.getWorkType(workTypeID);
                }
                return workType;
            }
        }

        public TaskInfo Task
        {
            get
            {
                if (task == null)
                {
                    task = TaskInfo.getAssignedTask(workTypeID);
                }
                return task;
            }
        }
        */

        public List<TakeFiveResponseInfo> TakeFiveResponses
        {
            get
            {
                if (responses == null)
                {
                    responses = TakeFiveResponseInfo.getWorkResponses(workID);
                }
                return responses;
            }
        }

        private WorkInfo(NuRacingDataSet.workRow row)
        {
            workID = row.Work_UID;
            timeWorkedMins = row.Work_TimeWorkedMins;
            username = row.User_Username;
            dateCompleted = row.Work_DateCompleted;
            description = row.Work_Description;
            takeFiveTaken = row.Work_TakeFiveTaken;
            workTypeID = row.WorkType_UID;
            TaskID = row.Task_UID;
        }

        // Written by James Hibbard
        /// <summary>
        ///     Returns the WorkInfo for the given WorkID
        /// </summary>
        /// <param name="WorkID">The WorkID to specify the row</param>
        /// <returns>A WorkInfo object containing all info about the row.</returns>
        public WorkInfo getWorkInfo(int WorkID)
        {
            workTableAdapter workAdapter = new workTableAdapter();
            NuRacingDataSet.workDataTable workTable = workAdapter.GetWork(WorkID);
            if (workTable.Rows.Count == 0)
            {
                throw new ArgumentException("WorkID wasn't valid");
            }
            return new WorkInfo((NuRacingDataSet.workRow)workTable.Rows[0]);
        }

        // Written by James Hibbard
        /// <summary>
        ///     Returns the WorkInfo for the given TaskID
        /// </summary>
        /// <param name="TaskID">The TaskID to specify the row</param>
        /// <returns>If the taskID has a Work record, a WorkInfo object containing all info about the row, if it doesn't, returns null.</returns>
        public WorkInfo getTaskWorkInfo(int TaskID)
        {
            workTableAdapter workAdapter = new workTableAdapter();
            NuRacingDataSet.workDataTable workTable = workAdapter.GetDataByTaskID(TaskID)
            if (workTable.Rows.Count == 0)
            {
                return null;
            }
            else 
            {
                return new WorkInfo((NuRacingDataSet.workRow)workTable.Rows[0]);
            }
        }

        // Writen By James Hibbard
        /// <summary>
        ///     Returns a list of all WorkInfo objects the user recorded
        /// </summary>
        /// <param name="Username">The Username of the user to get the Work Info for</param>
        /// <returns>A list of all the work records</returns>
        public List<WorkInfo> getUserWorkInfo(String Username)
        {
            workTableAdapter workAdapter = new workTableAdapter();
            NuRacingDataSet.workDataTable workTable = workAdapter.GetDataByUsername(Username);

            List<WorkInfo> result = new List<WorkInfo>();

            foreach (NuRacingDataSet.workRow workRow in workTable.Rows)
            {
                result.Add(new WorkInfo(workRow));
            }

            return result;
        }

        // Written By James Hibbard
        /// <summary>
        ///     Gets all WorkInfo records for a specific WorkType
        /// </summary>
        /// <param name="WorkTypeID">The ID of the Worktype</param>
        /// <returns>A List of the WorkInfo records</returns>
        public List<WorkInfo> getWorkTypeWorkInfo(int WorkTypeID)
        {
            workTableAdapter workAdapter = new workTableAdapter();
            NuRacingDataSet.workDataTable workTable = workAdapter.GetDataByWorkTypeID(WorkTypeID);

            List<WorkInfo> result = new List<WorkInfo>();

            foreach (NuRacingDataSet.workRow workRow in workTable.Rows)
            {
                result.Add(new WorkInfo(workRow));
            }

            return result;
        }
        
        // Written By James Hibbard
        /// <summary>
        ///     Gets all WorkInfo records for a specific Project
        /// </summary>
        /// <param name="ProjectID">The ID of the Project</param>
        /// <returns>A list of the WorkInfo records</returns>
        public List<WorkInfo> getProjectWorkInfo(int ProjectID)
        {
            worktypeTableAdapter workTypeAdapter = new worktypeTableAdapter();
            NuRacingDataSet.worktypeDataTable workTypeTable = workTypeAdapter.GetDataByProjectID(ProjectID);

            List<WorkInfo> result = new List<WorkInfo>();

            foreach (NuRacingDataSet.worktypeRow workTypeRow in workTypeTable.Rows)
            {
                result.AddRange(getWorkTypeWorkInfo(workTypeRow.WorkType_UID));
            }

            return result;
        }
    }
}
