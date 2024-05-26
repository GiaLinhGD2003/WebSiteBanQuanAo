using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebsiteBanQuanAo16.BLL;
using WebsiteBanQuanAo16.Common.Req;
using WebsiteBanQuanAo16.Common.Rsp;

namespace WebsiteBanQuanAo16.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        //Phuong thuc khoi tao de lien ket voi lop BLL
        private NhanVienSvc nhanVienSvc;
        public NhanVienController()
        {
            nhanVienSvc = new NhanVienSvc();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("{id}")]
        public IActionResult GetEmployeeByID(int id)
        {
            var rsp = new SingleRsp();
            rsp = nhanVienSvc.Read(id);
            return Ok(rsp);
        }

        [HttpGet("GetAllEmployee")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetEmployeeByALL()
        {
            var rsp = new SingleRsp();
            rsp.Data = nhanVienSvc.All;
            return Ok(rsp);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("CreateEmployee")]
        public IActionResult CreateEmployee(NhanVienReq employeeReq)
        {
            var rsp = new SingleRsp();
            rsp = nhanVienSvc.themNhanVien (employeeReq);
            return Ok(rsp);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateEmployee/{id}")]
        public IActionResult suaNhanVien(int id, [FromBody] NhanVienReq nhanVienReq)
        {
            if (id != nhanVienReq.MaNv)
            {
                return BadRequest();
            }
            var rsp = new SingleRsp();
            rsp = nhanVienSvc.suaNhanVien(nhanVienReq);
            return Ok(rsp);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteEmployee")]
        public IActionResult xoaNhanVien(int id)
        {
            var rsp = new SingleRsp();
            rsp = nhanVienSvc.xoaNhanVien(id);
            return Ok(rsp);
        }
    }
}
