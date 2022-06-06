using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitDirectory.Core.Dtos;
using UnitDirectory.Core.Interfaces.Repositories;

namespace UnitDirectory.Application.Queries.GetUnitListToMove
{
    public class GetUnitListToMoveQueryHandler : IRequestHandler<GetUnitListToMoveQuery, IEnumerable<UnitDto>>
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IMapper _mapper;

        public GetUnitListToMoveQueryHandler(IUnitRepository unitRepository, IMapper mapper)
        {
            _unitRepository = unitRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UnitDto>> Handle(GetUnitListToMoveQuery request, CancellationToken cancellationToken)
        {
            var units = await _unitRepository.GetAllAsync();
            var regulatedList = RegulateUnitList(_mapper.Map<List<UnitDto>>(units), request.Id);

            return regulatedList;
        }

        private IEnumerable<UnitDto> RegulateUnitList(IEnumerable<UnitDto> units, Guid excludedUnitId)
        {
            var result = new List<UnitDto>(units.Count());

            var root = units.Single(unit => unit.ParentId is null);
            AddToResult(root, units, result, excludedUnitId, 0);

            return result;
        }

        private void AddToResult(UnitDto unit, IEnumerable<UnitDto> units, List<UnitDto> result, Guid excludedUnitId, int level)
        {
            unit.Level = level;
            result.Add(unit);

            var children = GetChildren(units, unit.Id);
            foreach (var child in children)
            {
                if (child.Id == excludedUnitId)
                    continue;

                AddToResult(child, units, result, excludedUnitId, level + 1);
            }
        }

        private IEnumerable<UnitDto> GetChildren(IEnumerable<UnitDto> units, Guid id)
        {
            return units.Where(unit => unit.ParentId == id)
                .OrderBy(unit => unit.Index);
        }
    }
}
