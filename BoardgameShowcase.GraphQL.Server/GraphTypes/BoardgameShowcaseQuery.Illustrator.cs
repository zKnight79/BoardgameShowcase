using GraphQL;
using GraphQL.Types;

namespace BoardgameShowcase.GraphQL.Server.GraphTypes
{
    public partial class BoardgameShowcaseQuery
    {
        private void AddGetAllIllustratorsQuery()
        {
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<IllustratorType>>>>(
                name: "illustrators",
                description: "Get all illustrators",
                resolve: context => _illustratorService.GetAllAsync()
            );
        }
        private void AddGetIllustratorByIdQuery()
        {
            Field<IllustratorType>(
                name: "illustrator",
                description: "Get illustrator by ID",
                arguments: new()
                {
                    new QueryArgument<NonNullGraphType<StringGraphType>>()
                    {
                        Name = "id",
                        Description = "The unique ID of the illustrator."
                    }
                },
                resolve: context => _illustratorService.GetByIdAsync(context.GetArgument<string>("id"))
            );
        }
        private void AddGetIllustratorByName()
        {
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<IllustratorType>>>>(
                name: "illustratorsByName",
                description: "Get illustrators containing name part",
                arguments: new()
                {
                    new QueryArgument<NonNullGraphType<StringGraphType>>()
                    {
                        Name = "namePart",
                        Description = "A part of the illustrator name."
                    }
                },
                resolve: context => _illustratorService.GetByNameAsync(context.GetArgument<string>("namePart"))
            );
        }
    }
}
