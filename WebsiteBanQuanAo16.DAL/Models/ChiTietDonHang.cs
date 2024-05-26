using System;
using System.Collections.Generic;

#nullable disable

namespace WebsiteBanQuanAo16.DAL.Models
{
    public partial class ChiTietDonHang
    {
        public string MaDh { get; set; }
        public string MaSp { get; set; }
        public int? SoLuong { get; set; }
        public int? DonGia { get; set; }

        public virtual DonHang MaDhNavigation { get; set; }
        public virtual SanPham MaSpNavigation { get; set; }
    }
}
