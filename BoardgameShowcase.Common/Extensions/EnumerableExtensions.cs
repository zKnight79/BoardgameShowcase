namespace BoardgameShowcase.Common.Extensions
{
    public static class EnumerableExtensions
    {
        public static string JoinAsString<T>(this IEnumerable<T> source, string? separator = null)
        {
            return string.Join(separator, source);
        }
    }
}
