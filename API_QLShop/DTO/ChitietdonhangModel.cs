using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_QLShop.DTO
{
    public class ChitietdonhangModel
    {
        public class ChitietdonhangBase
        {
            public int Id { get; set; }
            public int DonHangId { get; set; }
            public int SanPhamId { get; set; }
            public int UserId { get; set; }
            public string SoDienThoai { get; set; }
            public short TinhTrangDonHang { get; set; }
            public string Diachi { get; set; }
            public double PhiShip { get; set; }
            public int KhuyenMaiId { get; set; }
            public string TenNguoiNhan { get; set; }
            public double TongTien { get; set; }

         
        }
        public class Intput
        {
            public class ThongTinChiTietDonHang : ChitietdonhangBase { }
            public class DocThongTinChiTietDonHang
            {
                public int Id { get; set; }
            }
            public class XoaChiTietDonHang
            {
                public int Id { get; set; }
            }

        }
        public class Output
        {
            public class ThongTinChiTietDonHang : ChitietdonhangBase
            {
                public DonhangModel.DonhangBase Donhang { get; set; }
                public string ThongBao { get; set; }
                
            }
        }
    }
}

