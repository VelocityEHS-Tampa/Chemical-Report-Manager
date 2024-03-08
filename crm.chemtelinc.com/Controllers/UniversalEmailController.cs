using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace crm.chemtelinc.com.Controllers
{
    public class UniversalEmailController : Controller
    {
        public void SendUniversalEmail(string toEmails, string subject, string body, string AttachmentLocation, string ProgramName)
        {
            var client = new SendGridClient("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");
            var from = new EmailAddress("ers@ehs.com");
            string[] emails = toEmails.Split(',');

            //Need a list created for SendGrid to send to multiple email address.
            List<EmailAddress> to = new List<EmailAddress>();
            foreach (string email in emails)
            {
                if (email.Trim() != null && email.Trim() != "")
                {
                    to.Add(new EmailAddress(email.Trim()));
                }
            }
            to.Add(new EmailAddress("ers@ehs.com"));
            to.Add(new EmailAddress("mpepitone@ehs.com"));

            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, to, subject, "", body, true);
            //Attach Saved PDF to email
            if (AttachmentLocation != null && AttachmentLocation != "")
            {
                var filename = Path.GetFileName(AttachmentLocation);
                var bytes = System.IO.File.ReadAllBytes(AttachmentLocation); //Get Attachment Bytes
                var file = Convert.ToBase64String(bytes);
                msg.AddAttachment(filename, file); //Add Attachment to email.
            }
            var response = client.SendEmailAsync(msg);

            string path = @"\\chem-fs1.ers.local\Log Files\CRMEmails.log";
            StreamWriter log;
            if (System.IO.File.Exists(path))
                log = System.IO.File.AppendText(path);
            else
                log = System.IO.File.CreateText(path);
            log.WriteLine("Date: " + DateTime.Now.ToShortDateString() + "\n" + "Time: " + DateTime.Now.ToShortTimeString() + "\n" + "Email Type: " + ProgramName + "\n Message: " + response.Result.StatusCode + "\n" + "\n\n\n");
            log.Close();
        }
    }
}