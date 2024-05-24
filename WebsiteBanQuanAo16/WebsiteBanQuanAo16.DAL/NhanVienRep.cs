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
  
        #endregion

        #region -- Methods --

        public SingleRsp CreateNhanVien(NhanVien employee)
        {
            var res = new SingleRsp();
            using (var context = new QLQuanAoContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var e = context.NhanViens.Add(employee);
                        context.SaveChanges();
                        tran.Commit();
                        res.SetMessage("Tao Employee thanh cong");
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                        res.SetMessage("Tao Employee that bai");
                    }
                }
            }
            return res;
        }
        public SingleRsp UpdateNhanVien(NhanVien employee)
        {
            var res = new SingleRsp();

            using (var context = new QLQuanAoContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.NhanViens.Update(employee);
                        context.SaveChanges();
                        tran.Commit();
                        res.SetMessage("Update Employee thanh cong");
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                        res.SetMessage("Update Employee that bai");
                    }
                }
            }
            return res;
        }
        public SingleRsp DeleteNhanVien(NhanVien employee)
        {
            var res = new SingleRsp();
            using (var context = new QLQuanAoContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.NhanViens.Remove(employee); 
                        context.SaveChanges();
                        tran.Commit();
                        res.SetMessage("Da xoa nhan vien");
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                        res.SetMessage("Xoa that bai");
                    }
                }
            }
            return res;
        }

        #endregion
    }
}
