using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer;
using DataAccessLayer.NuRacingDataSetTableAdapters;

//Written By Simon Davis

//Class obtains basic info on users

namespace BusinessLogicLayer
{
    public class UserInfo
    {
        private string fullname;

        private string username;

        private string email;

        private bool isActive;

        public string FullName
        {
            get
            {
                return fullname;
            }
        }

        public string UserName
        {
            get
            {
                return username;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
        }

        public bool IsActive
        {
            get
            {
                return isActive;
            }
        }

        //Written By Simon Davis

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="userRow">A row from the User table in the database</param>

        private UserInfo(NuRacingDataSet.userRow userRow)
        {
            fullname = userRow.User_FullName;

            username = userRow.User_Username;

            email = userRow.User_Email;

            isActive = userRow.User_Active;
        }

        //Written By Simon Davis

        /// <summary>
        /// Returns a UserInfo object for the specified user
        /// </summary>
        /// <param name="Username">User's username</param>
        /// <returns></returns>

        static public UserInfo getUser(string Username)
        {
            if (!User.UsernameExists(Username))
            {
                throw new ArgumentException("Username wasn't valid");
            }

            userTableAdapter userAdapter = new userTableAdapter();

            NuRacingDataSet.userDataTable userTable = userAdapter.GetUser(Username);

            NuRacingDataSet.userRow userRow = (NuRacingDataSet.userRow) userTable.Rows[0];

            UserInfo userInfo = new UserInfo(userRow);

            return userInfo;
        }

        //Written By Simon Davis

        /// <summary>
        /// Return a list of users of type UserInfo
        /// </summary>
        /// <returns></returns>

        static public List<UserInfo> getAllUsers()
        {
            List<UserInfo> userList = new List<UserInfo>();

            userTableAdapter userAdapter = new userTableAdapter();

            NuRacingDataSet.userDataTable userTable = userAdapter.GetData();

            foreach (NuRacingDataSet.userRow row in userTable.Rows)
            {
                if (row.User_Active)
                {
                    userList.Add(new UserInfo(row));
                }
            }

            return userList;
        }
    }
}
