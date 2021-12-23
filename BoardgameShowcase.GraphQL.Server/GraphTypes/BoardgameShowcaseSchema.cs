using GraphQL.Types;

namespace BoardgameShowcase.GraphQL.Server.GraphTypes
{
    public class BoardgameShowcaseSchema : Schema
    {
        public BoardgameShowcaseSchema(BoardgameShowcaseQuery boardgameShowcaseQuery)
        {
            Query = boardgameShowcaseQuery;
        }
    }
}
