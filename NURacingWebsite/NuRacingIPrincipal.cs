using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Security.Principal;

namespace NURacingWebsite
{
    public class NuRacingIPrincipal : System.Security.Principal.IPrincipal
    {
        private IIdentity myIdentity;
        private string [] userRoles;

        public IIdentity Identity
        {
            get
            {
                return myIdentity;
            }
        }

        public NuRacingIPrincipal(IIdentity identity, string [] roles)
        {
            myIdentity = identity;
            userRoles = new string[roles.Length];
            roles.CopyTo(userRoles, 0);
            Array.Sort(userRoles);
        }

        public bool IsInRole(string role)
        {
            return Array.BinarySearch(userRoles, role) >= 0;
        }
    }
}