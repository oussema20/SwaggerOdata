using Microsoft.EntityFrameworkCore;
using SwaggerOdata.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerOdata.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        public DbSet<Ninja> Ninjas { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
