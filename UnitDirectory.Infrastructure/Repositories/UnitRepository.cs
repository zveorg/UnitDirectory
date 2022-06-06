using Microsoft.EntityFrameworkCore;
using UnitDirectory.Core.Dtos;
using UnitDirectory.Core.Entities;
using UnitDirectory.Core.Interfaces.Repositories;
using UnitDirectory.Infrastructure.EntityFramework;

namespace UnitDirectory.Infrastructure.Repositories
{
    public class UnitRepository : BaseRepository<Unit>, IUnitRepository
    {
        public UnitRepository(DatabaseContext databaseContext) 
            : base(databaseContext) {}

        public async Task<IEnumerable<Unit>> GetChildrenAsync(Guid parentId)
        {
            var query  = from units in Context.Units
                         where units.ParentId == parentId
                         select units;
            return await query.ToListAsync();
        }
    }
}
