using System;
using System.Collections.Generic;
using System.Text;

namespace WebsiteBanQuanAo16.Common.Req
{
    public class TimSanPhamReq
    {
        
        public int Page { get; set; }
        public int Size { get; set; }
        //public int ID { get; set; }
        //public int Type { get; set; }
        public string Keyword { get; set; }
    }
}
