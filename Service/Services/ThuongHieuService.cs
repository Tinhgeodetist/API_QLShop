using Service.IServices;
using Service.Models;
using Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ThuongHieuService: Repository<Thuonghieu>,IThuonghieuService
    {
        public ThuongHieuService(QLShopContext context) : base(context) { }
        public List<Thuonghieu> DocDanhSachThuonghieu()
        {
            var dsThuongHieu = DocDanhSach().ToList();
            return dsThuongHieu;
        }
       
    }
}
