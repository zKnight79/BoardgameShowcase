namespace BoardgameShowcase.Common.Extensions
{
    /// <summary>
    /// Provides extension methods for <see cref="IEnumerable{T}"/>.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Creates a string that represent the collection,
        /// by joining string representations with an optional separator.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="source">The collection to join as string.</param>
        /// <param name="separator">
        /// A separator to use between the elements of the collection,
        /// <see langword="null"/> if unset.
        /// </param>
        /// <returns>
        /// A string that represent the collection,
        /// or <see cref="string.Empty"/> if the collection is empty.
        /// </returns>
        public static string JoinAsString<T>(this IEnumerable<T> source, string? separator = null)
        {
            return string.Join(separator, source);
        }
    }
}
