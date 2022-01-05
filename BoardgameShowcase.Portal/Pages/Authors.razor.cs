using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Model.Service;
using Microsoft.AspNetCore.Components;

namespace BoardgameShowcase.Portal.Pages
{
    public partial class Authors
    {
        public const string ROUTE = "authors";

        [Inject] private IAuthorService AuthorService { get; set; } = default!;

        private IEnumerable<Author> AuthorList { get; set; } = Enumerable.Empty<Author>();

        protected override async Task OnInitializedAsync()
        {
            AuthorList = await AuthorService.GetAllAsync();
        }
    }
}
