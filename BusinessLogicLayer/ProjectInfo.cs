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

        private bool beenChanged;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                beenChanged = beenChanged || value != name;
                name = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                beenChanged = beenChanged || value != description;
                description = value;
            }
        }

        public bool IsActive
        {
            get
            {
                return active;
            }
            set
            {
                beenChanged = beenChanged || value != active;
                active = value;
            }
        }

        public int? YearMade
        {
            get
            {
                return yearMade;
            }
            set
            {
                beenChanged = beenChanged || value != yearMade;
                yearMade = value;
            }

        }

        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                if (value != status)
                {
                    beenChanged = true;
                    status = value;
                    statusLastChanged = DateTime.Now;
                }
            }
        }

        public DateTime StatusLastChanged
        {
            get
            {
                return statusLastChanged;
            }
        }

        public int ProjectID
        {
            get
            {
                return projectID;
            }
        }

        private ProjectInfo(NuRacingDataSet.ProjectRow projectRow)
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
            beenChanged = false;
        }

        public static ProjectInfo getProject(int ProjectID)
        {
            ProjectTableAdapter projectAdapter = new ProjectTableAdapter();
            NuRacingDataSet.ProjectDataTable projectTable = projectAdapter.GetProject(ProjectID);
            
            if (projectTable.Rows.Count == 0)
            {
                throw new ArgumentException("Project doesn't exist");
            }

            return new ProjectInfo((NuRacingDataSet.ProjectRow) projectTable.Rows[0]);
        }

        public static List<ProjectInfo> getUserProjects(string Username, bool OnlyActive)
        {
            if (!User.UsernameExists(Username))
            {
                throw new ArgumentException("Username doesn't exist");
            }

            ProjectTableAdapter projectAdapter = new ProjectTableAdapter();
            NuRacingDataSet.ProjectDataTable projectTable = projectAdapter.GetData();

            List<ProjectInfo> result = new List<ProjectInfo>();

            foreach (NuRacingDataSet.ProjectRow projectRow in projectTable.Rows)
            {
                if (!(
                    (OnlyActive && (!projectRow.Project_Active)) ||
                    !(Project.userInvolvedIn(Username, projectRow.Project_UID))))
                {
                    result.Add(new ProjectInfo(projectRow));
                }
            }

            return result;
        }


        public static List<ProjectInfo> getProjects(bool OnlyActive = true)
        {
            ProjectTableAdapter projectAdapter = new ProjectTableAdapter();
            NuRacingDataSet.ProjectDataTable projectTable = projectAdapter.GetData();

            List<ProjectInfo> result = new List<ProjectInfo>();

            foreach (NuRacingDataSet.ProjectRow projectRow in projectTable.Rows)
            {
                result.Add(new ProjectInfo(projectRow));
            }
            return result;
        }

        public void updateDatabase()
        {
            if (beenChanged)
            {
                ProjectTableAdapter projectAdapter = new ProjectTableAdapter();
                NuRacingDataSet.ProjectDataTable projectTable = projectAdapter.GetProject(projectID);
                NuRacingDataSet.ProjectRow projectRow = (NuRacingDataSet.ProjectRow)(projectTable.Rows[0]);

                projectRow.Project_Active = active;
                projectRow.Project_Name = name;
                projectRow.Project_Description = description;
                projectRow.Project_UID = projectID;
                projectRow.Project_Status = status;
                projectRow.Project_StatusChangedDate = statusLastChanged;

                projectAdapter.Update(projectTable);
            }
        }

        public void resetData()
        {
            ProjectTableAdapter projectAdapter = new ProjectTableAdapter();
            NuRacingDataSet.ProjectDataTable projectTable = projectAdapter.GetProject(projectID);
            NuRacingDataSet.ProjectRow projectRow = (NuRacingDataSet.ProjectRow)(projectTable.Rows[0]);

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
            beenChanged = false;
        }
    }
}
