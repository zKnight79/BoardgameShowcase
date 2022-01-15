using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Model.Service;
using Microsoft.AspNetCore.Components;

namespace BoardgameShowcase.Portal.Pages
{
    public partial class Boardgames
    {
        public const string ROUTE = "boardgames";

        [Inject] private IBoardgameService BoardgameService { get; set; } = default!;
        [Inject] private NavigationManager NavigationManager { get; set; } = default!;

        private IEnumerable<Boardgame> BoardgameList { get; set; } = Enumerable.Empty<Boardgame>();

        protected override async Task OnInitializedAsync()
        {
            BoardgameList = await BoardgameService.GetAllAsync();
        }

        private void AddBoardgame()
        {
            NavigationManager.NavigateTo(BoardgameEdit.GetRoute());
        }
    }
}
