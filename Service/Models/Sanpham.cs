using System;
using System.Collections.Generic;

#nullable disable

namespace Service.Models
{
    public partial class Sanpham
    {
        public Sanpham()
        {
            Chitietdonhangs = new HashSet<Chitietdonhang>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
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
        public bool KichHoat { get; set; }

        public virtual Khuyenmai KhuyenMai { get; set; }
        public virtual Thuonghieu ThuongHieu { get; set; }
        public virtual User User { get; set; }
        public virtual Hinh Hinh { get; set; }
        public virtual ICollection<Chitietdonhang> Chitietdonhangs { get; set; }
    }
}
