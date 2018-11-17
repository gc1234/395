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

            // Just a heads up guys, we might wanna think about implementing some sort of password protector
            // Im sure its fine and we can leave it if we dont have time, but if we do, hashing the passwords would be our best bet

            // Just comment out my database and put yours
            //const string db = @"Server=DESKTOP-TK3L6OJ\BASE;Database=CMPT395Project;Trusted_Connection=True;ConnectRetryCount=0";
            const string db = @"Database = CMPT395Project; Trusted_Connection = True; ConnectRetryCount = 0";

            using (SqlConnection con = new SqlConnection(db))
            {

                // If you wanna write any kind of query, do it this way, save it as a string then use it
                string sql = "SELECT * FROM contractor WHERE email = '" + log.Email + "' AND password = '" + log.Password + "'";
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
                        HttpContext.Session.SetString(SessionName, log.Email);
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
            //const string db = @"Server=DESKTOP-TK3L6OJ\BASE;Database=CMPT395Project;Trusted_Connection=True;ConnectRetryCount=0";




                //We should have more restriction but this is fine for demonstration as example for now
                bool isNumber = int.TryParse(Hour.StoreHour, out int NumOfHour);
            if ((isNumber == true) && (NumOfHour >= 0) && (NumOfHour < 300))
            {
                Hour.InvalidHour = false;
                return RedirectToAction("Main");

                /*
                //Do code to Database
                using (SqlConnection con = new SqlConnection(db))
                {


                    string sql = "SELECT contractor_id FROM contractor WHERE email = '" + SessionName + "'";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        con.Close();

                        using (SqlCommand cmd = new SqlCommand(sql, con))
                        {

                        }
                            return RedirectToAction("Main");
                    }
                } */
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
