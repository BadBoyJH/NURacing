using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Configuration.Provider;

using BusinessLogicLayer;

namespace NURacingWebsite
{
    public class NuRacingRoleProvider : RoleProvider
    {
        public override string ApplicationName
        {
            get
            {
                return "NuRacing Website";
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            return Roles.GetAllRoles();
        }

        public override string[] GetRolesForUser(string Username)
        {
            if (!User.UsernameExists(Username))
            {
                return new string[0];
            }
            else
            {
                string[] result = new string[1];
                result[0] = Role.GetUserRole(Username);
                return result;
            }
        }

        public override string[] GetUsersInRole(string RoleName)
        {
            if (RoleName == null)
            {
                throw new ArgumentNullException("RoleName");
            }

            if (RoleName == "" || RoleName.Contains(','))
            {
                throw new ArgumentException("RoleName was invalid");
            }

            if (!Role.UserRoles.Contains(RoleName))
            {
                throw new ProviderException("Rolename doesn't exist");
            }

            return Role.getUsersInRole(RoleName);
        }

        public override bool IsUserInRole(string Username, string RoleName)
        {
            return Role.GetUserRole(Username) == RoleName;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string RoleName)
        {
            return Role.UserRoles.Contains(RoleName);
        }
    }
}