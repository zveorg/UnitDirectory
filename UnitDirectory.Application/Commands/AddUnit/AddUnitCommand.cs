using MediatR;

namespace UnitDirectory.Application.Commands.AddUnit
{
    public class AddUnitCommand : IRequest
    {
        public string Name { get; set; }
        public Guid ParentId { get; set; }
    }
}
