namespace BoardgameShowcase.Common.Extensions
{
    public static class ListExtensions
    {
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
