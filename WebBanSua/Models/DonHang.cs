using System;
using System.Collections.Generic;

namespace WebCafe.Models;

public partial class DonHang
{
    public DonHang()
    {
        ChiTietDonHangs = new HashSet<ChiTietDonHang>();
        QuanLyShippers = new HashSet<QuanLyShipper>();
        TrangThaiDhs = new HashSet<TrangThaiDh>();
    }

    public int MaDh { get; set; }

    public int MaKh { get; set; }

    public DateTime NgayTao { get; set; }

    public bool TrangThaiHuyDon { get; set; }

    public bool ThanhToan { get; set; }

    public DateTime NgayThanhToan { get; set; }

    public string Note { get; set; }

    public int TongTien { get; set; }

    public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; } = new List<ChiTietDonHang>();

    public virtual KhachHang MaKhNavigation { get; set; } = null!;

    public virtual ICollection<QuanLyShipper> QuanLyShippers { get; } = new List<QuanLyShipper>();

    public virtual ICollection<TrangThaiDh> TrangThaiDhs { get; } = new List<TrangThaiDh>();
}
