using System;
using System.Collections.Generic;

#nullable disable

namespace Service.Models
{
    public partial class Hinh
    {
        public int HinhId { get; set; }
        public string Thumbnails { get; set; }
        public string Carousel { get; set; }
        public bool KichHoat { get; set; }
        public DateTime? NgayHetHan { get; set; }

        public virtual Sanpham HinhNavigation { get; set; }
    }
}
