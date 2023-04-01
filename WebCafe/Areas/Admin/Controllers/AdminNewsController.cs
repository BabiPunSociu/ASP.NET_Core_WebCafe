using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebCafe.Models;

namespace WebCafe.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminNewsController : Controller
    {
        private readonly CuaHangBanCafeContext _context;

        public AdminNewsController(CuaHangBanCafeContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.TinTucs.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tinTuc = await _context.TinTucs
                .FirstOrDefaultAsync(m => m.MaTt == id);
            if (tinTuc == null)
            {
                return NotFound();
            }

            return View(tinTuc);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaTt,TenTt,AnhTt,Motangan,Motadai,Tacgia,CreateDate,LoaiTin")] TinTuc tinTuc)
        {
            if (ModelState.IsValid)
            {
                tinTuc.CreateDate = DateTime.Now;
                _context.Add(tinTuc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tinTuc);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                await Console.Out.WriteLineAsync("id null");
                return NotFound();
            }

            var tinTuc = await _context.TinTucs.FindAsync(id);
            if (tinTuc == null)
            {
                await Console.Out.WriteLineAsync("not found");
                return NotFound();
            }
            return View(tinTuc);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaTt,TenTt,AnhTt,Motangan,Motadai,Tacgia,CreateDate,LoaiTin")] TinTuc tinTuc)
        {
            if (id != tinTuc.MaTt)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tinTuc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TinTucExists(tinTuc.MaTt))
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
            return View(tinTuc);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tinTuc = await _context.TinTucs
                .FirstOrDefaultAsync(m => m.MaTt == id);
            if (tinTuc == null)
            {
                return NotFound();
            }

            return View(tinTuc);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tinTuc = await _context.TinTucs.FindAsync(id);
            _context.TinTucs.Remove(tinTuc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TinTucExists(int id)
        {
            return _context.TinTucs.Any(e => e.MaTt == id);
        }
    }
}
