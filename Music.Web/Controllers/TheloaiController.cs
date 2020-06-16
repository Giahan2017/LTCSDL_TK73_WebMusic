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
    public class TheloaiController : ControllerBase
    {
        public TheloaiController()
        {
            _svc = new TheloaiSvc();
        }
        [HttpPost("get-by-MaTheloai")]
        public IActionResult getTheloaiByMaTheloai([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            res = _svc.Read(req.Keyword);
            return Ok(res);
        }
        [HttpPost("create-theloai")]
        public IActionResult CreateTheloai([FromBody] TheloaiReq req)
        {
            var res = _svc.CreateTheloai(req);
            return Ok(res);
        }
        [HttpPost("update-theloai")]
        public IActionResult UpdateTheloai([FromBody] TheloaiReq req)
        {
            var res = _svc.UpdateTheloai(req);
            return Ok(res);
        }
        [HttpPost("delete-theloai")]
        public IActionResult DeleteTheloai([FromBody] TheloaiReq req)
        {
            var res = _svc.DeleteTheloai(req.MaTheLoai);
            return Ok(res);
        }
        private readonly TheloaiSvc _svc;
    }
}
