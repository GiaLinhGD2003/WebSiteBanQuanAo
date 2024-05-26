using System;
using System.Collections.Generic;

#nullable disable

namespace WebsiteBanQuanAo16.DAL.Models
{
    public partial class User
    {
        public User()
        {
            DanhGia = new HashSet<DanhGia>();
            KhachHangs = new HashSet<KhachHang>();
            NhanViens = new HashSet<NhanVien>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string MatKhau { get; set; }
        public string Email { get; set; }
        public string Sdt { get; set; }
        public bool? Quyen { get; set; }

        public virtual ICollection<DanhGia> DanhGia { get; set; }
        public virtual ICollection<KhachHang> KhachHangs { get; set; }
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
