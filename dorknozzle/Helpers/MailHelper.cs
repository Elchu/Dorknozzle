using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace dorknozzle.Helpers
{
    public static class MailHelper
    {
        private static SmtpClient _smtpClient;

        static MailHelper()
        {
            _smtpClient = new SmtpClient();
        }

        public static void SendEmail(string recipientAddress, string subject, string news)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("aspmvc0@gmail.com", "Subskrypcja", Encoding.UTF8);

                mail.Bcc.Add(new MailAddress(recipientAddress));

                mail.Subject = subject;
                mail.Body = news;
                mail.SubjectEncoding = Encoding.UTF8;
                mail.BodyEncoding = Encoding.UTF8;
                mail.Priority = MailPriority.High;

                _smtpClient.Send(mail);
            }
        }

        public static void SendEmailAll(List<string> recipientAddress, string subject, string news)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("aspmvc0@gmail.com", "Subskrypcja", Encoding.UTF8);

                foreach (string adres in recipientAddress)
                {
                    mail.Bcc.Add(new MailAddress(adres));
                }

                mail.Subject = subject;
                mail.Body = news;
                mail.SubjectEncoding = Encoding.UTF8;
                mail.BodyEncoding = Encoding.UTF8;
                mail.Priority = MailPriority.High;

                _smtpClient.Send(mail);
            }
        }
    }
}
