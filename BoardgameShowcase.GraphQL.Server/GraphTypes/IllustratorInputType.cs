using BoardgameShowcase.Model.Entity;
using GraphQL.Types;

namespace BoardgameShowcase.GraphQL.Server.GraphTypes
{
    public class IllustratorInputType : InputObjectGraphType<Illustrator>
    {
        public IllustratorInputType()
        {
            Name = $"{nameof(Illustrator)}Input";
            Description = "Input type for illustrator";

            Field(i => i.Id, nullable: true).Description("The unique identifier of the illustrator");
            Field(i => i.Name).Description("The name of the illustrator");
        }
    }
}
