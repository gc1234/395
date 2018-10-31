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
    public class EmployeeHoursController : Controller
    {
        private readonly ProjectContext _context;

        public EmployeeHoursController(ProjectContext context)
        {
            _context = context;
        }

        // GET: EmployeeHours
        public async Task<IActionResult> Index()
        {
            var projectContext = _context.EmployeeHour.Include(e => e.Contract);
            return View(await projectContext.ToListAsync());
        }

        // GET: EmployeeHours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeHour = await _context.EmployeeHour
                .Include(e => e.Contract)
                .FirstOrDefaultAsync(m => m.TimeSheetId == id);
            if (employeeHour == null)
            {
                return NotFound();
            }

            return View(employeeHour);
        }

        // GET: EmployeeHours/Create
        public IActionResult Create()
        {
            ViewData["ContractId"] = new SelectList(_context.Contract, "ContractId", "ContractId");
            return View();
        }

        // POST: EmployeeHours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TimeSheetId,ContractId,Year,Month,CurrentMonth,PreviousMonth")] EmployeeHour employeeHour)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeHour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContractId"] = new SelectList(_context.Contract, "ContractId", "ContractId", employeeHour.ContractId);
            return View(employeeHour);
        }

        // GET: EmployeeHours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeHour = await _context.EmployeeHour.FindAsync(id);
            if (employeeHour == null)
            {
                return NotFound();
            }
            ViewData["ContractId"] = new SelectList(_context.Contract, "ContractId", "ContractId", employeeHour.ContractId);
            return View(employeeHour);
        }

        // POST: EmployeeHours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TimeSheetId,ContractId,Year,Month,CurrentMonth,PreviousMonth")] EmployeeHour employeeHour)
        {
            if (id != employeeHour.TimeSheetId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeHour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeHourExists(employeeHour.TimeSheetId))
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
            ViewData["ContractId"] = new SelectList(_context.Contract, "ContractId", "ContractId", employeeHour.ContractId);
            return View(employeeHour);
        }

        // GET: EmployeeHours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeHour = await _context.EmployeeHour
                .Include(e => e.Contract)
                .FirstOrDefaultAsync(m => m.TimeSheetId == id);
            if (employeeHour == null)
            {
                return NotFound();
            }

            return View(employeeHour);
        }

        // POST: EmployeeHours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeHour = await _context.EmployeeHour.FindAsync(id);
            _context.EmployeeHour.Remove(employeeHour);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeHourExists(int id)
        {
            return _context.EmployeeHour.Any(e => e.TimeSheetId == id);
        }
    }
}
