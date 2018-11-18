

namespace CMPT395Project.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
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

       
        [DataType(DataType.Text)]
        public string Username { get; set; }
   
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public IEnumerable<SelectListItem> AccessLevel { get; set; }

        public bool FirstLogin { get; set; }

    }
}
