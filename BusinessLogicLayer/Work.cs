using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer;
using DataAccessLayer.NuRacingDataSetTableAdapters;

namespace BusinessLogicLayer
{
    public static class Work
    {
        public static void AddWork(string[] Usernames, DateTime DateCompleted, string Description, int WorkTypeID, int TimeWorkedMins, bool TakeFiveTaken)
        {
            foreach (String Username in Usernames)
            {
                if (User.UsernameExists(Username))
                {
                    throw new ArgumentException("Username doesn't exist: " + Username);
                }
            }

            if (WorkType.WorkTypeExists(WorkTypeID))
            {
                throw new ArgumentException("Work Type doesn't exist");
            } 
            
            WorkTableAdapter workAdapter = new WorkTableAdapter();
            NuRacingDataSet.WorkDataTable workTable = workAdapter.GetData();
            NuRacingDataSet.WorkRow workRow = workTable.NewWorkRow();

            workRow.Work_DateCompleted = DateCompleted;
            workRow.Work_Description = Description;
            workRow.WorkType_UID = WorkTypeID;
            workRow.Work_TimeWorkedMins = TimeWorkedMins;
            workRow.SetTask_UIDNull();
            workRow.Work_TakeFiveTaken = TakeFiveTaken;

            workTable.AddWorkRow(workRow);
            workAdapter.Update(workTable);

            WorkDoneByTableAdapter workDoneByAdapter = new WorkDoneByTableAdapter();
            NuRacingDataSet.WorkDoneByDataTable workDoneByTable = workDoneByAdapter.GetData();

            foreach (string Username in Usernames)
            {
                NuRacingDataSet.WorkDoneByRow newWorkDoneByRow = workDoneByTable.NewWorkDoneByRow();

                newWorkDoneByRow.WorkRow = workRow;
                newWorkDoneByRow.User_Username = Username;

                workDoneByTable.AddWorkDoneByRow(newWorkDoneByRow);
            }

            workDoneByAdapter.Update(workDoneByTable);
        }

        public static void CompleteTask(string Username, DateTime DateCompleted, int AssignedTaskID, string Description, int TimeWorkedMins, bool TakeFiveTaken)
        {
            if (User.UsernameExists(Username))
            {
                throw new ArgumentException("Username doesn't exist");
            }
            if (AssignedTask.taskExists(AssignedTaskID))
            {
                throw new ArgumentException("Task doesn't exist");
            }
            if (TaskInfo.getAssignedTask(AssignedTaskID).TakeFiveNeeded && !TakeFiveTaken)
            {
                throw new ArgumentException("Take Five was required");
            }

            if ((new AssignedUserTableAdapter()).GetDataByBoth(AssignedTaskID, Username).Rows.Count == 0)
            {
                throw new ArgumentException("Username wasn't consistant with Assigned Task record");
            }

            int WorkTypeID = ((NuRacingDataSet.AssignedTaskRow)((new AssignedTaskTableAdapter()).GetAssignedTask(AssignedTaskID).Rows[0])).WorkType_UID;

            WorkTableAdapter workAdapter = new WorkTableAdapter();
            NuRacingDataSet.WorkDataTable workTable = workAdapter.GetData();
            NuRacingDataSet.WorkRow workRow = workTable.NewWorkRow();

            workRow.Work_DateCompleted = DateCompleted;
            workRow.Work_Description = Description;
            workRow.WorkType_UID = WorkTypeID;
            workRow.Work_TimeWorkedMins = TimeWorkedMins;
            workRow.Task_UID = AssignedTaskID;
            workRow.Work_TakeFiveTaken = TakeFiveTaken;

            workTable.AddWorkRow(workRow);
            workAdapter.Update(workTable);

            WorkDoneByTableAdapter workDoneByAdapter = new WorkDoneByTableAdapter();
            NuRacingDataSet.WorkDoneByDataTable workDoneByTable = workDoneByAdapter.GetData();
            NuRacingDataSet.WorkDoneByRow workDoneByRow = workDoneByTable.NewWorkDoneByRow();

            workDoneByRow.User_Username = Username;
            workDoneByRow.WorkRow = workRow;

            workDoneByTable.AddWorkDoneByRow(workDoneByRow);
            workDoneByAdapter.Update(workDoneByTable);
        }

        public static bool WorkExists(int WorkID)
        {
            return (new WorkTableAdapter().GetWork(WorkID).Rows.Count != 0);
        }
    }
}
