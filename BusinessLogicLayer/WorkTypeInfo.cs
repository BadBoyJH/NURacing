using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer;
using DataAccessLayer.NuRacingDataSetTableAdapters;

namespace BusinessLogicLayer
{
    public class WorkTypeInfo
    {
        private int workTypeID;
        private int projectID;
        private ProjectInfo project;
        private string name;
        private string status;
        private DateTime statusLastChanged;

        public int WorkTypeID
        {
            get
            {
                return workTypeID;
            }
        }

        public ProjectInfo Project
        {
            get
            {
                if (project == null)
                {
                    project = ProjectInfo.getProject(projectID);
                }
                return project;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public string Status
        {
            get
            {
                return status;
            }
        }

        public DateTime StatusLastChanged
        {
            get
            {
                return statusLastChanged;
            }
        }

        private WorkTypeInfo(NuRacingDataSet.WorkTypeRow row)
        {
            workTypeID = row.WorkType_UID;
            projectID = row.Project_UID;
            name = row.WorkType_Name;
            status = row.WorkType_Status;
            statusLastChanged = row.WorkType_StatusChangedDate;
        }

        public static WorkTypeInfo getWorkType(int WorkType)
        {
            WorkTypeTableAdapter workTypeAdapter = new WorkTypeTableAdapter();
            NuRacingDataSet.WorkTypeDataTable WorkTypeTable = workTypeAdapter.GetWorkType(WorkType);

            if (WorkTypeTable.Rows.Count == 0)
            {
                throw new ArgumentException("Work Type Doesn't Exist");
            }

            return new WorkTypeInfo((NuRacingDataSet.WorkTypeRow)WorkTypeTable.Rows[0]);
        }

        public static List<WorkTypeInfo> getProjectWorkTypes(int ProjectID)
        {
            WorkTypeTableAdapter workTypeAdapter = new WorkTypeTableAdapter();
            NuRacingDataSet.WorkTypeDataTable WorkTypeTable = workTypeAdapter.GetDataByProjectID(ProjectID);

            List<WorkTypeInfo> result = new List<WorkTypeInfo>();

            foreach (NuRacingDataSet.WorkTypeRow WorkTypeRow in WorkTypeTable.Rows)
            {
                result.Add(new WorkTypeInfo(WorkTypeRow));
            }

            return result;
        }

        public static List<WorkTypeInfo> getAllWorkTypes()
        {
            WorkTypeTableAdapter workTypeAdapter = new WorkTypeTableAdapter();
            NuRacingDataSet.WorkTypeDataTable WorkTypeTable = workTypeAdapter.GetData();

            List<WorkTypeInfo> result = new List<WorkTypeInfo>();

            foreach (NuRacingDataSet.WorkTypeRow WorkTypeRow in WorkTypeTable.Rows)
            {
                result.Add(new WorkTypeInfo(WorkTypeRow));
            }

            return result;
        }

        public static List<WorkTypeInfo> getActiveWorkTypes()
        {
            WorkTypeTableAdapter workTypeAdapter = new WorkTypeTableAdapter();
            NuRacingDataSet.WorkTypeDataTable WorkTypeTable = workTypeAdapter.GetData();

            List<WorkTypeInfo> result = new List<WorkTypeInfo>();

            foreach (NuRacingDataSet.WorkTypeRow WorkTypeRow in WorkTypeTable.Rows)
            {
                if (BusinessLogicLayer.Project.projectActive(WorkTypeRow.Project_UID))
                {
                    result.Add(new WorkTypeInfo(WorkTypeRow));
                }
            }

            return result;
        }
    }
}
