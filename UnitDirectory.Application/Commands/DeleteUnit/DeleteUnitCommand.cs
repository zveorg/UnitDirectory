using MediatR;

namespace UnitDirectory.Application.Commands.DeleteUnit
{
    public class DeleteUnitCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
