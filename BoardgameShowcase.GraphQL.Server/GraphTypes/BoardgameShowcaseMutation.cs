using BoardgameShowcase.Common.Extensions;
using BoardgameShowcase.Model.Service;
using GraphQL.Types;

namespace BoardgameShowcase.GraphQL.Server.GraphTypes
{
    public partial class BoardgameShowcaseMutation : ObjectGraphType
    {
        private readonly IAuthorService _authorService;

        public BoardgameShowcaseMutation(IServiceProvider serviceProvider)
        {
            Name = nameof(BoardgameShowcaseMutation);
            Description = "Mutation for Boardgame Showcase";

            _authorService = serviceProvider.GetRequiredService<IAuthorService>();

            this.CallPrivateUnheritedParameterlessMethodsReturning(typeof(void));
        }
    }
}
