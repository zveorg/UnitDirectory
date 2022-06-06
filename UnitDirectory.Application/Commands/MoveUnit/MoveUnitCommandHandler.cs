using MediatR;
using UnitDirectory.Core.Exceptions;
using UnitDirectory.Core.Interfaces.Repositories;

namespace UnitDirectory.Application.Commands.MoveUnit
{
    public class MoveUnitCommandHandler : IRequestHandler<MoveUnitCommand>
    {
        private readonly IUnitRepository _unitRepository;

        public MoveUnitCommandHandler(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }

        public async Task<Unit> Handle(MoveUnitCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitRepository.GetById(request.Id);
            if (entity == null)
            {
                throw new ItemNotFoundException("There is no unit with such id.");
            }

            var parent = await _unitRepository.GetById(request.ParentId);
            if (parent == null)
            {
                throw new ItemNotFoundException("There is no parent unit with such id.");
            }

            entity.ParentId = request.ParentId;

            await _unitRepository.UpdateAsync(entity);

            return Unit.Value;
        }
    }
}
