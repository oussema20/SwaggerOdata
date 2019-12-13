﻿using Microsoft.EntityFrameworkCore;
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
    }
}
