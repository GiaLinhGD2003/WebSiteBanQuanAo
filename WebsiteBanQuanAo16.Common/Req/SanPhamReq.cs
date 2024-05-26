using System;
using System.Collections.Generic;
using System.Text;

namespace WebsiteBanQuanAo16.Common.Req
{
    public class SanPhamReq
    {
		public int MaSp { get; set; }
		public string MaLoai { get; set; }
		public string TenSp { get; set; }
		public string ThongTinSp { get; set; }
		public int? Gia { get; set; }
		public int? SoLuong { get; set; }
		public string KichThuoc { get; set; }


	}
}
