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
            string Email = Console.ReadLine();
            User.resetPassword(Username, Email);

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

            List<string> CarParts = new List<string>();
            CarParts.Add("Engine");
            CarParts.Add("Chasis");
            CarParts.Add("Suspension");
            CarParts.Add("Electronics");
             */

            User.addUser("TestAcc", "abc123lol", "Administrator", "Steve", "McQueen", "NuRacingTest@westnet.com.au", "StudentNumber", "YearOfGraduation Fake Data", "DegreeName Fake Data", "MedicareNumber Fake Data", "Allergies Fake Data", "MedicalConditions Fake Data", "DietaryRequirements Fake Data", true, "SAEMembershipNumber Fake Data", DateTime.Now.AddYears(2), "CAMSMembershipNumber Fake Data", "CAMSLicenseType Fake Data", "DriversLicenseNumber Fake Data", "DriversLicenseState Fake Data", "EmergencyContactName Fake Data", "EmergencyContactPhoneNumber Fake Data");
            User.addUser("asdfsdfsd","abc123lol" ,"Administrator","ddddddd","sdgsdg","ddddddd@ddddd.com","c3145577", "YearOfGraduation Fake Data", "DegreeName Fake Data", "MedicareNumber Fake Data", "Allergies Fake Data", "MedicalConditions Fake Data", "DietaryRequirements Fake Data", true, "SAEMembershipNumber Fake Data", DateTime.Now.AddYears(2), "CAMSMembershipNumber Fake Data", "CAMSLicenseType Fake Data", "DriversLicenseNumber Fake Data", "DriversLicenseState Fake Data", "EmergencyContactName Fake Data", "EmergencyContactPhoneNumber Fake Data");
            User.addUser("Bob Saget","abc123lol","Administrator","Sagettttt","Bobbbbbbb","Callanbush2@hotmail.com", "11111111111", "YearOfGraduation Fake Data", "DegreeName Fake Data", "MedicareNumber Fake Data", "Allergies Fake Data", "MedicalConditions Fake Data", "DietaryRequirements Fake Data", true, "SAEMembershipNumber Fake Data", DateTime.Now.AddYears(2), "CAMSMembershipNumber Fake Data", "CAMSLicenseType Fake Data", "DriversLicenseNumber Fake Data", "DriversLicenseState Fake Data", "EmergencyContactName Fake Data", "EmergencyContactPhoneNumber Fake Data");
            User.addUser("Smoogy","abc123lol","Administrator","Cush","Ballan","Callanbush2@hotmail.com","c3145510", "YearOfGraduation Fake Data", "DegreeName Fake Data", "MedicareNumber Fake Data", "Allergies Fake Data", "MedicalConditions Fake Data", "DietaryRequirements Fake Data", true, "SAEMembershipNumber Fake Data", DateTime.Now.AddYears(2), "CAMSMembershipNumber Fake Data", "CAMSLicenseType Fake Data", "DriversLicenseNumber Fake Data", "DriversLicenseState Fake Data", "EmergencyContactName Fake Data", "EmergencyContactPhoneNumber Fake Data");
            
            
            /*
            Project.addDefaultCar("Big Red Car", 0, "Chugga Chugga big red car");

            Project.addDefaultCar("NU17", 2015, "The car that James deserves", true);
    
            List<string> assignedUser = new List<string>();
            assignedUser.Add("TestAcc");

            AssignedTask.addTask("TestAcc", assignedUser, 1, new DateTime(2013, 10, 15), "Do Stuff", "Do some stuff really well", false);
            AssignedTask.addTask("TestAcc", assignedUser, 1, new DateTime(2013, 10, 15), "Do Moree Stuff", "Do some stuff even well", false);
            AssignedTask.addTask("TestAcc", assignedUser, 1, new DateTime(2013, 10, 15), "Do Even More Stuff", "Do some stuff very well", false);
            AssignedTask.addTask("TestAcc", assignedUser, 1, new DateTime(2013, 10, 15), "Do All The Stuff", "Yeah Whatever", false);
            */
            Console.WriteLine("Done adding data");

            Console.ReadLine();
        }
    }
}
