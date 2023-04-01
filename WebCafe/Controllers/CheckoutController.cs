using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCafe.Extension;
using WebCafe.Models;
using WebCafe.ModelViews;

namespace WebCafe.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly CuaHangBanCafeContext _context;

        public CheckoutController(CuaHangBanCafeContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index(int id)
        {
            var maKH = HttpContext.Session.GetString("MaKh");
            id = int.Parse(maKH);
            var customerUser = await _context.KhachHangs.FindAsync(id);
            return View(customerUser);
        }

        [HttpPost]
        public IActionResult Index(KhachHang customer)
        {
            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
            var tt = cart.Sum(t=>t.TongTien);
            var maKh = HttpContext.Session.GetString("MaKh");
            if (customer.Diachi == null)
            {
                ModelState.AddModelError("", "Địa chỉ không được để trống");
            }

            if (maKh != null)
            {
                var khachHang = _context.KhachHangs.AsNoTracking().SingleOrDefault(x => x.MaKh == Convert.ToInt32(maKh));
                khachHang.Phone = customer.Phone;
                khachHang.Diachi = customer.Diachi;
                _context.Update(khachHang);
                _context.SaveChanges();
            }
            if (ModelState.IsValid)
            {
                //Khởi tạo đơn hàng
                DonHang donHang = new DonHang();
                donHang.MaKh = customer.MaKh;
                donHang.NgayTao = DateTime.Now;
                donHang.TrangThaiHuyDon = true;
                donHang.ThanhToan = true;
                donHang.NgayThanhToan = DateTime.Now;
                donHang.Note = null;
                donHang.TongTien = Convert.ToInt32(tt);
                _context.Add(donHang);
                _context.SaveChanges();

                foreach (var item in cart)
                {
                    ChiTietDonHang chiTietDonHang = new ChiTietDonHang();
                    chiTietDonHang.MaDh = donHang.MaDh;
                    chiTietDonHang.MaSp = item.sanPham.MaSp;
                    chiTietDonHang.SoLuong = item.soLuong;
                    chiTietDonHang.TongTien = Convert.ToInt32(item.TongTien);
                    chiTietDonHang.Ngaygiao = 0;
                    _context.Add(chiTietDonHang);


                    var sanPham = _context.SanPhams.AsNoTracking().SingleOrDefault(x => x.MaSp == item.sanPham.MaSp);
                    sanPham.SoLuong = sanPham.SoLuong - item.soLuong;
                    _context.Update(sanPham);
                }
                _context.SaveChanges();
                HttpContext.Session.Remove("GioHang");
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            return View();

        }
    }
}
