using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebsiteBanQuanAo16.BLL;

namespace WebsiteBanQuanAo16.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonHangController : ControllerBase
    {
        private DonHangSvc dhSvc;
        public DonHangController()
        {
            dhSvc = new DonHangSvc();

        }
    }
}
