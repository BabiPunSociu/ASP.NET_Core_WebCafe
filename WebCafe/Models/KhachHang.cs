using System;
using System.Collections.Generic;

namespace WebCafe.Models;

public partial class KhachHang
{
    public int MaKh { get; set; }

    public string TenKh { get; set; } = null!;

    public string? GioiTinh { get; set; }

    public string? AvatarKh { get; set; }

    public string? Diachi { get; set; }

    public DateTime? Ngaysinh { get; set; }

    public int Phone { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public int? AccountId { get; set; }

    public virtual Account? Account { get; set; }

    public virtual ICollection<DonHang> DonHangs { get; } = new List<DonHang>();

    public enum Gender
    {
        Nam,
        Nữ
    }
}
