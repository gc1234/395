using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using Utilities.SendEmail_Clients;

namespace Utilities
{
    /// <summary>
    /// This class manages the sending of email messages to contractors.
    /// This allows contractors to be reminded to submit their monthly invoices.
    /// 
    /// Authors:
    ///     Brent Farand    BF
    ///     
    /// Changes:
    ///     2018-11-15  BF  Initial
    ///     2018-11-16  BF  Reworked to allow sending email to any email address provider
    ///     2018-11-18  BF  Reworked to be more generic: can now be used to email anyone rather than just contractors
    ///                     Added methods to allow this class creater usability in the future
    ///                         Different ways of setting fields of the email, allowing attachments, etc.
    ///                         This allows the class to be used for any method of emailing, in this project or others
    ///     
    /// References:
    ///     https://stackoverflow.com/questions/449887/sending-e-mail-using-c-sharp
    ///     https://stackoverflow.com/questions/9201239/send-e-mail-via-smtp-using-c-sharp
    /// </summary>
    public sealed class SendEmail
    {
        // The instance of SendEmail - Singleton design pattern
        private static readonly Lazy<SendEmail> instance = new Lazy<SendEmail>(() => new SendEmail());

        // The list of recipients to send the email message to
        private List<string> recipients;

        // The email to send to all recipients 
        private MailMessage mail;

        // The name of the sender of the email - used as the closing part of the email
        private string senderName;

        // The email address of the sender of the email
        private string senderEmailAddress;

        /// <summary>
        /// Returns the instance of SendEmail - Singleton design pattern.
        /// 
        /// Authors:
        ///     Brent Farand    BF
        ///     
        /// Changes:
        ///     2018-11-15  BF  Initial
        /// </summary>
        public static SendEmail Instance
        {
            get { return instance.Value; }
        }

        /// <summary>
        /// Constructor for the instance of SendEmail.
        /// 
        /// Authors:
        ///     Brent Farand    BF
        ///     
        /// Changes:
        ///     2018-11-15  BF  Initial
        /// </summary>
        private SendEmail() { }

        /// <summary>
        /// Sets the sender's name of the email.
        /// 
        /// Authors:
        ///     Brent Farand    BF
        ///     
        /// Changes:   
        ///     2018-11-15  BF  Initial
        /// </summary>
        /// 
        /// <param name="name">The name of the email's sender</param>
        public static void SetSenderName(string name)
        {
            Instance.senderName = name;
        }

        /// <summary>
        /// Sets the email address of the sender of the email.
        /// 
        /// Authors:
        ///     Brent Farand    BF
        ///     
        /// Changes:
        ///     2018-11-16  BF  Initial
        /// </summary>
        /// 
        /// <param name="emailAddress">The email address of the mail's sender</param>
        public static void SetSenderEmailAddress(string emailAddress)
        {
            Instance.senderEmailAddress = emailAddress;
        }

        /// <summary>
        /// Sets the recipient of the email to only the email address given.
        /// This clears all previous recipients of the email.
        /// 
        /// Authors:
        ///     Brent Farand    BF
        ///     
        /// Changes:
        ///     2018-11-18  BF  Initial
        /// </summary>
        /// 
        /// <param name="emailAddress">The email address of the recipient</param>
        public static void SetRecipient(string emailAddress)
        {
            if(Instance.recipients == null)
            {
                Instance.recipients = new List<string>();
            }
            Instance.recipients.Clear();
            Instance.recipients.Add(emailAddress);
        }

        /// <summary>
        /// Adds the given email address as a recipient of the email.
        /// Functionally different than "SetRecipient" as it adds the email address instead of making it the only email address.
        /// 
        /// Authors:
        ///     Brent Farand    BF
        ///     
        /// Changes:
        ///     2018-11-18  BF  Initial
        /// </summary>
        /// 
        /// <param name="emailAddress">The email address to add to the recipients of the email</param>
        public static void AddRecipient(string emailAddress)
        {
            Instance.recipients.Add(emailAddress);
        }

        /// <summary>
        /// Sets the recipients of the email to the list of email addresses given.
        /// 
        /// Authors:
        ///     Brent Farand    BF
        ///     
        /// Changes:
        ///     2018-11-18  BF  Initial
        /// </summary>
        /// 
        /// <param name="emailAddresses">The email addresses to set as the recipients of the email</param>
        public static void SetRecipients(List<string> emailAddresses)
        {
            Instance.recipients = emailAddresses;
        }

        /// <summary>
        /// Adds the given email addresses to the recipients of the email.
        /// 
        /// Authors:
        ///     Brent Farand    BF
        ///     
        /// Changes:
        ///     2018-11-18  BF  Initial
        /// </summary>
        /// 
        /// <param name="emailAddresses">Email addresses to add to the recipients of the email</param>
        public static void AddRecipients(List<string> emailAddresses)
        {
            Instance.recipients.AddRange(emailAddresses);
        }

        /// <summary>
        /// Creates a new MailMessage to be prepared with sender and recipient information.
        /// 
        /// Authors:
        ///     Brent Farand    BF
        ///     
        /// Changes
        ///     2018-11-18  BF  Initial
        /// </summary>
        public static void StartEmail()
        {
            Instance.mail = new MailMessage();
            Instance.mail.From = new MailAddress(Instance.senderEmailAddress, "Contracting Company");
        }

        /// <summary>
        /// Sets the subject of the email.
        /// 
        /// Authors:
        ///     Brent Farand    BF
        ///     
        /// Changes:
        ///     2018-11-15  BF  Initial
        /// </summary>
        /// 
        /// <param name="subject">The subject of the email</param>
        public static void SetSubject(string subject)
        {
            if(Instance.mail != null)
            {
                Instance.mail.Subject = subject;
            }
            else
            {
                Console.WriteLine("Attempted to assign a subject to the email without initialization.");
            }
        }

        /// <summary>
        /// Sets the body of the email message.
        /// 
        /// Authors:
        ///     Brent Farand    BF
        ///     
        /// Changes:
        ///     2018-11-15  BF  Initial
        /// </summary>
        /// 
        /// <param name="body">The body (main content) of the email</param>
        public static void SetBody(string body)
        {
            if(Instance.mail != null)
            {
                Instance.mail.Body = body;
            }
            else
            {
                Console.WriteLine("Attempted to assign a body to the email without initialization.");
            }
        }

        /// <summary>
        /// Sets the priority level of the mail.
        /// 
        /// Authors:
        ///     Brent Farand    BF
        ///     
        /// Changes:
        ///     2018-11-15  BF  Initial
        /// </summary>
        /// 
        /// <param name="priority">The priority of the email</param>
        public static void SetPriority(MailPriority priority)
        {
            if(Instance.mail != null)
            {
                Instance.mail.Priority = priority;
            }
            else
            {
                Console.WriteLine("Attempted to assign a priority to the email without initialization.");
            }
        }

        /// <summary>
        /// Adds the given attachment to the email, converting it to a file.
        /// 
        /// Authors:
        ///     Brent Farand    BF
        ///     
        /// Changes:
        ///     2018-11-18  BF  Initial
        /// </summary>
        /// 
        /// <param name="attachment">The attachment (in bytes) to attach to the email message</param>
        /// <param name="fileName">The desired name of the file created from the byte array</param>
        public static void AddAttachment(byte[] attachment, string fileName)
        {
            if (Instance.mail != null)
            {
                if(attachment[0] == 0x25 && attachment[1] == 0x50 && attachment[2] == 0x44 && attachment[3] == 0x46)
                {
                    fileName = fileName + ".pdf";
                }
                else
                {
                    fileName = fileName + ".docx";
                }
                Instance.mail.Attachments.Add(new Attachment(new MemoryStream(attachment), fileName));
            }
            else
            {
                Console.WriteLine("Attempted to add an attachment to the email without initialization.");
            }

        }

        /// <summary>
        /// Sends an email to all contractor emails in 'contractorEmails'.
        /// The email's subject is emailSubject and its body is emailBody.
        /// 
        /// Authors:
        ///     Brent Farand    BF
        ///     
        /// Changes:
        ///     2018-11-15  BF  Initial
        /// </summary>
        /// 
        /// <param name="emailAddressPassword">The password to the email address of the employee sending the email</param>
        public static void Email(string senderEmailAddressPassword)
        {
            using (SmtpClient client = SendEmailClientFactory.CreateSendEmailClient(Instance.senderEmailAddress, senderEmailAddressPassword).GetSmptClient())
            {
                Instance.mail.Body = Instance.mail.Body.Replace("[Employee Name]", Instance.senderName);
                foreach (string recipient in Instance.recipients)
                {
                    Instance.mail.To.Add(recipient);
                    client.Send(Instance.mail);
                    Instance.mail.To.Clear();
                }
            }
        }

        /// <summary>
        /// Disposes the previously created MailMessage.
        /// 
        /// Authors:
        ///     Brent Farand    BF
        ///     
        /// Changes:
        ///     2018-11-18  BF  Initial
        /// </summary>
        public static void EndEmail()
        {
            Instance.mail.Dispose();
        }
    }
}