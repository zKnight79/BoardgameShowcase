using BoardgameShowcase.Model.Entity;
using GraphQL;
using GraphQL.Types;

namespace BoardgameShowcase.GraphQL.Server.GraphTypes
{
    public partial class BoardgameShowcaseMutation
    {
        private void AddSavePublisherMutation()
        {
            Field<PublisherType>(
                name: $"save{nameof(Publisher)}",
                description: "Saves an publisher",
                arguments: new()
                {
                    new QueryArgument<NonNullGraphType<PublisherInputType>>()
                    {
                        Name = "inputPublisher",
                        Description = "The publisher to save",
                    }
                },
                resolve: context => _publisherService.SaveAsync(context.GetArgument<Publisher>("inputPublisher"))
            );
        }

        private void AddRemovePublisherMutation()
        {
            Field<PublisherType>(
                name: $"remove{nameof(Publisher)}",
                description: "Removes an publisher",
                arguments: new()
                {
                    new QueryArgument<NonNullGraphType<StringGraphType>>()
                    {
                        Name = "publisherId",
                        Description = "The unique ID of the publisher to remove",
                    }
                },
                resolve: context => _publisherService.RemoveByIdAsync(context.GetArgument<string>("publisherId"))
            );
        }
    }
}
