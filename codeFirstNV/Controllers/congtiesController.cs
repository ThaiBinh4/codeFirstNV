using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using codeFirstNV.Data;
using codeFirstNV.Models;

namespace codeFirstNV.Controllers
{
    public class congtiesController : Controller
    {
        private readonly codeFirstNVContext _context;

        public congtiesController(codeFirstNVContext context)
        {
            _context = context;
        }

        // GET: congties
        public async Task<IActionResult> Index()
        {
            return View(await _context.congty.ToListAsync());
        }

        // GET: congties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var congty = await _context.congty
                .FirstOrDefaultAsync(m => m.id == id);
            if (congty == null)
            {
                return NotFound();
            }

            return View(congty);
        }

        // GET: congties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: congties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,diachi")] congty congty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(congty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(congty);
        }

        // GET: congties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var congty = await _context.congty.FindAsync(id);
            if (congty == null)
            {
                return NotFound();
            }
            return View(congty);
        }

        // POST: congties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,diachi")] congty congty)
        {
            if (id != congty.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(congty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!congtyExists(congty.id))
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
            return View(congty);
        }

        // GET: congties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var congty = await _context.congty
                .FirstOrDefaultAsync(m => m.id == id);
            if (congty == null)
            {
                return NotFound();
            }

            return View(congty);
        }

        // POST: congties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var congty = await _context.congty.FindAsync(id);
            if (congty != null)
            {
                _context.congty.Remove(congty);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool congtyExists(int id)
        {
            return _context.congty.Any(e => e.id == id);
        }
    }
}
