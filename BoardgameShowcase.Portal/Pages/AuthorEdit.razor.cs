using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Model.Service;
using BoardgameShowcase.Portal.Widgets;
using Microsoft.AspNetCore.Components;

namespace BoardgameShowcase.Portal.Pages
{
    public partial class AuthorEdit
    {
        private const string ROUTE_PARAM = $"{{{nameof(AuthorId)}?}}";
        public const string ROUTE = $"{Authors.ROUTE}/edit/{ROUTE_PARAM}";
        public static string GetRoute(string? authorId = null) => ROUTE.Replace(ROUTE_PARAM, authorId);

        [Inject] private IAuthorService AuthorService { get; set; } = default!;
        [Inject] private NavigationManager NavigationManager { get; set; } = default!;
        
        [Parameter] public string AuthorId { get; set; } = string.Empty;

        private Author Author { get; set; } = default!;
        private FormInputField<string>? AuthorNameField { get; set; }
        private string? ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Author = (await AuthorService.GetByIdAsync(AuthorId)) ?? new();
            await FocusAuthorNameField(300);
        }

        private async Task FocusAuthorNameField(int delay = 0)
        {
            await Task.Delay(delay);
            if (AuthorNameField is not null)
            {
                await AuthorNameField.SetFocus();
            }
        }

        private async Task Validate()
        {
            ErrorMessage = null;
            if (string.IsNullOrWhiteSpace(Author.Name))
            {
                ErrorMessage = "Author name must be set";
                await FocusAuthorNameField();
            }
            else
            {
                Author? saved = await AuthorService.SaveAsync(Author);
                if (saved is null)
                {
                    ErrorMessage = "An internal error prevented saving the author. Please try again.";
                }
                else
                {
                    ReturnToAuthorList();
                }
            }
        }

        private void ReturnToAuthorList()
        {
            NavigationManager.NavigateTo(Authors.ROUTE);
        }
    }
}
