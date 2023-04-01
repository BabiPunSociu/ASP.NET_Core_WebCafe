using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebCafe.Models;

namespace WebCafe.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCategoryController : Controller
    {
        private readonly CuaHangBanCafeContext _context;

        public AdminCategoryController(CuaHangBanCafeContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.DanhMucSps.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhMucSp = await _context.DanhMucSps
                .FirstOrDefaultAsync(m => m.MaDm == id);
            if (danhMucSp == null)
            {
                return NotFound();
            }

            return View(danhMucSp);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaDm,TenDm,AnhDm,MoTaDm,TrangThai")] DanhMucSp danhMucSp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(danhMucSp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(danhMucSp);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhMucSp = await _context.DanhMucSps.FindAsync(id);
            if (danhMucSp == null)
            {
                return NotFound();
            }
            return View(danhMucSp);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaDm,TenDm,AnhDm,MoTaDm,TrangThai")] DanhMucSp danhMucSp)
        {
            if (id != danhMucSp.MaDm)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(danhMucSp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanhMucSpExists(danhMucSp.MaDm))
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
            return View(danhMucSp);
        }

        private bool DanhMucSpExists(int id)
        {
            return _context.DanhMucSps.Any(e => e.MaDm == id);
        }
    }
}
