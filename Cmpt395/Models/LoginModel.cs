using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Cmpt395.Models
{
    //Login Model to store password and Email
    public class LoginModel
    {
        
        public string Email { get; set; }
        
        public string Password { get; set; }
       
    }
}
