using GraphQL;
using GraphQL.Types;

namespace BoardgameShowcase.GraphQL.Server.GraphTypes
{
    public partial class BoardgameShowcaseQuery
    {
        private void AddGetAllPublishersQuery()
        {
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<PublisherType>>>>(
                name: "Publishers",
                description: "Get all publishers",
                resolve: context => _publisherService.GetAllAsync()
            );
        }
        private void AddGetPublisherByIdQuery()
        {
            Field<PublisherType>(
                name: "Publisher",
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
        private void AddGetPublisherByName()
        {
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<PublisherType>>>>(
                name: "PublishersByName",
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
