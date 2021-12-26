using GraphQL;
using GraphQL.Types;

namespace BoardgameShowcase.GraphQL.Server.GraphTypes
{
    public partial class BoardgameShowcaseQuery
    {
        private void AddGetAllPublishersQuery()
        {
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<PublisherType>>>>(
                name: "publishers",
                description: "Get all publishers",
                resolve: context => _publisherService.GetAllAsync()
            );
        }
        private void AddGetPublisherByIdQuery()
        {
            Field<PublisherType>(
                name: "publisher",
                description: "Get publisher by ID",
                arguments: new()
                {
                    new QueryArgument<NonNullGraphType<StringGraphType>>()
                    {
                        Name = "id",
                        Description = "The unique ID of the publisher."
                    }
                },
                resolve: context => _publisherService.GetByIdAsync(context.GetArgument<string>("id"))
            );
        }
        private void AddGetPublisherByNameQuery()
        {
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<PublisherType>>>>(
                name: "publishersByName",
                description: "Get publishers containing name part",
                arguments: new()
                {
                    new QueryArgument<NonNullGraphType<StringGraphType>>()
                    {
                        Name = "namePart",
                        Description = "A part of the publisher name."
                    }
                },
                resolve: context => _publisherService.GetByNameAsync(context.GetArgument<string>("namePart"))
            );
        }
    }
}
