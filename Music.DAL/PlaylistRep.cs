using System;
using System.Collections.Generic;
using System.Text;
using Music.Common.DAL;
using System.Linq;

namespace Music.DAL
{
    using Models;
    using Music.Common.Rsp;

    public class PlaylistRep : GenericRep<DBMusicContext, Playlist>
    {
        public override Playlist Read(String PLId)
        {
            var res = All.FirstOrDefault(b => b.MaPlayList == PLId);
            return res;
        }

        public SingleRsp CreatePlaylist(Playlist pl)
        {
            var res = new SingleRsp();
            using (var context = new DBMusicContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Playlist.Add(pl);
                        context.SaveChanges();
                        tran.Commit();

                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }

        public SingleRsp UpdatePlaylist(Playlist pl)
        {
            var res = new SingleRsp();
            using (var context = new DBMusicContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Playlist.Update(pl);
                        context.SaveChanges();
                        tran.Commit();

                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }
        public string DeletePlaylist(string MaID)
        {
            var n = base.All.First(i => i.MaPlayList == MaID);
            Context.Playlist.Remove(n);
            Context.SaveChanges();
            return n.MaPlayList;
        }
    }
}
