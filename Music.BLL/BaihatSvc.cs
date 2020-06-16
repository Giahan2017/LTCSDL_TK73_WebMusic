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
    public class BaihatSvc : GenericSvc<BaihatRep, Baihat>
    {
        public override SingleRsp Read(string MaID)
        {
            var res = new SingleRsp();
            var m = _rep.Read(MaID);
            res.Data = m;
            return res;
        }
        //public override SingleRsp 

        public SingleRsp CreateBaihat(BaihatReq song)
        {
            var res = new SingleRsp();
            Baihat baihat = new Baihat();
            baihat.MaBaiHat = song.MaBaiHat;
            baihat.MaCaSi = song.MaCaSi;
            baihat.MaTheLoai = song.MaTheLoai;
            baihat.TenBaiHat = song.TenBaiHat;
            baihat.QuocGia = song.QuocGia;
            baihat.FileLoiBaiHat = song.FileLoiBaiHat;
            baihat.LinkNhac = song.LinkNhac;
            baihat.NgayTao = song.NgayTao;
            baihat.NguoiTao = song.NguoiTao;
            baihat.NgayChinhSua = song.NgayChinhSua;
            baihat.NguoiChinhSua = song.NguoiChinhSua;
            baihat.GhiChu = song.GhiChu;
            res = _rep.CreateBaihat(baihat); 
            return res;
        }

        public SingleRsp UpdateBaihat(BaihatReq song)
        {
            var res = new SingleRsp();
            Baihat baihat = new Baihat();
            baihat.MaBaiHat = song.MaBaiHat;
            baihat.MaCaSi = song.MaCaSi;
            baihat.MaTheLoai = song.MaTheLoai;
            baihat.TenBaiHat = song.TenBaiHat;
            baihat.QuocGia = song.QuocGia;
            baihat.FileLoiBaiHat = song.FileLoiBaiHat;
            baihat.LinkNhac = song.LinkNhac;
            baihat.NgayTao = song.NgayTao;
            baihat.NguoiTao = song.NguoiTao;
            baihat.NgayChinhSua = song.NgayChinhSua;
            baihat.NguoiChinhSua = song.NguoiChinhSua;
            baihat.GhiChu = song.GhiChu;
            res = _rep.UpdateBaihat(baihat);
            return res;
        }

        public SingleRsp DeleteBaihat(string MaID)
        {
            var res = new SingleRsp();
            try
            {
                res.Data = _rep.DeleteBaihat(MaID);
            }
            catch (Exception ex)
            {
                res.SetError(ex.StackTrace);
            }
            return res;
        }
    }
}
