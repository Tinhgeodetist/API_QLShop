using Service.Models;
using Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IUserService: IRepository<User>
    {
        ThongTinUser DangNhap(string Email, string Matkhau);
        ThongBao DangKyNhanVien(User Nhan_vien_moi);
        User TimNhanVien(string Email);
        ThongBao ThayDoiMatKhau(int Id, string Email, string MatkhauCu,string MatkhauMoi);
        User DocThongTinThanhVien(int Id);
        ThongBao ThemThanhVien(User Nhan_vien_moi);
        ThongBao KichHoatTaiKhoan(string email);
        
    }
}
