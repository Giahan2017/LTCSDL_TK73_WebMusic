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
    using Music.DAL;

    [Route("api/[controller]")]
    [ApiController]
    public class BaihatController : ControllerBase
    {
        public BaihatController()
        {
            _svc = new BaihatSvc();
        }
        [HttpPost("get-by-MaBaiHat")]
        public IActionResult getMusicByMaBaiHat([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            res = _svc.Read(req.Keyword);
            return Ok(res);
        }

        [HttpPost("create-baihat")]
        public IActionResult CreateBaihat([FromBody] BaihatReq req)
        {
            var res = _svc.CreateBaihat(req);
            return Ok(res);
        }

        [HttpPost("update-baihat")]
        public IActionResult UpdateBaihat([FromBody] BaihatReq req)
        {
            var res = _svc.UpdateBaihat(req);
            return Ok(res);
        }
        [HttpPost("delete-baihat")]
        public IActionResult DeleteBaihat([FromBody] BaihatReq req)
        {
            var res = _svc.DeleteBaihat(req.MaBaiHat);
            return Ok(res);
        }
        private readonly BaihatSvc _svc;
    }
}