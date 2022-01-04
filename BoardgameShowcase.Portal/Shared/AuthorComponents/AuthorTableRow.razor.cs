using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Model.Service;
using Microsoft.AspNetCore.Components;

namespace BoardgameShowcase.Portal.Shared.AuthorComponents
{
    public partial class AuthorTableRow
    {
        private const int MAX_BOARDGAME_COUNT = 3;
        
        [Inject] private IBoardgameService BoardgameService { get; set; } = default!;

        [Parameter, EditorRequired] public Author Author { get; set; } = default!;

        private IEnumerable<Boardgame> Boardgames { get; set; } = Enumerable.Empty<Boardgame>();

        private IEnumerable<Boardgame> BoardgameList => Boardgames.Take(MAX_BOARDGAME_COUNT);
        private int BoardgameCount => Boardgames.Count();

        protected override async Task OnInitializedAsync()
        {
            Boardgames = await BoardgameService.GetByAuthorAsync(Author);
        }
    }
}
