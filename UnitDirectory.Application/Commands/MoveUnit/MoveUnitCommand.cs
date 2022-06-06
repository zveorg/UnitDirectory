using MediatR;

namespace UnitDirectory.Application.Commands.MoveUnit
{
    public class MoveUnitCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid ParentId { get; set; }
    }
}
