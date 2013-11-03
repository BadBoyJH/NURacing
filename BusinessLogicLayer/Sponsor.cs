using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.NuRacingDataSetTableAdapters;

namespace BusinessLogicLayer
{
    public static class Sponsor
    {
        public static void AddSponsor(string Username, int ProjectID)
        {
            if (!User.UsernameExists(Username))
            {
                throw new ArgumentException("Username wasn't valid");
            }

            if (Role.GetUserRole(Username) != "Sponsor")
            {
                throw new ArgumentException("User isn't a sponsor");
            }
            
            if (!Project.projectExists(ProjectID))
            {
                throw new ArgumentException("ProjectID wasn't valid");
            }

            SponsoredTableAdapter sponsoredAdapter = new SponsoredTableAdapter();
            NuRacingDataSet.SponsoredDataTable sponsoredTable = sponsoredAdapter.GetDataByBoth(Username, ProjectID);

            if (sponsoredTable.Rows.Count != 0)
            {
                throw new ArgumentException("User is already sponsoring that project");
            }
            
            NuRacingDataSet.SponsoredRow sponsoredRow = sponsoredTable.NewSponsoredRow();

            sponsoredRow.User_UserName = Username;
            sponsoredRow.Project_UID = ProjectID;

            sponsoredTable.AddSponsoredRow(sponsoredRow);
            sponsoredAdapter.Update(sponsoredTable);
        }

        public static void RemoveSponsor(string Username, int ProjectID)
        {
            if (!User.UsernameExists(Username))
            {
                throw new ArgumentException("Username wasn't valid");
            }

            if (!Project.projectExists(ProjectID))
            {
                throw new ArgumentException("ProjectID wasn't valid");
            }

            SponsoredTableAdapter sponsoredAdapter = new SponsoredTableAdapter();
            NuRacingDataSet.SponsoredDataTable sponsoredTable = sponsoredAdapter.GetDataByBoth(Username, ProjectID);
            
            foreach (NuRacingDataSet.SponsoredRow row in sponsoredTable.Rows)
            {
                row.Delete();
            }

            sponsoredAdapter.Update(sponsoredTable);
        }
    }
}
