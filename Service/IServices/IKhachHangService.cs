using Service.Base;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IKhachHangService :IBaseRepository<Khachhang>
    {
        ThongTinKhachHang DangNhap(string Email, string Matkhau);
        ThongBao DangKyKhachHang(Khachhang Khach_moi);
        List<Khachhang> DocDanhSachKhachHang();
        Khachhang TimKhachHang(string Email);
        ThongBao ThayDoiMatKhau(int Id, string Email, string MatkhauCu, string MatkhauMoi);
        Khachhang DocThongTinKhachHang(int Id);
        ThongBao ThemKhachHang(Khachhang Khach_hang_moi);
        
        ThongBao KichHoatTaiKhoan(string email);
    }
}
