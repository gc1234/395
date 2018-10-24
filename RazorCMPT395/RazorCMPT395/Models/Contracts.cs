using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorCMPT395.Models
{
    public class Contracts
    {
        public int contractId { get; set; }
        public int companyId { get; set; }
        public int contractorId { get; set; }

        public int p1CharRate { get; set; }
        public int p1PayRate { get; set; }
        public DateTime p1StartDate { get; set; }
        public DateTime p1EndtDate { get; set; }

        public int p2CharRate { get; set; }
        public int p2PayRate { get; set; }
        public DateTime p2StartDate { get; set; }
        public DateTime p2EndtDate { get; set; }

        public int p3CharRate { get; set; }
        public int p3PayRate { get; set; }
        public DateTime p3StartDate { get; set; }
        public DateTime p3EndtDate { get; set; }

        public int p4CharRate { get; set; }
        public int p4PayRate { get; set; }
        public DateTime p4StartDate { get; set; }
        public DateTime p4EndtDate { get; set; }

        public String renewal { get; set; }
        public Char activeContract { get; set; }
    }
}
