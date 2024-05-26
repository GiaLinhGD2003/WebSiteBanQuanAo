using System;
using System.Collections.Generic;
using System.Text;
using WebsiteBanQuanAo16.Common.DAL;
using WebsiteBanQuanAo16.DAL.Models;
using System.Linq;
using WebsiteBanQuanAo16.Common.Rsp;

namespace WebsiteBanQuanAo16.DAL
{
    public class DonHangRep : GenericRep<QLQuanAoContext , DonHang>
    {
        #region -- Overrides --


        public override DonHang Read(string id)
        {
            var res = All.FirstOrDefault(p => p.MaDh == id);
            return res;
        }


        public int Remove(int id)
        {
            var m = base.All.First(i => i.OrderId == id);
            m = base.Delete(m);
            return m.OrderId;
        }

        #endregion
        #region -- Methods --
        public SingleRsp timDonHang (string id)
        {
            var res = new SingleRsp();
            res.Data = All.Where(x => x.MaDh == id);
            return res;
        }

        public SingleRsp themSanPham(DonHang order)
        {
            var res = new SingleRsp();
            using (var context = new QLQuanAoContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.DonHangs.Update(order);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetMessage(ex.Message);
                    }
                }
            }
            return res;
        }
        public SingleRsp xoaSanPham(DonHang order)
        {
            var res = new SingleRsp();
            using (var context = new QLQuanAoContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.DonHangs.Remove(order);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetMessage(ex.Message);
                    }
                }
            }
            return res;
        }

        #endregion
        public DonHangRep()
        {

        }
    }
}
