using System;
using System.Collections.Generic;

namespace WebCafe.Models;

public partial class DanhMucSp
{
    public int MaDm { get; set; }

    public string TenDm { get; set; } = null!;

    public string AnhDm { get; set; }

    public string MoTaDm { get; set; }

    public bool TrangThai { get; set; }

    public virtual ICollection<SanPham> SanPhams { get; } = new List<SanPham>();

    public enum Category
    {
        True,
        False
    }

}
