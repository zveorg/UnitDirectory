using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnitDirectory.Application.Commands.MoveUnit;
using UnitDirectory.Application.Queries.GetUnitListToMove;
using UnitDirectory.Core.Dtos;

namespace UnitDirectory.Pages
{
    public class MoveUnitModel : PageModel
    {
        private readonly IMediator _mediator;

        [BindProperty]
        public Guid Id { get; set; }
        public IEnumerable<UnitDto> Units { get; private set; }

        public MoveUnitModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task OnGetAsync(Guid id)
        {
            Id = id;
            Units = await _mediator.Send(new GetUnitListToMoveQuery { Id = id });
        }

        public async Task<IActionResult> OnPostPatchAsync(Guid parentId)
        {
            await _mediator.Send(new MoveUnitCommand { Id = Id, ParentId = parentId });

            return RedirectToPage("Index");
        }
    }
}
