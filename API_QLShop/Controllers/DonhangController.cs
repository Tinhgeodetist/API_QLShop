using API_QLShop.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_QLShop.Common;
using API_QLShop.DTO;
using Service.IServices;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_QLShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonhangController : ControllerBase
    {

        private readonly ISanPhamService _iSanphamService;
        private readonly ILoaihangService _iloaihangService;
        private readonly IDonhangService _idonhangService;
        private readonly IKhachHangService _ikhachangService;
        public DonhangController(IDonhangService idonhangService, ISanPhamService iSanphamService, ILoaihangService iloaihangService)
        {
            _iSanphamService = iSanphamService;
            _idonhangService = idonhangService;
            _iloaihangService = iloaihangService;
        }
        [HttpPost("MuaDonHang")]
        public ThongBaoModel MuaDonHang(DonhangModel.Input.MuaDonHang input)
        {
            var tb = new ThongBaoModel { Maso = 0, Noidung = "" };
            try
            {
                if (input == null || input.DanhSachDonHang.Count == 0)
                {
                    tb.Maso = 1;
                    tb.Noidung = "Thông tin đơn hàng không hợp lệ";
                }
                else
                {
                    var dsDonhang = new List<Donhang>();
                    foreach (var don in input.DanhSachDonHang)
                    {
                        var donmua = new Donhang()
                        {
                            NgayTao = DateTime.Today.Date,
                            Id = don.Id,
                            KhachHangId = don.KhachHangId,
                            Ten = don.Ten,
                            SoDienThoai = don.SoDienThoai,
                            DiaChi = don.DiaChi,
                            GiamGia = don.GiamGia,
                            TinhTrangDonHang = true,
                            TongTien = don.TongTien,
                            NoiDung = don.NoiDung
                        };
                        dsDonhang.Add(donmua);
                    }
                    if (!_idonhangService.MuaDonHang(dsDonhang))
                    {
                        tb.Maso = 3;
                        tb.Noidung = "Có lỗi trong quá trình mua! Xin thử lại";
                    };
                }
            }
            catch (Exception ex)
            {
                tb.Maso =  2;
                tb.Noidung = "Lỗi mua vé. " + ex.Message;
            }
            return tb;
        }
        [HttpPost("DanhSachDonHangTheoKhachHang")]
        public List<DonhangModel.Output.ThongTinDonHang> DanhSachDonHangTheoKhachHang(DonhangModel.Input.DocDanhSachDonHangTheoKh input)
        {
            

            var DH= _idonhangService.DocDanhSachDonHangTheoKhachHang(input.KhachHangId);
            var dsDH = DH.Select(x=> new DonhangModel.Output.ThongTinDonHang()
                {
                    Id = x.Id,
                    Ten = x.Ten,
                    SoDienThoai = x.SoDienThoai,
                    NgayTao = DateTime.Today.Date,
                    DsSanPhamId =x.DsSanPhamId,
                    KhachHangId= x.KhachHangId,                    
                    DiaChi = x.DiaChi,
                    GiamGia = x.GiamGia,
                    TinhTrangDonHang = true,
                    TongTien = x.TongTien,
                    NoiDung = x.NoiDung,
                    Email= x.Email,
                    PhiShip= x.PhiShip,
                    MaGiamGia = x.MaGiamGia,                    
                    
                }).ToList();
            return dsDH;
        }
        [HttpPost("ThongTinDonHang")]
        public DonhangModel.Output.ThongTinDonHang ThongTinDonHang(DonhangModel.Input.DocThongTinDonHang input)
        {

            DonhangModel.Output.ThongTinDonHang thongTinDonHang = new DonhangModel.Output.ThongTinDonHang();
            
            var DH = _idonhangService.DocThongTinDonHang(input.Id);
            if (DH != null && DH.Id > 0)
            {
                thongTinDonHang = new();
                Utilities.PropertyCopier<Donhang, DonhangModel.Output.ThongTinDonHang>.Copy(DH, thongTinDonHang);
                thongTinDonHang.Id = DH.Id;
                thongTinDonHang.Khachhang = new KhachhangModel.KhachhangBase()
                {
                    Idkhachhang = DH.KhachHang.Id,
                    HoTenKh = DH.KhachHang.Ten+ DH.KhachHang.TenLot,
                    Email = DH.KhachHang.Email,
                };
                var dsSanPham = _iSanphamService.DocDanhSachSanPham();
                var dsIdSanPham = thongTinDonHang.DsSanPhamId.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
                var donhang_SP = dsSanPham.Where(x => dsIdSanPham.Contains(x.Id.ToString())).ToList();
                if (donhang_SP.Count > 0)
                {
                    foreach (var sp in donhang_SP)
                    {
                        thongTinDonHang.DanhSachsanpham.Add(new SanPhamModel.SanPhamBase()
                        {
                            Id = sp.Id,
                            TenSanPham = sp.TenSanPham,
                            GiaSanPham = sp.GiaSanPham,
                            MaSanPham = sp.MaSanPham,
                            HinhSanPham = sp.HinhSanPham
                        });
                    }
                }
               
            }

            return thongTinDonHang;
        }
        [HttpPost("ThemDonHangMoi")]
        public bool ThemDonHang(DonhangModel.Input.ThongTinDonHang donHang)
        {
            try
            {
                Donhang donhangthemmoi= new();
                Utilities.PropertyCopier<DonhangModel.DonhangBase, Donhang>.Copy(donHang, donhangthemmoi);
                _idonhangService.Them(donhangthemmoi);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        [HttpPost("CapNhatDonHang")]
        public bool CapNhatDonHang(DonhangModel.Input.ThongTinDonHang donHang)
        {
            try
            {
                var dhcapnhat = _idonhangService.DocThongTinDonHang(donHang.Id);
                if (dhcapnhat != null)
                {
                    Utilities.PropertyCopier<DonhangModel.DonhangBase, Donhang>.Copy(donHang, dhcapnhat);
                    _idonhangService.Sua(dhcapnhat);
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        [HttpPost("XoaDH")]
        public bool XoaDonhang(DonhangModel.Input.XoaDonHang input)
        {
            try
            {
                var dh= _idonhangService.DocThongTinDonHang(input.Id);
                if (dh== null) return false;
                var kq = _idonhangService.Xoa(dh);
                return kq;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
