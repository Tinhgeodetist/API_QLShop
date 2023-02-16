using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_QLShop.DTO
{
    public class SanPhamModel
    {
        public class SanPhamBase
        {
            public int Id { get; set; }
            public int? UserId { get; set; }
            public int ThuongHieuId { get; set; }
            public int LoaiHangId { get; set; }
            public int? KhuyenMaiId { get; set; }
            public string MaSanPham { get; set; }
            public string TenSanPham { get; set; }
            public int GiaSanPham { get; set; }
            public string HinhSanPham { get; set; }
            public DateTime NgayTao { get; set; }
            public DateTime NgayCapNhat { get; set; }
            public double GiamGia { get; set; }
            public int SoLuong { get; set; }
            public string ThongTin { get; set; }
            public bool? TrangThai { get; set; }
            public int Gia { get; set; }

        }
        public class Input
        {
            public class ThongTinSanPham : SanPhamBase
            {

            }

            public class DocThongTinSanPham
            {
                public int ID { set; get; }
            }
            public class XoaSanPham : DocThongTinSanPham { }
            public class TimThongTinSP
            {
                public string TuKhoa { get; set; }
                public int PageSize { get; set; }
                public int CurrentPage { get; set; }
            }
            public class SanPhamTheoLoaiHang
            {
                public int LoaihangId { get; set; }
                public int PageSize { get; set; }
                public int CurrentPage { get; set; }
            }
            public class SanPhamTheoThuongHieu
            {
                public int ThuongHieuID { get; set; }
                public int CurrentPage { get; set; }
                public int PageSize { get; set; }
            }
            public class SanPhamDangKhuyenMai
            { 
                
                public int CurrentPage { get; set; }
                public int PageSize { get; set; }
            }

        }

        public class Output
        {
            public class ThongTinSanPham : SanPhamBase
            {
               
                public ThuongHieuModel.ThuongHieuBase ThuongHieu { get; set; }
                public KhuyenmaiModel.KhuyenMaiBase KhuyenMai { get; set; }
                public LoaihangModel.LoaiHangBase LoaiHangSP { get; set; }
                // cần gì thêm vô
                public ThongTinSanPham()
                {
                    
                    ThuongHieu = new ThuongHieuModel.ThuongHieuBase();
                    KhuyenMai = new KhuyenmaiModel.KhuyenMaiBase();
                    LoaiHangSP = new LoaihangModel.LoaiHangBase();
                }
            }
            public class SanPhamLoaiHang
            {
                public LoaihangModel.LoaiHangBase LoaihangHienHanh { get; set; }
                public List<LoaihangModel.LoaiHangBase> DanhSachLoaiHang { get; set; }
                public List<SanPhamModel.Output.ThongTinSanPham> DanhSachSanPham { get; set; }
                public int CurrentPage { get; set; }
                public int PageCount { get; set; }
                public SanPhamLoaiHang()
                {
                    LoaihangHienHanh = new();
                    DanhSachSanPham = new();
                    DanhSachLoaiHang = new();
                }
                    
            }

            public class SanPhamThuongHieu
            {
                public ThuongHieuModel.ThuongHieuBase ThuongHieuHienHanh { get; set; }
                public List<ThuongHieuModel.ThuongHieuBase> DanhSachThuongHieu { get; set; }
                public List<SanPhamModel.Output.ThongTinSanPham> DanhSachSanPham { get; set; }
                public int CurrentPage { get; set; }
                public int PageCount { get; set; }
                public SanPhamThuongHieu()
                {
                    ThuongHieuHienHanh = new();
                    DanhSachSanPham = new();
                    DanhSachThuongHieu = new();
                }
            }
            public class SanPhamKhuyenMai
            {
                public KhuyenmaiModel.KhuyenMaiBase KhuyenMaiHienHanh{ get; set; }
                public List<KhuyenmaiModel.KhuyenMaiBase> DanhSachKhuyenMai{ get; set; }
                public List<SanPhamModel.Output.ThongTinSanPham> DanhSachSanPham { get; set; }
                public int CurrentPage { get; set; }
                public int PageCount { get; set; }
                public SanPhamKhuyenMai()
                {
                    KhuyenMaiHienHanh = new();
                    DanhSachSanPham = new();
                    DanhSachKhuyenMai = new();
                }
            }

            public class ThemSPMoi :SanPhamBase
            {
                public List <ThuongHieuModel.ThuongHieuBase> DanhSachThuongHieu { get; set; }
                public ChucnangModel.ChucnangBase Chucnang { get; set; }
                public List<LoaihangModel.LoaiHangBase> DanhSachLoaiHang { get; set; }
                public string ThongBao { get; set; }
                public ThemSPMoi()
                {
                    DanhSachThuongHieu = new List<ThuongHieuModel.ThuongHieuBase>();
                    DanhSachLoaiHang = new List<LoaihangModel.LoaiHangBase>();
                    Chucnang = new ChucnangModel.ChucnangBase();
                }

            }
            public class CapNhatSanPham:SanPhamBase
            {
                public List<ThuongHieuModel.ThuongHieuBase> DanhSachThuongHieu { get; set; }
                public ChucnangModel.ChucnangBase Chucnang { get; set; }
                public List<LoaihangModel.LoaiHangBase> DanhSachLoaiHang { get; set; }
                public string ThongBao { get; set; }
                public CapNhatSanPham()
                {
                    DanhSachThuongHieu = new List<ThuongHieuModel.ThuongHieuBase>();
                    DanhSachLoaiHang = new List<LoaihangModel.LoaiHangBase>();
                    Chucnang = new ChucnangModel.ChucnangBase();
                }
            }
        }
    }
}
