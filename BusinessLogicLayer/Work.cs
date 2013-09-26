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
        

        public static void AddItem(String Username, DateTime DateCompleted, String Description, int WorkTypeID, int TimeWorkedMins, bool TakeFiveTaken)
        {
            if (User.UsernameExists(Username))
            {
                throw new ArgumentException("Username doesn't exist");
            }            
            if (WorkTypeID.WorkTypeExists(WorkTypeID))
            {
                throw new ArgumentException("Work Type doesn't exist");
            }


            workTableAdapter workAdapter = new workTableAdapter();
            NuRacingDataSet.workDataTable workTable = workAdapter.GetData();
            NuRacingDataSet.workRow workRow = workTable.NewworkRow();

            workRow.User_Username = Username;
            workRow.Work_DateCompleted = DateCompleted;
            workRow.Work_Description = Description;
            workRow.WorkType_UID = WorkTypeID;
            workRow.Work_TimeWorkedMins = TimeWorkedMins;
            workRow.Task_UID = System.Data.Sql.
            workRow.Work_TakeFiveTaken = TakeFiveTaken;
        }
    }

    public static void CompleteTask()
    
            if (User.UsernameExists(Username))
            {
                throw new ArgumentException("Username doesn't exist");
            }            
            if (WorkTypeID.WorkTypeExists(WorkTypeID))
            {
                throw new ArgumentException("Work Type doesn't exist");
            }
            /*
            if (AssignedTask.taskExists(TaskID))
            {
                throw new ArgumentException("Task doesn't exist");
            }
            */ 
}
