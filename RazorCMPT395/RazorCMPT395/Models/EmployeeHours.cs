using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorCMPT395.Models
{
    public class EmployeeHours
    {
        public int timeSheetId { get; set; }
        public int contractId { get; set; }
        public int year { get; set; }
        public int month { get; set; }
        public int currentMonth { get; set; }
        public int previousMonth { get; set; }
    }
}
