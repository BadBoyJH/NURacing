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
            
            if (!Project.projectExists(ProjectID))
            {
                throw new ArgumentException("ProjectID wasn't valid");
            }

            SponsoredTableAdapter sponsoredAdapter = new SponsoredTableAdapter();
            NuRacingDataSet.SponsoredDataTable sponsoredTable = sponsoredAdapter.GetData();
            NuRacingDataSet.SponsoredRow sponsoredRow = sponsoredTable.NewSponsoredRow();

            sponsoredRow.User_UserName = Username;
            sponsoredRow.Project_UID = ProjectID;

            sponsoredTable.AddSponsoredRow(sponsoredRow);
            sponsoredAdapter.Update(sponsoredTable);
        }
    }
}
