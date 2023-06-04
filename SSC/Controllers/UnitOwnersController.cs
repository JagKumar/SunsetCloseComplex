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
    public class UnitOwnersController : Controller
    {
        private readonly SscContext _context;

        public UnitOwnersController(SscContext context)
        {
            _context = context;
        }

        // GET: UnitOwners
        public async Task<IActionResult> Index()
        {
              return View(await _context.UnitOwners.ToListAsync());
        }

        // GET: UnitOwners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UnitOwners == null)
            {
                return NotFound();
            }

            var unitOwner = await _context.UnitOwners
                .FirstOrDefaultAsync(m => m.UnitNo == id);
            if (unitOwner == null)
            {
                return NotFound();
            }

            return View(unitOwner);
        }

        // GET: UnitOwners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UnitOwners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UnitNo,OwnerName,ContactNo,Email,IsResidentInComplex")] UnitOwner unitOwner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unitOwner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            string errors = string.Join(";", ModelState.Values
                .SelectMany(x => x.Errors)
                .Select(x => x.ErrorMessage));

            ModelState.AddModelError("", errors);
            return View(unitOwner);
        }

        // GET: UnitOwners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UnitOwners == null)
            {
                return NotFound();
            }

            var unitOwner = await _context.UnitOwners.FindAsync(id);
            if (unitOwner == null)
            {
                return NotFound();
            }
            return View(unitOwner);
        }

        // POST: UnitOwners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UnitNo,OwnerName,ContactNo,Email,IsResidentInComplex")] UnitOwner unitOwner)
        {
            if (id != unitOwner.UnitNo)
            {
                return NotFound();

            }

            if (ModelState.IsValid)
            {
                try
                {
                    

                    _context.Update(unitOwner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnitOwnerExists(unitOwner.UnitNo))
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
            return View(unitOwner);
        }

        // GET: UnitOwners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UnitOwners == null)
            {
                return NotFound();
            }

            var unitOwner = await _context.UnitOwners
                .FirstOrDefaultAsync(m => m.UnitNo == id);
            if (unitOwner == null)
            {
                return NotFound();
            }

            return View(unitOwner);
        }

        // POST: UnitOwners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UnitOwners == null)
            {
                return Problem("Entity set 'SscContext.UnitOwners'  is null.");
            }
            var unitOwner = await _context.UnitOwners.FindAsync(id);
            if (unitOwner != null)
            {
                _context.UnitOwners.Remove(unitOwner);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnitOwnerExists(int id)
        {
          return _context.UnitOwners.Any(e => e.UnitNo == id);
        }
    }
}
