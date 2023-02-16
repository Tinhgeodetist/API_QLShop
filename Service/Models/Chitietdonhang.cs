using System;
using System.Collections.Generic;

#nullable disable

namespace Service.Models
{
    public partial class Chitietdonhang
    {
        public int Id { get; set; }
        public int DonHangId { get; set; }
        public int? SanPhamId { get; set; }
        public int? UserId { get; set; }
        public string SoDienThoai { get; set; }
        public bool TinhTrangDonHang { get; set; }
        public string Diachi { get; set; }
        public double? PhiShip { get; set; }
        public double? TongTien { get; set; }

        public virtual Donhang DonHang { get; set; }
        public virtual Sanpham SanPham { get; set; }
    }
}
