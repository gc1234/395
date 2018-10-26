using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cmpt395.Pages
{
    public class IndexModel : PageModel
    {

        public string Email { get; set; }

        public string Password { get; set; }

       
    
        [HttpGet]
        public void OnGet()
        {

        }



        //Grab data and if the sent data email is equal to Hello then we redirect the page. Have to add database to test login method Also i haven't figured out how to make a message be passed
        //back into the screen if it is a invalid attempt aka invalid login and produce a mesage saying that. 
        //@author Anthony Wong
        [HttpPost]
        public IActionResult OnPost(IndexModel Idenitity)
        {
            Email = Idenitity.Email;
            Password = Idenitity.Password;
          
            if (Email.Equals("Hello"))
            {
                
                return RedirectToPage("Content");
                
            }
            else {
              
                return null; }
            
        }

        
    }
}
