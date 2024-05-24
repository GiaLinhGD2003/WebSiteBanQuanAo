using System;
using System.Collections.Generic;
using System.Text;
using WebsiteBanQuanAo16.Common.DAL;
using WebsiteBanQuanAo16.DAL.Models;
using System.Linq;
using WebsiteBanQuanAo16.Common.Rsp;

namespace WebsiteBanQuanAo16.DAL
{
    public class NhanVienRep:GenericRep<QLQuanAoContext,NhanVien>
    {
        #region -- Overrides --


        public override NhanVien Read(int id)
        {
            var res = All.FirstOrDefault(e => e.MaNv == id);
            return res;
        }
        public int Remove(int id)
        {
            var m = base.All.First(e => e.MaNv == id);
            m = base.Delete(m);
            return m.MaNv;
        }
        #endregion

        #region -- Methods --

        public SingleRsp CreateEmployee(NhanVien NV)
        {
            var res = new SingleRsp();
            using (var context = new QLQuanAoContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var e = context.NhanViens.Add(NV);
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
        public SingleRsp UpdateEmployee(NhanVien employee)
        {
            var res = new SingleRsp();
            using (var context = new QLQuanAoContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.NhanViens.Update(employee);
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
