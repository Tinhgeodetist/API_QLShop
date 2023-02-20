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
    public class LoaihangService : Repository<Loaihang>,ILoaihangService
    {
        public LoaihangService(QLShopContext context) : base(context) { }

        public  List<Loaihang> DocDanhSachLoaiHang()
        {
            var dsLoaihang = DocDanhSach().ToList();
            return dsLoaihang;
        }
        public Loaihang DocThongTinLoaiHang(int id)
        {
            var loaihang = DocTheoDieuKien(x=>x.Id.Equals(id)).FirstOrDefault();
            return loaihang;
        }
        public new bool Xoa(Loaihang entity)
        {
            try
            {
                
                var SP = _context.Sanphams
                                   .FirstOrDefault(x => x.LoaiHangId.Equals(entity.Id));
                if (SP != null) return false;
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
