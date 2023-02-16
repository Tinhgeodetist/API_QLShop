using API_QLShop.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_QLShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChucnangController : ControllerBase
    {

        private readonly IChucnangService _ichucnangService;
        private ISanPhamService _isanphamService;
        public ChucnangController(IChucnangService ichucnangService, ISanPhamService isanphamService)
        {
            _ichucnangService = ichucnangService;
            _isanphamService = isanphamService;
        }
        [HttpPost("ThongTinChucNang")]
        public ChucnangModel.Output.ThongTinChucNang DocThongTinChucNang(ChucnangModel.Input.DocThongTinChucNang input)
        {
            var chucnang = _ichucnangService.DocThongTinChucNang(input.SanphamId);

            var thongtin = new ChucnangModel.Output.ThongTinChucNang {
                SanPhamId = chucnang.SanPhamId,
                ThietKe = chucnang.ThietKe,
                BoXuLy = chucnang.BoXuLy,
                BoNhoLuuTru = chucnang.BoNhoLuuTru,
                Amthanh = chucnang.Amthanh,
                BaoHanhId = chucnang.BaoHanhId,
                GiaoTiepKetNoi = chucnang.GiaoTiepKetNoi,
                Vga = chucnang.Vga,
                HeDieuHanh = chucnang.HeDieuHanh,
                ManHinh = chucnang.ManHinh,
                Pin = chucnang.Pin,
                BaoMat = chucnang.BaoMat,
                Camera = chucnang.Camera,
            };
            return thongtin;
            
        }
    }
}
