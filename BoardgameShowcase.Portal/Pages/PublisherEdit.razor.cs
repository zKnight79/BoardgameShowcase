using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Model.Service;
using BoardgameShowcase.Portal.Widgets;
using Microsoft.AspNetCore.Components;

namespace BoardgameShowcase.Portal.Pages
{
    public partial class PublisherEdit
    {
        private const string ROUTE_PARAM = $"{{{nameof(PublisherId)}?}}";
        public const string ROUTE = $"{Publishers.ROUTE}/edit/{ROUTE_PARAM}";
        public static string GetRoute(string? publisherId = null) => ROUTE.Replace(ROUTE_PARAM, publisherId);

        [Inject] private IPublisherService PublisherService { get; set; } = default!;
        [Inject] private NavigationManager NavigationManager { get; set; } = default!;
        
        [Parameter] public string PublisherId { get; set; } = string.Empty;

        private Publisher Publisher { get; set; } = default!;
        private FormTextField? PublisherNameField { get; set; }
        private string? ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Publisher = (await PublisherService.GetByIdAsync(PublisherId)) ?? new();
            await FocusPublisherNameField(300);
        }

        private async Task FocusPublisherNameField(int delay = 0)
        {
            await Task.Delay(delay);
            if (PublisherNameField is not null)
            {
                await PublisherNameField.SetFocus();
            }
        }

        private async Task Validate()
        {
            ErrorMessage = null;
            if (string.IsNullOrWhiteSpace(Publisher.Name))
            {
                ErrorMessage = "Publisher name must be set";
                await FocusPublisherNameField();
            }
            else
            {
                Publisher? saved = await PublisherService.SaveAsync(Publisher);
                if (saved is null)
                {
                    ErrorMessage = "An internal error prevented saving the publisher. Please try again.";
                }
                else
                {
                    ReturnToPublisherList();
                }
            }
        }

        private void ReturnToPublisherList()
        {
            NavigationManager.NavigateTo(Publishers.ROUTE);
        }
    }
}
