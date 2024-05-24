using System;
using System.Collections.Generic;

#nullable disable

namespace WebsiteBanQuanAo16.DAL.Models
{
    public partial class KhachHang
    {
        public KhachHang()
        {
            DonHangs = new HashSet<DonHang>();
        }

        public string MaKh { get; set; }
        public string UserId { get; set; }
        public string TenKh { get; set; }
        public string Sdt { get; set; }
        public string Diachi { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
