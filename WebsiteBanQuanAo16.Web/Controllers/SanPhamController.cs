using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebsiteBanQuanAo16.BLL;
using WebsiteBanQuanAo16.Common.Req;
using WebsiteBanQuanAo16.Common.Rsp;

namespace WebsiteBanQuanAo16.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private SanPhamSvc sanPhamSvc;

        public SanPhamController ()
        {
            sanPhamSvc = new SanPhamSvc ();
        }
        [HttpPost("create-product")]
        public IActionResult themSanPham([FromBody] SanPhamReq sanPhamReq)
        {
            var res = new SingleRsp();
            res = sanPhamSvc.themSanPham (sanPhamReq);
            return Ok(res);
        }
        [HttpPost("search-product")]
        public IActionResult timSanPham([FromBody] TimSanPhamReq timSanPhamReq)
        {
            var res = new SingleRsp();
            res = (SingleRsp)sanPhamSvc.timSanPham(timSanPhamReq);
            return Ok(res);
        }
        [HttpPut("update-product")]
        public IActionResult suaSanPham([FromBody] SanPhamReq sanPhamReq, string id)
        {
            var res = sanPhamSvc.suaSanPham(sanPhamReq, id);
            return Ok(res);
        }
        [HttpDelete("delete-product")]
        public IActionResult xoaSanPham(int id)
        {
            var res = sanPhamSvc.xoaSanpham(id);
            return Ok(res);
        }
    }
    
}
