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
    public class nhanviensController : Controller
    {
        private readonly codeFirstNVContext _context;

        public nhanviensController(codeFirstNVContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index1()
        {
            //var btefnhanVienPhongBanCongtyContext = _context.NhanViens.Include(n => n.IdphongbanNavigation);
            //return View(await btefnhanVienPhongBanCongtyContext.ToListAsync());
            var nhanViens = from n in _context.nhanvien
                            select n;
            int idpb = (
                            from p in _context.phongban
                            where p.Namephongban.Contains("marketing")
                            select p.Idphongban).FirstOrDefault();

            nhanViens = nhanViens.Where(n =>n.idphongban==idpb && n.tuoi >= 30 && n.tuoi <= 40);

            return View(await nhanViens.ToListAsync());

        }
        // GET: nhanviens
        public async Task<IActionResult> Index()
        {
            return View(await _context.nhanvien.ToListAsync());
        }

        // GET: nhanviens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.nhanvien
                .FirstOrDefaultAsync(m => m.IdNV == id);
            if (nhanvien == null)
            {
                return NotFound();
            }

            return View(nhanvien);
        }

        // GET: nhanviens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: nhanviens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNV,TenNV,tuoi,idphongban")] nhanvien nhanvien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhanvien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nhanvien);
        }

        // GET: nhanviens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.nhanvien.FindAsync(id);
            if (nhanvien == null)
            {
                return NotFound();
            }
            return View(nhanvien);
        }

        // POST: nhanviens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNV,TenNV,tuoi,idphongban")] nhanvien nhanvien)
        {
            if (id != nhanvien.IdNV)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanvien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!nhanvienExists(nhanvien.IdNV))
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
            return View(nhanvien);
        }

        // GET: nhanviens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.nhanvien
                .FirstOrDefaultAsync(m => m.IdNV == id);
            if (nhanvien == null)
            {
                return NotFound();
            }

            return View(nhanvien);
        }

        // POST: nhanviens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nhanvien = await _context.nhanvien.FindAsync(id);
            if (nhanvien != null)
            {
                _context.nhanvien.Remove(nhanvien);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool nhanvienExists(int id)
        {
            return _context.nhanvien.Any(e => e.IdNV == id);
        }
    }
}
