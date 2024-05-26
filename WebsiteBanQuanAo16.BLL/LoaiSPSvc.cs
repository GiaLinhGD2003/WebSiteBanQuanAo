using WebsiteBanQuanAo16.Common.BLL;
using WebsiteBanQuanAo16.Common.Rsp;
using WebsiteBanQuanAo16.DAL;
using WebsiteBanQuanAo16.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebsiteBanQuanAo16.BLL
{
    public  class LoaiSPSvc: GenericSvc<LoaiSPRep, LoaiSp>
    {
        private LoaiSPRep loaiSPRep; 
        #region -- Overrides --
        public LoaiSPSvc()
        {
            loaiSPRep = new LoaiSPRep();
        }
        
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            res.Data = _rep.Read(id);

            return res;
        }

        
        public override SingleRsp Update(LoaiSp m)
        {
            var res = new SingleRsp();

            var m1 = m.MaLoai > 0 ? _rep.Read(m.MaLoai) : _rep.Read(m.);
            if (m1 == null)
            {
                res.SetError("EZ103", "No data.");
            }
            else
            {
                res = base.Update(m);
                res.Data = m;
            }

            return res;
        }
        #endregion

        #region -- Methods --


        #endregion
    }
}
