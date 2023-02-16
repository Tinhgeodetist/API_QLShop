
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_QLShop.DTO
{
    public class DonhangModel
    {
        public  class DonhangBase
        {
            public int Id { get; set; }
            public int KhachHangId { get; set; }
            public bool TinhTrangDonHang { get; set; }
            public double? GiamGia { get; set; }
            public double? PhiShip { get; set; }
            public double? TongTien { get; set; }
            public string MaGiamGia { get; set; }
            public string Ten { get; set; }
            public string SoDienThoai { get; set; }
            public string Email { get; set; }
            public string DiaChi { get; set; }
            public DateTime NgayTao { get; set; }
            public DateTime NgayCapNhat { get; set; }
            public string NoiDung { get; set; }
            public string DsSanPhamId { get; set; }

        }
        public class Input 
        {
            public class ThongTinDonHang : DonhangBase { }
            public class DocThongTinDonHang
            {
                public int Id { get; set; }
            }

            public class TimThongTinDonHang
            {
                public string KhachHangId { get; set; }
                public int PageSize { get; set; }
                public int CurrentPage { get; set; }
            }
            public class DocDanhSachDonHangTheoKh
            {
                public int KhachHangId { get; set; }
                public int PageSize { get; set; }
                public int CurrentPage { get; set; }
            }
            public class MuaDonHang
            {
                public List<ThongTinDonHang> DanhSachDonHang { get; set; }
                public MuaDonHang()
                {
                    DanhSachDonHang = new();
                }
            }
            public class ThemDonHang : DonhangBase
            {
                public List<ThuongHieuModel.ThuongHieuBase> DanhSachThuongHieu { get; set; }
                public List<LoaihangModel.LoaiHangBase> DanhSachLoaiHang { get; set; }
                public KhachhangModel.KhachhangBase KhachHang { get; set; }
                public string ThongBao { get; set; }
                public ThemDonHang()
                {
                    DanhSachLoaiHang = new List<LoaihangModel.LoaiHangBase>();
                    DanhSachThuongHieu = new List<ThuongHieuModel.ThuongHieuBase>();
                    KhachHang = new KhachhangModel.KhachhangBase();
                }
            }

            public class XoaDonHang
            {
                public int Id { get; set; }
            }
        }
        public class Output
        {
            public class ThongTinDonHang:DonhangBase
            {
                public List<SanPhamModel.SanPhamBase> DanhSachsanpham{ get; set; }
                public KhachhangModel.KhachhangBase  Khachhang{ get; set; }
                public ThongTinDonHang()
                {
                   DanhSachsanpham= new List<SanPhamModel.SanPhamBase>();
                    Khachhang = new KhachhangModel.KhachhangBase();
                }
                

            }

            public class DonHangTheoKhachHang
            {
                public KhachhangModel.KhachhangBase KhachHangDangOnl { get; set; }
                public List<KhachhangModel.KhachhangBase> DanhSachKhacHang { get; set; }
                public List<Donhang> DanhSachDonHang { get; set; }
                public int CurrentPage { get; set; }
                public int PageCount { get; set; }
                public DonHangTheoKhachHang()
                {
                    KhachHangDangOnl = new KhachhangModel.KhachhangBase();
                    DanhSachDonHang = new List<Donhang>();
                    DanhSachKhacHang = new List<KhachhangModel.KhachhangBase>();

                }
            }
            public class DonHangTheoNgay
            {
              
                
                public List<Donhang> DanhSachDonHang { get; set; }
                public DateTime NgayDonHang { get; set; }
                
                public int CurrentPage { get; set; }
                public int PageCount { get; set; }
                public DonHangTheoNgay()
                {                
                    DanhSachDonHang = new List<Donhang>();
                  

                }
            }
            public class ThemDonHang : DonhangBase
            {
                
                public List<SanPhamModel.SanPhamBase> DanhSachSanPham { get; set; }
                
                public KhachhangModel.KhachhangBase KhachHang { get; set; }
                public string ThongBao { get; set; }
                public ThemDonHang()
                {
                    DanhSachSanPham = new List<SanPhamModel.SanPhamBase>();
                    KhachHang = new KhachhangModel.KhachhangBase();
                }
            }
            public class CapNhatDon : DonhangBase
            {

                public List<SanPhamModel.SanPhamBase> DanhSachSanPham { get; set; }

                public KhachhangModel.KhachhangBase KhachHang { get; set; }
                public string ThongBao { get; set; }
                public CapNhatDon()
                {
                    DanhSachSanPham = new List<SanPhamModel.SanPhamBase>();
                    KhachHang = new KhachhangModel.KhachhangBase();
                }
            }

        }
    }
}
