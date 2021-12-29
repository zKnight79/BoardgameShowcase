using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Repository.GraphQL.Response;
using Microsoft.Extensions.Logging;

namespace BoardgameShowcase.Repository.GraphQL.Subscription
{
    class AuthorSubscription : GenericSubscription<Author>, IAuthorSubscription
    {
        public AuthorSubscription(ILogger<AuthorSubscription> logger, IDataAccess dataAccess)
            : base(logger, dataAccess)
        {
        }

        protected override string GqlAddedSubscription => GQL.AuthorAdded;
        protected override string GqlModifiedSubscription => GQL.AuthorModified;
        protected override string GqlRemovedSubscription => GQL.AuthorRemoved;

        protected override IDisposable Subscribe(string gqlSubscription, Action<Author> action)
        {
            return DataAccess.Subscription(gqlSubscription, (AuthorResponse response) =>
            {
                Author? author = response.Author;
                if (author is not null)
                {
                    action(author);
                }
            });
        }
    }
}
