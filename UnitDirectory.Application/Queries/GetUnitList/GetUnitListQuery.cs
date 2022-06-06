using MediatR;
using UnitDirectory.Core.Dtos;

namespace UnitDirectory.Application.Queries.GetUnitList
{
    public class GetUnitListQuery : IRequest<IEnumerable<UnitDto>>
    {
    }
}
