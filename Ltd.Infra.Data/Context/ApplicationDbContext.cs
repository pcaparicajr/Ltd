using Ltd.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ltd.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public  ApplicationDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Funcionario> Funcionario { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
