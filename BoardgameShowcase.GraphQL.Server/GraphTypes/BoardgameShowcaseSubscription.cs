using BoardgameShowcase.Common.Extensions;
using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Model.Service;
using GraphQL;
using GraphQL.Types;

namespace BoardgameShowcase.GraphQL.Server.GraphTypes
{
    public partial class BoardgameShowcaseSubscription : ObjectGraphType
    {
        private readonly IAuthorService _authorService;
        private readonly IIllustratorService _illustratorService;
        private readonly IPublisherService _publisherService;
        private readonly IBoardgameService _boardgameService;

        public BoardgameShowcaseSubscription(IServiceProvider serviceProvider)
        {
            Name = nameof(BoardgameShowcaseSubscription);
            Description = "Subscription for Boardgame Showcase";

            _authorService = serviceProvider.GetRequiredService<IAuthorService>();
            _illustratorService = serviceProvider.GetRequiredService<IIllustratorService>();
            _publisherService = serviceProvider.GetRequiredService<IPublisherService>();
            _boardgameService = serviceProvider.GetRequiredService<IBoardgameService>();

            this.CallPrivateUnheritedParameterlessMethodsReturning(typeof(void));
        }

        private T GetEntityFromContext<T>(IResolveFieldContext context) where T : GenericEntity
        {
            if (context.Source is T entity)
            {
                return entity;
            }
            else
            {
                throw new ArgumentException($"{nameof(context)}.{nameof(context.Source)} must be a valid {typeof(T).Name}");
            }
        }
    }
}
