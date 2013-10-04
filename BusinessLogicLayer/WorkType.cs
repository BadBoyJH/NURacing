using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer;
using DataAccessLayer.NuRacingDataSetTableAdapters;

namespace BusinessLogicLayer
{
    public static class WorkType
    {
		static public void AddWorkType(int ProjectID, string Name)
        {
            worktypeTableAdapter workTypeAdapter = new worktypeTableAdapter();
            NuRacingDataSet.worktypeDataTable WorkTypeTable = workTypeAdapter.GetData();
            NuRacingDataSet.worktypeRow WorkTypeRow = WorkTypeTable.NewworktypeRow();

            WorkTypeRow.Project_UID = ProjectID;
            WorkTypeRow.WorkType_Name = Name;
            WorkTypeRow.WorkType_Status = "Planning";
            WorkTypeRow.WorkType_StatusChangedDate = DateTime.Now;

            WorkTypeTable.AddworktypeRow(WorkTypeRow);

            workTypeAdapter.Update(WorkTypeTable);
        }

        static public bool WorkTypeExists(int WorkTypeID)
        {
            return (new worktypeTableAdapter().GetWorkType(WorkTypeID).Rows.Count != 0);
        }

        static public void ChangeStatus(int WorkTypeID, string newStatus)
        {
            worktypeTableAdapter workTypeAdapter = new worktypeTableAdapter();
            NuRacingDataSet.worktypeDataTable WorkTypeTable = workTypeAdapter.GetWorkType(WorkTypeID);
            NuRacingDataSet.worktypeRow WorkTypeRow = (NuRacingDataSet.worktypeRow) WorkTypeTable.Rows[0];

            WorkTypeRow.WorkType_Status = newStatus;
            WorkTypeRow.WorkType_StatusChangedDate = DateTime.Now;

            workTypeAdapter.Update(WorkTypeTable);
        }
    }
}
