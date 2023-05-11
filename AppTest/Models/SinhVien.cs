using System;
using System.Collections.Generic;

namespace AppTest.Models;

public partial class SinhVien
{
    public long Id { get; set; }

    public DateTime Date { get; set; }

    public string? HoVaTen { get; set; }

    public long? IdChucVu { get; set; }

    public bool? LaLopPho { get; set; }

    public bool? LaLopTruong { get; set; }

    public bool? LaToTruong { get; set; }

    public virtual Lop? IdChucVuNavigation { get; set; }
}
