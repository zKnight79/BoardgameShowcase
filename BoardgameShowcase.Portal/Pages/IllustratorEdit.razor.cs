using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Model.Service;
using BoardgameShowcase.Portal.Widgets;
using Microsoft.AspNetCore.Components;

namespace BoardgameShowcase.Portal.Pages
{
    public partial class IllustratorEdit
    {
        private const string ROUTE_PARAM = $"{{{nameof(IllustratorId)}?}}";
        public const string ROUTE = $"{Illustrators.ROUTE}/edit/{ROUTE_PARAM}";
        public static string GetRoute(string? illustratorId = null) => ROUTE.Replace(ROUTE_PARAM, illustratorId);

        [Inject] private IIllustratorService IllustratorService { get; set; } = default!;
        [Inject] private NavigationManager NavigationManager { get; set; } = default!;
        
        [Parameter] public string IllustratorId { get; set; } = string.Empty;

        private Illustrator Illustrator { get; set; } = default!;
        private FormTextField? IllustratorNameField { get; set; }
        private string? ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Illustrator = (await IllustratorService.GetByIdAsync(IllustratorId)) ?? new();
            await FocusIllustratorNameField(300);
        }

        private async Task FocusIllustratorNameField(int delay = 0)
        {
            await Task.Delay(delay);
            if (IllustratorNameField is not null)
            {
                await IllustratorNameField.SetFocus();
            }
        }

        private async Task Validate()
        {
            ErrorMessage = null;
            if (string.IsNullOrWhiteSpace(Illustrator.Name))
            {
                ErrorMessage = "Illustrator name must be set";
                await FocusIllustratorNameField();
            }
            else
            {
                Illustrator? saved = await IllustratorService.SaveAsync(Illustrator);
                if (saved is null)
                {
                    ErrorMessage = "An internal error prevented saving the illustrator. Please try again.";
                }
                else
                {
                    ReturnToIllustratorList();
                }
            }
        }

        private void ReturnToIllustratorList()
        {
            NavigationManager.NavigateTo(Illustrators.ROUTE);
        }
    }
}
