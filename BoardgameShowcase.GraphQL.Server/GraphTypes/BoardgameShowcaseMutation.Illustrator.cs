using BoardgameShowcase.Model.Entity;
using GraphQL;
using GraphQL.Types;

namespace BoardgameShowcase.GraphQL.Server.GraphTypes
{
    public partial class BoardgameShowcaseMutation
    {
        private void AddSaveIllustratorMutation()
        {
            Field<IllustratorType>(
                name: $"save{nameof(Illustrator)}",
                description: "Saves an illustrator",
                arguments: new()
                {
                    new QueryArgument<NonNullGraphType<IllustratorInputType>>()
                    {
                        Name = "inputIllustrator",
                        Description = "The illustrator to save",
                    }
                },
                resolve: context => _illustratorService.SaveAsync(context.GetArgument<Illustrator>("inputIllustrator"))
            );
        }

        private void AddRemoveIllustratorMutation()
        {
            Field<IllustratorType>(
                name: $"remove{nameof(Illustrator)}",
                description: "Removes an illustrator",
                arguments: new()
                {
                    new QueryArgument<NonNullGraphType<StringGraphType>>()
                    {
                        Name = "illustratorId",
                        Description = "The unique ID of the illustrator to remove",
                    }
                },
                resolve: context => _illustratorService.RemoveByIdAsync(context.GetArgument<string>("illustratorId"))
            );
        }
    }
}
