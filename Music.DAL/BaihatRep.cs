using System;
using System.Collections.Generic;
using System.Text;
using Music.Common.DAL;
using System.Linq;

namespace Music.DAL
{
    using Models;
    using Music.Common.Rsp;

    public class BaihatRep : GenericRep<DBMusicContext, Baihat>
    {
        public override Baihat Read(String SongId)
        {
            var res = All.FirstOrDefault(b => b.MaBaiHat == SongId);
            return res;
        }

        //Tao bai hat moi
        public SingleRsp CreateBaihat(Baihat song)
        {
            var res = new SingleRsp();
            using (var context = new DBMusicContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Baihat.Add(song);
                        context.SaveChanges();
                        tran.Commit();

                    }
                    catch(Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }

        //Cap nhat bai hat
        public SingleRsp UpdateBaihat(Baihat song)
        {
            var res = new SingleRsp();
            using (var context = new DBMusicContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Baihat.Update(song);
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
        // Xoa bai hat
        public string DeleteBaihat(string MaID)
        {
            var n = base.All.First(i => i.MaBaiHat == MaID);
            Context.Baihat.Remove(n);
            Context.SaveChanges();
            return n.MaBaiHat;
        }
    }

}
