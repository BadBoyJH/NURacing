using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer;
using DataAccessLayer.NuRacingDataSetTableAdapters;

// Written By Simon Davis
// Updated By James Hibbard

//Class obtains basic info on users

namespace BusinessLogicLayer
{
    public class UserInfo
    {
        // Personal Info
        private string givenName;
        private string surname;
        private string username;
        private string email;
        private string studentnumber;
        private string estimatedGraduationYear;
        private string degree;
        private string medicareNumber;
        private string allergies;
        private string medicalConditions;
        private string dietaryRequirements;
        private bool indemnityFormSigned;

        // Society for Automotive Engineers Info
        private string saeMembershipNumber;
        private DateTime saeMembershipExpiry;

        // Confederation of Motor Sport Info
        private string camsMembershipNumber;
        private string camsLicenseType;

        // Drivers License Info
        private string driversLicenseNumber;
        private string driversLicenseState;

        // Emergency Contact Info
        private string emergencyContactName;
        private string emergencyContactPhoneNumber;

        // Internal Stuff
        private DateTime dateCreated;
        private DateTime lastLoggedIn;
        private DateTime lastActivity;
        private DateTime passwordLastChanged;
        private DateTime lastLockedOut;
        private bool isActive;

        public string GivenName
        {
            get
            {
                return givenName;
            }
        }

        public string Surname
        {
            get
            {
                return surname;
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

        public string StudentNumber
        {
            get
            {
                return studentnumber;
            }
        }

        public string EstimatedGraduationYear
        {
            get
            {
                return estimatedGraduationYear;
            }
        }

        public string Degree
        {
            get
            {
                return degree;
            }
        }

        public string MedicareNumber
        {
            get
            {
                return medicareNumber;
            }
        }

        public string Allergies
        {
            get
            {
                return allergies;
            }
        }

        public string MedicalConditions
        {
            get
            {
                return medicalConditions;
            }
        }

        public string DietaryRequirements
        {
            get
            {
                return dietaryRequirements;
            }
        }

        public bool IndemnityFormSigned
        {
            get
            {
                return indemnityFormSigned;
            }
        }

        public string SAEMembershipNumber
        {
            get
            {
                return saeMembershipNumber;
            }
        }

        public DateTime SAEMembershipExpiry
        {
            get
            {
                return saeMembershipExpiry;
            }
        }

        public string CAMSMembershipNumber
        {
            get
            {
                return camsMembershipNumber;
            }
        }

        public string CAMSLicenseType
        {
            get
            {
                return camsLicenseType;
            }
        }

        public string DriversLicenseNumber
        {
            get
            {
                return driversLicenseNumber;
            }
        }

        public string DriversLicenseState
        {
            get
            {
                return driversLicenseState;
            }
        }

        public string EmergencyContactName
        {
            get
            {
                return emergencyContactName;
            }
        }

        public string EmergencyContactPhoneNumber
        {
            get
            {
                return emergencyContactPhoneNumber;
            }
        }

        public DateTime DateCreated
        {
            get
            {
                return dateCreated;
            }
        }

        public DateTime LastLoggedIn
        {
            get
            {
                return lastLoggedIn;
            }
        }

        public DateTime LastActivity
        {
            get
            {
                return lastActivity;
            }
        }

        public DateTime PasswordLastChanged
        {
            get
            {
                return passwordLastChanged;
            }
        }

        public DateTime LastLockedOut
        {
            get
            {
                return lastLockedOut;
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
        //Updated By James Hibbard

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="userRow">A row from the User table in the database</param>

        private UserInfo(NuRacingDataSet.userRow userRow)
        {
            givenName = userRow.User_GivenName;
            surname = userRow.User_Surname;
            username = userRow.User_Username;
            email = userRow.User_Email;
            studentnumber = userRow.User_StudentNumber;
            estimatedGraduationYear = userRow.User_EstGraduationYear;
            degree = userRow.User_Degree;
            medicareNumber = userRow.User_MedicareNo;
            allergies = userRow.User_Allergies;
            medicalConditions = userRow.User_MedicareNo;
            dietaryRequirements = userRow.User_DietaryRequirements;
            indemnityFormSigned = userRow.User_IndemnityFormSigned;

            saeMembershipNumber = userRow.User_SAE_MemberNo;
            saeMembershipExpiry = userRow.User_SAE_Expiry;

            camsMembershipNumber = userRow.User_CAMS_MemberNo;
            camsLicenseType = userRow.User_CAMS_LicenseType;

            driversLicenseNumber = userRow.User_LicenseNo;
            driversLicenseState = userRow.User_LicenseState;

            emergencyContactName = userRow.User_EmergencyContactName;
            emergencyContactPhoneNumber = userRow.User_EmergencyContactNumber;

            dateCreated = userRow.User_Created;
            lastLoggedIn = userRow.User_LastLogin;
            lastActivity = userRow.User_LastActivity;
            passwordLastChanged = userRow.User_LastPasswordChanged;
            lastLockedOut = userRow.User_LastLockoutDate;
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
