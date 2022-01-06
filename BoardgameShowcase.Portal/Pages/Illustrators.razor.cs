using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Model.Service;
using Microsoft.AspNetCore.Components;

namespace BoardgameShowcase.Portal.Pages
{
    public partial class Illustrators
    {
        public const string ROUTE = "illustrators";

        [Inject] private IIllustratorService IllustratorService { get; set; } = default!;

        private IEnumerable<Illustrator> IllustratorList { get; set; } = Enumerable.Empty<Illustrator>();

        protected override async Task OnInitializedAsync()
        {
            IllustratorList = await IllustratorService.GetAllAsync();
        }
    }
}
