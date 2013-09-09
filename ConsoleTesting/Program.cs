using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLogicLayer;

namespace ConsoleTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            //User.resetPassword("BadBoyJH");

            //User.generateNewPassword("BadBoyJH", "89C84AD9ED219D77D180FA5B0E8287A3");

            string userRole;
            User.authenticateUser("BadBoyJH", "8E8524182BBB9BB8", out userRole);
            Console.WriteLine(userRole);

            Console.ReadLine();
        }
    }
}
