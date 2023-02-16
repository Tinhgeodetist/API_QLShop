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

    public class SanPhamService : Repository<Sanpham>, ISanPhamService
    {
        public SanPhamService(QLShopContext context) : base(context) { }

        public Sanpham DocThongTinSanPham(int id)
        {
            var model = _context.Sanphams.FirstOrDefault(x => x.Id.Equals(id));
            return model;
        }
        public List<Sanpham> DocDanhSachSanPham()
        {
            var dsSP = DocDanhSach().ToList();
            return dsSP;
        }
        public List<Sanpham> DocDanhSachSanPhamCoKhuyenMai( int currentPage, int PageSize = 20)
        {
            var dsSPDangKm = DocTheoDieuKien(x => x.KhuyenMaiId != null , x => x.ThuongHieu).ToList();
            return dsSPDangKm;
        }
        public List<Sanpham> DocDanhSachSanPhamDangHot(bool hot = true)
        {
            var dsSPDangHot = DocTheoDieuKien(x => x.TrangThai != null && x.TrangThai == hot, x => x.ThuongHieu).ToList();
            return dsSPDangHot;
        }
        public List<Sanpham> DocDanhSachSanPhamTheoLoaiHang(int loaiHangId, int CurrentPage ,int pageSize = 20)
        {
            var loaihangs = _context.Loaihangs.ToList();
            List<Sanpham> dsSPTheoLoaiHang = null;
            if(loaiHangId>0)
            {
                dsSPTheoLoaiHang = DocTheoDieuKien(x => x.LoaiHangId.Equals(loaiHangId), x => x.ThuongHieu).ToList();

            }
            else
            {
                dsSPTheoLoaiHang = DocDanhSach().ToList();
            }
            if (pageSize <= 0)
                pageSize = 20;
            float numberpage = (float)dsSPTheoLoaiHang.Count() / pageSize;
            int pageCount = (int)Math.Ceiling(numberpage);

            if (CurrentPage > pageCount) CurrentPage = pageCount;
            dsSPTheoLoaiHang = dsSPTheoLoaiHang.Skip((CurrentPage - 1) * pageSize).Take(pageSize).ToList();
            return dsSPTheoLoaiHang;
        }

        public List<Sanpham> DocDanhSachSanPhamTheoThuongHieu(int ThuonghieuId,int CurrentPage, int pageSize = 20)
        {
            var thuonghieus = _context.Thuonghieus.ToList();
            List<Sanpham> dsSPTheoThuongHieu = null;
            if (ThuonghieuId > 0)
            {
                dsSPTheoThuongHieu = DocTheoDieuKien(x => x.ThuongHieuId.Equals(ThuonghieuId)).ToList();

            }
            else
            {
                dsSPTheoThuongHieu = DocDanhSach().ToList();
            }
            if (pageSize <= 0)
                pageSize = 20;
            float numberpage = (float)dsSPTheoThuongHieu.Count() / pageSize;
            int pageCount = (int)Math.Ceiling(numberpage);

            if (CurrentPage > pageCount) CurrentPage = pageCount;
            dsSPTheoThuongHieu = dsSPTheoThuongHieu.Skip((CurrentPage - 1) * pageSize).Take(pageSize).ToList();
            return dsSPTheoThuongHieu;
        }
    }
}
