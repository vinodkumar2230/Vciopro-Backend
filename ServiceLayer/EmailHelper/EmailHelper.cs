using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace ServiceLayer.EmailHelper
{
    public class EmailHelper
    {
        public static void SendEmail(string emailid, string body, string subject, Attachment attachmentObj, bool async)
        {

            try
            {

                string smtpEmailAddress = WebConfigurationManager.AppSettings["SMTP_DEFAULT_EMAIL"];
                string smtppassword = WebConfigurationManager.AppSettings["SMTP_DEFAULT_PASSWORD"];
                System.Net.NetworkCredential basicAuthenticationInfo1 = new System.Net.NetworkCredential(smtpEmailAddress, smtppassword);
                SmtpClient SmtpServer = new SmtpClient();
                if (WebConfigurationManager.AppSettings["SMTP_DEFAULT_HOST"] == "relay-hosting.secureserver.net")
                {

                    SmtpServer.Host = "mail.smartdatainc.net";
                    SmtpServer.Port = 25;
                    SmtpServer.UseDefaultCredentials = false;
                    SmtpServer.Credentials = basicAuthenticationInfo1;
                    SmtpServer.EnableSsl = false;
                }
                else
                {

                    SmtpServer.Host = WebConfigurationManager.AppSettings["SMTP_DEFAULT_HOST"].ToString();
                    SmtpServer.Port = 587;
                    SmtpServer.UseDefaultCredentials = false;
                    SmtpServer.Credentials = basicAuthenticationInfo1;

                }
                var mail = new System.Net.Mail.MailMessage();
                string[] multi = emailid.Split(',');
                foreach (string item in multi)
                {
                    mail.To.Add(new MailAddress(item));
                }
                mail.Subject = subject;

                mail.From = new MailAddress(smtpEmailAddress, "Displayco");
                mail.Body = body;
                if (attachmentObj != null)
                    mail.Attachments.Add(attachmentObj);
                mail.IsBodyHtml = true;

                SmtpServer.Send(mail);

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
       
        private static SmtpClient GetSMTPClient(string Host)
        {
            //return new SmtpClient
            //        {
            //            Host = "smtp.gmail.com",
            //            Port = 25,
            //            EnableSsl = false,
            //            DeliveryMethod = SmtpDeliveryMethod.Network,
            //        };
            switch (Host)
            {
                case "relay-hosting.secureserver.net":
                    return new SmtpClient
                    {
                        Host = "relay-hosting.secureserver.net",
                        Port = 25,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                    };
                default:
                    return new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 25,
                        //EnableSsl = false,
                        //DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                    };
                    //return new System.Net.Mail.SmtpClient();
            }
        }
        public static bool IsValidEmail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }




    }
}
