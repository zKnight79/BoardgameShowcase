namespace BoardgameShowcase.Common.Utility
{
    public static class StringUtil
    {
        public static string NewGuid() => $"{Guid.NewGuid():N}";
    }
}
