using System;
using System.Collections.Generic;

namespace WebCafe.Models;

public partial class TinTuc
{
    public int MaTt { get; set; }

    public string TenTt { get; set; } = null!;

    public string AnhTt { get; set; } = null!;

    public string Motangan { get; set; } = null!;

    public string Motadai { get; set; } = null!;

    public string Tacgia { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public bool? LoaiTin { get; set; }
}
