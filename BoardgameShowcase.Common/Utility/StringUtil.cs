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
    }
}
