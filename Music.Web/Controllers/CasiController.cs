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
    public class CasiController : ControllerBase
    {
        public CasiController()
        {
            _svc = new CasiSvc();
        }
        [HttpPost("get-by-MaCasi")]
        public IActionResult getCasiByMaCasi([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            res = _svc.Read(req.Keyword);
            return Ok(res);
        }

        [HttpPost("create-casi")]
        public IActionResult CreateCasi([FromBody] CasiReq req)
        {
            var res = _svc.CreateCasi(req);
            return Ok(res);
        }
        [HttpPost("update-casi")]
        public IActionResult UpdateCasi([FromBody] CasiReq req)
        {
            var res = _svc.UpdateCasi(req);
            return Ok(res);
        }
        [HttpPost("delete-casi")]
        public IActionResult DeleteCasi([FromBody] CasiReq req)
        {
            var res = _svc.DeleteCasi(req.MaCaSi);
            return Ok(res);
        }
        private readonly CasiSvc _svc;
    }
}