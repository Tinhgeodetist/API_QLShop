using Service.Models;
using Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface ISanPhamService : IRepository<Sanpham>
    {
        List<Sanpham> DocDanhSachSanPhamDangHot(bool hot = true);
        List<Sanpham> DocDanhSachSanPhamTheoLoaiHang(int LoaihangId,int currentPage, int pageSize = 20);
        List<Sanpham> DocDanhSachSanPhamTheoThuongHieu(int ThuonghieuId,int currentPage, int pageSize = 20);
        List<Sanpham> DocDanhSachSanPhamCoKhuyenMai(int currentPage, int PageSize = 20);
        List<Sanpham> DocDanhSachSanPham();
        Sanpham DocThongTinSanPham(int id);

    }
}
