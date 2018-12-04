using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using CMPT395Project.Class;
using CMPT395Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMPT395Project.Controllers
{
    public class EmailController : Controller
    {
        private readonly ProjectContext _context;

        public EmailController(ProjectContext context)
        {
            _context = context;
            GetContactorEmails();
        }

        public IActionResult Index()
        {
            return View();
        }

        // Sends Emails
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(EmailModel email)
        {
            List<string> emailList = GetContactorEmails();

            if ((ModelState.IsValid) && (emailList.Count() != 0))
            {
                try
                {
                    var message = new MailMessage();

                    // add each contractor to send message to
                    foreach (var contractorEmail in emailList)
                    {
                        message.To.Add(new MailAddress(contractorEmail.ToString()));
                    }

                    message.From = new MailAddress(email.Sender.ToString());  // replace with valid value
                    message.Subject = email.Header;
                    message.Body = email.Body;
                    message.IsBodyHtml = true;

                    using (var smtp = new SmtpClient())
                    {
                        var credential = new NetworkCredential
                        {
                            UserName = email.Sender.ToString(),  // replace with valid value
                            Password = email.Pass.ToString(),  // replace with valid value
                        };

                        // for yahoo accounts
                        if ((email.Sender.Split('@')[1].Split('.')[0] == "yahoo") || (email.Sender.Split('@')[1].Split('.')[0] == "yahoomail"))
                        {
                            smtp.UseDefaultCredentials = false;
                            smtp.Credentials = credential;
                            smtp.Port = 587;
                            smtp.Host = "smtp.mail.yahoo.com";
                            smtp.EnableSsl = true;
                            await smtp.SendMailAsync(message);

                            return RedirectToAction("SentEmail");
                        }

                        // for hotmail accounts
                        else if ((email.Sender.Split('@')[1].Split('.')[0] == "hotmail") || (email.Sender.Split('@')[1].Split('.')[0] == "live") || (email.Sender.Split('@')[1].Split('.')[0] == "outlook"))
                        {
                            smtp.UseDefaultCredentials = false;
                            smtp.Credentials = credential;
                            smtp.Port = 587;
                            smtp.Host = "smtp-mail.outlook.com";
                            smtp.EnableSsl = true;
                            await smtp.SendMailAsync(message);

                            return RedirectToAction("SentEmail");
                        }

                        // for aol accounts
                        else if (email.Sender.Split('@')[1].Split('.')[0] == "aol")
                        {
                            smtp.UseDefaultCredentials = false;
                            smtp.Credentials = credential;
                            smtp.Port = 587;
                            smtp.Host = "smtp.aol.com";
                            smtp.EnableSsl = true;
                            await smtp.SendMailAsync(message);

                            return RedirectToAction("SentEmail");
                        }

                        // for google accounts
                        else
                        {
                            smtp.UseDefaultCredentials = false;
                            smtp.Credentials = credential;
                            smtp.Host = "smtp.gmail.com";
                            smtp.Port = 587;
                            smtp.EnableSsl = true;
                            await smtp.SendMailAsync(message);

                            return RedirectToAction("SentEmail");
                        }
                    }
                }

                catch
                {
                    return RedirectToAction("ErrorEmail");
                }
            }

            return View(email);
        }

        public ViewResult SentEmail()
        {
            return View();
        }

        public ViewResult ErrorEmail()
        {
            return View();
        }

        // Returns a list of contractor emails
        public List<string> GetContactorEmails()
        {
            var db = new DatabaseConnect().ConnectionString();

            string currentContractor;
            List<string> emailList = new List<string>();

            using (SqlConnection con = new SqlConnection(db))
            {
                string sql = "SELECT Email FROM Contractor";

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        currentContractor = reader.GetString(0);
                        if (ValidEmail(currentContractor))
                        {
                            emailList.Add(currentContractor);
                        }
                        
                    }
                    reader.Close();
                    con.Close();

                }
            }

            return emailList;

        }

        // Checks if the email of the contractor has inputted his hours for the month
        public Boolean ValidEmail(string email)
        {
            var db = new DatabaseConnect().ConnectionString();

            int contractID = 0;
            int empID = 0;


            using (SqlConnection con = new SqlConnection(db))
            {

                string sql1 = "SELECT ContractorID FROM Contractor WHERE Email = '" + email + "'";

                using (SqlCommand cmd = new SqlCommand(sql1, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        contractID = reader.GetInt32(0);
                    }
                    reader.Close();
                    con.Close();

                }

                string sql2 = "SELECT ContractId FROM Contract WHERE ContractorId = " + empID + "";

                using (SqlCommand cmd = new SqlCommand(sql2, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        contractID = reader.GetInt32(0);
                    }
                    reader.Close();
                    con.Close();

                }

                string sql3 = "SELECT currentMonth FROM EmployeeHour WHERE ContractId = " + contractID + " AND Year = " + DateTime.Now.Year + " And Month =" + DateTime.Now.Month + "";

                using (SqlCommand cmd = new SqlCommand(sql3, con))
                {
                    con.Open();

                    Object obj = cmd.ExecuteScalar();
                    con.Close();

                    // if it exists
                    if (obj == null)
                    {
                        return true;
                    }


                }

            }

            return false;
        }
    }
}