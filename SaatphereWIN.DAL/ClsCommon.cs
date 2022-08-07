using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Win32;
using System.Net.Mail;
using System.Net;

namespace SaatphereWIN.DAL
{
    public class ClsCommon
    {
        public enum SearchMode
        {
            City,
            Id,
            Name,
            Mobile,
            Email,
            AssignedCustomers,
            AssignedExecutives
        }

        public bool IsNumeric(string s)
        {
            int output;
            return int.TryParse(s, out output);
        }


        public void ExecuteQuery(string Query)
        {
            var con = new SqlConnection(Global.SaatphereCon);
            var query = Query;

            var cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
        }


        /// <summary>
        /// Removes the HTML tag and its attriutes from the text provided
        /// </summary>
        /// <returns></returns>
        public string RemoveHtmlTag(string textToFilter)
        {
            string body = textToFilter;
            bool foundFlag = false;
            string filteredText = string.Empty;
            string response = string.Empty;

            for (int i = 0; i <= body.Length - 1; i++)
            {
                if (body.Substring(i, 1) == "<")
                {
                    foundFlag = true;
                }
                else if (body.Substring(i, 1) == ">")
                {
                    foundFlag = false;
                }

                if (!foundFlag)
                {
                    filteredText = filteredText + body.Substring(i, 1);
                }
            }

            response = filteredText.Replace("<", "").Replace(">", "");
            return response;
        }


        public string GetRandomPassword(int length)
        {
            char[] chars = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&".ToCharArray();
            var password = string.Empty;
            var random = new Random();

            for (int i = 0; i < length; i++)
            {
                int x = random.Next(1, chars.Length);
                //Don't Allow Repetation of Characters
                if (!password.Contains(chars.GetValue(x).ToString()))
                    password += chars.GetValue(x);
                else
                    i--;
            }
            return password;
        }

        public void SendMailfromSaatphere(string fromEmailAddress, string fromDisplayName, string toEmailAddress,
                               string toDisplayName, string subject, string body, string frmpass = "")
        {
            //check the default mail sending setting
            //read mail sending via google or peopleonegroup
            Microsoft.Win32.RegistryKey keyEmailPreference = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("EMAILPREFERENCE");
            string emailSender = keyEmailPreference.GetValue("EmailSender").ToString();

            if (emailSender == "Google")
            {
                try
                {
                    SendGmail(fromEmailAddress, fromDisplayName, toEmailAddress, toDisplayName, subject, body, frmpass);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                
            }
            else if (emailSender == "PeopleOneGroup")
            {
                try
                {
                    //Read emailaddress and password from the registry
                    //may 14, 2017
                    //--------------------------------------------------------------------------------------------------------
                    RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("PROFILESENDINGEMAIL");
                    string emailAddress = key.GetValue("EmailAddress").ToString();
                    string password = key.GetValue("Password").ToString();
                    //--------------------------------------------------------------------------------------------------------

                    fromEmailAddress = "profiles@peopleonegroup.com";

                    MailAddress SendFrom = new MailAddress("profiles@peopleonegroup.com", fromDisplayName);
                    MailAddress SendTo = new MailAddress(toEmailAddress, toDisplayName);

                    MailMessage MyMessage = new MailMessage(SendFrom, SendTo); //Direct mail From to To
                    MailAddress Bcc = new MailAddress("saatphereprofilematch@gmail.com", "");
                    MyMessage.Bcc.Add(Bcc);

                    MyMessage.Subject = subject;
                    MyMessage.Body = body;
                    MyMessage.IsBodyHtml = true;

                    var emailClient = new SmtpClient("mail.peopleonegroup.com");
                    var SMTPUserInfo = new NetworkCredential("profiles@peopleonegroup.com", "P@rents1982");

                    emailClient.EnableSsl = false;
                    emailClient.UseDefaultCredentials = false;
                    emailClient.Credentials = SMTPUserInfo;

                    emailClient.Send(MyMessage);
                }
                catch (Exception)
                {
                    SendGmail(fromEmailAddress, fromDisplayName, toEmailAddress, toDisplayName, subject, body, frmpass);

                    if (toEmailAddress == "krayknot@gmail.com")
                    {
                        //If Error sending mail then send the mail via ErrorHandler
                        SendMailfromGoogleAccount(fromEmailAddress, toEmailAddress, "", "webmaster@shreeshaadi.com", subject, body);
                        //Error describing mail
                        SendMailfromGoogleAccount(fromEmailAddress, toEmailAddress, "", "webmaster@shreeshaadi.com", "Saatphere: Mail Feature not running", body);
                    }
                }
            }
        }

        public void SendGmail(string fromEmailAddress, string fromDisplayName, string toEmailAddress,
                               string toDisplayName, string subject, string body, string frmpass = "")
        {
            //Read emailaddress and password from the registry
            //may 14, 2017
            //--------------------------------------------------------------------------------------------------------
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("PROFILESENDINGEMAIL");
            string emailAddress = key.GetValue("GmailEmailAddress").ToString();
            string password = key.GetValue("GmailPassword").ToString();
            //--------------------------------------------------------------------------------------------------------

            var fromAddress = new MailAddress(emailAddress, fromDisplayName);
            var toAddress = new MailAddress(toEmailAddress, toDisplayName);
            string fromPassword = password;
            
            var smtp = new SmtpClient
            {                
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body, 
                IsBodyHtml=true
            })
            {
                smtp.Send(message);
            }
        }
        
        public void SendMailfromGoogleAccount(string sender, string receiver, string cc, string bcc, string subject, string body)
        {
            try
            {
                //Read emailaddress and password from the registry
                //may 14, 2017
                //--------------------------------------------------------------------------------------------------------
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("PROFILESENDINGEMAIL");
                string emailAddress = key.GetValue("GmailEmailAddress").ToString();
                string password = key.GetValue("GmailPassword").ToString();
                //--------------------------------------------------------------------------------------------------------


                /* Create a new blank MailMessage with the from and to adreesses*/
                var mailMessage = new MailMessage(sender, receiver);
                /*Checking the condition that the cc is empty or not if not then * include them*/
                if (!string.IsNullOrEmpty(cc))
                {
                    mailMessage.CC.Add(cc);
                }
                /*Checking the condition that the Bcc is empty or not if not then * include them*/
                if (!string.IsNullOrEmpty(bcc))
                {
                    mailMessage.Bcc.Add(bcc);
                }

                //Ading Subject to the Mail
                mailMessage.Subject = subject;

                //Adding the Mail Body
                mailMessage.Body = body;

                mailMessage.IsBodyHtml = true;
                
                /* Set the SMTP server and send the email with attachment */
                SmtpClient smtpClient = new SmtpClient();
                //this will be the host in case of gamil and it varies from the service provider
                smtpClient.Host = "smtp.gmail.com";
                //this will be the port in case of gamil for dotnet and it varies from the service provider
                smtpClient.Port = 587;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new System.Net.NetworkCredential(emailAddress, password);

                //this will be the true in case of gamil and it varies from the service provider
                smtpClient.EnableSsl = true;
                smtpClient.Send(mailMessage);
              
            }
            catch (Exception ex)
            {

            }
        }



        public DataSet GetTableData(string TableName)
        {
            return GetDatasetonSQLQuery(Global.GetTableData.Replace("{TABLENAME}", TableName));
        }

        public DataSet GetTableDatafromQuery(string Query)
        {
            return GetDatasetonSQLQuery(Query);
        }

        public DataSet GetTables()
        {
            return GetDatasetonSQLQuery(Global.GetAllTables);
        }

        /// <summary>
        /// Return Dataset based on the SQL Query provided
        /// </summary>
        /// <param name="SQLQuery">SQL Query</param>
        /// <returns></returns>
        public DataSet GetDatasetonSQLQuery(string SQLQuery, string Connection)
        {
            SqlConnection con = new SqlConnection(Connection);
            string query = SQLQuery;

            SqlDataAdapter dad = new SqlDataAdapter(query, con);
            DataSet dst = new DataSet();
            dad.Fill(dst);
            con.Dispose();

            return dst;
        }

        public DataSet GetDatasetonSQLQuery(string SQLQuery)
        {
            SqlConnection con = new SqlConnection(Global.SaatphereCon);
            string query = SQLQuery;

            SqlDataAdapter dad = new SqlDataAdapter(query, con);
            DataSet dst = new DataSet();
            dad.Fill(dst);
            con.Dispose();
              
            return dst;
        }

        public string Read(string KeyName)
        {
            // Opening the registry key
            RegistryKey rk = Registry.LocalMachine;
            // Open a subKey as read-only
            RegistryKey sk1 = rk.OpenSubKey("SOFTWARE\\Saatphere");
            // If the RegistrySubKey doesn't exist -> (null)
            if (sk1 == null)
            {
                return null;
            }
            else
            {
                try
                {
                    // If the RegistryKey exists I get its value
                    // or null is returned.
                    return (string)sk1.GetValue(KeyName.ToUpper());
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public string Write(string KeyName, object Value)
        {
            string response = string.Empty;
            
            try
            {
                // Setting
                RegistryKey rk = Registry.LocalMachine;
                // I have to use CreateSubKey 
                // (create or open it if already exits), 
                // 'cause OpenSubKey open a subKey as read-only
                RegistryKey sk1 = rk.CreateSubKey("SOFTWARE\\Saatphere");
                // Save the value
                sk1.SetValue(KeyName.ToUpper(), Value);

                //return true;
            }
            catch (Exception e)
            {
                response = e.Message;
                //return false;
            }
            return response;
        }

        public DataSet SearchBiodata(string SearchString, SearchMode Searchmode)
        {
            DataSet response = new DataSet();
            string query = Global.SearchQuery;

            if (Searchmode == SearchMode.City)
            {
                query = query + " and city='" + SearchString + "'";
            }
            else if (Searchmode == SearchMode.Email)
            {
                query = query + " and (Biodata.Email LIKE '%" + SearchString + "%' OR Biodata.Biodata_Email2 LIKE '%" + SearchString + "%')";               
            }
            else if (Searchmode == SearchMode.Id)
            {
                query = query + " and RowIdBiodata like '%" + SearchString + "%'";
            }
            else if (Searchmode == SearchMode.Mobile)
            {
                query = query + " and Biodata.Mobile LIKE '%" + SearchString + "%'";
            }
            else if (Searchmode == SearchMode.Name)
            {
                query = query + " and ( Name LIKE '%" + SearchString + "%' OR FirstName LIKE '%" + SearchString + "%' OR SurName LIKE '%" + SearchString + "%')";
            }
            else if (Searchmode == SearchMode.AssignedCustomers)
            {
                query = "SELECT " + SaatphereWIN.DAL.Global.SearchResultsColumnsCustomerDetails + " FROM [dbo].[CustomerDetails] where CustomerDetails_ExecutiveDSRID = " + SearchString;
            }
            else if (Searchmode == SearchMode.AssignedExecutives)
            {
                query = "SELECT " + SaatphereWIN.DAL.Global.SearchResultsColumnsCustomerDetails + " FROM [dbo].[CustomerDetails] where CustomerDetails_Name like '%" + SearchString + "%'";

            }


            response = GetDatasetonSQLQuery(query);

            return response;
        }

    }
}
