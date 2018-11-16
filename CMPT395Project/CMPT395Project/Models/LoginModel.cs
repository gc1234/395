

namespace CMPT395Project.Models
{

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
/*
 * This is the Login Model which will contain the Data for the Userlogin
 * @Author: Anthony Wong
 * @Version 1.0
 * @Date: October 28,2018
 * 
 * */
    public class LoginModel
    {

       
        [EmailAddress]
        public string Email { get; set; }
   
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool FirstLogin { get; set; }

        [EmailAddress]
        public string AdminEmail { get; set; }
        [DataType(DataType.Password)]
        public string AdminPassword { get; set; }





    }
}
