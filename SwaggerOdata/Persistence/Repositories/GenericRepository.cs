using Microsoft.EntityFrameworkCore;
using SwaggerOdata.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerOdata.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private AppDbContext _context;
        public GenericRepository()
        {
            //table = _context.Set<T>();
        }
        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            var rep = await _context.Set<T>().ToListAsync();
            return rep;
        }
        public void Add(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();


        }

        public void SaveChanges()
        {
            //throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            var del = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(del);
            _context.SaveChanges();
        }

        public T GetById(object id)
        {
            return _context.Set<T>().Find(id);

        }

        //public void Update(T obj)
        //{
        //    _context.Set<T>().Attach(obj);
        //    _context.Entry(obj).State = EntityState.Modified;
        //}
    }
}
 