using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer;
using DataAccessLayer.NuRacingDataSetTableAdapters;

namespace BusinessLogicLayer
{
    public struct TakeFiveResponse
    {
        public int TakeFiveID;
        public string Response;
    }

    public static class Work
    {
        private static void StoreWork(DateTime DateCompleted, string Description, int? taskID, int WorkTypeID, int TimeWorkedMins, bool TakeFiveTaken)
        {
            WorkTableAdapter workAdapter = new WorkTableAdapter();
            NuRacingDataSet.WorkDataTable workTable = workAdapter.GetData();
            NuRacingDataSet.WorkRow workRow = workTable.NewWorkRow();

            workRow.Work_DateCompleted = DateCompleted;
            workRow.Work_Description = Description;
            workRow.WorkType_UID = WorkTypeID;
            workRow.Work_TimeWorkedMins = TimeWorkedMins;
            if (taskID == null)
            {
                workRow.SetTask_UIDNull();
            }
            else
            {
                workRow.Task_UID = taskID.Value;
            }
            workRow.Work_TakeFiveTaken = TakeFiveTaken;

            workTable.AddWorkRow(workRow);
            workAdapter.Update(workTable);
        }

        private static int findWorkID(DateTime DateCompleted, string Description, int? TaskID, int WorkTypeID, int TimeWorkedMins, bool TakeFiveTaken)
        {
            WorkTableAdapter workAdapter = new WorkTableAdapter();
            NuRacingDataSet.WorkDataTable workTable = workAdapter.GetData();
            
            foreach (NuRacingDataSet.WorkRow workRow in workTable.Rows)
            {
                if (workRow.Work_DateCompleted.Date == DateCompleted.Date &&
                    workRow.Work_Description == Description &&
                    workRow.WorkType_UID == WorkTypeID &&
                    workRow.Work_TimeWorkedMins == TimeWorkedMins &&
                    workRow.Work_TakeFiveTaken == TakeFiveTaken)
                {
                    if (TaskID == null && workRow.IsTask_UIDNull())
                    {
                        return workRow.Work_UID;
                    }
                    if (TaskID == null || workRow.IsTask_UIDNull())
                    {
                    }
                    else if (TaskID.Value == workRow.Task_UID)
                    {
                        return workRow.Work_UID;
                    }
                }
            }

            throw new ArgumentException("Unknown error connecting adding work to database");
        }

        private static void StoreWorkDoneBy(string[] Usernames, int WorkID)
        {
            WorkDoneByTableAdapter workDoneByAdapter = new WorkDoneByTableAdapter();
            NuRacingDataSet.WorkDoneByDataTable workDoneByTable = workDoneByAdapter.GetData();

            foreach (string Username in Usernames)
            {
                NuRacingDataSet.WorkDoneByRow newWorkDoneByRow = workDoneByTable.NewWorkDoneByRow();

                newWorkDoneByRow.Work_UID = WorkID;
                newWorkDoneByRow.User_Username = Username;

                workDoneByTable.AddWorkDoneByRow(newWorkDoneByRow);
            }

            workDoneByAdapter.Update(workDoneByTable);
        }

        private static void StoreTakeFivesTaken(TakeFiveResponse[] responses, int WorkID)
        {
            TakeFiveResponseTableAdapter responseAdapter = new TakeFiveResponseTableAdapter();
            NuRacingDataSet.TakeFiveResponseDataTable responseTable = responseAdapter.GetData();

            foreach (TakeFiveResponse response in responses)
            {
                NuRacingDataSet.TakeFiveResponseRow responseRow = responseTable.NewTakeFiveResponseRow();

                responseRow.Work_UID = WorkID;
                responseRow.TakeFive_UID = response.TakeFiveID;
                responseRow.TakeFiveResponse_Reason = response.Response;

                responseTable.AddTakeFiveResponseRow(responseRow);
            }

            responseAdapter.Update(responseTable);

        }

        public static void AddWork(string[] Usernames, DateTime DateCompleted, string Description, int WorkTypeID, int TimeWorkedMins, bool TakeFiveTaken)
        {
            foreach (String Username in Usernames)
            {
                if (!User.UsernameExists(Username))
                {
                    throw new ArgumentException("Username doesn't exist: " + Username);
                }
            }

            if (WorkType.WorkTypeExists(WorkTypeID))
            {
                throw new ArgumentException("Work Type doesn't exist");
            }

            StoreWork(DateCompleted, Description, null, WorkTypeID, TimeWorkedMins, TakeFiveTaken);
            int WorkID = findWorkID(DateCompleted, Description, null, WorkTypeID, TimeWorkedMins, TakeFiveTaken);

            StoreWorkDoneBy(Usernames, WorkID);
        }

        public static void AddWork(string[] Usernames, DateTime DateCompleted, string Description, int WorkTypeID, int TimeWorkedMins, TakeFiveResponse[] TakeFiveResponses)
        {
            foreach (String Username in Usernames)
            {
                if (!User.UsernameExists(Username))
                {
                    throw new ArgumentException("Username doesn't exist: " + Username);
                }
            }

            if (!WorkType.WorkTypeExists(WorkTypeID))
            {
                throw new ArgumentException("Work Type doesn't exist");
            }

            StoreWork(DateCompleted, Description, null, WorkTypeID, TimeWorkedMins, true);
            int WorkID = findWorkID(DateCompleted, Description, null, WorkTypeID, TimeWorkedMins, true);

            StoreWorkDoneBy(Usernames, WorkID);

            StoreTakeFivesTaken(TakeFiveResponses, WorkID);
        }

        public static void CompleteTask(string[] Usernames, DateTime DateCompleted, int AssignedTaskID, string Description, int TimeWorkedMins, bool TakeFiveTaken)
        {
            foreach (string Username in Usernames)
            {
                if (!User.UsernameExists(Username))
                {
                    throw new ArgumentException("Username doesn't exist");
                }
                if ((new AssignedUserTableAdapter()).GetDataByBoth(AssignedTaskID, Username).Rows.Count == 0)
                {
                    throw new ArgumentException("Username wasn't consistant with Assigned Task record");
                }
            }
            if (AssignedTask.taskExists(AssignedTaskID))
            {
                throw new ArgumentException("Task doesn't exist");
            }
            if (TaskInfo.getAssignedTask(AssignedTaskID).TakeFiveNeeded && !TakeFiveTaken)
            {
                throw new ArgumentException("Take Five was required");
            }

            int WorkTypeID = ((NuRacingDataSet.AssignedTaskRow)((new AssignedTaskTableAdapter()).GetAssignedTask(AssignedTaskID).Rows[0])).WorkType_UID;

            StoreWork(DateCompleted, Description, AssignedTaskID, WorkTypeID, TimeWorkedMins, TakeFiveTaken);
            int WorkID = findWorkID(DateCompleted, Description, AssignedTaskID, WorkTypeID, TimeWorkedMins, TakeFiveTaken);

            StoreWorkDoneBy(Usernames, WorkID);
        }

        public static void CompleteTask(string[] Usernames, DateTime DateCompleted, int AssignedTaskID, string Description, int TimeWorkedMins, TakeFiveResponse[] takeFiveResponses)
        {
            foreach (string Username in Usernames)
            {
                if (!User.UsernameExists(Username))
                {
                    throw new ArgumentException("Username doesn't exist");
                }
                if ((new AssignedUserTableAdapter()).GetDataByBoth(AssignedTaskID, Username).Rows.Count == 0)
                {
                    throw new ArgumentException("Username wasn't consistant with Assigned Task record");
                }
            }
            if (AssignedTask.taskExists(AssignedTaskID))
            {
                throw new ArgumentException("Task doesn't exist");
            }

            int WorkTypeID = ((NuRacingDataSet.AssignedTaskRow)((new AssignedTaskTableAdapter()).GetAssignedTask(AssignedTaskID).Rows[0])).WorkType_UID;

            StoreWork(DateCompleted, Description, AssignedTaskID, WorkTypeID, TimeWorkedMins, true);
            int WorkID = findWorkID(DateCompleted, Description, AssignedTaskID, WorkTypeID, TimeWorkedMins, true);

            StoreWorkDoneBy(Usernames, WorkID);

            StoreTakeFivesTaken(takeFiveResponses, WorkID);
        }

        public static bool WorkExists(int WorkID)
        {
            return (new WorkTableAdapter().GetWork(WorkID).Rows.Count != 0);
        }
    }
}
