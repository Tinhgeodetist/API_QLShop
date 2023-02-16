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
    public class HinhController : ControllerBase
    {

        private readonly IHinhService _ihinhService;
        public HinhController(IHinhService ihinhService)
        {
            _ihinhService = ihinhService;
        }
        [HttpPost("DanhSachHinh")]
        public List<HinhModel.Output.ThongTinHinh> DanhSachHinh(HinhModel.Input.DocDanhSachHinh input)
        {
            var hinhs = _ihinhService.DocDanhSachHinh(input.QuanTri);
            var dshinh = hinhs.Select(x => new HinhModel.Output.ThongTinHinh()
            {
                HinhId = x.HinhId,
                Carousel = x.Carousel,
                Thumbnails = x.Thumbnails,
                KichHoat = x.KichHoat,
            }).ToList();
            return dshinh;
        }
        [HttpPost("ThemHinh")]
        public ThongBaoModel ThemHinhMoi(HinhModel.Input.ThongTinHinh input)
        {
            var thongbao = new ThongBaoModel { Maso = 1, Noidung = "" };
            try
            {
                var hinh = _ihinhService.Them(new Service.Models.Hinh()
                {
                    HinhId = input.HinhId,
                    Carousel = input.Carousel,
                    Thumbnails = input.Thumbnails,
                    KichHoat = input.KichHoat,
                });
                if (hinh != null)
                {
                    thongbao.Noidung = hinh.HinhId.ToString();
                }
                else
                {
                    thongbao.Maso = 1;
                    thongbao.Noidung = "Không thêm được hình";
                }

            }
            catch (Exception)
            {
                thongbao.Maso = 1;
                thongbao.Noidung = "Không thêm được Hình";
            }
            return thongbao;
        }
        [HttpPost("ThongTinHinh")]
        public HinhModel.Output.ThongTinHinh ThongTinHinh(HinhModel.Input.ThongTinHinh input)
        {
            var Hinh = _ihinhService.DocThongTinHinh(input.HinhId);
            HinhModel.Output.ThongTinHinh thongtinHinh = new HinhModel.Output.ThongTinHinh()
            {
                HinhId = input.HinhId,
                Carousel = input.Carousel,
                Thumbnails = input.Thumbnails,
                KichHoat = input.KichHoat,
            };
            return thongtinHinh;
        }
        [HttpPost("CapNhatHinh")]
        public ThongBaoModel CapNhatHinh(HinhModel.Input.ThongTinHinh input)
        {
            var tb = new ThongBaoModel { Maso = 1, Noidung = "" };
            try
            {
                Service.Models.Hinh hinh = new()
                {
                    HinhId = input.HinhId,
                    Carousel = input.Carousel,
                    Thumbnails = input.Thumbnails,
                    KichHoat = input.KichHoat
                };
                if (!_ihinhService.Sua(hinh))
                {
                    tb.Maso = 1;
                    tb.Noidung = "Không cập nhật đươc Hình";

                }

            }
            catch(Exception )
            {
                tb.Maso = 1;
                tb.Noidung = "Không cập nhật đươc Hình";
            }
            return tb;
        }
        [HttpPost("XoaHinh")]
        public ThongBaoModel XoaHinh(HinhModel.Input.XoaHinh input)
        {
            var tb = new ThongBaoModel { Maso = 1, Noidung = "" };
            if (input.Id > 0)
            {
                var Hinh = _ihinhService.DocThongTinHinh(input.Id);
                if (Hinh != null && _ihinhService.Xoa(Hinh))
                    tb.Noidung = Hinh.ToString();
                else
                {
                    tb.Maso = 1;
                    tb.Noidung = "Không xóa được Hình";
                }
                
            }
            else
            {
                tb.Maso = 1;
                tb.Noidung = "Không xóa được Hình";
            }
            return tb;
        }

    }
}
