using API_QLShop.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_QLShop.Common;
using Service.IServices;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_CSC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhuyenmaiController : ControllerBase
    {
        private readonly IKhuyenmaiService _iKhuyenmaiservice;
        public KhuyenmaiController(IKhuyenmaiService ikhuyenmaiservice)
        {
            _iKhuyenmaiservice = ikhuyenmaiservice;
        }
        [HttpPost("DanhSachKhuyenMaiTheoLoaiHang")]
        public List<KhuyenmaiModel.Output.ThongTinKhuyenMai> DanhSachKhuyenMaiTheoLoaiHang(KhuyenmaiModel.Input.DanhSachKhuyenMaiTheoLoaiHang input)
        {
            var dsKM = _iKhuyenmaiservice.DocDanhSachKhuyenMaiTheoLoaihang(input.LoaihangId)
                .Select(p => new KhuyenmaiModel.Output.ThongTinKhuyenMai()
                {
                    Id = p.Id,
                    NgayBatDau = p.NgayBatDau,
                    NgayKetThuc = p.NgayKetThuc,
                    PhanTramGiam = p.PhanTramGiam,
                    QuaTangKem = p.QuaTangKem,
                    VoucherTangKem = p.VoucherTangKem,

                }).ToList();
            return dsKM;
        }
        [HttpPost("ThongTinKhuyenMai")]
        public KhuyenmaiModel.Output.ThongTinKhuyenMai DocThongTinKhuyenMai(KhuyenmaiModel.Input.DanhSachKhuyenMaiTheoLoaiHang input)
        {
            var KM = _iKhuyenmaiservice.DocThongTinKhuyenMai(input.LoaihangId);
            if (KM == null) return new KhuyenmaiModel.Output.ThongTinKhuyenMai();
            var thongtinKM = new KhuyenmaiModel.Output.ThongTinKhuyenMai
            {
                Id = KM.Id,
                NgayBatDau = KM.NgayBatDau,
                NgayKetThuc = KM.NgayKetThuc,
                PhanTramGiam = KM.PhanTramGiam,
                QuaTangKem = KM.QuaTangKem,
                VoucherTangKem = KM.VoucherTangKem,

            };
            return thongtinKM;
        }
        // Thêm sửa xóa
        [HttpPost("DanhSachKhuyenMaiDangCo")]
        public List<KhuyenmaiModel.Output.ThongTinKhuyenMai> DanhSachKhuyenMaiDangCo(KhuyenmaiModel.Input.DanhSachKhuyenMaiDangCo input)
        {
            var KM = _iKhuyenmaiservice.DocDanhSachKhuyenMaiDangCo(input.Ngaydienra).Select(x=> new KhuyenmaiModel.Output.ThongTinKhuyenMai()
            {
                Id = x.Id,
                NgayBatDau = x.NgayBatDau,
                NgayKetThuc = x.NgayKetThuc,
                PhanTramGiam = x.PhanTramGiam,
                QuaTangKem = x.QuaTangKem,
                VoucherTangKem = x.VoucherTangKem,
                LoaiHangId = x.LoaiHangId,
                
            }).ToList();
            return KM;
        }
        [HttpPost("ThemKhuyenMai")]
        public ThongBaoModel ThemKhuyenMai(KhuyenmaiModel.Input.ThongTinKhuyenMai khuyenMai)
        {
            var tb = new ThongBaoModel { Maso = 0, Noidung = "" };
            try
            {
                var KhuyenMaiMoi = new Khuyenmai();
                Utilities.PropertyCopier<KhuyenmaiModel.Input.ThongTinKhuyenMai, Khuyenmai>.Copy(khuyenMai, KhuyenMaiMoi);
                var km = _iKhuyenmaiservice.Them(KhuyenMaiMoi);
                if (km != null) tb.Noidung = km.Id.ToString();
                else
                {
                    tb.Maso = 1;
                    tb.Noidung = "Không thêm được khuyến mại mới";
                }
            }
            catch (Exception ex)
            {
                tb.Maso = 1;
                tb.Noidung = "Không thêm được khuyến mại mới" + ex.Message;
            }
            return tb;
        }
        [HttpPost("XoaKhuyenMai")]
        public ThongBaoModel XoaKhuyenMai(KhuyenmaiModel.Input.XoaKhuyenMai input)
        {
            var tb = new ThongBaoModel { Maso = 0, Noidung = "" };
            try
            {
                
                var km = _iKhuyenmaiservice.DocThongTinKhuyenMai(input.Id);
                if (km != null|| !_iKhuyenmaiservice.Xoa(km))                
                {
                    tb.Maso = 1;
                    tb.Noidung = "Không xóa được thông tin khuyến mại";
                }
            }
            catch (Exception ex)
            {
                tb.Maso = 1;
                tb.Noidung = "Không xóa được thông tin khuyến mại" + ex.Message;
            }
            return tb;
        }
        [HttpPost("CapNhatKhuyenMai")]
        public ThongBaoModel CapNhatKhuyenMai(KhuyenmaiModel.Input.ThongTinKhuyenMai input)
        {
            var tb = new ThongBaoModel { Maso = 0, Noidung = "" };
            try
            {
                var kmsua = new Khuyenmai();
                
                if (!_iKhuyenmaiservice.Sua(kmsua))
                {
                    tb.Maso = 1;
                    tb.Noidung = "Không sửa được thông tin khuyến mại";
                }
            }
            catch (Exception ex)
            {
                tb.Maso = 1;
                tb.Noidung = "Không sửa được thông tin khuyến mại" + ex.Message;
            }
            return tb;
        }
    }
}
