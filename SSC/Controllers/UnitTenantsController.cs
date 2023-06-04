using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SSC.Data;
using SSC.Models;

namespace SSC.Controllers
{
    public class UnitTenantsController : Controller
    {
        private readonly SscContext _context;

        public UnitTenantsController(SscContext context)
        {
            _context = context;
        }

        // GET: UnitTenants
        public async Task<IActionResult> Index()
        {
              return View(await _context.UnitTenants.ToListAsync());
        }

        // GET: UnitTenants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UnitTenants == null)
            {
                return NotFound();
            }

            var unitTenant = await _context.UnitTenants
                .FirstOrDefaultAsync(m => m.UnitNo == id);
            if (unitTenant == null)
            {
                return NotFound();
            }

            return View(unitTenant);
        }

        // GET: UnitTenants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UnitTenants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UnitNo,TenantName,TenantSurname,TenantContactNo,TenantEmail,NoOfPersonsStaying")] UnitTenant unitTenant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unitTenant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unitTenant);
        }

        // GET: UnitTenants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UnitTenants == null)
            {
                return NotFound();
            }

            var unitTenant = await _context.UnitTenants.FindAsync(id);
            if (unitTenant == null)
            {
                return NotFound();
            }
            return View(unitTenant);
        }

        // POST: UnitTenants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UnitNo,TenantName,TenantSurname,TenantContactNo,TenantEmail,NoOfPersonsStaying")] UnitTenant unitTenant)
        {
            if (id != unitTenant.UnitNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unitTenant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnitTenantExists(unitTenant.UnitNo))
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
            return View(unitTenant);
        }

        // GET: UnitTenants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UnitTenants == null)
            {
                return NotFound();
            }

            var unitTenant = await _context.UnitTenants
                .FirstOrDefaultAsync(m => m.UnitNo == id);
            if (unitTenant == null)
            {
                return NotFound();
            }

            return View(unitTenant);
        }

        // POST: UnitTenants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UnitTenants == null)
            {
                return Problem("Entity set 'SscContext.UnitTenant'  is null.");
            }
            var unitTenant = await _context.UnitTenants.FindAsync(id);
            if (unitTenant != null)
            {
                _context.UnitTenants.Remove(unitTenant);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnitTenantExists(int id)
        {
          return _context.UnitTenants.Any(e => e.UnitNo == id);
        }
    }
}
