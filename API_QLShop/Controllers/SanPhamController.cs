using API_QLShop.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_QLShop.Common;
using Service.IServices;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_CSC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private ISanPhamService _iSanPhamService;
        private ILoaihangService _iLoaihangService;
        private IThuonghieuService _iThuonghieuService;
        private  IKhuyenmaiService _iKhuyenmaiService;
        private IChucnangService _iChucnangService;
        public SanPhamController(ISanPhamService isanPhamService, ILoaihangService iloaihangService,IThuonghieuService ithuonghieuService, IChucnangService ichucnangService)

        {
            
            _iSanPhamService = isanPhamService;
            _iLoaihangService = iloaihangService;
            _iThuonghieuService = ithuonghieuService;
            _iChucnangService = ichucnangService;
        }
        [HttpPost("DanhSachSanPhamTheoLoaiHang")]
        public SanPhamModel.Output.SanPhamLoaiHang DanhSachSanPhamTheoLoaiHang(SanPhamModel.Input.SanPhamTheoLoaiHang input)
        {
            var result = new SanPhamModel.Output.SanPhamLoaiHang();
            var dsSPTheoLoaiHang = _iSanPhamService.DocDanhSachSanPhamTheoLoaiHang(input.LoaihangId, input.CurrentPage, input.PageSize);
            if (input.PageSize <= 0)
                input.PageSize = 20;
            float numberpage = (float)dsSPTheoLoaiHang.Count() / input.PageSize;
            int pageCount = (int)Math.Ceiling(numberpage);
            int currentPage = input.CurrentPage;

            if (currentPage > pageCount) currentPage = pageCount;
            var dsSP = dsSPTheoLoaiHang.Select(x => new SanPhamModel.Output.ThongTinSanPham()
            {
                TenSanPham = x.TenSanPham,
                Id = x.Id,
                Gia = x.Gia,
                GiamGia = x.GiamGia,
                GiaSanPham = x.GiaSanPham,
                HinhSanPham = x.HinhSanPham,
                KhuyenMaiId = x.KhuyenMaiId,
                KhuyenMai = new KhuyenmaiModel.KhuyenMaiBase
                {
                    Id = x.KhuyenMai.Id,
                    NgayBatDau = x.KhuyenMai.NgayBatDau,
                    NgayKetThuc = x.KhuyenMai.NgayKetThuc,
                    PhanTramGiam = x.KhuyenMai.PhanTramGiam,
                    QuaTangKem = x.KhuyenMai.QuaTangKem,
                    VoucherTangKem = x.KhuyenMai.VoucherTangKem
                },
                LoaiHangId = x.LoaiHangId,
                  MaSanPham = x.MaSanPham,
                NgayCapNhat = x.NgayCapNhat,
                NgayTao = x.NgayTao,
                SoLuong = x.SoLuong,
                ThongTin = x.ThongTin,
                ThuongHieuId = x.ThuongHieuId,
                ThuongHieu = new ThuongHieuModel.ThuongHieuBase
                {
                    Id = x.ThuongHieu.Id,
                    TenThuongHieu = x.ThuongHieu.TenThuongHieu
                },
                TrangThai = x.TrangThai,
                UserId = x.UserId,

            }).ToList();
            var dsLoaiHang = _iLoaihangService.DocDanhSachLoaiHang();
            if (input.LoaihangId != 0)
            {
                var lh = dsLoaiHang.FirstOrDefault(x => x.Id.Equals(input.LoaihangId));
                result.LoaihangHienHanh = new LoaihangModel.LoaiHangBase()
                {
                    Id= input.LoaihangId,
                    Ten = lh.TenLoaiHang
                };
            }
            result.DanhSachSanPham = dsSP;
            result.CurrentPage = input.CurrentPage;
            result.PageCount = pageCount;
            result.DanhSachLoaiHang = dsLoaiHang.Select(t => new LoaihangModel.LoaiHangBase { Id = t.Id, Ten = t.TenLoaiHang }).ToList();
            return result;

        }

        [HttpPost("DanhSachSanPhamTheoThuongHieu")]
        public SanPhamModel.Output.SanPhamThuongHieu DanhSachSanPhamTheoThuongHieu(SanPhamModel.Input.SanPhamTheoThuongHieu input)
        {
            var model = new SanPhamModel.Output.SanPhamThuongHieu();
            var dsSPTheoTH = _iSanPhamService.DocDanhSachSanPhamTheoThuongHieu(input.ThuongHieuID, input.CurrentPage, input.PageSize);
            if (input.PageSize <= 0)
                input.PageSize = 20;
            float numberpage = (float)dsSPTheoTH.Count() / input.PageSize;
            int pageCount = (int)Math.Ceiling(numberpage);

            int currentPage = input.CurrentPage;
            if (currentPage > pageCount) currentPage = pageCount;            
            var dsSP = dsSPTheoTH.Select(x=> new SanPhamModel.Output.ThongTinSanPham

            {
                TenSanPham = x.TenSanPham,
                Id = x.Id,
                Gia = x.Gia,
                GiamGia= x.GiamGia,
                GiaSanPham = x.GiaSanPham,
                HinhSanPham = x.HinhSanPham,
                KhuyenMaiId = x.KhuyenMaiId,
                KhuyenMai = new KhuyenmaiModel.KhuyenMaiBase
                {
                    Id = x.KhuyenMai.Id,
                    NgayBatDau = x.KhuyenMai.NgayBatDau,
                    NgayKetThuc = x.KhuyenMai.NgayKetThuc,
                    PhanTramGiam = x.KhuyenMai.PhanTramGiam,
                    QuaTangKem = x.KhuyenMai.QuaTangKem,
                    VoucherTangKem = x.KhuyenMai.VoucherTangKem                    
                },
                LoaiHangId = x.LoaiHangId,
                 //Không làm được list tên loại hàng??????
                MaSanPham = x.MaSanPham,
                NgayCapNhat = x.NgayCapNhat,
                NgayTao = x.NgayTao,
                SoLuong = x.SoLuong,
                ThongTin = x.ThongTin,
                ThuongHieuId = x.ThuongHieuId,
                ThuongHieu = new ThuongHieuModel.ThuongHieuBase
                {
                    Id = x.ThuongHieu.Id,
                    TenThuongHieu = x.ThuongHieu.TenThuongHieu
                },
                TrangThai = x.TrangThai,
                UserId = x.UserId,
                
            }).ToList();
            var dsThuongHieu = _iThuonghieuService.DocDanhSachThuonghieu();
            foreach(var sp in dsSP)
            {
                int idTH = sp.ThuongHieuId;
                var thuonghieu_SP = dsSP.Where(x => idTH.Equals(x.ThuongHieuId)).ToList();
                
            }
            if (input.ThuongHieuID != 0)
            {
                var th = dsThuongHieu.FirstOrDefault(x => x.Id.Equals(input.ThuongHieuID));
                model.ThuongHieuHienHanh= new ThuongHieuModel.ThuongHieuBase
                {
                    Id=input.ThuongHieuID,
                    TenThuongHieu = th.TenThuongHieu,
                };
            }
            model.DanhSachSanPham = dsSP;
            model.CurrentPage = input.CurrentPage;
            model.PageCount = pageCount;
            model.DanhSachThuongHieu = dsThuongHieu.Select(t => new ThuongHieuModel.ThuongHieuBase { Id = t.Id, TenThuongHieu = t.TenThuongHieu }).ToList();
            return model;

        }
        [HttpPost("DanhSachSanPhamCoKhuyenMai")]
        public SanPhamModel.Output.SanPhamKhuyenMai DanhSachSanPhamDangKhuyenMai(SanPhamModel.Input.SanPhamDangKhuyenMai input)
        {
            var result = new SanPhamModel.Output.SanPhamKhuyenMai();
            var dsSPDangKM = _iSanPhamService.DocDanhSachSanPhamCoKhuyenMai(input.CurrentPage,input.PageSize);
            
            if (input.PageSize <= 0)
                input.PageSize = 20;
            float numberpage = (float)dsSPDangKM.Count() / input.PageSize;
            int pageCount = (int)Math.Ceiling(numberpage);

            int currentPage = input.CurrentPage;
            if (currentPage > pageCount) currentPage = pageCount;
            var dsSP = dsSPDangKM.Select(x => new SanPhamModel.Output.ThongTinSanPham

            {
                TenSanPham = x.TenSanPham,
                Id = x.Id,
                Gia = x.Gia,
                GiamGia = x.GiamGia,
                GiaSanPham = x.GiaSanPham,
                HinhSanPham = x.HinhSanPham,
                KhuyenMaiId = x.KhuyenMaiId,
                KhuyenMai = new KhuyenmaiModel.KhuyenMaiBase
                {
                    Id = x.KhuyenMai.Id,
                    NgayBatDau = x.KhuyenMai.NgayBatDau,
                    NgayKetThuc = x.KhuyenMai.NgayKetThuc,
                    PhanTramGiam = x.KhuyenMai.PhanTramGiam,
                    QuaTangKem = x.KhuyenMai.QuaTangKem,
                    VoucherTangKem = x.KhuyenMai.VoucherTangKem
                },
                LoaiHangId = x.LoaiHangId,
                
                MaSanPham = x.MaSanPham,
                NgayCapNhat = x.NgayCapNhat,
                NgayTao = x.NgayTao,
                SoLuong = x.SoLuong,
                ThongTin = x.ThongTin,
                ThuongHieuId = x.ThuongHieuId,
                ThuongHieu = new ThuongHieuModel.ThuongHieuBase
                {
                    Id = x.ThuongHieu.Id,
                    TenThuongHieu = x.ThuongHieu.TenThuongHieu
                },
                TrangThai = x.TrangThai,
                UserId = x.UserId,

            }).ToList();
            
            result.DanhSachSanPham = dsSP;
            result.CurrentPage = input.CurrentPage;
            result.PageCount = pageCount;
            result.DanhSachKhuyenMai= dsSPDangKM.Select(t => new KhuyenmaiModel.KhuyenMaiBase{ Id = t.Id,PhanTramGiam = t.GiamGia }).ToList();
            return result;

        }

        [HttpPost("ThongTinSP")]
        public SanPhamModel.Output.ThongTinSanPham THongTinSanPham(SanPhamModel.Input.DocThongTinSanPham input)
        {
            SanPhamModel.Output.ThongTinSanPham thongTinSanPham = new SanPhamModel.Output.ThongTinSanPham();
            var SP = _iSanPhamService.DocThongTinSanPham(input.ID);
            if (SP != null && SP.Id > 0)
            {
                thongTinSanPham = new();
                Utilities.PropertyCopier<Service.Models.Sanpham, SanPhamModel.Output.ThongTinSanPham>.Copy(SP, thongTinSanPham);
                thongTinSanPham.Id = SP.Id;
                thongTinSanPham.ThuongHieu = new ThuongHieuModel.ThuongHieuBase()
                {
                    Id = SP.ThuongHieu.Id,
                    TenThuongHieu = SP.ThuongHieu.TenThuongHieu,
                };
                thongTinSanPham.KhuyenMai = new KhuyenmaiModel.KhuyenMaiBase()
                {
                    Id = SP.KhuyenMai.Id,
                    NgayBatDau = SP .KhuyenMai.NgayBatDau,
                    NgayKetThuc = SP.KhuyenMai.NgayKetThuc,
                    PhanTramGiam = SP.KhuyenMai.PhanTramGiam,
                    QuaTangKem = SP.KhuyenMai.QuaTangKem,
                    VoucherTangKem = SP.KhuyenMai.VoucherTangKem
                };
                var dsLoaiHang = _iLoaihangService.DocDanhSach();
                
            }
            return thongTinSanPham;
        }
        [HttpPost("ThemSPMoi")]
        public bool ThemSPMoi(SanPhamModel.Input.ThongTinSanPham sanPham)
        {
            try
            {
                Sanpham spThemMoi = new();
                Utilities.PropertyCopier<SanPhamModel.SanPhamBase, Sanpham>.Copy(sanPham, spThemMoi);
                _iSanPhamService.Them(spThemMoi);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        [HttpPost("CapNhatSP")]
        public bool CapNhatSP(SanPhamModel.Input.ThongTinSanPham sanpham)
        {
            try
            {
                var spCapNhat = _iSanPhamService.DocThongTinSanPham(sanpham.Id);
                if (spCapNhat != null)
                {
                    Utilities.PropertyCopier<SanPhamModel.SanPhamBase, Sanpham>.Copy(sanpham, spCapNhat);
                    return _iSanPhamService.Sua(spCapNhat);

                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        [HttpPost("XoaSP")]
        public bool XoaSP(SanPhamModel.Input.XoaSanPham input)
        {
            try
            {
                var SP = _iSanPhamService.DocThongTinSanPham(input.ID);
                if (SP == null) return false;
                var kq = _iSanPhamService.Xoa(SP);
                return kq;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
