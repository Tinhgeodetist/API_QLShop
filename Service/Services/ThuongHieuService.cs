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
        public Thuonghieu DocThongTinThuongHieu(int id)
        {
            var xepHang = DocTheoDieuKien(x => x.Id.Equals(id)).FirstOrDefault();
            return xepHang;
        }

        public new bool Xoa(Thuonghieu entity)
        {
            try
            {
                var phim = _context.Thuonghieus.FirstOrDefault(x => x.Id.Equals(entity.Id));
                if (phim != null) return false;
                base.Xoa(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
