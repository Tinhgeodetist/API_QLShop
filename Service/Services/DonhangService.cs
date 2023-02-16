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
    public class DonhangService:Repository<Donhang>, IDonhangService
    {

        
        public DonhangService(QLShopContext context ):base(context) { }

        public bool CapNhatThongTinDonHang(Donhang DonHang)
        {
            return false;
        }
        public bool KiemTraDonHangHopLe(List<Donhang> dsDonHang)
        {
            try
            {
                if (dsDonHang.Count == 0) return false;
                foreach (var donmua in dsDonHang)
                {
                    var don = DocTheoDieuKien(x => x.TinhTrangDonHang.Equals(1) || x.DiaChi.Equals(donmua.DiaChi) || x.KhachHangId.Equals(donmua.KhachHangId) || x.TinhTrangDonHang.Equals(2)).FirstOrDefault();
                    if (don != null)
                    {
                        return false;

                    }

                }
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }
        public bool MuaDonHang(List<Donhang> dsDon)
        {
            try
            {
                if (KiemTraDonHangHopLe(dsDon))
                {
                    _context.Donhangs.AddRange(dsDon);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception )
            {
                return false;
            }
        }
        public List<Donhang> DocDanhSachDonHangTheoKhachHang(int khachhangId)
        {
            var donhangs = _context.Loaihangs.ToList();
            List<Donhang> dsDonHangTheoKH = null;
            if (khachhangId > 0)
            {
                dsDonHangTheoKH = DocTheoDieuKien(x => x.KhachHangId.Equals(khachhangId), x => x.Ten).ToList();

            }
            else dsDonHangTheoKH = DocDanhSach().ToList();
           
            return dsDonHangTheoKH;
        }
        public List<Donhang> DocDanhSachDonHangTheoNgay(DateTime dateTime)
        {
            return DocTheoDieuKien(x => x.NgayTao.Equals(dateTime), x => x.KhachHang).ToList();

        }
        

        public Donhang DocThongTinDonHang(int id)
        {
            return DocTheoDieuKien(x => x.Id.Equals(id), x => x.KhachHang).FirstOrDefault();
        }

      
    }
}
