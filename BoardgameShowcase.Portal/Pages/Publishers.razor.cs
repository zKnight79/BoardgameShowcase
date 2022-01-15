using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Model.Service;
using Microsoft.AspNetCore.Components;

namespace BoardgameShowcase.Portal.Pages
{
    public partial class Publishers
    {
        public const string ROUTE = "publishers";

        [Inject] private IPublisherService PublisherService { get; set; } = default!;
        [Inject] private NavigationManager NavigationManager { get; set; } = default!;

        private IEnumerable<Publisher> PublisherList { get; set; } = Enumerable.Empty<Publisher>();

        protected override async Task OnInitializedAsync()
        {
            PublisherList = await PublisherService.GetAllAsync();
        }

        private void AddPublisher()
        {
            NavigationManager.NavigateTo(PublisherEdit.GetRoute());
        }
    }
}
