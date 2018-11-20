namespace Utilities.SendEmail_Clients
{
    /// <summary>
    /// Creates the proper SMTP client given an employee's email address.
    /// Factory design pattern.
    /// 
    /// Authors:
    ///     Brent Farand    BF
    ///     
    /// Changes:
    ///     2018-11-16  BF  Initial
    /// References:
    ///     https://www.c-sharpcorner.com/article/factory-method-design-pattern-in-c-sharp/
    ///     https://stackoverflow.com/questions/19446001/send-smtp-mail-from-gmail-live-aol-or-yahoo-accounts-when-my-pc-is-connected-v
    /// </summary>
    public static class SendEmailClientFactory
    {
        /// <summary>
        /// Given the email address and email address password of an employee, creates a new SMTP client.
        /// The SMTP client created is tailored for the server of the employee's email address.
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
        /// <returns>A new SendEmailClient for the server of the employee's email address</returns>
        public static SendEmailClient CreateSendEmailClient(string employeeEmail, string employeeEmailPassword)
        {
            switch (employeeEmail.Split('@')[1].Split('.')[0])
            {
                case ("msn"):
                case ("live"):
                case ("hotmail"):
                case ("outlook"):
                    return new SendEmailOutlookClient(employeeEmail, employeeEmailPassword);
                case ("aol"):
                    return new SendEmailAOLClient(employeeEmail, employeeEmailPassword);
                case ("yahoo"):
                case ("ymail"):
                case ("rocketmail"):
                case ("yahoomail"):
                    return new SendEmailYahooClient(employeeEmail, employeeEmailPassword);
                default:
                    return new SendEmailGoogleClient(employeeEmail, employeeEmailPassword);
            }
        }
    }
}