using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebCafe.Models;

namespace WebCafe.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly CuaHangBanCafeContext _context;

        public SanPhamController(CuaHangBanCafeContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var CuaHangBanCafeContext = _context.SanPhams.Include(s => s.MaDmNavigation);
            return View(await CuaHangBanCafeContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams
                .Include(s => s.MaDmNavigation)
                .FirstOrDefaultAsync(m => m.MaSp == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

       public async Task<IActionResult> SuaTT()
        {
            var CuaHangBanCafeContext = _context.SanPhams.Include(s => s.MaDmNavigation);
            return View(await CuaHangBanCafeContext.ToListAsync());
        }

        public async Task<IActionResult> SuaChua()
        {
            var CuaHangBanCafeContext = _context.SanPhams.Include(s => s.MaDmNavigation);
            return View(await CuaHangBanCafeContext.ToListAsync());
        }

        public async Task<IActionResult> BoPhomat()
        {
            var CuaHangBanCafeContext = _context.SanPhams.Include(s => s.MaDmNavigation);
            return View(await CuaHangBanCafeContext.ToListAsync());
        }


        private bool SanPhamExists(int id)
        {
            return _context.SanPhams.Any(e => e.MaSp == id);
        }
    }
}
