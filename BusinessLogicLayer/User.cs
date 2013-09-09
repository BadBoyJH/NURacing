using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Security.Cryptography;

using DataAccessLayer;
using DataAccessLayer.NuRacingDataSetTableAdapters;

namespace BusinessLogicLayer
{
    public static class User
    {
        static private Random randomGenerator = new Random();
        
        static public string passwordRegEx
        {
            get
            {
                return settings.passwordRegEx;
            }
        }

        static public int passwordMinNonAlphaNumericChars
        {
            get
            {
                return settings.passwordMinNonAlphaNumericChars;
            }
        }

        static public int passwordMinUppercase
        {
            get
            {
                return settings.passwordMinUppercase;
            }
        }

        static public int passwordMinLowercase
        {
            get
            {
                return settings.passwordMinLowercase;
            }
        }
        
        static public int passwordMinNumerals
        {
            get
            {
                return settings.passwordMinNumerals;
            }
        }

        static public int passwordMinLength
        {
            get
            {
                return settings.passwordMinLength;
            }
        }

        static private BusinessLogicSettings settings;

        static User()
        {
            settings = new BusinessLogicSettings();
        }
       
        /// <summary>
        ///     Generates a random salt
        /// </summary>
        /// <returns>16 byte salt</returns>
        private static byte[] CreateSalt()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] salt = new byte[16];
            rng.GetBytes(salt);
            return salt;

        }

        private static byte[] HashPassword(string Password, byte[] Salt)
        {
            byte[] saltAndPwd = System.Text.Encoding.Unicode.GetBytes(String.Concat(Password, Salt));
            SHA1 encryptor = SHA1.Create();
            byte[] hash = encryptor.ComputeHash(saltAndPwd);

            return hash;
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

        /// <summary>
        ///     Checks if the given password is valid
        /// </summary>
        /// <param name="password">The password to check</param>
        /// <returns>True the password is valid</returns>
        static public bool validPassword(string password)
        {
            if (password.Length < passwordMinLength)
            {
                return false;
            }

            if (passwordRegEx != "")    
            {
                Regex RegularExpression = new Regex(passwordRegEx);
                Match match = RegularExpression.Match(password);
                if (match.Captures.Count == 0)
                {
                    return false;
                }
                if (match.Captures[0].Length == password.Length)
                {
                    return false;
                }
            }

            int nonAlphaNumeric = 0;
            int lowercase = 0;
            int uppercase = 0;
            int numerals = 0;
            
            foreach (char c in password)
            {
                if ('0' <= c && c <= '9')
                {
                    numerals++;
                }
                else if ('A' <= c && c <= 'Z')
                {
                    uppercase++;
                }
                else if ('A' <= c && c <= 'Z')
                {
                    lowercase++;
                }
                else
                {
                    nonAlphaNumeric++;
                }
            }

            return  (nonAlphaNumeric > passwordMinNonAlphaNumericChars &&
                uppercase > passwordMinUppercase &&
                lowercase > passwordMinLowercase &&
                numerals > passwordMinNumerals);
        }

        //  Written By James Hibbard
        /// <summary>
        ///     Checks if the Username is stored in the database.
        /// </summary>
        /// <param name="Username">The Username to check</param>
        /// <returns>True if the username exists</returns>
        static internal bool UsernameExists(string Username)
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
            if (!UsernameExists(Username))
            {
                userRole = null;
                return false;
            }
            
            userTableAdapter userAdapter = new userTableAdapter();
            NuRacingDataSet.userDataTable userTable = userAdapter.GetUser(Username);

            NuRacingDataSet.userRow userRow = (NuRacingDataSet.userRow)userTable.Rows[0];
            if (userRow.User_PasswordHash.SequenceEqual(HashPassword(Password, userRow.User_PasswordSalt)))
            {
                if (userRow.User_Active)
                {
                    userRole = userRow.User_Role;
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
            if (UsernameExists(Username))
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

                EmailManager.SendPasswordResetRequest(byteCode, getEmail(Username));
            }
            else
            {
                throw new ArgumentException("Username wasn't valid");
            }
        }

        static private void generateNewPassword(string Username)
        {
            StringBuilder builder = new StringBuilder();
            byte[] ByteCode = getByteString(8);
            foreach (byte b in ByteCode)
            {
                builder.Append(b.ToString("X2"));
            }
            string newPassword = builder.ToString();

            userTableAdapter userAdapter = new userTableAdapter();
            NuRacingDataSet.userDataTable userTable = userAdapter.GetUser(Username);

            foreach (NuRacingDataSet.userRow userRow in userTable.Rows)
            {
                if (userRow.User_Username == Username)
                {
                    byte[] salt = CreateSalt();
                    byte[] hash = HashPassword(newPassword, salt);

                    userRow.User_PasswordHash = hash;
                    userRow.User_PasswordSalt = salt;

                    userAdapter.Update(userTable);

                    EmailManager.sendPasswordResetEmail(newPassword, userRow.User_Email);
                }
            }
        }


        static public void generateNewPassword(string Username, string ResetRequestID)
        {
            if (ResetRequestID.Length != 32)
            {
                throw new ArgumentException("ResetRequestID should be 32 characters");
            }

            byte[] ByteResetRequestID = new byte[16];

            for (int i = 0; i < ResetRequestID.Length / 2; i++)
            {
                ByteResetRequestID[i] = (byte)((ResetRequestID[i * 2] - (ResetRequestID[i * 2] < 58 ? 48 : 55)) * 16 + (ResetRequestID[i * 2 + 1] - (ResetRequestID[i * 2 + 1] < 58 ? 48 : 55)));
            }

            passwordresetrequestTableAdapter prrAdapter = new passwordresetrequestTableAdapter();
            NuRacingDataSet.passwordresetrequestDataTable prrTable = prrAdapter.GetData();

            foreach (NuRacingDataSet.passwordresetrequestRow prrRow in prrTable.Rows)
            {
                if (ByteResetRequestID.SequenceEqual(prrRow.PasswordRR_UID) && Username == prrRow.User_UserName)
                {
                    if (prrRow.PasswordRR_ExpiryDate < DateTime.Now)
                    {
                        throw new ArgumentException("Request Expired");
                    }

                    generateNewPassword(Username);
                    return;
                }
            }
            throw new ArgumentException("Can't find a matching record");
        }

        public static void SetUserActiveStatus(string Username, bool active)
        {
            if (UsernameExists(Username))
            {
                userTableAdapter userAdapter = new userTableAdapter();
                NuRacingDataSet.userDataTable userTable = userAdapter.GetUser(Username);
                NuRacingDataSet.userRow userRow = userTable[0];
                if (userRow.User_Active != active)
                {
                    //avoid making the connection if possible
                    userRow.User_Active = active;
                    userAdapter.Update(userTable);
                }
            }
            else
            {
                throw new ArgumentException("Username wasn't valid");
            }
        }
    }
}
