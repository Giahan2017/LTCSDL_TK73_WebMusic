using System;
using System.Collections.Generic;
using System.Text;
using Music.Common.DAL;
using System.Linq;

namespace Music.DAL
{
    using Models;
    using Music.Common.Rsp;

    public class AlbumRep : GenericRep<DBMusicContext, Album>
    {
        public override Album Read(String AlbumId)
        {
            var res = All.FirstOrDefault(b => b.MaAb == AlbumId);
            return res;
        }

        public SingleRsp CreateAlbum(Album alb)
        {
            var res = new SingleRsp();
            using (var context = new DBMusicContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Album.Add(alb);
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

        public SingleRsp UpdateAlbum(Album alb)
        {
            var res = new SingleRsp();
            using (var context = new DBMusicContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Album.Update(alb);
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

        public string DeleteAlbum(string MaID)
        {
            var n = base.All.First(i => i.MaAb == MaID);
            Context.Album.Remove(n);
            Context.SaveChanges();
            return n.MaAb;
        }
    }
}