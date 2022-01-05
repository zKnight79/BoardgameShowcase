using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Model.Service;
using BoardgameShowcase.Model.Subscription;

namespace BoardgameShowcase.Repository.Subscription
{
    class AuthorSubscription : GenericSubscription<Author>, IAuthorSubscription
    {
        public AuthorSubscription(IAuthorService authorService)
            : base(authorService)
        {
        }
    }
}
