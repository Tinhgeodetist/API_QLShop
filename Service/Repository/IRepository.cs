using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repository
{
        public interface IRepository<T> where T : class
        {
            T Them(T entity);
            bool Xoa(T entity);
            bool Sua(T entity);
            IEnumerable<T> DocDanhSach(params Expression<Func<T, object>>[] cacthamso);
            IEnumerable<T> DocTheoDieuKien(Expression<Func<T, bool>> dieukien, params Expression<Func<T, object>>[] cacthamso);
        }
}
