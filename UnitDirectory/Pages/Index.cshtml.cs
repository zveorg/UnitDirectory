using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnitDirectory.Application.Commands.DeleteUnit;
using UnitDirectory.Application.Queries.ExportUnitList;
using UnitDirectory.Application.Queries.GetUnitList;
using UnitDirectory.Core.Dtos;

namespace UnitDirectory.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IMediator _mediator;

        public IEnumerable<UnitDto> Units { get; private set; }

        public IndexModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task OnGetAsync()
        {
            Units = await _mediator.Send(new GetUnitListQuery());
        }

        public async Task<IActionResult> OnPostDeleteAsync(Guid id)
        {
            await _mediator.Send(new DeleteUnitCommand { Id = id });

            return RedirectToPage();
        }

        public IActionResult OnPostRefresh()
        {
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostExport()
        {
            using var stream = new MemoryStream();
            using var writer = new StreamWriter(stream);
            var units = await _mediator.Send(new ExportUnitListQuery());
            var unitArray = units.ToArray();
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(Core.Entities.Unit[]));
            serializer.Serialize(stream, unitArray);
            var byteArray = stream.ToArray();

            return File(byteArray, "text/xml", $"Export-{DateTime.Now.ToString("yyy-MM-dd-hh-mm-ss")}.xml");
        }
    }
}
