using System.Collections.Generic;

namespace Extensions
{
    public static class ListExtensions
    {
        public static bool HasIndex<T>(this List<T> target, int index)
        {
            return index< 0 || index >= target.Count;
        }
    }
}