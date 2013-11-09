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
        private string userRole;
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
                beenChanged = givenName != value;
                givenName = value;
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
                beenChanged = surname != value;
                surname = value;
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
                beenChanged = email != value;
                email = value;
            }
        }

        public string UserRole
        {
            get
            {
                return userRole;
            }
            set
            {
                if (Role.UserRoles.Contains<string>(value))
                {
                    beenChanged = givenName != userRole;
                    userRole = value;
                }
                else
                {
                    throw new ArgumentException(value + " is not a valid role");
                }
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
                beenChanged = studentnumber != value;
                studentnumber = value;
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
                beenChanged = estimatedGraduationYear != value;
                estimatedGraduationYear = value;
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
                beenChanged = degree != value;
                degree = value;
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
                beenChanged = medicareNumber != value;
                medicareNumber = value;
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
                beenChanged = allergies != value;
                allergies = value;
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
                beenChanged = medicalConditions != value;
                medicalConditions = value;
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
                beenChanged = dietaryRequirements != value;
                dietaryRequirements = value;
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
                beenChanged = indemnityFormSigned != value;
                indemnityFormSigned = value;
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
                beenChanged = saeMembershipNumber != value;
                saeMembershipNumber = value;
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
                beenChanged = saeMembershipExpiry != value;
                saeMembershipExpiry = value;
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
                beenChanged = camsMembershipNumber != value;
                camsMembershipNumber = value;
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
                beenChanged = camsLicenseType != value;
                camsLicenseType = value;
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
                beenChanged = beenChanged || driversLicenseNumber != value;
                driversLicenseNumber = value;
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
                beenChanged = beenChanged || driversLicenseState != value;
                driversLicenseState = value;
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
                beenChanged = beenChanged || emergencyContactName != value;
                emergencyContactName = value;
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
                beenChanged = beenChanged || emergencyContactPhoneNumber != value;
                emergencyContactPhoneNumber = value;
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
            set
            {
                beenChanged = beenChanged || isActive != value;
                isActive = value;
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
            userRole = userRow.User_Role;

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

        static public List<UserInfo> getAllUsers(bool activeOnly = true)
        {
            List<UserInfo> userList = new List<UserInfo>();

            UserTableAdapter userAdapter = new UserTableAdapter();

            NuRacingDataSet.UserDataTable userTable = userAdapter.GetData();

            foreach (NuRacingDataSet.UserRow row in userTable.Rows)
            {
                if (row.User_Active || !activeOnly)
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
                userRow.User_Role = userRole;
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
