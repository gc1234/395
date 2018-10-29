using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Models;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        /**
         *The two variable below are created to store the user Login information so that it can be authenticated through the different pages.
         * */
        const string SessionName = "_Name";
        const string SessionPassword ="_Password";


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
        public IActionResult Index(LoginModel log) {

            
            
            log.FirstLogin = false;

            //This is a checker to see if the user is a valid user and should be replace with a database instead of this test function.
            if (log.Email.Equals("a@g")) {

                //Store the Email and Password of the user for authentication
                HttpContext.Session.SetString(SessionName, log.Email);
                HttpContext.Session.SetString(SessionPassword, log.Password);
                //Redirect to about page
                return RedirectToAction("About");
            }
            //if it is unsuccessful in attempt to login we go back to page with new data aka firstlogin = false;
            return View(log);
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
