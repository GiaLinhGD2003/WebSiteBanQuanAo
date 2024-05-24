using WebsiteBanQuanAo16.Common.BLL;
using WebsiteBanQuanAo16.Common.Rsp;
using System;
using System.Collections.Generic;
using System.Text;
using WebsiteBanQuanAo16.DAL;
using WebsiteBanQuanAo16.DAL.Models;
using System.Net.Http;
using WebsiteBanQuanAo16.Common.Req;
using System.Linq;

namespace WebsiteBanQuanAo16.BLL
{
    public class UserSvc : GenericSvc<UserRep,User>
    {
        UserRep userRep;
        public UserSvc() 
        { 
            userRep = new UserRep();
        }

        //Lấy user theo ID truyền vào
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

        public SingleRsp CreateUser(UserReq userReq)
        {
            var res = new SingleRsp();
            User user = new User();
            user.UserName = userReq.UserName; ;
            user.Email = userReq.Email;
            user.MatKhau = userReq.MatKhau;
            user.Quyen = userReq.Quyen;
            //Nếu isAdmin khác 0 hoặc 1 thì gán mặc định là 0
            if (userReq.Quyen != true && userReq.Quyen != false)
                user.Quyen = false;
            userRep.CreateUser(user);
            return res;
        }

        public SingleRsp UpdateUser(UserReq userReq)
        {
            var res = new SingleRsp();
            User user = new User();
            user.UserName = userReq.UserName;
            user.Email = userReq.Email;
            user.MatKhau = userReq.MatKhau;
			user.Quyen = userReq.Quyen;
			//Nếu isAdmin khác 0 hoặc 1 thì gán mặc định là 0
			if (userReq.Quyen != true && userReq.Quyen != false)
				user.Quyen = false;
			userRep.UpdateUser(user);
            return res;
        }

        public SingleRsp DeleteUser(int id)
        {
            var res = new SingleRsp();
            var context = new QLQuanAoContext();
            var user = context.Users.Find(id);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
                res.SetMessage("Da xoa user");
            }
            else
            {
                res.SetMessage("Khong tim thay user");
                res.SetError("404", "Khong tim thay user");
            }
            return res;
        }
    }
}
