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

                //This is a checker to see if the user is a valid user and should be replace with a database instead of this test function.
                if (log.Email.Equals("a@g"))
                {

                    //Store the Email and Password of the user for authentication
                    HttpContext.Session.SetString(SessionName, log.Email);
                    HttpContext.Session.SetString(SessionPassword, log.Password);
                    //Redirect to about page
                    return RedirectToAction("About");
                }
                //if it is unsuccessful in attempt to login we go back to page with new data aka firstlogin = false;
                return View(log);
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
            //We should have more restriction but this is fine for demonstration as example for now
            if (int.TryParse(Hour.Hour, out int NumOfHour))
            {
                Hour.InvalidHour = false;
                //Do code to Database
                return RedirectToAction("Main");
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
