using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace CMPT395Project.Models
{
    public class ReportHourModel
    {
        [Required]
        public string Hour { get; set; }
        public bool InvalidHour { get; set; }
    }
}
