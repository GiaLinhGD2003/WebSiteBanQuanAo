using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using WebsiteBanQuanAo16.Common.BLL;
using WebsiteBanQuanAo16.Common.Req;
using WebsiteBanQuanAo16.Common.Rsp;
using WebsiteBanQuanAo16.DAL;
using WebsiteBanQuanAo16.DAL.Models;

namespace WebsiteBanQuanAo16.BLL
{
    public class SanPhamSvc : GenericSvc<SanPhamRep, SanPham>
    {
        private SanPhamRep productRep;
        #region -- Overrides --

        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }

        public override SingleRsp Update(SanPham m)
        {
            var res = new SingleRsp();

            var m1 = m.MaSp > 0 ? _rep.Read(m.MaSp) : _rep.Read(m.MaSp);
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

        #region  -- Methods --
        public object SearchSanPham(SearchProductReq s)
        {
            var res = new SingleRsp();
            try
            {
                var sp = All.Where(x => x.TenSp.Contains(s.Keyword));
                if (sp != null)
                {
                    var offset = (s.Page - 1) * s.Size;
                    var total = sp.Count();
                    int totalPage = (total % s.Size) == 0 ? (int)(total / s.Size) :
                        (int)(1 + (total / s.Size));
                    var data = sp.OrderBy(x => x.TenSp).Skip(offset).Take(s.Size).ToList();
                    var obj = new
                    {
                        Data = data,
                        TotalRecord = total,
                        TotalPages = totalPage,
                        Page = s.Page,
                        Size = s.Size

                    };
                    res.Data = obj;
                }
                else
                {
                    res.SetMessage("Khong tim thay san pham");
                    res.SetError("404", "Khong tim thay san pham");
                }
            }
            catch (Exception ex) 
            {
                res.SetMessage(ex.Message);
            }
            
            return res;
        }

        public SingleRsp CreateSanPham(SanPhamReq sanphamReq)
        {
            var res = new SingleRsp();
            SanPham sp = new SanPham();
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    sp.MaSp = sanphamReq.MaSp;
					sp.MaLoai = sanphamReq.MaLoai;
					sp.TenSp = sanphamReq.TenSp;
					sp.ThongTinSp = sanphamReq.ThongTinSp;
					sp.Gia = sanphamReq.Gia;
					sp.SoLuong = sanphamReq.SoLuong;                   
                    sp.KichThuoc = sanphamReq.KichThuoc;
					res = productRep.CreateProduct(sp);
                }
            }
            catch (Exception ex)
            {
                res.SetMessage(ex.Message);
            }
            return res;
        }

        public SingleRsp UpdateSanPham(SanPhamReq sanphamReq, string id)
        {
            int result;
            var context = new QLQuanAoContext();
            var res = new SingleRsp();
            using (var tran = context.Database.BeginTransaction())
            {
                try
                {
                    if (int.TryParse(id, out result))
                    {
                        var sp = context.SanPhams.FirstOrDefault(u => u.MaSp == result);
                        if (sp != null)
                        {
							sp.MaLoai = sanphamReq.MaLoai;
							sp.TenSp = sanphamReq.TenSp;
							sp.ThongTinSp = sanphamReq.ThongTinSp;
							sp.Gia = sanphamReq.Gia;
							sp.SoLuong = sanphamReq.SoLuong;
							sp.KichThuoc = sanphamReq.KichThuoc;
							context.SaveChanges();
                            tran.Commit();
                            res.SetMessage("Update thanh cong");
                        }
                        else
                        {
                            res.SetMessage("Khong tim thay san pham");
                            res.SetError("404", "Khong tim thay san pham");
                        }
                    }
                    else
                    {
                        res.SetError("400", "Ma san pham khong hop le");
                    }
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    res.SetError(ex.StackTrace);
                    res.SetMessage(ex.Message);
                }
            }
            return res;
        }

        public SingleRsp DeleteProduct(int id)
        {
            var res = new SingleRsp();
            var context = new QLQuanAoContext();
            try
            {
                var product = context.SanPhams.Find(id);
                if (product != null)
                {
                    context.SanPhams.Remove(product);
                    context.SaveChanges();
                    res.SetMessage("Đã xóa sản phẩm");
                }
                else
                {
                    res.SetMessage("Không tìm thấy sản phẩm");
                    res.SetError("404", "Không tìm thấy sản phẩm");
                }
            }
            catch (Exception ex)
            {
                res.SetMessage(ex.Message);
            }
            return res;
        }
        #endregion
        public SanPhamSvc()
        {
            productRep = new SanPhamRep();
        }
    }
}

