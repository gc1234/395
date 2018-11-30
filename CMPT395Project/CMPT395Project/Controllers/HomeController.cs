using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CMPT395Project.Models;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CMPT395Project.Controllers
{


    public class HomeController : Controller
    {
        /**
         *The two variable below are created to store the user Login information so that it can be authenticated through the different pages.
         * */
        const string SessionName = "_Name";
        const string SessionPassword = "_Password";


        /**
         * This Function is called the first time the Attempts to login.
         * @Author: Anthony Wong
         * @Version 1.0
         * @Date: October 28,2018
         * */
        public IActionResult Index()
        {
            LoginModel log = new LoginModel
            {
                FirstLogin = true
            };
            return View(log);
        }

        public IActionResult Logout() {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
        /**
         * This Method is called after the User first attempted login and 
         * Saves the Session of the Email and password in addtion to redirecting the user if
         * it is a valid login.
         * @Author: Anthony Wong
         * @Version 1.0
         * @Date: October 28,2018
         * */
        [HttpPost]
        public IActionResult Index(LoginModel log)
        {
            log.FirstLogin = false;
            bool isNumber = int.TryParse(log.Username, out int NumOfHour);

            // Just comment out my database and put yours
            //const string db = @"Server=DESKTOP-TK3L6OJ\BASE;Database=CMPT395Project;Trusted_Connection=True;ConnectRetryCount=0";
            const string db = @"Database = CMPT395Project; Trusted_Connection = True; ConnectRetryCount = 0";


            string level = Request.Form["AccessLevel"].ToString();

            if (level == "Contractor")
            { 
                using (SqlConnection con = new SqlConnection(db))
                {
                
                    // If you wanna write any kind of query, do it this way, save it as a string then use it
                    string sql = "SELECT * FROM contractor WHERE email = '" + log.Username + "' AND password = '" + log.Password + "'";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {

                        // If the row were looking for exists, ExecuteScalar juts returns it 
                        con.Open();
                        Object obj = cmd.ExecuteScalar();
                        con.Close();

                        // if it exists
                        if (obj != null)
                        {
                            //Store the Email and Password of the user for authentication
                            HttpContext.Session.SetString(SessionName, log.Username);
                            HttpContext.Session.SetString(SessionPassword, log.Password);
                            //Redirect to about page
                            return RedirectToAction("About");
                        }

                        // if not
                        else
                        {
                            return View(log);
                        }
                    }
                }
            }
            else if (( level == "Admin") && (isNumber == true))
            {
                using (SqlConnection con = new SqlConnection(db))
                {

                    // If you wanna write any kind of query, do it this way, save it as a string then use it
                    string sql = "SELECT * FROM admin WHERE AdminId = '" + log.Username + "' AND Password = '" + log.Password + "'";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {

                        // If the row were looking for exists, ExecuteScalar juts returns it 
                        con.Open();
                        Object obj = cmd.ExecuteScalar();
                        con.Close();

                        // if it exists
                        if (obj != null)
                        {
                            //Store the Email and Password of the user for authentication
                            HttpContext.Session.SetString(SessionName, log.Username);
                            HttpContext.Session.SetString(SessionPassword, log.Password);


                            return RedirectToAction("Create", "Admins");
                        }

                        // if not
                        else
                        {
                            return View(log);
                        }
                    }
                }
            }
            else
            {
                return View(log);
            }

        }
    
        //The MainPage After Login
        public IActionResult Main() {
    
             return View();
          }


        /**
         * This Method is called the first time the user Enter the view
         * @Author: Anthony Wong
         * @Version 1.0
         * @Date: November 2,2018
         * */
        public IActionResult ReportHour() {
            ReportHourModel Hour = new ReportHourModel
            {
                InvalidHour = false
            };
            return View(Hour);
          }


        /**
         * This View is called after the user submits data back to the database
         * @Author: Anthony Wong
         * @Version 1.0
         * @Date: November 2,2018
         * */
         [HttpPost]
        public IActionResult ReportHour(ReportHourModel Hour) {

            Hour.InvalidHour = true;
            const string db = @"Server=DESKTOP-TK3L6OJ\BASE;Database=CMPT395Project;Trusted_Connection=True;ConnectRetryCount=0";




            //We should have more restriction but this is fine for demonstration as example for now
            bool isNumber = int.TryParse(Hour.StoreHour, out int NumOfHour);

            string email = HttpContext.Session.GetString("_Name");
            int empID = 0;
            int contractID = 0;
            int actualMonth = DateTime.Now.Month;
            int actualYear = DateTime.Now.Year;

            if ((isNumber == true) && (NumOfHour >= 0) && (NumOfHour < 300))
            {
                Hour.InvalidHour = false;

                //Do code to Database
                using (SqlConnection con = new SqlConnection(db))
                {
                    string sql1 = "SELECT ContractorID FROM Contractor WHERE Email = '" + email + "'";

                    using (SqlCommand cmd = new SqlCommand(sql1, con))
                    {
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            empID = reader.GetInt32(0);
                        }
                        reader.Close();
                        con.Close();

                    }

                    string sql2 = "SELECT ContractId FROM Contract WHERE ContractId = " + empID + "";

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

                    string sql3 = "INSERT EmployeeHour (ContractId, Year, Month, CurrentMonth, PreviousMonth) VALUES (" + contractID + ", " + actualYear +", " + actualMonth + ", " + empID + ", 0)";


                    using (SqlCommand cmd = new SqlCommand(sql3, con))
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();


                    }
                    return RedirectToAction("About");
                }
            }
            else
            {
                return View(Hour);

            }
           
        }
          
   

        public IActionResult About()
        {
              //This is just a checker to make sure data can go between Pages.
              ViewData["Name"] = HttpContext.Session.GetString(SessionName);
              ViewData["Message"] = "Your application description page.";

              return View();
        }

            public IActionResult Contact()
            {

                ViewData["Message"] = "Your contact page.";

                return View();
            }

            public IActionResult Privacy()
            {
                return View();
            }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
    }
