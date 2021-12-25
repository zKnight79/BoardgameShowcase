using BoardgameShowcase.Model.Service;
using GraphQL.Types;
using System.Reflection;

namespace BoardgameShowcase.GraphQL.Server.GraphTypes
{
    public partial class BoardgameShowcaseQuery : ObjectGraphType<object>
    {
        private readonly IAuthorService _authorService;

        public BoardgameShowcaseQuery(IAuthorService authorService)
        {
            Name = nameof(BoardgameShowcaseQuery);
            Description = "Query for Boardgame Showcase";

            _authorService = authorService;

            // Call private unherited instance parameterless methods returning void
            IEnumerable<MethodInfo> methods = GetType().GetMethods(BindingFlags.Instance|BindingFlags.NonPublic)
                .Where(x => x.DeclaringType == GetType() && x.ReturnType == typeof(void) && x.GetParameters().Length == 0);
            foreach (MethodInfo method in methods)
            {
                _ = method.Invoke(this, null);
            }
        }
    }
}
