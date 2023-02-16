using API_QLShop.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_CSC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaihangController : ControllerBase
    {
        private readonly ILoaihangService _iLoaihangService;
        public LoaihangController(ILoaihangService iLoaiHangService)
        {
            _iLoaihangService = iLoaiHangService;
        }
        [HttpPost("DanhSachLoaiHang")]
        public List<LoaihangModel.Output.ThongTinLoaiHang> DanhSachLoaiHang()
        {
            var dsLoaihang = _iLoaihangService.DocDanhSachLoaiHang();
            return dsLoaihang.Select(lh => new LoaihangModel.Output.ThongTinLoaiHang
            {
                Id = lh.Id,
                Ten = lh.TenLoaiHang
            }).ToList();
        }
        [HttpPost("ThongTinLoaiHang")]
        public LoaihangModel.Output.ThongTinLoaiHang ThongTinLoaiHang(LoaihangModel.Input.ThongTinLoaiHang input)
        {
            var Loaihang = _iLoaihangService.DocThongTinLoaiHang(input.Id);
            var thongtin = new LoaihangModel.Output.ThongTinLoaiHang()
            {
                Id =Loaihang.Id,
                Ten = Loaihang.TenLoaiHang,
                
            };
            return thongtin;
        }



    }
}
