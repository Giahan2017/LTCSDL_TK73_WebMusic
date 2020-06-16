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
    public class AlbumController : ControllerBase
    {
        public AlbumController()
        {
            _svc = new AlbumSvc();
        }
        [HttpPost("get-by-MaAlbum")]
        public IActionResult getAlbumByAlbum([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            res = _svc.Read(req.Keyword);
            return Ok(res);
        }

        [HttpPost("create-album")]
        public IActionResult CreateAlbum([FromBody] AlbumReq req)
        {
            var res = _svc.CreateAlbum(req);
            return Ok(res);
        }

        [HttpPost("update-album")]
        public IActionResult UpdateAlbum([FromBody] AlbumReq req)
        {
            var res = _svc.UpdateAlbum(req);
            return Ok(res);
        }

        [HttpPost("delete-album")]
        public IActionResult DeleteAlbum([FromBody] AlbumReq req)
        {
            var res = _svc.DeleteAlbum(req.MaAb);
            return Ok(res);
        }
        private readonly AlbumSvc _svc;
    }
}