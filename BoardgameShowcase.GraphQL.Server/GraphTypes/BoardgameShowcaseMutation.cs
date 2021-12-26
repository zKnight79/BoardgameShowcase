using BoardgameShowcase.Common.Extensions;
using BoardgameShowcase.Model.Service;
using GraphQL.Types;

namespace BoardgameShowcase.GraphQL.Server.GraphTypes
{
    public partial class BoardgameShowcaseMutation : ObjectGraphType
    {
        private readonly IAuthorService _authorService;
        private readonly IIllustratorService _illustratorService;
        private readonly IPublisherService _publisherService;

        public BoardgameShowcaseMutation(IServiceProvider serviceProvider)
        {
            Name = nameof(BoardgameShowcaseMutation);
            Description = "Mutation for Boardgame Showcase";

            _authorService = serviceProvider.GetRequiredService<IAuthorService>();
            _illustratorService = serviceProvider.GetRequiredService<IIllustratorService>();
            _publisherService = serviceProvider.GetRequiredService<IPublisherService>();

            this.CallPrivateUnheritedParameterlessMethodsReturning(typeof(void));
        }
    }
}
