using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using ACM;
using Models;

namespace Services
{
    public class EmailSender : IEmailSender
    {
        public bool Send(string to, string subject, string text)
        {
            try
            {
                SmtpClient client = new SmtpClient(MagicStrings.GmailString, 587);
                client.EnableSsl = true;
                client.Timeout = 100000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(MagicStrings.EmailSenderName, MagicStrings.EmailSenderPassword);
                MailMessage mail = new MailMessage(MagicStrings.EmailSenderName, to, subject, text);
                mail.IsBodyHtml = true;
                mail.BodyEncoding = UTF8Encoding.UTF8;
                client.Send(mail);
                return true;
            }
            catch (Exception)
            {
                throw new Utilities.ACMException();
            }

        }
    }
}
