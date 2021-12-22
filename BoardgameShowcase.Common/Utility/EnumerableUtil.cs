namespace BoardgameShowcase.Common.Utility
{
    public static class EnumerableUtil
    {
        public static IEnumerable<T> From<T>(params T?[] args)
        {
            return from arg in args
                   where arg is not null
                   select arg;
        }
    }
}
