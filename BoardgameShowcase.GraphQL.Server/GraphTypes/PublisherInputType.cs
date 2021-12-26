using BoardgameShowcase.Model.Entity;
using GraphQL.Types;

namespace BoardgameShowcase.GraphQL.Server.GraphTypes
{
    public class PublisherInputType : InputObjectGraphType<Publisher>
    {
        public PublisherInputType()
        {
            Name = $"{nameof(Publisher)}Input";
            Description = "Input type for publisher";

            Field(i => i.Id, nullable: true).Description("The unique identifier of the publisher");
            Field(i => i.Name).Description("The name of the publisher");
        }
    }
}
