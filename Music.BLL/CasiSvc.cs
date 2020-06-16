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
    public class CasiSvc : GenericSvc<CasiRep, Casi>
    {
        public override SingleRsp Read(string MaID)
        {
            var res = new SingleRsp();
            var m = _rep.Read(MaID);
            res.Data = m;
            return res;
        }
        //public override SingleRsp 

        public SingleRsp CreateCasi(CasiReq singer)
        {
            var res = new SingleRsp();
            Casi casi = new Casi();
            casi.MaCaSi = singer.MaCaSi;
            casi.TenCaSi = singer.TenCaSi;
            casi.GioiTinh = singer.GioiTinh;
            casi.QuocTich = singer.QuocTich;
            casi.HinhAnh = singer.HinhAnh;
            casi.GhiChu = singer.GhiChu;
            res = _rep.CreateCasi(casi);
            return res;
        }

        public SingleRsp UpdateCasi(CasiReq singer)
        {
            var res = new SingleRsp();
            Casi casi = new Casi();
            casi.MaCaSi = singer.MaCaSi;
            casi.TenCaSi = singer.TenCaSi;
            casi.GioiTinh = singer.GioiTinh;
            casi.QuocTich = singer.QuocTich;
            casi.HinhAnh = singer.HinhAnh;
            casi.GhiChu = singer.GhiChu;
            res = _rep.UpdateCasi(casi);
            return res;
        }

        public SingleRsp DeleteCasi(string MaID)
        {
            var res = new SingleRsp();
            try
            {
                res.Data = _rep.DeleteCasi(MaID);
            }
            catch (Exception ex)
            {
                res.SetError(ex.StackTrace);
            }
            return res;
        }
    }
}
