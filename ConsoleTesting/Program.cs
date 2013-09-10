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
            Console.Write("What is the username to send the reset request for? : ");
            string Username = Console.ReadLine();
            User.resetPassword(Username);

            Console.WriteLine("\nReset Request made");
            Console.Write("What is the bytecode from the email? : ");
            string Bytecode = Console.ReadLine();
            User.generateNewPassword(Username, Bytecode);

            string userRole;
            Console.Write("What is the password from the email? : ");
            if (User.authenticateUser("BadBoyJH", "8E8524182BBB9BB8", out userRole))
            {
                Console.WriteLine("User validated");
                Console.WriteLine(userRole);
            }
            else
            {
                Console.WriteLine("User not validated");
            }

            Console.ReadLine();
        }
    }
}
