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
            WorkTypeTableAdapter workTypeAdapter = new WorkTypeTableAdapter();
            NuRacingDataSet.WorkTypeDataTable WorkTypeTable = workTypeAdapter.GetData();
            NuRacingDataSet.WorkTypeRow WorkTypeRow = WorkTypeTable.NewWorkTypeRow();

            WorkTypeRow.Project_UID = ProjectID;
            WorkTypeRow.WorkType_Name = Name;
            WorkTypeRow.WorkType_Status = "Planning";
            WorkTypeRow.WorkType_StatusChangedDate = DateTime.Now;

            WorkTypeTable.AddWorkTypeRow(WorkTypeRow);

            workTypeAdapter.Update(WorkTypeTable);
        }

        static public bool WorkTypeExists(int WorkTypeID)
        {
            return (new WorkTypeTableAdapter().GetWorkType(WorkTypeID).Rows.Count != 0);
        }

        static public void ChangeStatus(int WorkTypeID, string newStatus)
        {
            WorkTypeTableAdapter workTypeAdapter = new WorkTypeTableAdapter();
            NuRacingDataSet.WorkTypeDataTable WorkTypeTable = workTypeAdapter.GetWorkType(WorkTypeID);
            NuRacingDataSet.WorkTypeRow WorkTypeRow = (NuRacingDataSet.WorkTypeRow) WorkTypeTable.Rows[0];

            WorkTypeRow.WorkType_Status = newStatus;
            WorkTypeRow.WorkType_StatusChangedDate = DateTime.Now;

            workTypeAdapter.Update(WorkTypeTable);
        }
    }
}
