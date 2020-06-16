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
    public class PlaylistSvc : GenericSvc<PlaylistRep, Playlist>
    {
        public override SingleRsp Read(string MaID)
        {
            var res = new SingleRsp();
            var m = _rep.Read(MaID);
            res.Data = m;
            return res;
        }

        public SingleRsp CreatePlaylist(PlaylistReq pl)
        {
            var res = new SingleRsp();
            Playlist playlist = new Playlist();
            playlist.MaPlayList = pl.MaPlayList;
            playlist.TenPlaylist = pl.TenPlaylist;
            playlist.MaBaiHat = pl.MaBaiHat;
            playlist.MaUser = pl.MaUser;
            playlist.GhiChu = pl.GhiChu;
            res = _rep.CreatePlaylist(playlist);
            return res;
        }
        public SingleRsp UpdatePlaylist(PlaylistReq pl)
        {
            var res = new SingleRsp();
            Playlist playlist = new Playlist();
            playlist.MaPlayList = pl.MaPlayList;
            playlist.TenPlaylist = pl.TenPlaylist;
            playlist.MaBaiHat = pl.MaBaiHat;
            playlist.MaUser = pl.MaUser;
            playlist.GhiChu = pl.GhiChu;
            res = _rep.UpdatePlaylist(playlist);
            return res;
        }

        public SingleRsp DeletePlaylist(string MaID)
        {
            var res = new SingleRsp();
            try
            {
                res.Data = _rep.DeletePlaylist(MaID);
            }
            catch (Exception ex)
            {
                res.SetError(ex.StackTrace);
            }
            return res;
        }
        //public override SingleRsp 
    }
}
