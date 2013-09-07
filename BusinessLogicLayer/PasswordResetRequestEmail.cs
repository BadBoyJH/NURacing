using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace BusinessLogicLayer
{
    class PasswordResetRequestEmail
    {
        private static string ourEmail = "NuRacingTest@westnet.com.au";
        private static string ourPassword = "CaJaMiNiSaSiTo3930";


        static public void SendPasswordResetRequest(byte[] ByteCode, string recipient)
        {
            StringBuilder builder = new StringBuilder();

            foreach (byte b in ByteCode)
            {
                builder.Append(b.ToString("X2"));
            }

            string HexCode = builder.ToString();

            MailMessage email = new MailMessage();

            email.To.Add(recipient);
            email.Subject = "NURacing Online - Password Reset";
            email.From = new MailAddress(ourEmail);
            email.Body = generateMessage(HexCode);

            SmtpClient smtp = new SmtpClient("mail.westnet.com.au");
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(ourEmail, ourPassword);

            smtp.Send(email);
        }

        static private string generateMessage(string HexCode)
        {
            string message = 
                "Until further notice this will have to do\n" +
                "Bytecode is : " + HexCode + "\n" +
                "NURacing Test";

            return message;
        }
    }
}
