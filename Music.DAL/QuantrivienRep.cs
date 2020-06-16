using System;
using System.Collections.Generic;
using System.Text;
using Music.Common.DAL;
using System.Linq;

namespace Music.DAL
{
    using Models;
    using Music.Common.Rsp;

    public class QuantrivienRep : GenericRep<DBMusicContext, Quantrivien>
    {
        public override Quantrivien Read(String AdminId)
        {
            var res = All.FirstOrDefault(b => b.MaQuanTri == AdminId);
            return res;
        }

        public SingleRsp CreateQuantrivien(Quantrivien admin)
        {
            var res = new SingleRsp();
            using (var context = new DBMusicContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Quantrivien.Add(admin);
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

        public SingleRsp UpdateQuantrivien(Quantrivien admin)
        {
            var res = new SingleRsp();
            using (var context = new DBMusicContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Quantrivien.Update(admin);
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
        public string DeleteQuantrivvien(string MaID)
        {
            var n = base.All.First(i => i.MaQuanTri == MaID);
            Context.Quantrivien.Remove(n);
            Context.SaveChanges();
            return n.MaQuanTri;
        }
    }
}
