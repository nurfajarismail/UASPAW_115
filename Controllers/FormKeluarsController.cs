using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UASPAW_115.Models;

namespace UASPAW_115.Controllers
{
    public class FormKeluarsController : Controller
    {
        private readonly Parkir_PawContext _context;

        public FormKeluarsController(Parkir_PawContext context)
        {
            _context = context;
        }

        // GET: FormKeluars
        public async Task<IActionResult> Index()
        {
            var parkir_PawContext = _context.FormKeluar.Include(f => f.IdKendaraanNavigation).Include(f => f.IdMasukNavigation).Include(f => f.IdTarifNavigation);
            return View(await parkir_PawContext.ToListAsync());
        }

        // GET: FormKeluars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formKeluar = await _context.FormKeluar
                .Include(f => f.IdKendaraanNavigation)
                .Include(f => f.IdMasukNavigation)
                .Include(f => f.IdTarifNavigation)
                .FirstOrDefaultAsync(m => m.IdKeluar == id);
            if (formKeluar == null)
            {
                return NotFound();
            }

            return View(formKeluar);
        }

        // GET: FormKeluars/Create
        public IActionResult Create()
        {
            ViewData["IdKendaraan"] = new SelectList(_context.JenisKendaraan, "IdKendaraan", "IdKendaraan");
            ViewData["IdMasuk"] = new SelectList(_context.FormMasuk, "IdMasuk", "IdMasuk");
            ViewData["IdTarif"] = new SelectList(_context.Tarif, "IdTarif", "IdTarif");
            return View();
        }

        // POST: FormKeluars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKeluar,TanggalKeluar,IdMasuk,IdKendaraan,IdTarif")] FormKeluar formKeluar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formKeluar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdKendaraan"] = new SelectList(_context.JenisKendaraan, "IdKendaraan", "IdKendaraan", formKeluar.IdKendaraan);
            ViewData["IdMasuk"] = new SelectList(_context.FormMasuk, "IdMasuk", "IdMasuk", formKeluar.IdMasuk);
            ViewData["IdTarif"] = new SelectList(_context.Tarif, "IdTarif", "IdTarif", formKeluar.IdTarif);
            return View(formKeluar);
        }

        // GET: FormKeluars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formKeluar = await _context.FormKeluar.FindAsync(id);
            if (formKeluar == null)
            {
                return NotFound();
            }
            ViewData["IdKendaraan"] = new SelectList(_context.JenisKendaraan, "IdKendaraan", "IdKendaraan", formKeluar.IdKendaraan);
            ViewData["IdMasuk"] = new SelectList(_context.FormMasuk, "IdMasuk", "IdMasuk", formKeluar.IdMasuk);
            ViewData["IdTarif"] = new SelectList(_context.Tarif, "IdTarif", "IdTarif", formKeluar.IdTarif);
            return View(formKeluar);
        }

        // POST: FormKeluars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdKeluar,TanggalKeluar,IdMasuk,IdKendaraan,IdTarif")] FormKeluar formKeluar)
        {
            if (id != formKeluar.IdKeluar)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formKeluar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormKeluarExists(formKeluar.IdKeluar))
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
            ViewData["IdKendaraan"] = new SelectList(_context.JenisKendaraan, "IdKendaraan", "IdKendaraan", formKeluar.IdKendaraan);
            ViewData["IdMasuk"] = new SelectList(_context.FormMasuk, "IdMasuk", "IdMasuk", formKeluar.IdMasuk);
            ViewData["IdTarif"] = new SelectList(_context.Tarif, "IdTarif", "IdTarif", formKeluar.IdTarif);
            return View(formKeluar);
        }

        // GET: FormKeluars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formKeluar = await _context.FormKeluar
                .Include(f => f.IdKendaraanNavigation)
                .Include(f => f.IdMasukNavigation)
                .Include(f => f.IdTarifNavigation)
                .FirstOrDefaultAsync(m => m.IdKeluar == id);
            if (formKeluar == null)
            {
                return NotFound();
            }

            return View(formKeluar);
        }

        // POST: FormKeluars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formKeluar = await _context.FormKeluar.FindAsync(id);
            _context.FormKeluar.Remove(formKeluar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormKeluarExists(int id)
        {
            return _context.FormKeluar.Any(e => e.IdKeluar == id);
        }
    }
}
