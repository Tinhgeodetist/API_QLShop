using Service.Models;
using Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IChucnangService :IRepository<Chucnang>

    {
        Chucnang DocThongTinChucNang(int SanphamId);
    }
}
