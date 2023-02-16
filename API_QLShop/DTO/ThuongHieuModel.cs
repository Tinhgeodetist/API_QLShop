using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_QLShop.DTO
{
    public class ThuongHieuModel
    {
        public class ThuongHieuBase
        {
            public int Id { get; set; }
            public string Nuoc { get; set; }
            public string TenThuongHieu { get; set; }
        }
        public class Input { }
        public class Output
        {
            public class ThongTinThuongHieu : ThuongHieuBase
            {
                public List<SanPhamModel.SanPhamBase> DanhSachThuongHieu { get; set; }
                public ThongTinThuongHieu()
                {
                    DanhSachThuongHieu = new List<SanPhamModel.SanPhamBase>();
                }
            }
        }
    }
}
