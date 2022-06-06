using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitDirectory.Core.Exceptions;
using UnitDirectory.Core.Interfaces.Repositories;

namespace UnitDirectory.Application.Commands.AddUnit
{
    public class AddUnitCommandHandler : IRequestHandler<AddUnitCommand>
    {
        private readonly IUnitRepository _unitRepository;

        public AddUnitCommandHandler(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }
        public async Task<Unit> Handle(AddUnitCommand request, CancellationToken cancellationToken)
        {
            var parent = await _unitRepository.GetById(request.ParentId);
            if (parent == null)
            {
                throw new ItemNotFoundException("There is no parent unit with such id.");
            }

            var siblings = await _unitRepository.GetChildrenAsync(request.ParentId);

            var entity = new Core.Entities.Unit
            {
                Name = request.Name,
                Index = siblings.Count() + 1,
                ParentId = request.ParentId
            };

            await _unitRepository.AddAsync(entity);

            return Unit.Value;
        }
    }
}
