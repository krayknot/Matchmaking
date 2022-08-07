using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace BulkEmail
{
    class Global
    {
        public void sendMail(string fromEmailAddress, string fromDisplayName, string toEmailAddress,
                            string toDisplayName, string subject, string body, string password, string img, string host)
        {
            try
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(fromEmailAddress, fromDisplayName);
                msg.To.Add(new MailAddress(toEmailAddress, toEmailAddress));


                msg.Subject = subject;
                msg.Body = body;
                msg.IsBodyHtml = true;

                System.Net.NetworkCredential mailAuthentication = new System.Net.NetworkCredential(fromEmailAddress, password);
                System.Net.Mail.SmtpClient mailClient = new System.Net.Mail.SmtpClient(host);
                mailClient.EnableSsl = false;
                mailClient.UseDefaultCredentials = false;
                mailClient.Credentials = mailAuthentication;
                mailClient.Send(msg);

            }

            catch (Exception ex)
            {

            }



           
          
        }








        public void sendMailfromgmail(string fromEmailAddress, string fromDisplayName, string toEmailAddress,
                           string toDisplayName, string subject, string body, string password, string img, string host, int port)
        {
            try
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(fromEmailAddress, fromDisplayName);
                msg.To.Add(new MailAddress(toEmailAddress, toEmailAddress));


                msg.Subject = subject;
                msg.Body = body;
                msg.IsBodyHtml = true;

                System.Net.NetworkCredential mailAuthentication = new System.Net.NetworkCredential(fromEmailAddress, password);
                System.Net.Mail.SmtpClient mailClient = new System.Net.Mail.SmtpClient(host, port);
                mailClient.EnableSsl = true;
                mailClient.UseDefaultCredentials = false;
                mailClient.Credentials = mailAuthentication;
                mailClient.Send(msg);

            }

            catch (Exception ex)
            {

            }



           
        }










        public static string html = string.Empty;
        public static string excel = string.Empty;
        public static string image = string.Empty;
        public static string imgexcel = string.Empty;
    }
}
