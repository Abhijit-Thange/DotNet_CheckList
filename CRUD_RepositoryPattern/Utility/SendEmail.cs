using CRUD_Operations_Product_and_Category.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Utility
{
    public class SendEmail :ISendEmail
    {
        public void sendMail(User user)
        {
           /* // Send email to logged -in user
            string emailSubject = "Welcome to our application";
            string emailBody = "Thank you for logging in. Welcome to our application!";
            string senderEmail = "arifkhan@nimapinfotech.com";

            WebMail.Send(senderEmail, emailSubject, emailBody, null, null, null, true, null, null, null, null, null, null);
         */   // Sender's email address and display name
            string emailSubject = "Welcome to our application";
            string emailBody = "Thank you for logging in. Welcome to our application!";
            string senderEmail = "thangeabhijit1998@gmail.com";
            string senderName = "Abhijit Thange";

            // Receiver's email address
            string receiverEmail = "abhijitthange4@gmail.com";

            // Create the email message
            MailMessage mail = new MailMessage();
            mail.Subject = emailSubject;
            mail.Body = emailBody;
            mail.From = new MailAddress(senderEmail, senderName);
            mail.To.Add(receiverEmail);

            // Configure the SMTP client
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential("abhijitthange@nimapinfotech.com", "Abhi@1998");

            // Send the email
              smtpClient.Send(mail);
          //  smtpClient.Send(senderEmail, receiverEmail, emailSubject, emailBody);

            // Redirect to the desired page after successful login

        }
    }
}
