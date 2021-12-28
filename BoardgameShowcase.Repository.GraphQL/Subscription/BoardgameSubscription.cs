using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Repository.GraphQL.Repository;
using BoardgameShowcase.Repository.GraphQL.Repository.Response;
using Microsoft.Extensions.Logging;

namespace BoardgameShowcase.Repository.GraphQL.Subscription
{
    class BoardgameSubscription : GenericSubscription<Boardgame>, IBoardgameSubscription
    {
        public BoardgameSubscription(ILogger<BoardgameSubscription> logger, IDataAccess dataAccess)
            : base(logger, dataAccess)
        {
        }

        protected override string GqlAddedSubscription => GQL.BoardgameAdded;
        protected override string GqlModifiedSubscription => GQL.BoardgameModified;
        protected override string GqlRemovedSubscription => GQL.BoardgameRemoved;

        protected override IDisposable Subscribe(string gqlSubscription, Action<Boardgame> action)
        {
            return DataAccess.Subscription(gqlSubscription, (BoardgameResponse response) =>
            {
                Boardgame? boardgame = response.Boardgame;
                if (boardgame is not null)
                {
                    action(boardgame);
                }
            });
        }
    }
}
