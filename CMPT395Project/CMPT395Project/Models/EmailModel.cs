using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMPT395Project.Models
{
    public class EmailModel
    {

        [Required]
        public string Sender { get; set; }

        [Required]
        public string Pass { get; set; }

        [Required]
        public string Header { get; set; }

        [Required]
        public string Body { get; set; }

    }
}
