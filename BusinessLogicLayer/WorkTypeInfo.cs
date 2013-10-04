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

        private WorkTypeInfo(NuRacingDataSet.worktypeRow row)
        {
            workTypeID = row.WorkType_UID;
            projectID = row.Project_UID;
            name = row.WorkType_Name;
            status = row.WorkType_Status;
            statusLastChanged = row.WorkType_StatusChangedDate;
        }

        public static WorkTypeInfo getWorkType(int WorkType)
        {
            worktypeTableAdapter workTypeAdapter = new worktypeTableAdapter();
            NuRacingDataSet.worktypeDataTable WorkTypeTable = workTypeAdapter.GetWorkType(WorkType);

            if (WorkTypeTable.Rows.Count == 0)
            {
                throw new ArgumentException("Work Type Doesn't Exist");
            }

            return new WorkTypeInfo((NuRacingDataSet.worktypeRow)WorkTypeTable.Rows[0]);
        }

        public static List<WorkTypeInfo> getProjectWorkTypes(int ProjectID)
        {
            worktypeTableAdapter workTypeAdapter = new worktypeTableAdapter();
            NuRacingDataSet.worktypeDataTable WorkTypeTable = workTypeAdapter.GetDataByProjectID(ProjectID);

            List<WorkTypeInfo> result = new List<WorkTypeInfo>();

            foreach (NuRacingDataSet.worktypeRow WorkTypeRow in WorkTypeTable.Rows)
            {
                result.Add(new WorkTypeInfo(WorkTypeRow));
            }

            return result;
        }

        public static List<WorkTypeInfo> getAllWorkTypes()
        {
            worktypeTableAdapter workTypeAdapter = new worktypeTableAdapter();
            NuRacingDataSet.worktypeDataTable WorkTypeTable = workTypeAdapter.GetData();

            List<WorkTypeInfo> result = new List<WorkTypeInfo>();

            foreach (NuRacingDataSet.worktypeRow WorkTypeRow in WorkTypeTable.Rows)
            {
                result.Add(new WorkTypeInfo(WorkTypeRow));
            }

            return result;
        }
    }
}
