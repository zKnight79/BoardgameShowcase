using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Model.Service;
using BoardgameShowcase.Model.Subscription;

namespace BoardgameShowcase.Repository.Subscription
{
    class BoardgameSubscription : GenericSubscription<Boardgame>, IBoardgameSubscription
    {
        public BoardgameSubscription(IBoardgameService boardgameService)
            : base(boardgameService)
        {
        }
    }
}
