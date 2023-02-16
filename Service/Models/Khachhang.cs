using System;
using System.Collections.Generic;

#nullable disable

namespace Service.Models
{
    public partial class Khachhang
    {
        public int Idkhachhang { get; set; }
        public string HoTenKh { get; set; }
        public string Email { get; set; }
        public string Sdt { get; set; }
        public string DiaChi { get; set; }
        public string Password { get; set; }
        public string ThanhPho { get; set; }
        public string ThongTin { get; set; }
        public string DsIddonhang { get; set; }
        public bool Kichhoat { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public DateTime? Ngaytao { get; set; }
    }
}
