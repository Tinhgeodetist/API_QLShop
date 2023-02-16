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
    public class KhuyenmaiSerivce:Repository<Khuyenmai>,IKhuyenmaiService
    {
        public KhuyenmaiSerivce(QLShopContext context) : base(context) { }
       public List<Khuyenmai> DocDanhSachKhuyenMaiDangCo(DateTime ngaydienra)
        {
            var dsKMDangCo = DocTheoDieuKien(x => x.NgayBatDau < ngaydienra & x.NgayKetThuc > ngaydienra).ToList();
            return  dsKMDangCo;
        }

        public Khuyenmai DocThongTinKhuyenMai(int id)
        {
            var khuyenmais = DocTheoDieuKien(x => x.Id.Equals(id)).FirstOrDefault();
            return khuyenmais;
        }
        public List<Khuyenmai> DocDanhSachKhuyenMaiTheoLoaihang(int loaihangId)
        {
            var khuyenmais = DocTheoDieuKien(x => x.Id.Equals(loaihangId)).ToList();
            return khuyenmais;
        }
    }
}
