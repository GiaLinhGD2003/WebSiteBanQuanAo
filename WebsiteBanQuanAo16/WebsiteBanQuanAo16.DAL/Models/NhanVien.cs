using System;
using System.Collections.Generic;

#nullable disable

namespace WebsiteBanQuanAo16.DAL.Models
{
    public partial class NhanVien
    {
        public int MaNv { get; set; }
        public string UserId { get; set; }
        public string TenNv { get; set; }
        public string NamSinh { get; set; }
        public string ChucVu { get; set; }
        public string Sdt { get; set; }
        public string Idcard { get; set; }

        public virtual User User { get; set; }
    }
}
