using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UnitDirectory.Core.Entities;
using UnitDirectory.Infrastructure.EntityFramework.Initializations;

namespace UnitDirectory.Infrastructure.EntityFramework
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Unit> Units { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var assembly = Assembly.GetExecutingAssembly();
            builder.ApplyConfigurationsFromAssembly(assembly);

            new DatabaseInitializer(builder).Seed();
        }
    }
}
