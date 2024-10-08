using System.Drawing.Printing;
using System.Net;
using System.Net.Mail;

namespace WorkflowSpecflowTests.Email
{
    public interface IEmailSender
    {
        Task SendEmailWithAttachmentAsync(string smtpUsername, string to, string subject, string body, string attachmentPath);
        Task SendEmailWithoutAttachmentAsync(string smtpUsername, string to, string subject, string body);

    }

    public class EmailSender : IEmailSender
    {

        private string _smtpUsername;
        private string _smtpPassword;

        private async Task LoginWith(string smtpUsername)
        {
            switch (smtpUsername)
            {
                case "Svc_HiscoxUKWorkflowAuto1":
                    _smtpUsername = "Svc_HiscoxUKWorkflowAuto1@hiscox.com";
                    _smtpPassword = "B5VmjAzKDov3Quer";
                    break;
                case "Svc_HiscoxUKWorkflowAuto2":
                    _smtpUsername = "Svc_HiscoxUKWorkflowAuto2@hiscox.com";
                    _smtpPassword = "B5VmjAzKDov3Quer";
                    break;
                case "Svc_HiscoxUKWorkflowAuto3":
                    _smtpUsername = "Svc_HiscoxUKWorkflowAuto3@hiscox.com";
                    _smtpPassword = "jPVfAlJ2h3WzCq71R6sX";
                    break;
                case "Svc_HiscoxUKWorkflowAuto4":
                    _smtpUsername = "Svc_HiscoxUKWorkflowAuto4@hiscox.com";
                    _smtpPassword = "uDdgltoiA3VB2LnmQ55b";
                    break;
                case "JohnsumitTest":
                    _smtpUsername = "JohnsumitTest@hotmail.com";
                    _smtpPassword = "Hiscox2024 ";
                    break;
                case "Haroldhanestest":
                    _smtpUsername = "Haroldhanestest@hotmail.com";
                    _smtpPassword = "Hiscox2024";
                    break;
                case "Tonysmithtest":
                    _smtpUsername = "Tonysmithtest@hotmail.com";
                    _smtpPassword = "Hiscox2024 ";
                    break;
                case "Sarahjones":
                    _smtpUsername = "Sarahjones@hotmail.com";
                    _smtpPassword = "Hiscox212024 ";
                    break;
                case "Garyadamstest":
                    _smtpUsername = "Garyadamstest@hotmail.com";
                    _smtpPassword = "Hiscox2024 ";
                    break;
                default:
                    break;
            }
        }

        public async Task SendEmailWithoutAttachmentAsync(string from, string to, string subject, string body)
        {
            try
            {
                LoginWith(from);
                using (var mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(from + "@hiscox.com");
                    mailMessage.To.Add(to + "@hiscox.com");
                    mailMessage.Subject = subject;
                    mailMessage.Body = body;
                    mailMessage.IsBodyHtml = true;


                    using (var smtpClient = new SmtpClient("relay.hiscox.com", 25))
                    {
                        smtpClient.Credentials = new NetworkCredential(_smtpUsername, _smtpPassword);
                        smtpClient.EnableSsl = false;

                        //Send the email
                        await smtpClient.SendMailAsync(mailMessage);
                        Console.WriteLine("Error sent successfully!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
            }
        }

        public async Task SendEmailWithAttachmentAsync(string from, string to, string subject, string body, string attachmentPath)
        {
            try
            {
                LoginWith(from);
                using (var mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(from + "@hiscox.com");
                    mailMessage.To.Add(to + "@hiscox.com");
                    mailMessage.Subject = subject;
                    mailMessage.Body = body;
                    mailMessage.IsBodyHtml = true;
                    if (!string.IsNullOrEmpty(attachmentPath) && File.Exists(attachmentPath))
                    {
                        var attachment = new Attachment(attachmentPath);
                        mailMessage.Attachments.Add(attachment);
                    }


                    using (var smtpClient = new SmtpClient("relay.hiscox.com", 25))
                    {
                        smtpClient.Credentials = new NetworkCredential(_smtpUsername, _smtpPassword);
                        smtpClient.EnableSsl = false;

                        //Send the email
                        await smtpClient.SendMailAsync(mailMessage);
                        Console.WriteLine("Error sent successfully!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
            }
        }
    }
}
