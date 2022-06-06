using MediatR;

namespace UnitDirectory.Application.Queries.ExportUnitList
{
    public class ExportUnitListQuery : IRequest<IEnumerable<Core.Entities.Unit>>
    {
    }
}
