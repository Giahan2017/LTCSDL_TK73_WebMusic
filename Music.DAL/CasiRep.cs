using System;
using System.Collections.Generic;
using System.Text;
using Music.Common.DAL;
using System.Linq;

namespace Music.DAL
{
    using Models;
    using Music.Common.Rsp;

    public class CasiRep : GenericRep<DBMusicContext, Casi>
    {
        public override Casi Read(String SingerId)
        {
            var res = All.FirstOrDefault(b => b.MaCaSi == SingerId);
            return res;
        }

        //Tao ca si moi
        public SingleRsp CreateCasi(Casi singer)
        {
            var res = new SingleRsp();
            using (var context = new DBMusicContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Casi.Add(singer);
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

        //Cap nhat ca si
        public SingleRsp UpdateCasi(Casi singer)
        {
            var res = new SingleRsp();
            using (var context = new DBMusicContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Casi.Update(singer);
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

        public string DeleteCasi(string MaID)
        {
            var n = base.All.First(i => i.MaCaSi == MaID);
            Context.Casi.Remove(n);
            Context.SaveChanges();
            return n.MaCaSi;
        }
    }
}
