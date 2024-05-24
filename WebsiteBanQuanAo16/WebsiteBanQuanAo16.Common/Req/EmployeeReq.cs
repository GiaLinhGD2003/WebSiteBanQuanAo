using System;
using System.Collections.Generic;
using System.Text;

namespace WebsiteBanQuanAo16.Common.Req
{
    public class NhanVienReq
    {
        public int EmployeeId { get; set; }
        public int? UserId { get; set; }
        public string EmployeeName { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Idcard { get; set; }
        public string Title { get; set; }
        public string Phone { get; set; }
    }
}
