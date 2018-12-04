using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailModel model)
        {
            List<string> emailList = GetContactorEmails();
            emailList.ElementAt(0);
            int x = 0;
            if (x == 0)
            {
                var message = new MailMessage();
                message.To.Add(new MailAddress("erik.halabi.10@gmail.com"));  // replace with valid value 
                message.From = new MailAddress("halabie2@mymacewan.ca");  // replace with valid value
                message.Subject = "test";
                message.Body = "test";
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "erik.halabi.10@gmail.com",  // replace with valid value
                        Password = "t5s2hhj72"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("SentEmail");
                }
            }
            return View();
        }

        public ViewResult Index()
        {
            List<string> emailList = GetContactorEmails();
            ViewData["test"] = ValidEmail(emailList.ElementAt(0)).ToString();
            ViewData["email"] = emailList.ElementAt(0);
            return View();
        }

        public ViewResult SentEmail()
        {
            return View();
        }

        public List<string> GetContactorEmails()
        {
            //const string db = @"Server=DESKTOP-TK3L6OJ\BASE;Database=CMPT395Project;Trusted_Connection=True;ConnectRetryCount=0";
            const string db = @"Database = CMPT395Project; Trusted_Connection = True; ConnectRetryCount = 0";

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
                        emailList.Add(currentContractor);
                        
                    }
                    reader.Close();
                    con.Close();

                }
            }

            return emailList;

        }

        public Boolean ValidEmail(string email)
        {
            //const string db = @"Server=DESKTOP-TK3L6OJ\BASE;Database=CMPT395Project;Trusted_Connection=True;ConnectRetryCount=0";
            const string db = @"Database = CMPT395Project; Trusted_Connection = True; ConnectRetryCount = 0";

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