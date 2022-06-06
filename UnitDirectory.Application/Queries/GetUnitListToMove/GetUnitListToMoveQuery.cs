using MediatR;
using UnitDirectory.Core.Dtos;

namespace UnitDirectory.Application.Queries.GetUnitListToMove
{
    public class GetUnitListToMoveQuery : IRequest<IEnumerable<UnitDto>>
    {
        public Guid Id { get; set; }
    }
}
