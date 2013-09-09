using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace NURacingWebsite
{
    public class NURacingMembershipProvider : MembershipProvider
    {
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


    }
}