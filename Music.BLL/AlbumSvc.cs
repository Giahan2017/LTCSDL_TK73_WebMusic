using System;
using System.Collections.Generic;
using System.Text;
using Music.Common.Rsp;
using Music.Common.BLL;

namespace Music.BLL
{
    using Music.Common.Req;
    using Music.DAL;
    using Music.DAL.Models;
    public class AlbumSvc : GenericSvc<AlbumRep, Album>
    {
        public override SingleRsp Read(string MaID)
        {
            var res = new SingleRsp();
            var m = _rep.Read(MaID);
            res.Data = m;
            return res;
        }
        //public override SingleRsp 

        public SingleRsp CreateAlbum(AlbumReq alb)
        {
            var res = new SingleRsp();
            Album album = new Album();
            album.MaAb = alb.MaAb;
            album.TenAb = alb.TenAb;
            album.GhiChu = alb.GhiChu;
            res = _rep.CreateAlbum(album);
            return res;
        }

        public SingleRsp UpdateAlbum(AlbumReq alb)
        {
            var res = new SingleRsp();
            Album album = new Album();
            album.MaAb = alb.MaAb;
            album.TenAb = alb.TenAb;
            album.GhiChu = alb.GhiChu;
            res = _rep.UpdateAlbum(album);
            return res;
        }

        public SingleRsp DeleteAlbum(string MaID)
        {
            var res = new SingleRsp();
            try
            {
                res.Data = _rep.DeleteAlbum(MaID);
            }
            catch (Exception ex)
            {
                res.SetError(ex.StackTrace);
            }
            return res;
        }
    }
}