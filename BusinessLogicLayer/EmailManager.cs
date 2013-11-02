using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace BusinessLogicLayer
{
    class EmailManager
    {
        private static string ourEmail = "nuracingautoreply@gmail.com";
        private static string ourPassword = "CaJaNiSaSiTo3930";
        private static SmtpClient smtp;

        static EmailManager()
        {
            smtp = new SmtpClient("smtp.gmail.com");
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(ourEmail, ourPassword);
            smtp.Port = 587;
            smtp.EnableSsl = true;
        }

        static public void SendPasswordResetRequest(byte[] ByteCode, string Recipient)
        {
            StringBuilder builder = new StringBuilder();

            foreach (byte b in ByteCode)
            {
                builder.Append(b.ToString("X2"));
            }

            string HexCode = builder.ToString();

            string message =
                "Dear User,\n\n" +
                "Follow this link to reset your password: http://localhost:58503/confirmPasswordReset.aspx?rrid=" + HexCode + "\n\n" +
                "This email is auto generated, please don't reply.\n\nYou can contact us at nuracinghelpdesk@gmail.com\n\n" +
                "Thanks,\n\nNURacing Team";

            MailMessage email = new MailMessage();
            email.To.Add(Recipient);
            email.Subject = "NURacing - Password Reset";
            email.From = new MailAddress(ourEmail);
            email.Body = message;

            try
            {
                smtp.Send(email);
            }

            catch
            {
                //Server error?
            }
        }

        static public void sendPasswordResetEmail(string Password, string Recipient)
        {
            string message =
                "Until further notice this will have to do\n" +
                "New Password is: " + Password + "\n" +
                "NURacing Test";

            MailMessage email = new MailMessage();
            email.To.Add(Recipient);
            email.Subject = "NURacing Online - Password Reset Complete";
            email.From = new MailAddress(ourEmail);
            email.Body = message;

            smtp.Send(email);
        }

        static public void newUser(string Username, string Password, string Recipient)
        {
            string message =
                "Until further notice this will have to do\n" +
                "Username is: " + Username + "\n" +
                "Password is: " + Password + "\n" +
                "NURacing Test";

            MailMessage email = new MailMessage();
            email.To.Add(Recipient);
            email.Subject = "NURacing Online - User Registration";
            email.From = new MailAddress(ourEmail);
            email.Body = message;

            smtp.Send(email);
            
        }

        static public void taskNotification(string assignedTo, string assignedBy, string taskName, string taskDescription, string recipient)
        {
            string message =
                assignedTo + ",\n\n"
                + assignedBy + " has assigned a task to you.\n\n"
                + taskName + ": " + taskDescription + ".\n\n"
                + "Love,\nThe Administrator";
        }
    }
}
