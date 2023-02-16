using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_QLShop.DTO
{
    public class UserModel
    {
        public class UserBase
        {
            public int Id { get; set; }
            public string Ten { get; set; }
            public string TenLot { get; set; }
            public string SoDienThoai { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public DateTime NgayTao { get; set; }
            public string ThongTin { get; set; }
            public string Diachi { get; set; }
            public string ThanhPho { get; set; }
            public bool KichHoat { get; set; }
            public string QuyenHan { get; set; }
            public int DoanhThu { get; set; }

        }
        public class Input
        {
            public class ThongTinThanhVienMoi : UserBase { }
            public class ThongTinThanhVien
            {
                public int Id { get; set; }
            }
            public class ThongTinThayDoiMatKhau
            {
                public int Id { get; set; }
                public string UserName { get; set; }
                public string Matkhaucu { get; set; }
                public string Matkhaumoi { get; set; }
            }
            public class ThongTinDangNhap
            {
                public string TenDangNhap { get; set; }
                public string Matkhau { get; set; }

            }
            public class KichHoatTaiKhoan
            {
                public string Email { get; set; }
            }
            public class DanhSachNhanVien
            {
                public bool QuanTri { get; set; }
            }
        }
        public class Output
        {
            public class ThongTinThanhVien :UserBase
            {
                public string AccesToken { get; set; }
                public string ThongBao { get; set; }
            }
        }

    }
}
