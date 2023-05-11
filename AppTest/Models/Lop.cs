using System;
using System.Collections.Generic;

namespace AppTest.Models;

public partial class Lop
{
    public long Id { get; set; }

    public int SoBd { get; set; }

    public string? TenChucVu { get; set; }

    public int? MaLop { get; set; }

    public virtual ICollection<SinhVien> SinhViens { get; set; } = new List<SinhVien>();
}
