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
    public class PlaylistController : ControllerBase
    {
        public PlaylistController()
        {
            _svc = new PlaylistSvc();
        }
        [HttpPost("get-by-MaPlaylist")]
        public IActionResult getPlaylistByMaBaiHat([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            res = _svc.Read(req.Keyword);
            return Ok(res);
        }
        [HttpPost("create-playlist")]
        public IActionResult CreatePlaylist([FromBody] PlaylistReq req)
        {
            var res = _svc.CreatePlaylist(req);
            return Ok(res);
        }
        [HttpPost("update-playlist")]
        public IActionResult UpdatePlaylist([FromBody] PlaylistReq req)
        {
            var res = _svc.UpdatePlaylist(req);
            return Ok(res);
        }
        [HttpPost("delete-playlist")]
        public IActionResult DeletePlaylist([FromBody] PlaylistReq req)
        {
            var res = _svc.DeletePlaylist(req.MaPlayList);
            return Ok(res);
        }
        private readonly PlaylistSvc _svc;
    }
}