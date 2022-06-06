using AutoMapper;
using MediatR;
using UnitDirectory.Core.Dtos;
using UnitDirectory.Core.Interfaces.Repositories;

namespace UnitDirectory.Application.Queries.GetUnitList
{
    public class GetUnitListQueryHandler 
        : IRequestHandler<GetUnitListQuery, IEnumerable<UnitDto>>
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IMapper _mapper;

        public GetUnitListQueryHandler(IUnitRepository unitRepository, IMapper mapper)
        {
            _unitRepository = unitRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UnitDto>> Handle(GetUnitListQuery query, CancellationToken cancellationToken)
        {
            var units = await _unitRepository.GetAllAsync();
            var regulatedList = RegulateUnitList(_mapper.Map<List<UnitDto>>(units));

            return regulatedList;
        }

        private IEnumerable<UnitDto> RegulateUnitList(IEnumerable<UnitDto> units)
        {
            var result = new List<UnitDto>(units.Count());

            var root = units.Single(unit => unit.ParentId is null);
            AddToResult(root, units, result, 0);

            return result;
        }

        private void AddToResult(UnitDto unit ,IEnumerable<UnitDto> units, List<UnitDto> result, int level)
        {
            unit.Level = level;
            result.Add(unit);

            var children = GetChildren(units, unit.Id);
            foreach(var child in children)
            {
                AddToResult(child, units, result, level + 1);
            }
        }

        private IEnumerable<UnitDto> GetChildren(IEnumerable<UnitDto> units, Guid id)
        {
            return units.Where(unit => unit.ParentId == id)
                .OrderBy(unit => unit.Index);
        }
    }
}
