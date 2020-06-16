using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Music.Controllers
{
    using BLL;
    using Music.DAL.Models;
    using Common.Req;
    using Common.Rsp;
    [Route("api/[controller]")]
    [ApiController]
    public class NguoidungController : ControllerBase
    {
        public NguoidungController()
        {
            _svc = new NguoidungSvc();
        }
        [HttpPost("get-by-MaNguoidung")]
        public IActionResult getNguoidungByMaNguoidung([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            res = _svc.Read(req.Keyword);
            return Ok(res);
        }
        [HttpPost("create-nguoidung")]
        public IActionResult CreateNguoidung([FromBody] NguoidungReq req)
        {
            var res = _svc.CreateNguoidung(req);
            return Ok(res);
        }
        [HttpPost("update-nguoidung")]
        public IActionResult UpdateNguoidung([FromBody] NguoidungReq req)
        {
            var res = _svc.UpdateNguoidung(req);
            return Ok(res);
        }
        [HttpPost("delete-nguoidung")]
        public IActionResult DeleteNguoidung([FromBody] NguoidungReq req)
        {
            var res = _svc.DeleteNguoidung(req.MaUser);
            return Ok(res);
        }
        private readonly NguoidungSvc _svc;
    }
}