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
        static private RNGCryptoServiceProvider saltGenerator = new RNGCryptoServiceProvider();
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
            byte[] salt = new byte[16];
            saltGenerator.GetBytes(salt);
            return salt;

        }

        /// <summary>
        ///     Creates the Hashed Password
        /// </summary>
        /// <param name="Password">The password to has</param>
        /// <param name="Salt">The Salt to append</param>
        /// <returns>The Hash as a bytestring</returns>
        private static byte[] HashPassword(string Password, byte[] Salt)
        {
            byte[] saltAndPwd = System.Text.Encoding.Unicode.GetBytes(String.Concat(Password, Salt));
            SHA256 encryptor = SHA256.Create();
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

            return  (nonAlphaNumeric >= passwordMinNonAlphaNumericChars &&
                uppercase >= passwordMinUppercase &&
                lowercase >= passwordMinLowercase &&
                numerals >= passwordMinNumerals);
        }

        //  Written By James Hibbard
        /// <summary>
        ///     Checks if the Username is stored in the database.
        /// </summary>
        /// <param name="Username">The Username to check</param>
        /// <returns>True if the username exists</returns>
        static public bool UsernameExists(string Username)
        {
            UserTableAdapter userAdapter = new UserTableAdapter();
            NuRacingDataSet.UserDataTable userTable = userAdapter.GetUser(Username);

            return userTable.Rows.Count != 0;
        }

        static internal bool EmailExists(string Email)
        {
            UserTableAdapter userAdapter = new UserTableAdapter();
            NuRacingDataSet.UserDataTable userTable = userAdapter.GetData();
            
            foreach (NuRacingDataSet.UserRow userRow in userTable.Rows)
            {
                if (userRow.User_Email == Email)
                {
                    return true;
                }
            }

            return false;
        }

        //  Written By James Hibbard
        /// <summary>
        ///     Gets the email for the given user    
        /// </summary>
        /// <param name="Username"></param>
        /// <returns></returns>
        static public string getEmail(string Username)
        {
            UserTableAdapter userAdapter = new UserTableAdapter();
            NuRacingDataSet.UserDataTable userTable = userAdapter.GetUser(Username);

            if (userTable.Rows.Count == 0)
            {
                throw new ArgumentException("Username wasn't a valid user");
            }
            else
            {
                return userTable.Rows[0][userTable.User_EmailColumn].ToString();
            }
        }

        static public bool isEmailValid(string Email)
        {
            try
            {
                new System.Net.Mail.MailAddress(Email);
                return true;
            }
            catch
            {
                return false;
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
            
            UserTableAdapter userAdapter = new UserTableAdapter();
            NuRacingDataSet.UserDataTable userTable = userAdapter.GetUser(Username);
            NuRacingDataSet.UserRow userRow = (NuRacingDataSet.UserRow)userTable.Rows[0];


            if (userRow.User_Active)
            {
                if (userRow.User_PasswordHash.SequenceEqual(HashPassword(Password, userRow.User_PasswordSalt)))
                {
                    userRole = userRow.User_Role;
                    return true;
                }
            }
            else
            {
                userRole = null;
                return false;
            }

            userRole = null;
            return false;
        }

        //  Written By James Hibbard
        /// <summary>
        ///     Sets the Last Activity Date in the database for the given user
        /// </summary>
        /// <param name="Username">The User that was active</param>
        static public void wasActive(string Username)
        {
            if (UsernameExists(Username))
            {
                UserTableAdapter userAdapter = new UserTableAdapter();
                NuRacingDataSet.UserDataTable userTable = userAdapter.GetUser(Username);
                NuRacingDataSet.UserRow userRow = (NuRacingDataSet.UserRow)userTable.Rows[0];

                userRow.User_LastActivity = DateTime.Now;

                userAdapter.Update(userTable);
            }
        }

        //  Written By James Hibbard
        /// <summary>
        ///     Sets up a reset password reset request for a given user.
        ///     Throws ArgumentException if username is invalid.
        /// </summary>
        /// <param name="Username">The User to set the request for.</param>
        /// <param name="Email">The User's email to provide an extra layer of security.</param>
        static public void resetPassword(string Username, string Email)
        {
            if (UsernameExists(Username))
            {
                if (Email.Equals(getEmail(Username)))
                {
                    PasswordResetRequestTableAdapter prrAdapter = new PasswordResetRequestTableAdapter();
                    NuRacingDataSet.PasswordResetRequestDataTable prrTable = prrAdapter.GetData();
                    NuRacingDataSet.PasswordResetRequestRow prrNewRow = prrTable.NewPasswordResetRequestRow();

                    byte[] byteCode = getByteString(16);

                    prrNewRow.PasswordRR_ExpiryDate = DateTime.Now.AddDays(2);
                    prrNewRow.User_UserName = Username;
                    prrNewRow.PasswordRR_UID = byteCode;

                    prrTable.AddPasswordResetRequestRow(prrNewRow);
                    prrAdapter.Update(prrTable);

                    EmailManager.SendPasswordResetRequest(byteCode, getEmail(Username));
                }
                else
                {
                    throw new ArgumentException("Email wasn't correct");
                }
            }
            else
            {
                throw new ArgumentException("Username wasn't valid");
            }
        }


        static public void setPassword(string Username, string NewPassword, string OldPassword)
        {
            string UserRole;

            if (!authenticateUser(Username, OldPassword, out UserRole))
            {
                throw new ArgumentException("Old Password was incorrect");
            }

            if (!validPassword(NewPassword))
            {
                throw new ArgumentException("Password wasn't valid");
            }

            if (UsernameExists(Username))
            {
                UserTableAdapter userAdapter = new UserTableAdapter();
                NuRacingDataSet.UserDataTable userTable = userAdapter.GetUser(Username);
                NuRacingDataSet.UserRow userRow = (NuRacingDataSet.UserRow)userTable.Rows[0];

                byte[] salt = CreateSalt();
                byte[] hash = HashPassword(NewPassword, salt);

                userRow.User_PasswordHash = hash;
                userRow.User_PasswordSalt = salt;

                userAdapter.Update(userTable);
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

            UserTableAdapter userAdapter = new UserTableAdapter();
            NuRacingDataSet.UserDataTable userTable = userAdapter.GetUser(Username);

            foreach (NuRacingDataSet.UserRow userRow in userTable.Rows)
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

            PasswordResetRequestTableAdapter prrAdapter = new PasswordResetRequestTableAdapter();
            NuRacingDataSet.PasswordResetRequestDataTable prrTable = prrAdapter.GetData();

            foreach (NuRacingDataSet.PasswordResetRequestRow prrRow in prrTable.Rows)
            {
                if (ByteResetRequestID.SequenceEqual(prrRow.PasswordRR_UID) && Username == prrRow.User_UserName)
                {
                    if (prrRow.PasswordRR_ExpiryDate < DateTime.Now)
                    {
                        throw new ArgumentException("Request Expired");
                    }

                    generateNewPassword(Username);

                    prrRow.Delete();
                    prrAdapter.Update(prrTable);

                    return;
                }
            }
            throw new ArgumentException("Can't find a matching record");
        }

        public static void SetUserActiveStatus(string Username, bool active)
        {
            if (UsernameExists(Username))
            {
                UserTableAdapter userAdapter = new UserTableAdapter();
                NuRacingDataSet.UserDataTable userTable = userAdapter.GetUser(Username);
                NuRacingDataSet.UserRow userRow = userTable[0];
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

        static public UserInfo addUser(string Username, string Password, string UserRole, string GivenName, string Surname, string Email, string StudentNumber,
            string YearOfGradutation, string DegreeName, string MedicareNumber, string Allergies, string MedicalConditions, string DietaryRequirements,
            bool IndemnityFormSigned, string SAEMembershipNumber, DateTime SAEExpiryDate, string CAMSMembershipNumber, string CAMSLicenseType, 
            string DriversLicenseNumber, string DriversLicenseState, string EmergencyContactName, string EmergencyContactPhoneNumber, bool IsActive = true)
        {
            UserTableAdapter userAdapter = new UserTableAdapter();
            NuRacingDataSet.UserDataTable userTable = userAdapter.GetData();
            NuRacingDataSet.UserRow userRow = userTable.NewUserRow();

            if (UsernameExists(Username))
            {
                throw new ArgumentException("Username already exists");
            }
            if (!isEmailValid(Email))
            {
                throw new ArgumentException("Email isn't in a valid format");
            }
            //if (EmailExists(Email))
            //{
            //    throw new ArgumentException("Email already exists");
            //}
            if (!validPassword(Password))
            {
                throw new ArgumentException("Invalid Password");
            }
            if (!Role.UserRoles.Contains(UserRole))
            {
                throw new ArgumentException("Invalid Role");
            }


            byte[] Salt = CreateSalt();
            byte[] HashedPassword = HashPassword(Password, Salt);

            userRow.User_Username = Username;
            userRow.User_PasswordHash = HashedPassword;
            userRow.User_PasswordSalt = Salt;
            userRow.User_Role = UserRole;
            userRow.User_GivenName = GivenName;
            userRow.User_Surname = Surname;
            userRow.User_Email = Email;
            userRow.User_StudentNumber = StudentNumber;
            userRow.User_EstGraduationYear = YearOfGradutation;
            userRow.User_Degree = DegreeName;
            userRow.User_MedicareNo = MedicareNumber;
            userRow.User_Allergies = Allergies;
            userRow.User_MedicalConditions = MedicalConditions;
            userRow.User_DietaryRequirements = DietaryRequirements;
            userRow.User_IndemnityFormSigned = IndemnityFormSigned;
            userRow.User_SAE_MemberNo = SAEMembershipNumber;
            userRow.User_SAE_Expiry = SAEExpiryDate;
            userRow.User_CAMS_MemberNo = CAMSMembershipNumber;
            userRow.User_CAMS_LicenseType = CAMSLicenseType;
            userRow.User_LicenseNo = DriversLicenseNumber;
            userRow.User_LicenseState = DriversLicenseState;
            userRow.User_EmergencyContactName = EmergencyContactName;
            userRow.User_EmergencyContactNumber = EmergencyContactPhoneNumber;
            userRow.User_Active = IsActive;

            userRow.User_Created = DateTime.Now;
            userRow.User_LastLogin = DateTime.Now;
            userRow.User_LastActivity = DateTime.Now;
            userRow.User_LastPasswordChanged = DateTime.Now;
            userRow.User_LastLockoutDate = DateTime.Now;

            userTable.AddUserRow(userRow);
            userAdapter.Update(userTable);

            EmailManager.newUser(Username, Password, Email);

            return UserInfo.getUser(Username);
        }
    }
}
