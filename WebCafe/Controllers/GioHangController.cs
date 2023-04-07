using Microsoft.AspNetCore.Mvc;
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

        CuaHangBanCafeContext db = new CuaHangBanCafeContext();

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

        public IActionResult Index()
        {
            var listGio = GioHang;
            return View(GioHang);
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
            catch (Exception)
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

                if (gioHang != null)
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
            catch (Exception)
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
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }

        }

        public ActionResult CleanCart()
        {
            HttpContext.Session.Remove("GioHang");
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("/cart/count")]
        public IActionResult GetCartCount()
        {
            int count = GioHang.Sum(item => item.soLuong);
            return Json(count);
        }

        [HttpPost]
        [Route("/giohang/sales")]
        public IActionResult GiamGia(string tenKM)
        {
            List<CartItem> gioHang = GioHang;
            try
            {
                double tongGiam1 = 0, tongGiam2 = 0;
                if (gioHang != null)
                {
                    var km = db.KhuyenMais.FirstOrDefault(predicate: x => x.TenKm == tenKM && x.TinhTrang == true);
                    tongGiam2 = 2;
                    if (km != null)
                    {
                        //tongGiam2 = 111;
                        if (km.LoaiKm == 1)
                        {
                            tongGiam1 = (double)km.GiaTri;
                        } else if (km.LoaiKm == 2)
                        {
                            tongGiam2 = (double)km.GiaTri;
                        }
                    }
                    HttpContext.Session.Set<List<CartItem>>("GioHang", gioHang);
                }
                return Json(new
                {
                    GiamGiaLoai1 = tongGiam1,
                    GiamGiaLoai2 = tongGiam2
                });

            }
            catch (Exception)
            {
                return Json(new { success = false });
            }
        }

        ////string tenKm = Request.Form["maGiamGia"];
        ////string tenKm = tenKM;
        ////int TongTienSP = TinhTongThanhTien();
        ////int SoLuongSP = TinhTongSoLuong();
        ////ViewBag.TienVanChuyen = TienVanChuyen;
        ////ViewBag.TongSoLuong = SoLuongSP;
        ////ViewBag.TongTien = TongTienSP;
        ////ViewBag.IsKM = 0;
        ////ViewBag.GiamGia = 0;
        //var gioHang = HttpContext.Session.Get<List<CartItem>>("GioHang");
        ////List<CartItem> listGioHang = GioHang;
        //KhuyenMai km = _context.KhuyenMais.FirstOrDefault(x => x.MaKm == tenKM && x.TinhTrang == true);
        ////ViewBag.ThanhToan = 10000;
        //double thanhToan = 0;
        //if (km == null)
        //{
        //    //ViewBag.KhuyenMai = "";
        //    //ViewBag.IsKM = 1;
        //    //ViewBag.ThanhToan = TongTienSP;
        //    //ViewBag.ThanhToan = 1000000000;
        //    thanhToan = 10000000000;
        //}
        //else if (tenKM % 1 == 0)
        //{
        //    double TienGiam = 0;
        //    //ViewBag.KhuyenMai = MaKM;
        //    //ViewBag.IsKM = 3;
        //    if (km.LoaiKm == 1)
        //    {
        //        //TienGiam = (TongTienSP * (km.GiaTri ?? 0)) / 100;
        //        //ViewBag.ThanhToan = TongTienSP + TienVanChuyen - TienGiam;
        //        //ViewBag.GiamGia = TienGiam;
        //        TienGiam = (gioHang.Sum(x => x.TongTien) * (km.GiaTri ?? 0)) / 100;
        //        thanhToan = gioHang.Sum(x => x.TongTien) - TienGiam;
        //    }
        //    else if (km.LoaiKm == 2)
        //    {
        //        thanhToan = (double)(gioHang.Sum(x => x.TongTien) - km.GiaTri);
        //    }
        //}
        //else
        //{
        //    //ViewBag.KhuyenMai = "";
        //    //ViewBag.IsKM = 2;
        //    thanhToan = gioHang.Sum(x => x.TongTien);
        //}

        //var viewModel = new GioHang
        //{
        //    ThanhToan = thanhToan,
        //    giohang = gioHang
        //};

        //return View("Index", viewModel);

    }
}