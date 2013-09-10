using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    class Role
    {
        static private BusinessLogicSettings settings;

        static public string[] UserRoles
        {
            get
            {
                return settings.UserRoles.Cast<string>().ToArray();
            }
        }

        static Role()
        {
            settings = new BusinessLogicSettings();
        }
    }
}
