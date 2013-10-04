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
            /*
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


            Console.WriteLine("Starting...");
            WorkType.AddWorkType(2, "yeheheheh");
            Console.WriteLine("Done");

            Console.WriteLine("");


            foreach (WorkTypeInfo WT in WorkTypeInfo.getWorkTypes(2))
            {
                Console.WriteLine(String.Format("ID: {0}\nName: {1}\n", WT.WorkTypeID, WT.Name));
            }

            Console.ReadLine();
            */

            List<string> CarParts = new List<string>();
            CarParts.Add("Engine");
            CarParts.Add("Chasis");
            CarParts.Add("Suspension");
            CarParts.Add("Electronics");

            Project.AddCar("Big Red Car", 0, "Chugga Chugga big red car", CarParts);

            Console.ReadLine();
        }
    }
}
