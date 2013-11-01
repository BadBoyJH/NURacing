using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer;
using DataAccessLayer.NuRacingDataSetTableAdapters;

namespace BusinessLogicLayer
{
    public class Role
    {
        static private BusinessLogicSettings settings;

        static public string[] UserRoles
        {
            get
            {
                return settings.UserRoles.Cast<string>().ToArray();
            }
        }

        static Role()
        {
            settings = new BusinessLogicSettings();
        }

        public static string GetUserRole(string Username)
        {
            UserTableAdapter userAdapter = new UserTableAdapter();
            NuRacingDataSet.UserDataTable userTable = userAdapter.GetUser(Username);
            NuRacingDataSet.UserRow userRow = (NuRacingDataSet.UserRow)userTable.Rows[0];

            return userRow.User_Role;
        }

        public static string[] getUsersInRole(string RoleName)
        {
            UserTableAdapter userAdapter = new UserTableAdapter();
            NuRacingDataSet.UserDataTable userTable = userAdapter.GetData();

            List<string> results = new List<string>();

            foreach (NuRacingDataSet.UserRow userRow in userTable.Rows)
            {
                results.Add(userRow.User_Username);
            }

            return results.ToArray();
        }

        public static bool greaterRole(string userRole, string comparisonRole)
        {
            if (userRole == "Administrator")
            {
                return true;
            }
            else if (userRole == "Staff")
            {
                return comparisonRole != "Administrator";
            }
            else if (userRole == "Team Leader")
            {
                return (comparisonRole == "Section Manager" ||
                    comparisonRole == "User" ||
                    comparisonRole == "Sponsor");
            }
            else
            {
                return false;
            }
        }
    }
}
