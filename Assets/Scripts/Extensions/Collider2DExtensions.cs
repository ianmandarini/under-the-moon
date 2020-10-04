using UnityEngine;

namespace Extensions
{
    public static class Collider2DExtensions
    {
        public static bool IsPlayer(this Collider2D target)
        {
            return target.CompareTag(Constants.PlayerTag);
        }
    }
}