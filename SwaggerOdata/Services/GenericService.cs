using SwaggerOdata.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerOdata.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {

        private readonly IGenericRepository<T> _genericRepo;


        public GenericService(IGenericRepository<T> genericRepo)
        {
            _genericRepo = genericRepo;
        }

        public void Add(T obj)
        {
            _genericRepo.Add(obj);
            _genericRepo.SaveChanges();
        }

        public void Delete(object id)
        {
            _genericRepo.Delete(id);
            _genericRepo.SaveChanges();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var serv = await _genericRepo.GetAll();
            return serv;

        }

        public T GetById(object id)
        {
            var solution = _genericRepo.GetById(id);
            return solution;

        }

    //public void Update(T obj)
    //{
    //    _genericRepo.Update(obj);
    //    _genericRepo.SaveChanges();

    //}

}
}
