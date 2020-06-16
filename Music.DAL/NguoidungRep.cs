using System;
using System.Collections.Generic;
using System.Text;
using Music.Common.DAL;
using System.Linq;

namespace Music.DAL
{
    using Models;
    using Music.Common.Rsp;

    public class NguoidungRep : GenericRep<DBMusicContext, Nguoidung>
    {
        public override Nguoidung Read(String UserId)
        {
            var res = All.FirstOrDefault(b => b.MaUser == UserId);
            return res;
        }

        public SingleRsp CreateNguoidung(Nguoidung user)
        {
            var res = new SingleRsp();
            using (var context = new DBMusicContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Nguoidung.Add(user);
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

        public SingleRsp UpdateNguoidung(Nguoidung user)
        {
            var res = new SingleRsp();
            using (var context = new DBMusicContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Nguoidung.Update(user);
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

        public string DeleteNguoidung(string MaID)
        {
            var n = base.All.First(i => i.MaUser == MaID);
            Context.Nguoidung.Remove(n);
            Context.SaveChanges();
            return n.MaUser;
        }
    }
}
