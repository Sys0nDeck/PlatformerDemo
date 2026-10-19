using UnityEngine;

namespace PlatformerDemo
{
    public class DistanceCounter
    {
        public bool IsTargetReached(Vector3 origin, Vector3 target, float minDistance)
        {
            var sqrDistance = (target - origin).sqrMagnitude;
            return sqrDistance <= Mathf.Pow(minDistance, 2);
        }
    }
}

