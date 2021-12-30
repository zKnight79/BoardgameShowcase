namespace BoardgameShowcase.Common.Utility
{
    /// <summary>
    /// Provides utility methods for <see cref="IEnumerable{T}"/>.
    /// </summary>
    public static class EnumerableUtil
    {
        /// <summary>
        /// Creates a new <see cref="IEnumerable{T}"/> from instances of T.
        /// </summary>
        /// <typeparam name="T">The type of the collection to create.</typeparam>
        /// <param name="args">Instances of T.</param>
        /// <returns>A collection of T, that contains the non <see langword="null"/> arguments.</returns>
        public static IEnumerable<T> From<T>(params T?[] args)
        {
            return from arg in args
                   where arg is not null
                   select arg;
        }
    }
}
