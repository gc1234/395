using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMPT395Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMPT395Project.Controllers
{
    public class EmailController : Controller
    {
        private readonly ProjectContext _context;

        public EmailController(ProjectContext context)
        {
            _context = context;
        }

        // GET: Contractors
        public async Task<IActionResult> Index(string searchString)
        {
            var projectContext = _context.Contractor.Include(c => c.Company);

            var contractors = from c in projectContext
                              select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                contractors = contractors.Where(s => s.LastName.Contains(searchString));
            }
            return View(await contractors.ToListAsync());


        }

        public ViewResult sentEmail()
        {
            return View();


        }
    }
}