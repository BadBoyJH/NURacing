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

        //  Written By James Hibbard
        /// <summary>
        ///     Gets a random byte string
        /// </summary>
        /// <param name="Length">The number of bytes to get</param>
        /// <returns>A randomised byte string</returns>
        static private byte[] getByteString(int Length)
        {
            byte[] result = new byte[Length];
            randomGenerator.NextBytes(result);
            return result;
        }

        //  Written By James Hibbard
        /// <summary>
        ///     Checks if the Username is stored in the database.
        /// </summary>
        /// <param name="Username">The Username to check</param>
        /// <returns>True if the username exists</returns>
        static private bool validUsername(string Username)
        {
            userTableAdapter userAdapter = new userTableAdapter();
            NuRacingDataSet.userDataTable userTable = userAdapter.GetUser(Username);

            return userTable.Rows.Count != 0;
        }

        //  Written By James Hibbard
        /// <summary>
        ///     Gets the email for the given user    
        /// </summary>
        /// <param name="Username"></param>
        /// <returns></returns>
        static public string getEmail(string Username)
        {
            userTableAdapter userAdapter = new userTableAdapter();
            NuRacingDataSet.userDataTable userTable = userAdapter.GetUser(Username);

            if (userTable.Rows.Count == 0)
            {
                throw new ArgumentException("Username wasn't a valid user");
            }
            else
            {
                return userTable.Rows[0][userTable.User_EmailColumn].ToString();
            }
        }


        //  Written By James Hibbard
        ///
        /// <summary>
        ///     Checks whether the validity of the password
        /// </summary>
        /// <param name="Username">The users Username</param>
        /// <param name="Password">The input password to check</param>
        /// <param name="userRole">Returns the role they're in (null if incorrect password)</param>
        /// <returns>True if the password is accurate</returns>
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

        //  Written By James Hibbard
        /// <summary>
        ///     Sets up a reset password reset request for a given user.
        ///     Throws ArgumentException if username is invalid.
        /// </summary>
        /// <param name="Username">The User to set the request for.</param>
        static public void resetPassword(string Username)
        {
            if (validUsername(Username))
            {
                passwordresetrequestTableAdapter prrAdapter = new passwordresetrequestTableAdapter();
                NuRacingDataSet.passwordresetrequestDataTable prrTable = prrAdapter.GetData();
                NuRacingDataSet.passwordresetrequestRow prrNewRow = prrTable.NewpasswordresetrequestRow();

                byte[] byteCode = getByteString(16);

                prrNewRow.PasswordRR_ExpiryDate = DateTime.Now.AddDays(2);
                prrNewRow.User_UserName = Username;
                prrNewRow.PasswordRR_UID = byteCode;

                prrTable.AddpasswordresetrequestRow(prrNewRow);
                prrAdapter.Update(prrTable);

                PasswordResetRequestEmail.SendPasswordResetRequest(byteCode, getEmail(Username));
            }
            else
            {
                throw new ArgumentException("Username wasn't valid");
            }
        }
    }
}
