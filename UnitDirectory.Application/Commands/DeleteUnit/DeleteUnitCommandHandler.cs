using MediatR;
using UnitDirectory.Core.Exceptions;
using UnitDirectory.Core.Interfaces.Repositories;

namespace UnitDirectory.Application.Commands.DeleteUnit
{
    public  class DeleteUnitCommandHandler : IRequestHandler<DeleteUnitCommand>
    {
        private readonly IUnitRepository _unitRepository;

        public DeleteUnitCommandHandler(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }
        public async Task<Unit> Handle(DeleteUnitCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitRepository.GetById(request.Id);
            if (entity == null)
            {
                throw new ItemNotFoundException("There is no unit with such id.");
            }

            await _unitRepository.RemoveAsync(entity);

            return Unit.Value;
        }
    }
}
