using System;
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
    }
}
