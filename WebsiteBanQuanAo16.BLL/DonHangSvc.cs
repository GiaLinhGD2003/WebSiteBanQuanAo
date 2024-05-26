using System;
using System.Collections.Generic;
using System.Text;
using WebsiteBanQuanAo16.DAL;
using WebsiteBanQuanAo16.Common.BLL;
using WebsiteBanQuanAo16.DAL.Models;

namespace WebsiteBanQuanAo16.BLL
{
    public class DonHangSvc : GenericSvc<DonHangRep,DonHang>
    {
        private DonHangRep donHangRep;
        public DonHangSvc() 
        {
            donHangRep = new DonHangRep();  
        }
    }
}
