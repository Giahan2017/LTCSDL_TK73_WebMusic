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
    public class QuantrivienSvc : GenericSvc<QuantrivienRep, Quantrivien>
    {
        public override SingleRsp Read(string MaID)
        {
            var res = new SingleRsp();
            var m = _rep.Read(MaID);
            res.Data = m;
            return res;
        }

        public SingleRsp CreateQuantrivien(QuantrivienReq admin)
        {
            var res = new SingleRsp();
            Quantrivien quantrivien = new Quantrivien();
            quantrivien.MaQuanTri = admin.MaQuanTri;
            quantrivien.TenQtv = admin.TenQtv;
            quantrivien.NgaySinh = admin.NgaySinh;
            quantrivien.GhiChu = admin.GhiChu;
            res = _rep.CreateQuantrivien(quantrivien);
            return res;
        }
        public SingleRsp UpdateQuantrivien(QuantrivienReq admin)
        {
            var res = new SingleRsp();
            Quantrivien quantrivien = new Quantrivien();
            quantrivien.MaQuanTri = admin.MaQuanTri;
            quantrivien.TenQtv = admin.TenQtv;
            quantrivien.NgaySinh = admin.NgaySinh;
            quantrivien.GhiChu = admin.GhiChu;
            res = _rep.UpdateQuantrivien(quantrivien);
            return res;
        }
        public SingleRsp DeleteQuantrivien(string MaID)
        {
            var res = new SingleRsp();
            try
            {
                res.Data = _rep.DeleteQuantrivvien(MaID);
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
