using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _2280601785_PhamDoQuangLong.Models;

namespace _2280601785_PhamDoQuangLong.Controllers
{
    public class SinhViensController : Controller
    {
        private readonly KtwebQlongContext _context;

        public SinhViensController(KtwebQlongContext context)
        {
            _context = context;
        }

        // GET: SinhViens
        public async Task<IActionResult> Index()
        {
            var ktwebQlongContext = _context.SinhViens.Include(s => s.MaNganhNavigation);
            return View(await ktwebQlongContext.ToListAsync());
        }

        // GET: SinhViens/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhVien = await _context.SinhViens
                .Include(s => s.MaNganhNavigation)
                .FirstOrDefaultAsync(m => m.MaSv == id);
            if (sinhVien == null)
            {
                return NotFound();
            }

            return View(sinhVien);
        }

        // GET: SinhViens/Create
        public IActionResult Create()
        {
            ViewData["MaNganh"] = new SelectList(_context.NganhHocs, "MaNganh", "MaNganh");
            return View();
        }

        // POST: SinhViens/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SinhVien sinhVien, IFormFile ImageUpload)
        {
            if (ModelState.IsValid)
            {
                if (ImageUpload != null && ImageUpload.Length > 0)
                {
                    var fileName = Path.GetFileName(ImageUpload.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Content/images", fileName);

                    // Save the image to the wwwroot/Content/images directory
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await ImageUpload.CopyToAsync(fileStream);
                    }

                    // Update the image path in the database
                    sinhVien.Hinh = "/Content/images/" + fileName;
                }

                _context.Add(sinhVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaNganh"] = new SelectList(_context.NganhHocs, "MaNganh", "MaNganh", sinhVien.MaNganh);
            return View(sinhVien);
        }

        // GET: SinhViens/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhVien = await _context.SinhViens.FindAsync(id);
            if (sinhVien == null)
            {
                return NotFound();
            }
            ViewData["MaNganh"] = new SelectList(_context.NganhHocs, "MaNganh", "MaNganh", sinhVien.MaNganh);
            return View(sinhVien);
        }

        // POST: SinhViens/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, SinhVien sinhVien, IFormFile ImageUpload)
        {
            if (id != sinhVien.MaSv)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (ImageUpload != null && ImageUpload.Length > 0)
                    {
                        var fileName = Path.GetFileName(ImageUpload.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Content/images", fileName);

                        // Save the image to the wwwroot/Content/images directory
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await ImageUpload.CopyToAsync(fileStream);
                        }

                        // Update the image path in the database
                        sinhVien.Hinh = "/Content/images/" + fileName;
                    }

                    _context.Update(sinhVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SinhVienExists(sinhVien.MaSv))
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
            ViewData["MaNganh"] = new SelectList(_context.NganhHocs, "MaNganh", "MaNganh", sinhVien.MaNganh);
            return View(sinhVien);
        }

        // GET: SinhViens/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhVien = await _context.SinhViens
                .Include(s => s.MaNganhNavigation)
                .FirstOrDefaultAsync(m => m.MaSv == id);
            if (sinhVien == null)
            {
                return NotFound();
            }

            return View(sinhVien);
        }

        // POST: SinhViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var sinhVien = await _context.SinhViens.FindAsync(id);
            if (sinhVien != null)
            {
                _context.SinhViens.Remove(sinhVien);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SinhVienExists(string id)
        {
            return _context.SinhViens.Any(e => e.MaSv == id);
        }
    }
}
