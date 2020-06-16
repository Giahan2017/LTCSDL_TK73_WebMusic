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
    public class NguoidungSvc : GenericSvc<NguoidungRep, Nguoidung>
    {
        public override SingleRsp Read(string MaID)
        {
            var res = new SingleRsp();
            var m = _rep.Read(MaID);
            res.Data = m;
            return res;
        }

        public SingleRsp CreateNguoidung(NguoidungReq user)
        {
            var res = new SingleRsp();
            Nguoidung nguoidung = new Nguoidung();
            nguoidung.MaUser = user.MaUser;
            nguoidung.TenUser = user.TenUser;
            nguoidung.MatKhau = user.MatKhau;
            nguoidung.NgaySinh = user.NgaySinh;
            nguoidung.GioiTinh = user.GioiTinh;
            nguoidung.GhiChu = user.GhiChu;
            res = _rep.CreateNguoidung(nguoidung);
            return res;
        }
        public SingleRsp UpdateNguoidung(NguoidungReq user)
        {
            var res = new SingleRsp();
            Nguoidung nguoidung = new Nguoidung();
            nguoidung.MaUser = user.MaUser;
            nguoidung.TenUser = user.TenUser;
            nguoidung.MatKhau = user.MatKhau;
            nguoidung.NgaySinh = user.NgaySinh;
            nguoidung.GioiTinh = user.GioiTinh;
            nguoidung.GhiChu = user.GhiChu;
            res = _rep.UpdateNguoidung(nguoidung);
            return res;
        }

        public SingleRsp DeleteNguoidung(string MaID)
        {
            var res = new SingleRsp();
            try
            {
                res.Data = _rep.DeleteNguoidung(MaID);
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
