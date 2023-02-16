using API_QLShop.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_QLShop.Auth;
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
    public class UserController : ControllerBase
    {
        private readonly IUserService _iUserService;
        private readonly IJwtAuthManager _jwtAuthManager;
        public UserController(IUserService iUserService, JwtAuthManager jwtAuthManager)
        {
            _iUserService = iUserService;
            _jwtAuthManager = jwtAuthManager;
        }
        [HttpPost("DangNhap")]
        public UserModel.Output.ThongTinThanhVien DangNhap(UserModel.Input.ThongTinDangNhap input)
        {
            UserModel.Output.ThongTinThanhVien thongTinNhanVien = new();
            var nhanvien = _iUserService.DangNhap(input.TenDangNhap, input.Matkhau);
            if (nhanvien != null)
            {
                Utilities.PropertyCopier<User, UserModel.Output.ThongTinThanhVien>.Copy(nhanvien, thongTinNhanVien);
                var userInfo = new UserInfo
                {
                    Id = nhanvien.Id,
                    Email = "",
                    HoTen = nhanvien.Ten + nhanvien.TenLot,
                    Username = nhanvien.Email,
                    UserAgent = HttpContext.Request.Headers["User-Agent"].ToString()
                };
                thongTinNhanVien.AccesToken = _jwtAuthManager.CreateToken(userInfo);
            }
            return thongTinNhanVien;
        }
        [HttpPost("DanhSachNhanVien")]
        public List<UserModel.Output.ThongTinThanhVien> DanhSachNhanVien(UserModel.Input.DanhSachNhanVien input)
        {
            var dsnhanvien = new List<UserModel.Output.ThongTinThanhVien>();
            if (input.QuanTri)
                dsnhanvien = _iUserService.DocDanhSach()
                                              .Select(x => new UserModel.Output.ThongTinThanhVien
                                              {
                                                  Id = x.Id,
                                                  Ten = x.Ten,
                                                  TenLot = x.TenLot,
                                                  Diachi = x.Diachi,
                                                  SoDienThoai = x.SoDienThoai,
                                                  Email = x.Email,
                                                  ThanhPho = x.ThanhPho,
                                                  Password = x.Password,
                                                  QuyenHan = x.QuyenHan,
                                                  DoanhThu = x.DoanhThu,
                                                  KichHoat = x.KichHoat,


                                              }).ToList();
            return dsnhanvien;
        }
        [HttpPost("ThayDoiMatKhau")]
        public ThongBaoModel ThayDoiMatKhau(UserModel.Input.ThongTinThayDoiMatKhau nhan_vien)
        {
            ThongBaoModel tb = new ThongBaoModel();
            var tb_ = _iUserService.ThayDoiMatKhau(nhan_vien.Id, nhan_vien.UserName, nhan_vien.Matkhaucu, nhan_vien.Matkhaumoi);
            tb.Maso = tb_.MaSo;
            tb.Noidung = tb_.NoiDung;
            return tb;
        }
        [HttpPost("ThongTinUser")]
        public UserModel.Output.ThongTinThanhVien ThongTinThanhVien(UserModel.Input.ThongTinThanhVien input)
        {
            var thanh_vien = _iUserService.DocThongTinThanhVien(input.Id);
            var thanh_vien_ = new UserModel.Output.ThongTinThanhVien();
            Utilities.PropertyCopier<User, UserModel.Output.ThongTinThanhVien>.Copy(thanh_vien, thanh_vien_);
            return thanh_vien_;
        }
        [HttpPost("ThemNhanVien")]
        public ThongBaoModel ThemThanhVien(UserModel.Input.ThongTinThanhVienMoi thanh_vien_moi)
        {
            ThongBaoModel tb = new ThongBaoModel();
            User thanh_vien = new();
            Utilities.PropertyCopier<UserModel.Input.ThongTinThanhVienMoi, User>.Copy(thanh_vien_moi, thanh_vien);
            var tb_ = _iUserService.ThemThanhVien(thanh_vien);
            tb.Maso = tb_.MaSo;
            tb.Noidung = tb_.NoiDung;

            return tb;
        }
        [HttpPost("KichHoatTaiKhoan")]
        public ThongBaoModel KichHoatTaiKhoan(UserModel.Input.KichHoatTaiKhoan input)
        {
            ThongBaoModel tb = new ThongBaoModel();
            var tb_ = _iUserService.KichHoatTaiKhoan(input.Email);
            tb.Maso = tb_.MaSo;
            tb.Noidung = tb_.NoiDung;

            return tb;
        }

        [Authorize]
        [HttpPost("DangXuat")]
        public bool Logout(UserModel.Input.ThongTinDangNhap input)
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

    }
}
