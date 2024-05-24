using System;
using System.Collections.Generic;

#nullable disable

namespace WebsiteBanQuanAo16.DAL.Models
{
    public partial class DonHang
    {
        public DonHang()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
            DanhGia = new HashSet<DanhGium>();
        }

        public string MaDh { get; set; }
        public string MaKh { get; set; }
        public DateTime? NgayDatHang { get; set; }
        public string DiaChiGiao { get; set; }
        public decimal? TongGia { get; set; }
        public string TrangThai { get; set; }

        public virtual KhachHang MaKhNavigation { get; set; }
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual ICollection<DanhGium> DanhGia { get; set; }
    }
}
