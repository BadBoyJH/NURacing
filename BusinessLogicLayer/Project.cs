using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer;
using DataAccessLayer.NuRacingDataSetTableAdapters;

namespace BusinessLogicLayer
{
    public static class Project
    {
        public static List<String> DefaultParts
        {
            get
            {
                return BusinessLogicSettings.Default.DefaultCarParts.Cast<string>().ToList<string>();
            }
        }

        public static void AddProject(string ProjectName, int YearOfProject, string ProjectDescription, bool IsActive = true)
        {
            ProjectTableAdapter projectAdapter = new ProjectTableAdapter();
            NuRacingDataSet.ProjectDataTable projectTable = new NuRacingDataSet.ProjectDataTable();

            projectAdapter.Fill(projectTable);

            NuRacingDataSet.ProjectRow newProjectRow = projectTable.NewProjectRow();

            newProjectRow.Project_Name = ProjectName;
            newProjectRow.Project_YearMade = YearOfProject;
            newProjectRow.Project_Description = ProjectDescription;
            newProjectRow.Project_Active = IsActive;
            newProjectRow.Project_Status = "Planning";
            newProjectRow.Project_StatusChangedDate = DateTime.Now;

            projectTable.AddProjectRow(newProjectRow);
            projectAdapter.Update(projectTable);
        }

        public static void AddCar(string CarName, int YearMade, string CarDescription, List<string> CarParts, bool IsCarActive = true)
        {

            AddProject(CarName, YearMade, CarDescription, IsCarActive);

            int ProjectID = -1;
            
            ProjectTableAdapter projectAdapter = new ProjectTableAdapter();
            NuRacingDataSet.ProjectDataTable projectTable = projectAdapter.GetData();

            foreach (NuRacingDataSet.ProjectRow projectRow in projectTable.Rows)
            {
                if (projectRow.Project_Name == CarName &&
                    projectRow.Project_YearMade == YearMade &&
                    projectRow.Project_Description == CarDescription &&
                    projectRow.Project_Active == IsCarActive)
                {
                    ProjectID = projectRow.Project_UID;
                    break;
                }   
            }

            if (ProjectID != -1)
            {
                foreach (string CarPart in CarParts)
                {
                    WorkType.AddWorkType(ProjectID, CarPart);
                }
            }
        }

        public static void addDefaultCar(string CarName, int YearMade, string CarDescription, bool IsCarActive = true)
        {
            AddCar(CarName, YearMade, CarDescription, DefaultParts, IsCarActive);
        }

        public static bool projectExists(int ProjectID)
        {
            return ((new ProjectTableAdapter()).GetProject(ProjectID).Rows.Count != 0);
        }

        public static bool projectActive(int ProjectID)
        {
            if (!projectExists(ProjectID))
            {
                throw new ArgumentException("Project doesn't exist");
            }
            else
            {
                ProjectTableAdapter projectAdapter = new ProjectTableAdapter();
                NuRacingDataSet.ProjectDataTable projectTable = projectAdapter.GetProject(ProjectID);
                return ((NuRacingDataSet.ProjectRow)projectTable.Rows[0]).Project_Active;
            }
        }

        public static bool userInvolvedIn(string Username, int ProjectID)
        {
            if (Role.GetUserRole(Username) != "Sponsor")
            {
                return true;
            }
            else
            {
                return (new SponsoredTableAdapter()).GetDataByBoth(Username, ProjectID).Rows.Count != 0;
            }
        }
    }
}
