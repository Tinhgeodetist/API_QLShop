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
    public class KhachhangService: Repository<Khachhang>, IKhachHangService
    {
        public KhachhangService(QLShopContext context) : base(context) { }
        public List<Khachhang> DocDanhSachKhachHang()
        {
            var dsKh = DocDanhSach().ToList();
            return dsKh;
        }
        public ThongTinKhachHang DangNhap(string TenDangNhap, string Matkhau)
        {
            ThongTinKhachHang thongTinKH = new();
            if (!string.IsNullOrEmpty(TenDangNhap) && !string.IsNullOrEmpty(Matkhau))
            {
                try
                {
                    var KH_ = DocTheoDieuKien(x => x.Email.Equals(TenDangNhap)
                                    && x.Password.Equals(Matkhau)).FirstOrDefault();
                    if (KH_ != null)
                    {
                        thongTinKH = new ThongTinKhachHang
                        {
                            Idkhachhang= KH_.Idkhachhang,
                            HoTenKh= KH_.HoTenKh,
                            Ngaytao = KH_.Ngaytao,
                            Ngaysinh = KH_.Ngaysinh,                            
                            Email = KH_.Email,
                            Sdt= KH_.Sdt,
                            ThanhPho = KH_.ThanhPho,
                            Password = KH_.Password,
                            ThongTin = KH_.ThongTin,
                            DiaChi= KH_.DiaChi,
                            DsIddonhang = KH_.DsIddonhang,
                            Kichhoat = KH_.Kichhoat
                        };

                    }
                    else
                    {
                        thongTinKH.ThongBao = "Tên đăng nhập không hợp lệ";
                    }
                }
                catch (Exception ex)
                {
                    thongTinKH.ThongBao = "Lỗi đăng nhập" + ex.Message;
                }
            }
            else
            {
                thongTinKH.ThongBao = "Tên đăng nhập phải khác rỗng";

            }
            return thongTinKH;
        }

        public ThongBao DangKyKhachHang(Khachhang KH_moi)
        {
            var tb = new ThongBao { MaSo = 1 };
            try
            {
                var KH_= base.Them(KH_moi);
                if (KH_moi != null)
                {
                    tb.MaSo = 0;
                    tb.NoiDung = KH_moi.Idkhachhang.ToString();
                }
                else
                    tb.NoiDung = "Lưu thông tin thành viên mới thành công";
            }
            catch (Exception ex)
            {
                tb.NoiDung = "Lỗi: " + ex.Message;
            }
            return tb;
        }
        public Khachhang TimKhachHang(string Email)
        {
            return DocTheoDieuKien(x => x.Equals(Email)).FirstOrDefault();
        }

        public ThongBao ThayDoiMatKhau(int Id, string Username, string MatkhauCu, string MatkhauMoi)
        {
            ThongBao tb = new ThongBao { MaSo = 1 };
            try
            {
                var thanhVienCapNhat = DocTheoDieuKien(p => p.Idkhachhang.Equals(Id) && p.Email.Equals(Username)).FirstOrDefault();
                if (thanhVienCapNhat != null)
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
            catch (Exception ex)
            {
                tb.NoiDung = "Lỗi " + ex.Message;
            }
            return tb;
        }
        
        public Khachhang DocThongTinKhachHang(int Id)
        {
            Khachhang thongTinKH= new();
            if (Id > 0)
            {
                try
                {
                    thongTinKH= DocTheoDieuKien(x => x.Idkhachhang.Equals(Id)).FirstOrDefault();
                }
                catch (Exception)
                {

                }
            }
            return thongTinKH;
        }
        

        public ThongBao KichHoatTaiKhoan(string email)
        {
            ThongBao tb = new ThongBao { MaSo = 1 };
            try
            {
                var thanhVienCapNhat = DocTheoDieuKien(p => p.Email.Equals(email)).FirstOrDefault();
                if (thanhVienCapNhat != null)
                {
                    thanhVienCapNhat.Kichhoat = true;
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
        public ThongBao ThemKhachHang(Khachhang Khang_hang_moi)
        {
            ThongBao tb = new ThongBao { MaSo = 1 };
            try
            {
                var chuoiTB = "";
                if (string.IsNullOrEmpty(Khang_hang_moi.Email)) chuoiTB = "Email phải khác rỗng";
                else
                {
                    var thanhvien = DocDanhSach(x => x.Email.Equals(Khang_hang_moi.Email)).FirstOrDefault();
                    if (thanhvien != null)
                        chuoiTB = "Email này đã được sử dụng";

                }
                if (string.IsNullOrEmpty(Khang_hang_moi.HoTenKh))
                    chuoiTB = "Tên khác rỗng";
                
                if (string.IsNullOrEmpty(Khang_hang_moi.Sdt))
                    chuoiTB = "Số điện thoại";
                if (string.IsNullOrEmpty(chuoiTB))
                {
                    var thanh_vien = base.Them(Khang_hang_moi);
                    if (thanh_vien != null)
                    {
                        tb.MaSo = 0;
                        chuoiTB = thanh_vien.Idkhachhang.ToString();
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
