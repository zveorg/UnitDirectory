using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnitDirectory.Application.Commands.AddUnit;

namespace UnitDirectory.Pages
{
    [IgnoreAntiforgeryToken]
    public class CreateUnitModel : PageModel
    {
        private readonly IMediator _mediator;

        [BindProperty]
        public AddUnitCommand Data { get; set; } = new();

        public CreateUnitModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        public IActionResult OnGet(Guid id)
        {
            Data.ParentId = id;

            return Page();
        }


        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            Data.ParentId = id;
            await _mediator.Send(Data);

            return RedirectToPage("Index");
        }
    }
}
