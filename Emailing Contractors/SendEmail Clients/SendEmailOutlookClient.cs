using System.Net.Mail;

namespace Utilities.SendEmail_Clients
{
    /// <summary>
    /// Implements an SMTP client when an employee sends an email from an msn, live, hotmail, or outlook email address.
    /// 
    /// Authors:
    ///     Brent Farand    BF
    ///     
    /// Changes:
    ///     2018-11-16  BF  Initial
    /// </summary>
    public sealed class SendEmailOutlookClient : SendEmailClient
    {
        /// <summary>
        /// Initializes the SMTP client fields as needed for an msn, live, hotmail, or outlook email address.
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
        public SendEmailOutlookClient(string employeeEmail, string employeeEmailPassword) : base(employeeEmail, employeeEmailPassword)
        {
            port = 587;
            deliveryMethod = SmtpDeliveryMethod.Network;
            host = "smtp-mail.outlook.com";
            enableSSL = true;
        }
    }
}