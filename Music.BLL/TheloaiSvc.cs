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
    public class TheloaiSvc : GenericSvc<TheloaiRep, Theloai>
    {
        public override SingleRsp Read(string MaID)
        {
            var res = new SingleRsp();
            var m = _rep.Read(MaID);
            res.Data = m;
            return res;
        }

        public SingleRsp CreateTheloai(Theloai category)
        {
            var res = new SingleRsp();
            Theloai theloai = new Theloai();
            theloai.MaTheLoai = category.MaTheLoai;
            theloai.TenTheLoai = category.TenTheLoai;
            theloai.GhiChu = category.GhiChu;
            res = _rep.CreateTheloai(theloai);
            return res;
        }

        

        public SingleRsp UpdateTheloai(Theloai category)
        {
            var res = new SingleRsp();
            Theloai theloai = new Theloai();
            theloai.MaTheLoai = category.MaTheLoai;
            theloai.TenTheLoai = category.TenTheLoai;
            theloai.GhiChu = category.GhiChu;
            res = _rep.UpdateTheloai(theloai);
            return res;
        }

        
        public SingleRsp DeleteTheloai(string MaID)
        {
            var res = new SingleRsp();
            try
            {
                res.Data = _rep.DeleteTheloai(MaID);
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