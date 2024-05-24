using System;
using System.Collections.Generic;

#nullable disable

namespace WebsiteBanQuanAo16.DAL.Models
{
    public partial class SanPham
    {
        public SanPham()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
            DanhGia = new HashSet<DanhGia>();
        }

        public int MaSp { get; set; }
        public string MaLoai { get; set; }
        public string TenSp { get; set; }
        public string ThongTinSp { get; set; }
        public int? Gia { get; set; }
        public int? SoLuong { get; set; }
        public string KichThuoc { get; set; }

        public virtual LoaiSp MaLoaiNavigation { get; set; }
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual ICollection<DanhGia> DanhGia { get; set; }
    }
}
