using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer;
using DataAccessLayer.NuRacingDataSetTableAdapters;

namespace BusinessLogicLayer
{
    static class Work
    {
        

        public static void AddWork(string Username, DateTime DateCompleted, string Description, int WorkTypeID, int TimeWorkedMins, bool TakeFiveTaken)
        {
            if (User.UsernameExists(Username))
            {
                throw new ArgumentException("Username doesn't exist");
            }            
            /*
            if (WorkType.WorkTypeExists(WorkTypeID))
            {
                throw new ArgumentException("Work Type doesn't exist");
            }
            */ 
            
            workTableAdapter workAdapter = new workTableAdapter();
            NuRacingDataSet.workDataTable workTable = workAdapter.GetData();
            NuRacingDataSet.workRow workRow = workTable.NewworkRow();

            workRow.User_Username = Username;

            workRow.Work_DateCompleted = DateCompleted;
            workRow.Work_Description = Description;
            workRow.WorkType_UID = WorkTypeID;
            workRow.Work_TimeWorkedMins = TimeWorkedMins;
            workRow.SetTask_UIDNull();
            workRow.Work_TakeFiveTaken = TakeFiveTaken;

            workTable.AddworkRow(workRow);
            workAdapter.Update(workTable);
        }

        public static void CompleteTask(string Username, DateTime DateCompleted, int AssignedTaskID, string Description, int TimeWorkedMins, bool TakeFiveTaken)
        {
            if (User.UsernameExists(Username))
            {
                throw new ArgumentException("Username doesn't exist");
            }
            /*
            if (AssignedTask.taskExists(TaskID))
            {
                throw new ArgumentException("Task doesn't exist");
            }
            if (TaskInfo.getTask(AssignedTaskID).TakeFiveNeeded && !takeFiveTaken)
            {
                throw new ArgumentException("Take Five was required");
            }
            TaskInfo task = TaskInfo.getAssignedTask(AssignedTaskID);
            if (Task.Username == Username)
            {
                throw new ArgumentException("Username wasn't consistant with Assigned Task record");
            }
            */

            workTableAdapter workAdapter = new workTableAdapter();
            NuRacingDataSet.workDataTable workTable = workAdapter.GetData();
            NuRacingDataSet.workRow workRow = workTable.NewworkRow();

            workRow.User_Username = Username;
            workRow.Work_DateCompleted = DateCompleted;
            workRow.Work_Description = Description;
            //workRow.WorkType_UID = task.WorkTypeID;
            workRow.Work_TimeWorkedMins = TimeWorkedMins;
            workRow.Task_UID = AssignedTaskID;
            workRow.Work_TakeFiveTaken = TakeFiveTaken;

            workTable.AddworkRow(workRow);
            workAdapter.Update(workTable);
        }

        public static bool WorkExists(int WorkID)
        {
            return (new workTableAdapter().GetWork(WorkID).Rows.Count != 0);
        }
    }
}
