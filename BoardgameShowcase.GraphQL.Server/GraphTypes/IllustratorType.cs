using BoardgameShowcase.Model.Entity;
using GraphQL.Types;

namespace BoardgameShowcase.GraphQL.Server.GraphTypes
{
    public class IllustratorType : ObjectGraphType<Illustrator>
    {
        public IllustratorType()
        {
            Name = nameof(Illustrator);
            Description = "A boardgame illustrator";

            Field(a => a.Id).Description("The unique identifier of the illustrator");
            Field(a => a.Name).Description("The name of the illustrator");
        }
    }
}
