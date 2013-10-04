using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer;
using DataAccessLayer.NuRacingDataSetTableAdapters;

namespace BusinessLogicLayer
{
    public class ProjectInfo
    {
        private int projectID;
        private string name;
        private string description;
        private bool active;
        private int? yearMade;
        private string status;
        private DateTime statusLastChanged;

        public string Name
        {
            get
            {
                return name;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
        }

        public bool IsActive
        {
            get
            {
                return active;
            }
        }

        public int? YearMade
        {
            get
            {
                return yearMade;
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

        private ProjectInfo(NuRacingDataSet.projectRow projectRow)
        {
            active = projectRow.Project_Active;
            name = projectRow.Project_Name;
            description = projectRow.Project_Description;
            projectID = projectRow.Project_UID;
            status = projectRow.Project_Status;
            statusLastChanged = projectRow.Project_StatusChangedDate;

            if (projectRow.IsProject_YearMadeNull())
            {
                yearMade = null;
            }
            else
            {
                yearMade = projectRow.Project_YearMade;
            }
        }

        public static ProjectInfo getProject(int ProjectID)
        {
            projectTableAdapter projectAdapter = new projectTableAdapter();
            NuRacingDataSet.projectDataTable projectTable = projectAdapter.GetProject(ProjectID);
            
            if (projectTable.Rows.Count == 0)
            {
                throw new ArgumentException("Project doesn't exist");
            }

            return new ProjectInfo((NuRacingDataSet.projectRow) projectTable.Rows[1]);
        }

        public static List<ProjectInfo> getUserProjects(string Username, bool OnlyActive)
        {
            if (!User.UsernameExists(Username))
            {
                throw new ArgumentException("Username doesn't exist");
            }

            projectTableAdapter projectAdapter = new projectTableAdapter();
            NuRacingDataSet.projectDataTable projectTable = projectAdapter.GetData();

            List<ProjectInfo> result = new List<ProjectInfo>();

            foreach (NuRacingDataSet.projectRow projectRow in projectTable.Rows)
            {
                if (!(
                    (OnlyActive && (!projectRow.Project_Active)) || 
                    (Project.userInvolvedIn(Username, projectRow.Project_UID))))
                {
                    result.Add(new ProjectInfo(projectRow));
                }
            }

            return result;
        }
    }
}
