using MediatR;
using UnitDirectory.Core.Interfaces.Repositories;

namespace UnitDirectory.Application.Queries.ExportUnitList
{
    public class ExportUnitListQueryHandler : IRequestHandler<ExportUnitListQuery, IEnumerable<Core.Entities.Unit>>
    {
        private readonly IUnitRepository _unitRepository;


        public ExportUnitListQueryHandler(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;

        }
        public async Task<IEnumerable<Core.Entities.Unit>> Handle(ExportUnitListQuery request, CancellationToken cancellationToken)
        {
            var units = await _unitRepository.GetAllAsync();
            return units;
        }
    }
}
