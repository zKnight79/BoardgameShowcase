using BoardgameShowcase.Model.Service;
using GraphQL.Types;
using System.Reflection;

namespace BoardgameShowcase.GraphQL.Server.GraphTypes
{
    public partial class BoardgameShowcaseQuery : ObjectGraphType<object>
    {
        private readonly IAuthorService _authorService;
        private readonly IIllustratorService _illustratorService;
        private readonly IPublisherService _publisherService;

        public BoardgameShowcaseQuery(
            IAuthorService authorService,
            IIllustratorService illustratorService,
            IPublisherService publisherService
        )
        {
            Name = nameof(BoardgameShowcaseQuery);
            Description = "Query for Boardgame Showcase";

            _authorService = authorService;
            _illustratorService = illustratorService;
            _publisherService = publisherService;

            // Call private unherited instance parameterless methods returning void
            IEnumerable<MethodInfo> methods = GetType().GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(
                    x => x.DeclaringType == GetType()
                    && x.ReturnType == typeof(void)
                    && x.GetParameters().Length == 0
                );
            foreach (MethodInfo method in methods)
            {
                _ = method.Invoke(this, null);
            }
        }
    }
}
