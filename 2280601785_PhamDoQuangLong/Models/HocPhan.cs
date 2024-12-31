using System;
using System.Collections.Generic;

namespace _2280601785_PhamDoQuangLong.Models;

public partial class HocPhan
{
    public string MaHp { get; set; } = null!;

    public string TenHp { get; set; } = null!;

    public int? SoTinChi { get; set; }

    public virtual ICollection<DangKy> MaDks { get; set; } = new List<DangKy>();
}
