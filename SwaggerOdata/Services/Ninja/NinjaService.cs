using SwaggerOdata.Persistence.Repositories;
using SwaggerOdata.Persistence.Repositories.Ninja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerOdata.Services.Ninja
{
    //public class NinjaService : GenericService<SwaggerOdata.Entities.Ninja>
    public class NinjaService : INinjaService
    {
        //public NinjaService(IGenericRepository<SwaggerOdata.Entities.Ninja> genericRepo) : base(genericRepo)
        private NinjaRepository _ninjaRepo;

        public NinjaService(NinjaRepository ninjaRepo)
        {
            _ninjaRepo = ninjaRepo;
        }
        public Entities.Ninja GetById(int id)
        {
            var ninja = _ninjaRepo.GetById(id);
            return ninja;
        }
        public Entities.Ninja GetByClan(string clan)
        {
            var ninja = _ninjaRepo.GetClan(clan);
            return ninja;
        }

        public Entities.Ninja GetByClanAndName(string clan, string name)
        {
            var ninja = _ninjaRepo.GetByClanAndName(clan, name);

            return ninja;
        }
    }
            }

