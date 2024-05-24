using System;
using System.Collections.Generic;
using System.Text;

namespace WebsiteBanQuanAo16.Common.Req
{
    public class UserReq
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string MatKhau { get; set; }
		public Boolean Quyen { get; set; }
    }
}
