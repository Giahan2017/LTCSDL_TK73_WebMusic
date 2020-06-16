using System;
using System.Collections.Generic;
using System.Text;
using Music.Common.DAL;
using System.Linq;

namespace Music.DAL
{
    using Models;
    using Music.Common.Rsp;

    public class TheloaiRep : GenericRep<DBMusicContext, Theloai>
    {
        public override Theloai Read(String CategoryId)
        {
            var res = All.FirstOrDefault(b => b.MaTheLoai == CategoryId);
            return res;
        }

        public SingleRsp CreateTheloai(Theloai category)
        {
            var res = new SingleRsp();
            using (var context = new DBMusicContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Theloai.Add(category);
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

        public SingleRsp UpdateTheloai(Theloai category)
        {
            var res = new SingleRsp();
            using (var context = new DBMusicContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Theloai.Update(category);
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
        public string DeleteTheloai(string MaID)
        {
            var n = base.All.First(i => i.MaTheLoai == MaID);
            Context.Theloai.Remove(n);
            Context.SaveChanges();
            return n.MaTheLoai;
        }
    }
}