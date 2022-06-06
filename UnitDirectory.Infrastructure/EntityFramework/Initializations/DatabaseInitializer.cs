using Microsoft.EntityFrameworkCore;

namespace UnitDirectory.Infrastructure.EntityFramework.Initializations
{
    internal class DatabaseInitializer
    {
        private readonly ModelBuilder _modelBuilder;

        public DatabaseInitializer(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            UnitInitializer.Seed(_modelBuilder);
        }
    }
}
