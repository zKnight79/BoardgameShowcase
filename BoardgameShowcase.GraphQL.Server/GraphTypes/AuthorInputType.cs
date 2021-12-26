using BoardgameShowcase.Model.Entity;
using GraphQL.Types;

namespace BoardgameShowcase.GraphQL.Server.GraphTypes
{
    public class AuthorInputType : InputObjectGraphType<Author>
    {
        public AuthorInputType()
        {
            Name = $"{nameof(Author)}Input";
            Description = "Input type for author";

            Field(a => a.Id, nullable: true).Description("The unique identifier of the author");
            Field(a => a.Name).Description("The name of the author");
        }
    }
}
