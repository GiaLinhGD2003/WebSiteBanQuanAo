using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebsiteBanQuanAo16.Common.Req;
using WebsiteBanQuanAo16.Common.Rsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteBanQuanAo16.BLL;

namespace WebsiteBanQuanAo16.Web.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiSPController : ControllerBase
    {
        private LoaiSPSvc loaiSPSvc;
        public LoaiSPController()
        {
            loaiSPSvc = new LoaiSPSvc();
        }
        [HttpPost("get-by-id")]
        public IActionResult getCategoryById([FromBody] SimpleReq simpleReq)
        {
            var res = new SingleRsp();
            res = loaiSPSvc.Read(simpleReq.Id);
            return Ok(res);
        }
        [HttpPost("get-all")]
        public IActionResult getAllCategories()
        {
            var res = new SingleRsp();
            res.Data = loaiSPSvc.All;
            return Ok(res);
        }
    }
}
