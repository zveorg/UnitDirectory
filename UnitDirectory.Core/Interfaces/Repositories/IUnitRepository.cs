using UnitDirectory.Core.Dtos;
using UnitDirectory.Core.Entities;

namespace UnitDirectory.Core.Interfaces.Repositories
{
    public interface IUnitRepository : IRepository<Unit>
    {
        Task<IEnumerable<Unit>> GetChildrenAsync(Guid parentId);
    }
}
