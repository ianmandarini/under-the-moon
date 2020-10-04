using UnityEngine;

namespace Extensions
{
    public static class FloatExtensions
    {
        public static float Magnitude(this float target)
        {
            return Mathf.Abs(target);
        }
    }
}