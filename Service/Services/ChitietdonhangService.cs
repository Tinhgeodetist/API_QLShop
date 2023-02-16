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
    public class ChitietdonhangService : Repository<Chitietdonhang>, IChitietdonhangService
    {
        public ChitietdonhangService(QLShopContext context) : base(context) { }
        
        public Chitietdonhang DocThongTinChiTietDonHang(int id)
        {
            return DocTheoDieuKien(x => x.DonHangId.Equals(id), x => x.SanPham, x => x.Diachi, x => x.SoDienThoai,x=>x.PhiShip, x => x.TongTien).FirstOrDefault();
        }
    }
}
