using API_QLShop.Auth;
using API_QLShop.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_QLShop.Auth;
using API_QLShop.Common;
using API_QLShop.DTO;
using Service.IServices;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTfulAPI_QLShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {        
            private readonly IKhachHangService _iKhachhangService;
            private readonly IJwtAuthManager _jwtAuthManager;
            public KhachHangController(IKhachHangService iKhachhangService, JwtAuthManager jwtAuthManager)
            {
                _iKhachhangService = iKhachhangService;
                _jwtAuthManager = jwtAuthManager;
            }
            [HttpPost("DangNhap")]
            public KhachhangModel.Output.ThongTinThanhVien DangNhap(KhachhangModel.Input.ThongTinDangNhap input)
            {
                KhachhangModel.Output.ThongTinThanhVien thongTinNhanVien = new();
                var Khach = _iKhachhangService.DangNhap(input.TenDangNhap, input.Matkhau);
                if (Khach != null && Khach.Idkhachhang>0)
                {
                    Utilities.PropertyCopier<Khachhang, KhachhangModel.Output.ThongTinThanhVien>.Copy(Khach, thongTinNhanVien);
                var userInfo = new UserInfo
                {
                    Id = Khach.Idkhachhang,
                    Email = Khach.Email,
                    HoTen = Khach.HoTenKh,
                    Username = Khach.Email,
                    UserAgent = HttpContext.Request.Headers["User-Agent"].ToString()

                    };
                    thongTinNhanVien.AccesToken = _jwtAuthManager.CreateToken(userInfo);
                }
                return thongTinNhanVien;
            }
            [HttpPost("DangNhapAnDanh")]
        public KhachhangModel.Output.ThongTinThanhVien DangNhapAnDanh()
        {
            var khinfo = new UserInfo()
            {
                Id = 0,
                Email = "",
                HoTen = "",
                Username = Guid.NewGuid().ToString(),
                UserAgent = HttpContext.Request.Headers["User-Agent"].ToString()
            };
            KhachhangModel.Output.ThongTinThanhVien thongtinThanhVien = new()
            {
                Idkhachhang = 0,
                Email = "",
                Sdt = "",
                HoTenKh = "Anonymous",
                Kichhoat = true,
                Password = "",
                Ngaysinh = DateTime.Today.Date,
                DiaChi = "",
                Ngaytao = DateTime.Today.Date,
                ThanhPho = "TPCHM",
                ThongTin ="",
                
                AccesToken = _jwtAuthManager.CreateToken(khinfo)

            };
            return thongtinThanhVien;


        }

        [Authorize]
            [HttpPost("DangXuat")]
            public bool Logout(KhachhangModel.Input.ThongTinDangNhap input)
            {
                try
                {
                    _jwtAuthManager.RemoveTokenByUserName(input.TenDangNhap);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

            }
        [HttpPost("DangKyKhachHang")]
        public ThongBaoModel DangKyKhachHang(KhachhangModel.Input.ThongTinThanhVienMoi thanh_vien)
        {
            ThongBaoModel tb = new ThongBaoModel { Maso= 1 };
            try
            {
                var chuoiTB = "";
                if (string.IsNullOrEmpty(thanh_vien.Email))
                    chuoiTB = "Email phải khác rỗng";
                else
                {
                    var thanhvien = _iKhachhangService.TimKhachHang(thanh_vien.Email);
                    if (thanhvien != null)
                        chuoiTB = "Email này đã được sử dụng rồi.";
                }
                if (string.IsNullOrEmpty(thanh_vien.HoTenKh))
                    chuoiTB = "Họ tên phải khác rỗng";
                if (string.IsNullOrEmpty(thanh_vien.Sdt))
                    chuoiTB = "Điện thoại phải khác rỗng";
                if (string.IsNullOrEmpty(chuoiTB))
                {
                    var thanh_vien_moi = new Khachhang();
                    Utilities.PropertyCopier<KhachhangModel.Input.ThongTinThanhVienMoi, Khachhang>.Copy(thanh_vien, thanh_vien_moi);
                    var tb_ = _iKhachhangService.DangKyKhachHang(thanh_vien_moi);
                    tb.Maso = tb_.MaSo;
                    chuoiTB = tb_.NoiDung;
                }
                tb.Noidung = chuoiTB;
            }
            catch (Exception ex)
            {
                tb.Noidung = "Lỗi: " + ex.Message;
            }
            return tb;
        }

        [HttpPost("ThemKhachHang")]
        public ThongBaoModel ThemThanhVien(KhachhangModel.Input.ThongTinThanhVienMoi thanh_vien_moi)
        {
            ThongBaoModel tb = new ThongBaoModel();
            Khachhang thanh_vien = new();
            Utilities.PropertyCopier<KhachhangModel.Input.ThongTinThanhVienMoi, Khachhang>.Copy(thanh_vien_moi, thanh_vien);
            var tb_ = _iKhachhangService.ThemKhachHang(thanh_vien);
            tb.Maso = tb_.MaSo;
            tb.Noidung = tb_.NoiDung;

            return tb;
        }
        [HttpPost("ThayDoiMatKhau")]
            public ThongBaoModel ThayDoiMatKhau(KhachhangModel.Input.ThongTinThayDoiMatKhau nhan_vien)
            {
                ThongBaoModel tb = new ThongBaoModel();
                var tb_ = _iKhachhangService.ThayDoiMatKhau(nhan_vien.Id, nhan_vien.UserName, nhan_vien.Matkhaucu, nhan_vien.Matkhaumoi);
                tb.Maso = tb_.MaSo;
                tb.Noidung = tb_.NoiDung;
                return tb;
            }
        [HttpPost("ThongTinKhachHang")]
        public KhachhangModel.Output.ThongTinThanhVien ThongTinKhach(KhachhangModel.Input.ThongTinThanhVien thong_tin)
        {
            
            var khach_hang = _iKhachhangService.DocThongTinKhachHang(thong_tin.Id);
            var khach_hang_1 = new KhachhangModel.Output.ThongTinThanhVien();
            Utilities.PropertyCopier<Khachhang, KhachhangModel.Output.ThongTinThanhVien>.Copy(khach_hang, khach_hang_1); 

           
            return khach_hang_1;
        }
        [HttpPost("KichHoatTaiKhoan")]
        public ThongBaoModel KichHoatTaiKhoan(KhachhangModel.Input.KichHoatTaiKhoan input)
        {
            ThongBaoModel tb = new ThongBaoModel();
            var tb_ = _iKhachhangService.KichHoatTaiKhoan(input.Email);
            tb.Maso = tb_.MaSo;
            tb.Noidung = tb_.NoiDung;
            return tb;
        }

    }
    

        
    
}
