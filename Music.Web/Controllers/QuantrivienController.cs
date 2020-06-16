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
    public class QuantrivienController : ControllerBase
    {
        public QuantrivienController()
        {
            _svc = new QuantrivienSvc();
        }
        [HttpPost("get-by-MaQuantrivien")]
        public IActionResult getQuantriviencByMaQuantri([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            res = _svc.Read(req.Keyword);
            return Ok(res);
        }
        [HttpPost("create-quantrivien")]
        public IActionResult CreateQuantrivien([FromBody] QuantrivienReq req)
        {
            var res = _svc.CreateQuantrivien(req);
            return Ok(res);
        }
        [HttpPost("update-quantrivien")]
        public IActionResult UpdateQuantrivien([FromBody] QuantrivienReq req)
        {
            var res = _svc.UpdateQuantrivien(req);
            return Ok(res);
        }
        [HttpPost("delete-quantrivien")]
        public IActionResult DeleteQuantrivien([FromBody] QuantrivienReq req)
        {
            var res = _svc.DeleteQuantrivien(req.MaQuanTri);
            return Ok(res);
        }
        private readonly QuantrivienSvc _svc;
    }
}