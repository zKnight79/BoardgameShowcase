namespace BoardgameShowcase.Common.Extensions
{
    /// <summary>
    /// Provides extension methods for <see cref="List{T}"/>.
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// Replaces the values of a <see cref="List{T}"/> by a new collection.
        /// Do nothing if the new collection is the same as the current.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="list">The <see cref="List{T}"/> that should receive a new collection of values.</param>
        /// <param name="values">The new collection of values.</param>
        public static void SetValues<T>(this List<T> list, IEnumerable<T> values)
        {
            if (list != values)
            {
                list.Clear();
                list.AddRange(values);
            }
        }
    }
}
