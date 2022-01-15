using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Model.Entity.Enumeration;
using BoardgameShowcase.Model.Service;
using BoardgameShowcase.Portal.Widgets;
using Microsoft.AspNetCore.Components;

namespace BoardgameShowcase.Portal.Pages
{
    public partial class BoardgameEdit
    {
        private const string ROUTE_PARAM = $"{{{nameof(BoardgameId)}?}}";
        public const string ROUTE = $"{Boardgames.ROUTE}/edit/{ROUTE_PARAM}";
        public static string GetRoute(string? boardgameId = null) => ROUTE.Replace(ROUTE_PARAM, boardgameId);

        [Inject] private IBoardgameService BoardgameService { get; set; } = default!;
        [Inject] private IAuthorService AuthorService { get; set; } = default!;
        [Inject] private IIllustratorService IllustratorService { get; set; } = default!;
        [Inject] private IPublisherService PublisherService { get; set; } = default!;
        [Inject] private NavigationManager NavigationManager { get; set; } = default!;

        [Parameter] public string BoardgameId { get; set; } = string.Empty;

        private Boardgame Boardgame { get; set; } = default!;
        private FormInputField<string>? BoardgameTitleField { get; set; }
        private string? ErrorMessage { get; set; }
        private IEnumerable<Author> AuthorList { get; set; } = default!;
        private IEnumerable<Illustrator> IllustratorList { get; set; } = default!;
        private IEnumerable<Publisher> PublisherList { get; set; } = default!;

        private IDictionary<string, string> AuthorOptions => AuthorList.ToDictionary(a => a.Id ?? "", a => a.Name);
        private IDictionary<string, string> IllustratorOptions => IllustratorList.ToDictionary(i => i.Id ?? "", i => i.Name);
        private IDictionary<string, string> PublisherOptions => PublisherList.ToDictionary(p => p.Id ?? "", p => p.Name);
        private IDictionary<Category, string> CategoryOptions => Enum.GetValues<Category>().ToDictionary(c => c, c => c switch
        {
            Category.Management => "Management",
            Category.Racing => "Racing",
            Category.Strategy => "Strategy",
            _ => "Unknown category"
        });
        private IDictionary<Theme, string> ThemeOptions => Enum.GetValues<Theme>().ToDictionary(t => t, t => t switch
        {
            Theme.Antiquity => "Antiquity",
            Theme.Medieval => "Medieval",
            Theme.Science_Fiction => "Science-fiction",
            Theme.Sciences => "Sciences",
            Theme.Economy => "Economy",
            Theme.Exploration => "Exploration",
            Theme.Europe => "Europe",
            Theme.USA => "U.S.A.",
            Theme.Trains => "Trains",
            Theme.Constructions => "Constructions",
            Theme.Arts => "Arts",
            _ => "Unknown theme"
        });
        private IDictionary<Mechanism, string> MechanismOptions => Enum.GetValues<Mechanism>().ToDictionary(m => m, m => m switch
        {
            Mechanism.Management => "Management",
            Mechanism.Ressources => "Ressources",
            Mechanism.Draft => "Draft",
            Mechanism.Tiles => "Tiles",
            Mechanism.Combination => "Combination",
            Mechanism.Powers => "Powers",
            Mechanism.Wargame => "Wargame",
            Mechanism.Exploration => "Exploration",
            Mechanism.Confrontation => "Confrontation",
            Mechanism.Cards => "Cards",
            Mechanism.Dice => "Dice",
            Mechanism.Collection => "Collection",
            Mechanism.Secret_Objectives => "Secret objectives",
            Mechanism.Placement => "Placement",
            _ => "Unknown mechanism"
        });

        protected override async Task OnInitializedAsync()
        {
            AuthorList = await AuthorService.GetAllAsync();
            IllustratorList = await IllustratorService.GetAllAsync();
            PublisherList = await PublisherService.GetAllAsync();
            Boardgame = (await BoardgameService.GetByIdAsync(BoardgameId)) ?? new();
            await FocusBoardgameTitleField(300);
        }

        private async Task FocusBoardgameTitleField(int delay = 0)
        {
            await Task.Delay(delay);
            if (BoardgameTitleField is not null)
            {
                await BoardgameTitleField.SetFocus();
            }
        }

        private async Task Validate()
        {
            ErrorMessage = null;
            if (string.IsNullOrWhiteSpace(Boardgame.Title))
            {
                ErrorMessage = "Boardgame's title must be set";
                await FocusBoardgameTitleField();
            }
            else if (string.IsNullOrWhiteSpace(Boardgame.AuthorId))
            {
                ErrorMessage = "Boardgame's author must be set";
            }
            else if (string.IsNullOrWhiteSpace(Boardgame.IllustratorId))
            {
                ErrorMessage = "Boardgame's illustrator must be set";
            }
            else if (string.IsNullOrWhiteSpace(Boardgame.PublisherId))
            {
                ErrorMessage = "Boardgame's publisher must be set";
            }
            else
            {
                Boardgame? saved = await BoardgameService.SaveAsync(Boardgame);
                if (saved is null)
                {
                    ErrorMessage = "An internal error prevented saving the boardgame. Please try again.";
                }
                else
                {
                    ReturnToBoardgameList();
                }
            }
        }

        private void ReturnToBoardgameList()
        {
            NavigationManager.NavigateTo(Boardgames.ROUTE);
        }
    }
}
