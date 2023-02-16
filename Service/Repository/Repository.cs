using Microsoft.EntityFrameworkCore;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly QLShopContext _context;
        public Repository(QLShopContext context)
        {
            _context = context;
        }
        public IEnumerable<T> DocDanhSach(params Expression<Func<T, object>>[] cacthamso)
        {
            var results = _context.Set<T>().AsQueryable();
            foreach (var include in cacthamso)
            {
                results.Include(include);
            }
            return results.ToList();
        }

        public IEnumerable<T> DocTheoDieuKien(Expression<Func<T, bool>> dieukien, params Expression<Func<T, object>>[] cacthamso)
        {
            var results = _context.Set<T>().Where(dieukien);
            foreach (var include in cacthamso)
            {
                results.Include(include);
            }
            return results.ToList();
        }

        public bool Sua(T entity)
        {
            try
            {
                _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public T Them(T entity)
        {
            try
            {
                var ent = _context.Set<T>().Add(entity);
                _context.SaveChanges();
                return ent.Entity;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Xoa(T entity)
        {
            try
            {
                _context.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
