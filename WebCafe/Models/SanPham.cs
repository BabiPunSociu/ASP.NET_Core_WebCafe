using System;
using System.Collections.Generic;

namespace WebCafe.Models;

public partial class SanPham
{
    public SanPham()
    {
        ChiTietDonHangs = new HashSet<ChiTietDonHang>();
    }
    public int MaSp { get; set; }

    public int MaDm { get; set; }

    public string TenSp { get; set; } = null!;

    public string AnhSp { get; set; } = null!;

    public string VideoSp { get; set; }

    public int GiaSp { get; set; }

    public bool TrangThai { get; set; }

    public int SoLuong { get; set; }

    public bool BestSeller { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime NgaySua { get; set; }

    public string MotaSp { get; set; } = null!;

    public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; } = new List<ChiTietDonHang>();

    public virtual DanhMucSp MaDmNavigation { get; set; }
}
