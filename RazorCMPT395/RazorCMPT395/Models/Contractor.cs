using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorCMPT395.Models
{
    public class Contractor
    {
        public int contractorId { get; set; }
        public string contractorFirstName { get; set; }
        public string contractorLastName { get; set; }
        public int companyId { get; set; }
        public string email { get; set; }
        public string password { get; set; }

    }
}
