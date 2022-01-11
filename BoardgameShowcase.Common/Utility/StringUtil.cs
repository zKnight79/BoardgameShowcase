namespace BoardgameShowcase.Common.Utility
{
    /// <summary>
    /// Provides utility methods for strings.
    /// </summary>
    public static class StringUtil
    {
        /// <summary>
        /// Create a new GUID (uppercase with no hyphens).
        /// </summary>
        /// <returns>A new GUID.</returns>
        public static string NewGuid() => $"{Guid.NewGuid():N}";

        /// <summary>
        /// Generate a <see cref="string"/> by separating non null <see cref="string"/> or white space arguments with a separator.
        /// </summary>
        /// <param name="separator">The separator used to separate the  <see cref="string"/> arguments.</param>
        /// <param name="args">The  <see cref="string"/> arguments.</param>
        /// <returns>The newly generated <see cref="string"/>.</returns>
        public static string JoinNonNullOrWhiteSpace(string separator, params string?[] args)
            => string.Join(separator, args.Where(str => !string.IsNullOrWhiteSpace(str)));
    }
}
