using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CMPT395Project.Models;

namespace CMPT395Project.Controllers
{
    public class ContractorsController : Controller
    {
        private readonly ProjectContext _context;

        public ContractorsController(ProjectContext context)
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

            //return View(await projectContext.ToListAsync());
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        // GET: Contractors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractor = await _context.Contractor
                .Include(c => c.Company)
                .FirstOrDefaultAsync(m => m.ContractorId == id);
            if (contractor == null)
            {
                return NotFound();
            }

            return View(contractor);
        }

        // GET: Contractors/Create
        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.Company, "CompanyId", "CompanyId");
            return View();
        }

        // POST: Contractors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContractorId,FirstName,LastName,CompanyId,Email,Password")] Contractor contractor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contractor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(_context.Company, "CompanyId", "CompanyId", contractor.CompanyId);
            return View(contractor);
        }

        // GET: Contractors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractor = await _context.Contractor.FindAsync(id);
            if (contractor == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Company, "CompanyId", "CompanyId", contractor.CompanyId);
            return View(contractor);
        }

        // POST: Contractors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContractorId,FirstName,LastName,CompanyId,Email,Password")] Contractor contractor)
        {
            if (id != contractor.ContractorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contractor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContractorExists(contractor.ContractorId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(_context.Company, "CompanyId", "CompanyId", contractor.CompanyId);
            return View(contractor);
        }

        // GET: Contractors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractor = await _context.Contractor
                .Include(c => c.Company)
                .FirstOrDefaultAsync(m => m.ContractorId == id);
            if (contractor == null)
            {
                return NotFound();
            }

            return View(contractor);
        }

        // POST: Contractors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contractor = await _context.Contractor.FindAsync(id);
            _context.Contractor.Remove(contractor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContractorExists(int id)
        {
            return _context.Contractor.Any(e => e.ContractorId == id);
        }
    }
}
