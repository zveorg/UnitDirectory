using Microsoft.EntityFrameworkCore;
using UnitDirectory.Core.Entities;

namespace UnitDirectory.Infrastructure.EntityFramework.Initializations
{
    public class UnitInitializer
    {
        public static void Seed(ModelBuilder builder)
        {
            var rootUnit = new Unit
            {
                Id = Guid.NewGuid(),
                Name = "Компания"
            };

            builder.Entity<Unit>().HasData(rootUnit);
        }
    }
}
