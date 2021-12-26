using BoardgameShowcase.Model.Entity;
using GraphQL.Types;

namespace BoardgameShowcase.GraphQL.Server.GraphTypes
{
    public class BoardgameInputType : InputObjectGraphType<Boardgame>
    {
        public BoardgameInputType()
        {
            Name = $"{nameof(Boardgame)}Input";
            Description = "Input type for boardgame";

            Field(i => i.Id, nullable: true).Description("The unique identifier of the boardgame");
            Field(i => i.Title).Description("The title of the boardgame");
            Field(i => i.AuthorId).Description("The unique identifier of the boardgame's author");
            Field(i => i.IllustratorId).Description("The unique identifier of the boardgame's illustrator");
            Field(i => i.PublisherId).Description("The unique identifier of the boardgame's publisher");
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
