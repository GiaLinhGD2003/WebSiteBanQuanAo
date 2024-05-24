using WebsiteBanQuanAo16.Common.DAL;
using WebsiteBanQuanAo16.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebsiteBanQuanAo16.DAL
{
    public class LoaiSPRep : GenericRep<QLQuanAoContext,LoaiSp >
    {
		#region -- Overrides --

		//public override LoaiSp Read(int id)
		//{
		//    var res = All.FirstOrDefault(p => p.MaLoai == id);
		//    return res;
		//}
		public override LoaiSp Read(int id)
        {
            return base.Read(id);
        }

        public int Remove(int id)
        {
            var m = base.All.First(i => i.MaLoai == id);
            m = base.Delete(m); 
            return m.MaLoai;
        }

        #endregion

        #region -- Methods --


        #endregion
    }
}
