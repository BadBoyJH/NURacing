using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer;
using DataAccessLayer.NuRacingDataSetTableAdapters;

namespace BusinessLogicLayer
{
    public class User
    {
        static private Random randomGenerator = new Random();


        static private String HashPassword(string Password, string Salt)
        {
            return Password;
        }

        static private byte[] getByteString(int Length)
        {
            byte[] result = new byte[Length];
            randomGenerator.NextBytes(result);
            return result;
        }

        static private bool validUsername(string Username)
        {
            userTableAdapter userAdapter = new userTableAdapter();
            NuRacingDataSet.userDataTable userTable = userAdapter.GetUser(Username);

            return userTable.Rows.Count == 0;
        }

        //  Written By James Hibbard
        /// <summary>
        ///     Returns a value based on whether the password is accurate or not.
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="userRole"></param>
        static public bool authenticateUser(string Username, string Password, out string userRole)
        {
            userTableAdapter userAdapter = new userTableAdapter();
            NuRacingDataSet.userDataTable userTable = userAdapter.GetUser(Username);
            
            if (userTable.Rows.Count == 0) // No user with that username exists
            {
                userRole = null;
                return false;
            }

            if (userTable.Rows[0][userTable.User_PasswordHashColumn].ToString() == HashPassword(Password, userTable.Rows[0][userTable.User_PasswordSaltColumn].ToString()))
            {
                if (Convert.ToBoolean(userTable.Rows[0][userTable.User_ActiveColumn]))
                {
                    userRole = userTable.Rows[0][userTable.User_RoleColumn].ToString();
                    return true;
                }
                else
                {
                    userRole = null;
                    return false;
                }
            }

            userRole = null;
            return false;
        }

        /// <summary>
        ///     Sets up a reset password reset request for a given user.
        /// </summary>
        /// <param name="Username">The User to set the request for.</param>
        static public void resetPassword(string Username)
        {
            if (validUsername(Username))
            {
                passwordresetrequestTableAdapter prrAdapter = new passwordresetrequestTableAdapter();
                NuRacingDataSet.passwordresetrequestDataTable prrTable = prrAdapter.GetData();
                NuRacingDataSet.passwordresetrequestRow prrNewRow = prrTable.NewpasswordresetrequestRow();

                prrNewRow.PasswordRR_ExpiryDate = DateTime.Now.AddDays(2);
                prrNewRow.User_UserName = Username;
                prrNewRow.PasswordRR_UID = getByteString(16);

                prrTable.AddpasswordresetrequestRow(prrNewRow);
                prrAdapter.Update(prrTable);
            }
        }
    }
}
