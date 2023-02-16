using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_QLShop.DTO
{
    public class KhachhangModel
    {
        
            public class KhachhangBase
            {
            public int Idkhachhang { get; set; }
            public string HoTenKh { get; set; }
            public string Email { get; set; }
            public string Sdt { get; set; }
            public string DiaChi { get; set; }
            public string Password { get; set; }
            public string ThanhPho { get; set; }
            public string ThongTin { get; set; }
            public string DsIddonhang { get; set; }
            public bool Kichhoat { get; set; }
            public DateTime Ngaysinh { get; set; }
            public DateTime Ngaytao { get; set; }

        }
            public class Input
            {
                public class ThongTinThanhVienMoi : KhachhangBase { }
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
            }
            public class Output
            {
                public class ThongTinThanhVien : KhachhangBase
                {
                    public string AccesToken { get; set; }
                    public string ThongBao { get; set; }
                }
            }
        }
}
