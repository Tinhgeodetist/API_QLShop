using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_QLShop.DTO
{
    public class HinhModel
    {
        public class HinhBase
        {
            public int HinhId { get; set; }
            public string Thumbnails { get; set; }
            public string Carousel { get; set; }
            public bool KichHoat { get; set; }
            public DateTime NgayHetHan { get; set; }

        }
        public class Input
        {
            public class ThongTinHinh: HinhBase { }
            public class DocDanhSachHinh
            {
                public bool QuanTri { get; set; }
            }
            public class DocThongTinHinh
            {
                public int Id { get; set; }
            }
            public class XoaHinh
            {
                public int Id { get; set; }
            }

        }
        public class Output
        {
            public class ThongTinHinh : HinhBase { }
        }
    }
}
