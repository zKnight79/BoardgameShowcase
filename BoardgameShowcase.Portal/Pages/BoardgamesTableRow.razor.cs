using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Model.Service;
using Microsoft.AspNetCore.Components;

namespace BoardgameShowcase.Portal.Pages
{
    public partial class BoardgamesTableRow
    {
        [Inject] private IAuthorService AuthorService { get; set; } = default!;
        [Inject] private IIllustratorService IllustratorService { get; set; } = default!;
        [Inject] private IPublisherService PublisherService { get; set; } = default!;

        [Parameter, EditorRequired] public Boardgame Boardgame { get; set; } = default!;

        private Author? Author { get; set; }
        private Illustrator? Illustrator { get; set; }
        private Publisher? Publisher { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Author = await AuthorService.GetByIdAsync(Boardgame.AuthorId);
            Illustrator = await IllustratorService.GetByIdAsync(Boardgame.IllustratorId);
            Publisher = await PublisherService.GetByIdAsync(Boardgame.PublisherId);
        }
    }
}
