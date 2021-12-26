using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Model.Service;
using GraphQL.Types;

namespace BoardgameShowcase.GraphQL.Server.GraphTypes
{
    public class BoardgameType : ObjectGraphType<Boardgame>
    {
        public BoardgameType()
        {
            Name = nameof(Boardgame);
            Description = "A boardgame";

            Field(b => b.Id).Description("The unique identifier of the boardgame");
            Field(b => b.Title).Description("The title of the boardgame");
            Field(b => b.AuthorId).Description("The unique identifier of the boardgame's author");
            Field(
                name: nameof(Author),
                description: "The author of the boardgame",
                type: typeof(AuthorType),
                resolve: context => context.RequestServices
                                                                   .GetRequiredService<IAuthorService>()
                                                                   .GetByIdAsync(context.Source.AuthorId)
            );
            Field(b => b.IllustratorId).Description("The unique identifier of the boardgame's illustrator");
            Field(
                name: nameof(Illustrator),
                description: "The illustrator of the boardgame",
                type: typeof(IllustratorType),
                resolve: context => context.RequestServices
                                                                   .GetRequiredService<IIllustratorService>()
                                                                   .GetByIdAsync(context.Source.IllustratorId)
            );
            Field(b => b.PublisherId).Description("The unique identifier of the boardgame's publisher");
            Field(
                name: nameof(Publisher),
                description: "The publisher of the boardgame",
                type: typeof(PublisherType),
                resolve: context => context.RequestServices
                                                                   .GetRequiredService<IPublisherService>()
                                                                   .GetByIdAsync(context.Source.PublisherId)
            );
            Field(b => b.MinimumPlayerCount).Description("The minimum number of players required to play this boardgame");
            Field(b => b.MaximumPlayerCount).Description("The maximum number of players required to play this boardgame");
            Field(b => b.MinimumPlayerAge).Description("The minimum age required to play this boardgame");
            Field(b => b.ApproximateGameTimeInMinutes).Description("The average duration of a game of this boardgame in minutes");
            Field(b => b.Category).Description("The category of the boardgame");
            Field(b => b.Themes).Description("The themes of the boardgame");
            Field(b => b.Mechanisms).Description("The mechanisms of the boardgame");
        }
    }
}
