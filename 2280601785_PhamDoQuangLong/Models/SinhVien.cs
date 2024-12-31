using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _2280601785_PhamDoQuangLong.Models;

public partial class SinhVien
{
    public string MaSv { get; set; } = null!;

    public string HoTen { get; set; } = null!;

    public string? GioiTinh { get; set; }

    public DateOnly? NgaySinh { get; set; }

    [StringLength(500)]
    public string? Hinh { get; set; }

    public string? MaNganh { get; set; }

    public virtual ICollection<DangKy> DangKies { get; set; } = new List<DangKy>();

    public virtual NganhHoc? MaNganhNavigation { get; set; }
}
