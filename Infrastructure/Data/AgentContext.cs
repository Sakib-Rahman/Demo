using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AgentContext : DbContext
    {
        static AgentContext()
        {
            Database.SetInitializer<AgentContext>(null);
        }

        public AgentContext() : base("AgentContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<AgentContext>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<StoreGeneratedIdentityKeyConvention>();
        }
        public DbSet<BusinessEntities> BusinessEntities { get; set; }
    }
}
