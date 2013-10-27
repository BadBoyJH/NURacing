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
        private string username;
        private string givenName;
        private string surname;
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

        // Modification Detection
        private bool beenChanged;

        public string GivenName
        {
            get
            {
                return givenName;
            }
            set
            {
                givenName = value;
                beenChanged = true;
            }
        }

        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
                beenChanged = true;
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
            set
            {
                email = value;
                beenChanged = true;
            }
        }

        public string StudentNumber
        {
            get
            {
                return studentnumber;
            }
            set
            {
                studentnumber = value;
                beenChanged = true;
            }
        }

        public string EstimatedGraduationYear
        {
            get
            {
                return estimatedGraduationYear;
            }
            set
            {
                estimatedGraduationYear = value;
                beenChanged = true;
            }
        }

        public string Degree
        {
            get
            {
                return degree;
            }
            set
            {
                degree = value;
                beenChanged = true;
            }
        }

        public string MedicareNumber
        {
            get
            {
                return medicareNumber;
            }
            set
            {
                medicareNumber = value;
                beenChanged = true;
            }
        }

        public string Allergies
        {
            get
            {
                return allergies;
            }
            set
            {
                allergies = value;
                beenChanged = true;
            }
        }

        public string MedicalConditions
        {
            get
            {
                return medicalConditions;
            }
            set
            {
                medicalConditions = value;
                beenChanged = true;
            }
        }

        public string DietaryRequirements
        {
            get
            {
                return dietaryRequirements;
            }
            set
            {
                dietaryRequirements = value;
                beenChanged = true;
            }
        }

        public bool IndemnityFormSigned
        {
            get
            {
                return indemnityFormSigned;
            }
            set
            {
                indemnityFormSigned = value;
                beenChanged = true;
            }
        }

        public string SAEMembershipNumber
        {
            get
            {
                return saeMembershipNumber;
            }
            set
            {
                saeMembershipNumber = value;
                beenChanged = true;
            }
        }

        public DateTime SAEMembershipExpiry
        {
            get
            {
                return saeMembershipExpiry;
            }
            set
            {
                saeMembershipExpiry = value;
                beenChanged = true;
            }
        }

        public string CAMSMembershipNumber
        {
            get
            {
                return camsMembershipNumber;
            }
            set
            {
                camsMembershipNumber = value;
                beenChanged = true;
            }
        }

        public string CAMSLicenseType
        {
            get
            {
                return camsLicenseType;
            }
            set
            {
                camsLicenseType = value;
                beenChanged = true;
            }
        }

        public string DriversLicenseNumber
        {
            get
            {
                return driversLicenseNumber;
            }
            set
            {
                driversLicenseNumber = value;
                beenChanged = true;
            }
        }

        public string DriversLicenseState
        {
            get
            {
                return driversLicenseState;
            }
            set
            {
                driversLicenseState = value;
                beenChanged = true;
            }
        }

        public string EmergencyContactName
        {
            get
            {
                return emergencyContactName;
            }
            set
            {
                emergencyContactName = value;
                beenChanged = true;
            }
        }

        public string EmergencyContactPhoneNumber
        {
            get
            {
                return emergencyContactPhoneNumber;
            }
            set
            {
                emergencyContactPhoneNumber = value;
                beenChanged = true;
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

        private UserInfo(NuRacingDataSet.UserRow userRow)
        {
            setData(userRow);
        }

        private void setData(NuRacingDataSet.UserRow userRow)
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

            UserTableAdapter userAdapter = new UserTableAdapter();

            NuRacingDataSet.UserDataTable userTable = userAdapter.GetUser(Username);

            NuRacingDataSet.UserRow userRow = (NuRacingDataSet.UserRow) userTable.Rows[0];

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

            UserTableAdapter userAdapter = new UserTableAdapter();

            NuRacingDataSet.UserDataTable userTable = userAdapter.GetData();

            foreach (NuRacingDataSet.UserRow row in userTable.Rows)
            {
                if (row.User_Active)
                {
                    userList.Add(new UserInfo(row));
                }
            }

            return userList;
        }

        public void updateDatabase()
        {
            if (beenChanged)
            {
                UserTableAdapter userAdapter = new UserTableAdapter();
                NuRacingDataSet.UserDataTable userTable = userAdapter.GetUser(username);
                NuRacingDataSet.UserRow userRow = (NuRacingDataSet.UserRow)userTable.Rows[0];

                userRow.User_GivenName = givenName;
                userRow.User_Surname = surname;
                userRow.User_Email = email;
                userRow.User_StudentNumber = studentnumber;
                userRow.User_EstGraduationYear = estimatedGraduationYear;
                userRow.User_Degree = degree;
                userRow.User_MedicareNo = medicareNumber;
                userRow.User_Allergies = allergies;
                userRow.User_MedicareNo = medicalConditions;
                userRow.User_DietaryRequirements = dietaryRequirements;
                userRow.User_IndemnityFormSigned = indemnityFormSigned;

                userRow.User_SAE_MemberNo = saeMembershipNumber;
                userRow.User_SAE_Expiry = saeMembershipExpiry;

                userRow.User_CAMS_MemberNo = camsMembershipNumber;
                userRow.User_CAMS_LicenseType = camsLicenseType;

                userRow.User_LicenseNo = driversLicenseNumber;
                userRow.User_LicenseState = driversLicenseState;

                userRow.User_EmergencyContactName = emergencyContactName;
                userRow.User_EmergencyContactNumber = emergencyContactPhoneNumber;

                userRow.User_Created = dateCreated;
                userRow.User_LastLogin = lastLoggedIn;
                userRow.User_LastActivity = lastActivity;
                userRow.User_LastPasswordChanged = passwordLastChanged;
                userRow.User_LastLockoutDate = lastLockedOut;
                userRow.User_Active = isActive;

                userAdapter.Update(userTable);
            }
        }

        public void resetData()
        {
            if (!beenChanged)
            {
                UserTableAdapter userAdapter = new UserTableAdapter();
                NuRacingDataSet.UserDataTable userTable = userAdapter.GetUser(username);
                NuRacingDataSet.UserRow userRow = (NuRacingDataSet.UserRow)userTable.Rows[0];

                setData(userRow);
            }
        }
    }
}
