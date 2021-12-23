using BoardgameShowcase.Model.Entity;
using GraphQL.Types;

namespace BoardgameShowcase.GraphQL.Server.GraphTypes
{
    public class AuthorType : ObjectGraphType<Author>
    {
        public AuthorType()
        {
            Name = nameof(Author);
            Description = "A boardgame author";

            Field(a => a.Id).Description("The unique identifier of the author");
            Field(a => a.Name).Description("The name of the author");
        }
    }
}
