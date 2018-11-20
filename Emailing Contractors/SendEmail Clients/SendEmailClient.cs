using System.Net;
using System.Net.Mail;

namespace Utilities.SendEmail_Clients
{
    /// <summary>
    /// This class provides a framework for all SMTP clients to implement.
    /// This is done to allow an employee to send email reminders, regardless of their own email provider.
    /// 
    /// Authors:
    ///     Brent Farand    BF
    ///     
    /// Changes:
    ///     2018-11-16  BF  Initial
    /// </summary>
    public abstract class SendEmailClient
    {
        protected int port;
        protected SmtpDeliveryMethod deliveryMethod;
        protected bool useDefaultCredentials;
        protected string host;
        protected ICredentialsByHost credentials;
        protected bool enableSSL;

        /// <summary>
        /// Initializes a new SmtpClient with parameters consistent for all SmtpClient hosts.
        /// 
        /// Authors:
        ///     Brent Farand    BF
        ///     
        /// Changes:
        ///     2018-11-16  BF  Initial
        /// </summary>
        /// 
        /// <param name="employeeEmail">The email address of the employee</param>
        /// <param name="employeeEmailPassword">The password to the email address of the employee</param>
        public SendEmailClient(string employeeEmail, string employeeEmailPassword)
        {
            useDefaultCredentials = false;
            credentials = new NetworkCredential(employeeEmail, employeeEmailPassword);
        }

        /// <summary>
        /// Returns a new SmtpClient using the client's given information.
        /// 
        /// Authors:
        ///     Brent Farand    BF
        ///     
        /// Changes:
        ///     2018-11-16  BF  Initial
        /// </summary>
        /// 
        /// <returns>A new SmtpClient</returns>
        public SmtpClient GetSmptClient()
        {
            return new SmtpClient
            {
                Port = port,
                DeliveryMethod = deliveryMethod,
                UseDefaultCredentials = useDefaultCredentials,
                Host = host,
                Credentials = credentials,
                EnableSsl = enableSSL
            };
        }
    }
}