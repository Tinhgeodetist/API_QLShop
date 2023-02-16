using Service.Models;
using Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IDonhangService:IRepository<Donhang>
    {
        List<Donhang> DocDanhSachDonHangTheoKhachHang(int khachhangId);
        List<Donhang> DocDanhSachDonHangTheoNgay(DateTime ngay);       
        Donhang DocThongTinDonHang(int id);
        bool MuaDonHang(List<Donhang> dsDonhang);
        bool KiemTraDonHangHopLe(List<Donhang> dsDonHang);
        bool CapNhatThongTinDonHang(Donhang DonHang);

    }
}
