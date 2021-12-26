using GraphQL.Types;

namespace BoardgameShowcase.GraphQL.Server.GraphTypes
{
    public class BoardgameShowcaseSchema : Schema
    {
        public BoardgameShowcaseSchema(
            BoardgameShowcaseQuery boardgameShowcaseQuery,
            BoardgameShowcaseMutation boardgameShowcaseMutation,
            BoardgameShowcaseSubscription boardgameShowcaseSubscription
        )
        {
            Query = boardgameShowcaseQuery;
            Mutation = boardgameShowcaseMutation;
            Subscription = boardgameShowcaseSubscription;
        }
    }
}
