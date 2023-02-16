using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_QLShop.DTO
{
    public class ChucnangModel
    {
        public class ChucnangBase
        {
            public int SanPhamId { get; set; }
            public int LoaiHangId { get; set; }
            public string ThietKe { get; set; }
            public string BoXuLy { get; set; }
            public string ManHinh { get; set; }
            public string Vga { get; set; }
            public string BoNhoLuuTru { get; set; }
            public string BaoMat { get; set; }
            public string GiaoTiepKetNoi { get; set; }
            public string Camera { get; set; }
            public string Amthanh { get; set; }
            public string BaoHanhId { get; set; }
            public string Pin { get; set; }
            public string HeDieuHanh { get; set; }
        }
        public class Input
        {
            public class ThongTinChucNang : ChucnangBase { }
            public class DocThongTinChucNang
            {
                public int SanphamId { get; set; }
            }
            public class XoaChucNang
            {
                public int Id { get; set; }
            }
        }
        public class Output
        {
            public class ThongTinChucNang : ChucnangBase
            {
                public SanPhamModel.SanPhamBase SanPham { get; set; }
                public ChucnangBase ChucNang { get; set; }
                public ThongTinChucNang()
                {
                    SanPham = new();
                    ChucNang = new();
                }
            }
        }
    }
}
