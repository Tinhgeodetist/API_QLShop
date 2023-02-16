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
    public class ChucnangService : Repository<Chucnang>,IChucnangService
    {
        public ChucnangService(QLShopContext context) : base(context) { }
        public Chucnang DocThongTinChucNang(int chucnangId)
        {
            var chucnang = DocTheoDieuKien(x => x.SanPhamId.Equals(chucnangId)).FirstOrDefault();
            return chucnang;
        }
    }
}
