using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

using BusinessLogicLayer;

namespace NURacingWebsite
{
    public class NURacingMembershipProvider : MembershipProvider
    {
        public override string Description
        {
            get
            {
                return "NuRacing Membership Provider";
            }
        }

        public override string Name
        {
            get
            {
                return base.Name;
            }
        }

        public override string ApplicationName
        {
            get
            {
                return "NuRacingWebsite";
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public override bool EnablePasswordReset
        {
            get
            {
                return true;
            }
        }

        public override bool EnablePasswordRetrieval
        {
            get
            {
                return false;
            }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get
            {
                return false;
            }
        }

        public override bool RequiresUniqueEmail
        {
            get
            {
                return false;
            }
        }

        public override int MaxInvalidPasswordAttempts
        {
            get 
            { 
                return 3; 
            }
        }

        public override int PasswordAttemptWindow
        {
            get 
            { 
                return 15;
            }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get 
            {
                return MembershipPasswordFormat.Hashed;
            }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get 
            {
                return BusinessLogicLayer.User.passwordMinNonAlphaNumericChars;
            }
        }

        public override int MinRequiredPasswordLength
        {
            get 
            {
                return BusinessLogicLayer.User.passwordMinLength;
            }
        }


        public override string PasswordStrengthRegularExpression
        {
            get 
            {
                return BusinessLogicLayer.User.passwordRegEx;
            }
        }

        public override MembershipUser CreateUser(
            string username,
            string password,
            string email,
            string passwordQuestion,
            string passwordAnswer,
            bool isApproved,
            Object providerUserKey,
            out MembershipCreateStatus status
        )
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateUser(string Username, string Password)
        {
            string UserRole;
            return User.authenticateUser(Username, Password, out UserRole);
        }

        private MembershipUser getMembershipUser(UserInfo Info)
        {
            return new MembershipUser(null, Info.UserName, Info.UserName, Info.Email, null, null, true, Info.IsActive, new DateTime(), new DateTime(), new DateTime(), new DateTime(), new DateTime());
        }

        public override MembershipUser GetUser(string username, bool LastActivityDate)
        {
            return getMembershipUser(UserInfo.getUser(username));
        }

        public override MembershipUser GetUser(object username, bool LastActivityDate)
        {
            return GetUser((string)username, LastActivityDate);
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            List<UserInfo> UserList = UserInfo.getAllUsers();
            MembershipUserCollection result = new MembershipUserCollection();

            int startIndex = pageIndex * pageSize;
            totalRecords = 0;

            for (int i = 0; i < pageSize && pageIndex + i < UserList.Count; i++)
            {
                result.Add(getMembershipUser(UserList[startIndex + i]));
                totalRecords++;
            }

            return result;
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
 	        throw new NotImplementedException();
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string Username)
        {
            try
            {
                User.SetUserActiveStatus(Username, true);
            }
            catch (ArgumentException)
            {
                return false;
            }
            return true;
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        protected override byte[] DecryptPassword(byte[] encodedPassword)
        {
            throw new NotImplementedException();
        }

        protected override byte[] EncryptPassword(byte[] password)
        {
            throw new NotImplementedException();
        }

        protected override byte[] EncryptPassword(byte[] password, System.Web.Configuration.MembershipPasswordCompatibilityMode legacyPasswordCompatibilityMode)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }
    }
}