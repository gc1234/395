using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cmpt395.Models;
using Microsoft.AspNetCore.Identity;
namespace Cmpt395.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        //Post Method that return data from the client and prints the data out onto the console.
        [HttpPost]
        public IActionResult Index(LoginModel Idenitity) {
            System.Diagnostics.Debug.WriteLine(Idenitity.Email);
            System.Diagnostics.Debug.WriteLine(Idenitity.Password);
            if (ModelState.IsValid) {
            }
            return View(Idenitity);

           
        }

        public IActionResult About()
        {
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
