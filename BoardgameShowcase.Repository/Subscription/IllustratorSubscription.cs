using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Model.Service;
using BoardgameShowcase.Model.Subscription;

namespace BoardgameShowcase.Repository.Subscription
{
    class IllustratorSubscription : GenericSubscription<Illustrator>, IIllustratorSubscription
    {
        public IllustratorSubscription(IIllustratorService illustratorService)
            : base(illustratorService)
        {
        }
    }
}
