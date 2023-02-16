

using Service.Models;
using Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IKhuyenmaiService : IRepository<Khuyenmai>
    {
        List<Khuyenmai> DocDanhSachKhuyenMaiDangCo(DateTime ngaydienra);
        Khuyenmai DocThongTinKhuyenMai(int Id);
         
        List<Khuyenmai> DocDanhSachKhuyenMaiTheoLoaihang(int loaihangId);
        
    }
}
