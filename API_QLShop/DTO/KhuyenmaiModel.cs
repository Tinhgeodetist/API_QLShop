using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_QLShop.DTO
{
    public class KhuyenmaiModel
    {
        public class KhuyenMaiBase
        {          
            public int Id { get; set; }
            public int LoaiHangId { get; set; }
            public DateTime NgayBatDau { get; set; }
            public DateTime NgayKetThuc { get; set; }
            public double PhanTramGiam { get; set; }
            public string QuaTangKem { get; set; }
            public string VoucherTangKem { get; set; }
            
        }
        public class Input
        {
            public class ThongTinKhuyenMai : KhuyenMaiBase { }
            public class DocThongTinKhuyenMai
            {
                public int Id { get; set; }
            }
            public class DanhSachKhuyenMaiDangCo
            {
                public DateTime Ngaydienra { get; set; }
            }

            public class DanhSachKhuyenMaiTheoLoaiHang
            {
                public int LoaihangId { get; set; }
            }

            public class XoaKhuyenMai
            {
                public int Id { get; set; }
            }
        }
        public class Output
        {
            public class ThongTinKhuyenMai : KhuyenMaiBase
            {
                public LoaihangModel.LoaiHangBase LoaiHang { get; set; }
               
                public string ThongBao { get; set; }
            }
        }
    }
}
