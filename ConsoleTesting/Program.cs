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

            //User.addUser("TestAcc", "abc123lol", "Administrator", "Steve", "McQueen", "NuRacingTest@westnet.com.au", "StudentNumber", "YearOfGraduation Fake Data", "DegreeName Fake Data", "MedicareNumber Fake Data", "Allergies Fake Data", "MedicalConditions Fake Data", "DietaryRequirements Fake Data", true, "SAEMembershipNumber Fake Data", DateTime.Now.AddYears(2), "CAMSMembershipNumber Fake Data", "CAMSLicenseType Fake Data", "DriversLicenseNumber Fake Data", "DriversLicenseState Fake Data", "EmergencyContactName Fake Data", "EmergencyContactPhoneNumber Fake Data");
            //User.addUser("asdfsdfsd","abc123lol" ,"Administrator","ddddddd","sdgsdg","ddddddd@ddddd.com","c3145577", "YearOfGraduation Fake Data", "DegreeName Fake Data", "MedicareNumber Fake Data", "Allergies Fake Data", "MedicalConditions Fake Data", "DietaryRequirements Fake Data", true, "SAEMembershipNumber Fake Data", DateTime.Now.AddYears(2), "CAMSMembershipNumber Fake Data", "CAMSLicenseType Fake Data", "DriversLicenseNumber Fake Data", "DriversLicenseState Fake Data", "EmergencyContactName Fake Data", "EmergencyContactPhoneNumber Fake Data");
            //User.addUser("Bob Saget","abc123lol","Administrator","Sagettttt","Bobbbbbbb","Callanbush2@hotmail.com", "11111111111", "YearOfGraduation Fake Data", "DegreeName Fake Data", "MedicareNumber Fake Data", "Allergies Fake Data", "MedicalConditions Fake Data", "DietaryRequirements Fake Data", true, "SAEMembershipNumber Fake Data", DateTime.Now.AddYears(2), "CAMSMembershipNumber Fake Data", "CAMSLicenseType Fake Data", "DriversLicenseNumber Fake Data", "DriversLicenseState Fake Data", "EmergencyContactName Fake Data", "EmergencyContactPhoneNumber Fake Data");
            //User.addUser("Smoogy","abc123lol","Administrator","Cush","Ballan","Callanbush2@hotmail.com","c3145510", "YearOfGraduation Fake Data", "DegreeName Fake Data", "MedicareNumber Fake Data", "Allergies Fake Data", "MedicalConditions Fake Data", "DietaryRequirements Fake Data", true, "SAEMembershipNumber Fake Data", DateTime.Now.AddYears(2), "CAMSMembershipNumber Fake Data", "CAMSLicenseType Fake Data", "DriversLicenseNumber Fake Data", "DriversLicenseState Fake Data", "EmergencyContactName Fake Data", "EmergencyContactPhoneNumber Fake Data");
            
            
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

            //string[] TestAccOnly = new string[1];
            //TestAccOnly[0] = "TestAcc";

            //Work.CompleteTask(TestAccOnly, DateTime.Now.AddDays(4), 3, "I did some stuff", 30, true);
            //Work.CompleteTask(TestAccOnly, DateTime.Now.AddDays(4), 3, "I did lots stuff", 30, true);
            //Work.CompleteTask(TestAccOnly, DateTime.Now.AddDays(4), 4, "Can I stop now?", 30, true);
            //Work.CompleteTask(TestAccOnly, DateTime.Now.AddDays(4), 7, "I am a dwarf, and I'm digging a hole, diggy diggy hole, I'm digging a hole", 1, true);

            //BusinessLogicLayer.TakeFiveResponse[] response1 = new BusinessLogicLayer.TakeFiveResponse[4];

            //response1[0].TakeFiveID = 1;
            //response1[0].Response = "DILLIGAF";
            //response1[1].TakeFiveID = 3;
            //response1[1].Response = "Lots of oil on the floor";
            //response1[2].TakeFiveID = 5;
            //response1[2].Response = "I shouted, does that count?";
            //response1[3].TakeFiveID = 7;
            //response1[3].Response = "Handle this you pansy";

            //AssignedTask.addTask("Smoogy", TestAccOnly.ToList<string>(), 1, DateTime.Now.AddMinutes(1000), "Be very rude", "Go ahead, make our day", true);


            //Work.CompleteTask(TestAccOnly, DateTime.Now, 8, "Insulted now?", 2, response1);

            User.addUser("LurgitSponsor", "abc123lol", "Sponsor", "Steve", "Jobs", "SteveJobs@hotmail.com", "c3145510", "YearOfGraduation Fake Data", "DegreeName Fake Data", "MedicareNumber Fake Data", "Allergies Fake Data", "MedicalConditions Fake Data", "DietaryRequirements Fake Data", true, "SAEMembershipNumber Fake Data", DateTime.Now.AddYears(2), "CAMSMembershipNumber Fake Data", "CAMSLicenseType Fake Data", "DriversLicenseNumber Fake Data", "DriversLicenseState Fake Data", "EmergencyContactName Fake Data", "EmergencyContactPhoneNumber Fake Data");

            Sponsor.AddSponsor("LurgitSponsor", 3);

            Console.WriteLine("Done adding data");

            Console.ReadLine();
        }
    }
}
