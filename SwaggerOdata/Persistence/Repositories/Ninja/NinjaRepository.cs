using SwaggerOdata.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SwaggerOdata.Persistence.Repositories.Ninja
{
    public class NinjaRepository 
    {
        private AppDbContext _ninjaContext;

        public NinjaRepository(AppDbContext context)
        {
            _ninjaContext = context;
        }

        public Entities.Ninja GetById(int id)
        {
            var ninja = _ninjaContext.Ninjas.Where(x => x.Id == id).FirstOrDefault();
            return ninja;
        }

        public Entities.Ninja GetClan(string clan)
        {
            var ninja = _ninjaContext.Ninjas.Where(x => x.Clan == clan).FirstOrDefault();
            return ninja;
        }

        public Entities.Ninja GetByClanAndName(string clan, string name)
        {
            var ninja = _ninjaContext.Ninjas.Where(x => x.Clan == clan && x.Name == name).FirstOrDefault();
            return ninja;
        }
    }

}
