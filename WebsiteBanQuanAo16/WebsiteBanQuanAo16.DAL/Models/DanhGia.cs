using System;
using System.Collections.Generic;

#nullable disable

namespace WebsiteBanQuanAo16.DAL.Models
{
    public partial class DanhGia
    {
        public string MaDg { get; set; }
        public string UserId { get; set; }
        public string MaSp { get; set; }
        public string NoiDung { get; set; }
        public string MaDh { get; set; }

        public virtual DonHang MaDhNavigation { get; set; }
        public virtual SanPham MaSpNavigation { get; set; }
        public virtual User User { get; set; }
    }
}
