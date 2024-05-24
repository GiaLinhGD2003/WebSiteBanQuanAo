using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebsiteBanQuanAo16.Common.BLL;
using WebsiteBanQuanAo16.Common.Req;
using WebsiteBanQuanAo16.Common.Rsp;
using WebsiteBanQuanAo16.DAL;
using WebsiteBanQuanAo16.DAL.Models;

namespace WebsiteBanQuanAo16.BLL
{
    public class NhanVienSvc:GenericSvc<NhanVienRep, NhanVien>
    {
        private NhanVienRep nhanvienRep;
        #region -- Overrides --

        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Read(id);
            if (res.Data == null)
            {
                res.SetMessage("Khong tim thay user");
                res.SetError("404", "Khong tim thay user");
            }
            return res;
        }

        #endregion

        #region -- Methods --

        public NhanVienSvc() 
        {
            nhanvienRep = new NhanVienRep();
        }
        public SingleRsp CreateNhanVien(NhanVienReq nhanvienReq)
        {
            var res = new SingleRsp();
            NhanVien e = new NhanVien(); 

            e.MaNv = nhanvienReq.MaNv;
            e.NamSinh = nhanvienReq.NamSinh;
            e.Idcard = nhanvienReq.Idcard;
            e.ChucVu = nhanvienReq.ChucVu;
            e.Sdt = nhanvienReq.Sdt;

            res = nhanvienRep.CreateNhanVien(e);

            return res;
        }

        public SingleRsp UpdateNhanVien(NhanVienReq nhanvienReq)
        {

            var res = new SingleRsp();
            //Employee ex = new Employee();
            var ex = nhanvienRep.Read(nhanvienReq.MaNv);
            //Cap nhat
            ex.UserId = nhanvienReq.UserId;
			ex.MaNv = nhanvienReq.MaNv;
			ex.NamSinh = nhanvienReq.NamSinh;
			ex.Idcard = nhanvienReq.Idcard;
			ex.ChucVu = nhanvienReq.ChucVu;
			ex.Sdt = nhanvienReq.Sdt;
			res = nhanvienRep.UpdateNhanVien(ex);
            return res;
        }

        public SingleRsp DeleteNhanVien(int employeeId)
        {
            var rsp = new SingleRsp();

            try
            {
                // Find the existing employee
                var e = nhanvienRep.Read(employeeId);

                if (e == null)
                {
                    rsp.SetError($"Employee ID {employeeId} khong tim thay.");
                    return rsp;
                }
                // Delete the employee from the database
                nhanvienRep.DeleteNhanVien(e);
                rsp.SetMessage("Xoa thanh cong.");
            }
            catch (Exception ex)
            {
                rsp.SetError(ex.StackTrace);
                rsp.SetMessage("Failed to delete employee.");
            }

            return rsp;
        }

        #endregion
    }
}
