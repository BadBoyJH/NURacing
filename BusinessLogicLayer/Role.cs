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
            userTableAdapter userAdapter = new userTableAdapter();
            NuRacingDataSet.userDataTable userTable = userAdapter.GetUser(Username);
            NuRacingDataSet.userRow userRow = (NuRacingDataSet.userRow)userTable.Rows[0];

            return userRow.User_Role;
        }

        public static string[] getUsersInRole(string RoleName)
        {
            userTableAdapter userAdapter = new userTableAdapter();
            NuRacingDataSet.userDataTable userTable = userAdapter.GetData();

            List<string> results = new List<string>();

            foreach (NuRacingDataSet.userRow userRow in userTable.Rows)
            {
                results.Add(userRow.User_Username);
            }

            return results.ToArray();
        }
    }
}
