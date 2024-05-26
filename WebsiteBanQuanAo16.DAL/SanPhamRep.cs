using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using WebsiteBanQuanAo16.Common.DAL;
using WebsiteBanQuanAo16.Common.Rsp;
using WebsiteBanQuanAo16.DAL.Models;

namespace WebsiteBanQuanAo16.DAL
{
    public class SanPhamRep : GenericRep<QLQuanAoContext, SanPham>
    {
       
        #region -- Overrides --


        public override SanPham Read(int id)
        {
            var res = All.FirstOrDefault(p => p.MaSp == id);
            return res;
        }


        public int Remove(int id)
        {
            var m = base.All.First(i => i.MaSp == id);
            m = base.Delete(m);
            return m.MaSp;
        }

        #endregion
        #region -- Methods --
        public SingleRsp themSanPham(SanPham sanpham)
        {
            var res = new SingleRsp();
            using (var context = new QLQuanAoContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.SanPhams.Add(sanpham);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
            
        }
        public SingleRsp timSanPham(string keyWord)
        {
            var res = new SingleRsp();
            res.Data = All.Where(x=>x.TenSp.Contains(keyWord));
            return res;
        }

        public SingleRsp suaSanPham(SanPham sanpham)
        {
            var res = new SingleRsp();
            using (var context = new QLQuanAoContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.SanPhams.Update(sanpham);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }
        public SingleRsp xoaSanPham (SanPham sanpham)
        {
            var res = new SingleRsp();
            using (var context = new QLQuanAoContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.SanPhams.Remove(sanpham);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }

        #endregion

    }
}
