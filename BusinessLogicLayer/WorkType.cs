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

            WorkTypeTable.AddworktypeRow(WorkTypeRow);

            workTypeAdapter.Update(WorkTypeTable);
        }

        static public bool WorkTypeExists(int WorkTypeID)
        {
            return (new worktypeTableAdapter().GetWorkType(WorkTypeID).Rows.Count != 0);
        }
    }
}
