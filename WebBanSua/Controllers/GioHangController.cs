using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebCafe.Extension;
using WebCafe.Models;
using WebCafe.ModelViews;

namespace WebCafe.Controllers
{
    public class GioHangController : Controller
    {
        private readonly CuaHangBanCafeContext _context;

        public GioHangController(CuaHangBanCafeContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var listGio = GioHang;
            return View(GioHang);
        }
        public List<CartItem> GioHang
        {
            get
            {
                var gh = HttpContext.Session.Get<List<CartItem>>("GioHang");
                if (gh == default(List<CartItem>))
                {
                    gh = new List<CartItem>();
                }
                return gh;
            }
        }

        [HttpPost]
        [Route("/giohang/add-cart")]
        public IActionResult AddToCart(int maSP, int soLuong)
        {
            List<CartItem> gioHang = GioHang;
            try
            {
                //Thêm vào giỏ
                CartItem item = gioHang.SingleOrDefault(p => p.sanPham.MaSp == maSP);
                if (item != null)
                {
                    item.soLuong = item.soLuong + soLuong;

                    HttpContext.Session.Set<List<CartItem>>("GioHang", gioHang);
                }
                else
                {
                    SanPham sp = _context.SanPhams.SingleOrDefault(p => p.MaSp == maSP);
                    item = new CartItem
                    {
                        soLuong = soLuong,
                        sanPham = sp
                    };
                    gioHang.Add(item);
                }
                HttpContext.Session.Set<List<CartItem>>("GioHang", gioHang);

                return Json(new { succeess = true });

            }
            catch (Exception ex)
            {
                return Json(new { succeess = false });
            }

        }

        [HttpPost]
        [Route("/giohang/update-cart")]
        public IActionResult UpdateCart(int maSP, int soLuong)
        {
           var gioHang = HttpContext.Session.Get<List<CartItem>>("GioHang");
            try
            {

               if(gioHang != null)
                {
                    CartItem item = gioHang.SingleOrDefault(p => p.sanPham.MaSp == maSP);
                    if (item != null)
                    {
                        item.soLuong = soLuong;
                    }
                    HttpContext.Session.Set<List<CartItem>>("GioHang", gioHang);
                }
                return Json(new
                {
                    soLuong = GioHang.Sum(p => p.soLuong)
                });

            }
            catch (Exception ex)
            {
                return Json(new { succeess = false });
            }

        }

        [HttpPost]
        [Route("/giohang/remove")]
        public ActionResult Remove(int maSP)
        {
            try
            {
                List<CartItem> gioHang = GioHang;
                CartItem item = gioHang.SingleOrDefault(p => p.sanPham.MaSp == maSP);
                if (item != null)
                {
                    gioHang.Remove(item);
                }
                HttpContext.Session.Set<List<CartItem>>("GioHang", gioHang);
                return Json(new { succeess = true });
            }
            catch
            {
                return Json(new { succeess = false });
            }

        }

        public ActionResult CleanCart()
        {
            HttpContext.Session.Remove("GioHang");
            return RedirectToAction("Index");

        }

       
    }
}
