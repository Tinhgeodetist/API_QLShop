using API_QLShop.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_QLShop.Common;
using Service.IServices;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_QLShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChitietdonhangController : ControllerBase
    {
        private readonly IChitietdonhangService _ichitietdonhangService;
        public ChitietdonhangController(IChitietdonhangService ichitietdonhangService)
        {
            _ichitietdonhangService= ichitietdonhangService;

        }
        [HttpPost("DocThongTinChiTietDonHang")]
        public ChitietdonhangModel.Output.ThongTinChiTietDonHang XemThongTinChiTietDonHang(ChitietdonhangModel.Intput.DocThongTinChiTietDonHang input)
        {
             ChitietdonhangModel.Output.ThongTinChiTietDonHang thongtinchitietDonhang = new();
            if (input.Id > 0)
            {
                try
                {
                    var ChiTiet = _ichitietdonhangService.DocThongTinChiTietDonHang(input.Id);
                    if (ChiTiet != null)
                    {
                        Utilities.PropertyCopier<Service.Models.Chitietdonhang, ChitietdonhangModel.Output.ThongTinChiTietDonHang>.Copy(ChiTiet, thongtinchitietDonhang);
                    }
                    else
                        {
                            thongtinchitietDonhang.ThongBao = "Lỗi. Không tìm thấy thông tin chi tiết đơn hàng";
                        }

                    
                }
                catch (Exception ex)
                {
                    thongtinchitietDonhang.ThongBao = "Lỗi " + ex.Message;
                }
                
            }
            else
            {
                thongtinchitietDonhang.ThongBao = "lỗi. Id Chi Tiết đon hàng không hợp lệ";
            }
            return thongtinchitietDonhang;
        }
        
    }
}
