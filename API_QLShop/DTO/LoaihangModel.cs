using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_QLShop.DTO
{
    public class LoaihangModel
    {
        public class LoaiHangBase
        {
            public int Id { get; set; }
            public string Ten { get; set; }
        }
        public class Input 
        {
            public class DocThongTinLoaiHang
            {
                public int Id { get; set; }
            }
            public class ThongTinLoaiHang : LoaiHangBase { }
        }
        public class Output
        {
            public class ThongTinLoaiHang :LoaiHangBase
            {
                public List<SanPhamModel.SanPhamBase> DanhSachSanPham { get; set; }
                public ThongTinLoaiHang()
                {
                    DanhSachSanPham = new List<SanPhamModel.SanPhamBase>();
                }

            }
        }
    }
}
