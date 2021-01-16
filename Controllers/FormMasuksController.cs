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
    public class FormMasuksController : Controller
    {
        private readonly Parkir_PawContext _context;

        public FormMasuksController(Parkir_PawContext context)
        {
            _context = context;
        }

        // GET: FormMasuks
        public async Task<IActionResult> Index()
        {
            return View(await _context.FormMasuk.ToListAsync());
        }

        // GET: FormMasuks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formMasuk = await _context.FormMasuk
                .FirstOrDefaultAsync(m => m.IdMasuk == id);
            if (formMasuk == null)
            {
                return NotFound();
            }

            return View(formMasuk);
        }

        // GET: FormMasuks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FormMasuks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMasuk,NoPolisi,TanggalMasuk")] FormMasuk formMasuk)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formMasuk);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(formMasuk);
        }

        // GET: FormMasuks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formMasuk = await _context.FormMasuk.FindAsync(id);
            if (formMasuk == null)
            {
                return NotFound();
            }
            return View(formMasuk);
        }

        // POST: FormMasuks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMasuk,NoPolisi,TanggalMasuk")] FormMasuk formMasuk)
        {
            if (id != formMasuk.IdMasuk)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formMasuk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormMasukExists(formMasuk.IdMasuk))
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
            return View(formMasuk);
        }

        // GET: FormMasuks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formMasuk = await _context.FormMasuk
                .FirstOrDefaultAsync(m => m.IdMasuk == id);
            if (formMasuk == null)
            {
                return NotFound();
            }

            return View(formMasuk);
        }

        // POST: FormMasuks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formMasuk = await _context.FormMasuk.FindAsync(id);
            _context.FormMasuk.Remove(formMasuk);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormMasukExists(int id)
        {
            return _context.FormMasuk.Any(e => e.IdMasuk == id);
        }
    }
}
