using Service.IServices;
using Service.Models;
using Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService:Repository<User>,IUserService
    {
        public UserService(QLShopContext context) : base(context) { }
        public ThongTinUser DangNhap(string TenDangNhap, string Matkhau)
        {
            ThongTinUser thongTinUser = new();
            if (!string.IsNullOrEmpty(TenDangNhap) && !string.IsNullOrEmpty(Matkhau))
            {
                try
                {
                    var user_ = DocTheoDieuKien(x => x.Email.Equals(TenDangNhap)
                                    && x.Password.Equals(Matkhau)).FirstOrDefault();
                    if (user_ != null)
                    {
                        thongTinUser = new ThongTinUser
                        {
                            Id = user_.Id,
                            Ten = user_.Ten,
                            TenLot = user_.TenLot,
                            NgayTao = user_.NgayTao,
                            Email = user_.Email,
                            SoDienThoai = user_.SoDienThoai,
                            ThanhPho = user_.ThanhPho,
                            Password = user_.Password,
                            ThongTin = user_.ThongTin
                        };

                    }
                    else
                    {
                        thongTinUser.ThongBao = "Tên đăng nhập không hợp lệ";
                    }
                }
                catch (Exception ex)
                {
                    thongTinUser.ThongBao = "Lỗi đăng nhập" + ex.Message;
                }
            }
            else
            {
                thongTinUser.ThongBao = "Tên đăng nhập phải khác rỗng";
                
            }
            return thongTinUser;
        }
        
        public ThongBao DangKyNhanVien(User Nhan_vien_moi)
        {
            var tb = new ThongBao { MaSo = 1 };
            try
            {
                var user_ = base.Them(Nhan_vien_moi);
                if (Nhan_vien_moi != null)
                {
                    tb.MaSo = 0;
                    tb.NoiDung = Nhan_vien_moi.Id.ToString();
                }
                else
                    tb.NoiDung = "Lưu thông tin thành viên mới thành công";
            }
            catch(Exception ex)
            {
                tb.NoiDung = "Lỗi: " + ex.Message;
            }
            return tb;
        }
        public User TimNhanVien(string Email)
        {
            return DocTheoDieuKien(x => x.Equals(Email)).FirstOrDefault();
        }

        public ThongBao ThayDoiMatKhau(int Id, string Username, string MatkhauCu,string MatkhauMoi)
        {
            ThongBao tb = new ThongBao { MaSo = 1 };
            try
            {
                var thanhVienCapNhat = DocTheoDieuKien(p => p.Id.Equals(Id) && p.Email.Equals(Username)).FirstOrDefault();
                if(thanhVienCapNhat !=null)
                {
                    if (thanhVienCapNhat.Password == MatkhauCu)
                    {
                        thanhVienCapNhat.Password = MatkhauMoi;
                        if (base.Sua(thanhVienCapNhat))
                        {
                            tb.MaSo = 0;
                            tb.NoiDung = "Thay đổi mật khẩu thành công";

                        }
                        else
                            tb.NoiDung = "Mật khẩu cũ không đúng";

                    }
                    else
                        tb.NoiDung = "Mật khẩu cũ không đúng:";
                }

            }
            catch(Exception ex)
            {
                tb.NoiDung = "Lỗi " + ex.Message; 
            }
            return tb;
        }
        public User DocThongTinThanhVien(int Id)
        {
            User thongTinUser = new();
            if(Id >0)
            {
                try
                {
                    thongTinUser = DocTheoDieuKien(x => x.Id.Equals(Id)).FirstOrDefault();
                }
                catch(Exception)
                {

                }
            }
            return thongTinUser;
        }

        public ThongBao KichHoatTaiKhoan(string email)
        {
            ThongBao tb = new ThongBao { MaSo = 1 };
            try
            {
                var thanhVienCapNhat = DocTheoDieuKien(p => p.Email.Equals(email)).FirstOrDefault();
                if (thanhVienCapNhat != null)
                {
                    thanhVienCapNhat.KichHoat = true;
                    if (base.Sua(thanhVienCapNhat))
                    {
                        tb.MaSo = 0;
                        tb.NoiDung = "Kích hoạt tài khoản thành công";
                    }
                    else
                        tb.NoiDung = "Kích hoạt tài khoản không thành công";
                }
            }
            catch (Exception ex)
            {
                tb.NoiDung = "Lỗi: " + ex.Message;
            }
            return tb;
        }
        public ThongBao ThemThanhVien(User Thanh_vien_moi)
        {
            ThongBao tb = new ThongBao { MaSo = 1 };
            try
            {
                var chuoiTB = "";
                if (string.IsNullOrEmpty(Thanh_vien_moi.Email)) chuoiTB = "Email phải khác rỗng";
                else
                {
                    var thanhvien = DocDanhSach(x => x.Email.Equals(Thanh_vien_moi.Email)).FirstOrDefault();
                    if (thanhvien != null)
                        chuoiTB = "Email này đã được sử dụng";
                    
                }
                if (string.IsNullOrEmpty(Thanh_vien_moi.Ten))
                    chuoiTB = "Tên khác rỗng";
                if (string.IsNullOrEmpty(Thanh_vien_moi.TenLot))
                    chuoiTB = "Tên lót khác rỗng";
                if (string.IsNullOrEmpty(Thanh_vien_moi.SoDienThoai))
                    chuoiTB = "Số điện thoại";
                if(string.IsNullOrEmpty(chuoiTB))
                {
                    var thanh_vien = base.Them(Thanh_vien_moi);
                    if (thanh_vien != null)
                    {
                        tb.MaSo = 0;
                        chuoiTB = thanh_vien.Id.ToString();
                    }
                    else
                        chuoiTB = " Lưu thông tin thành viên mới không thành công";
                }
                tb.NoiDung = chuoiTB;
            }
            catch (Exception ex)
            {
                tb.NoiDung = "Lỗi " + ex.Message;
            }
            return tb;
        }
       
    }
}
