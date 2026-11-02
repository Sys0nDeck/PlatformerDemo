using UnityEngine;

namespace PlatformerDemo
{
    public class GroundRayDetector : MonoBehaviour
    {
        public bool IsGroundExist()
        {
            float distance = 0.2f;
            Vector2 origin = new Vector2(transform.position.x, transform.position.y);
            var hit = Physics2D.Raycast(origin, Vector2.down, distance);

            if (hit.collider != null && hit.collider.TryGetComponent<Ground>(out _))
                return true;
            else
                return false;
        }
    }
}

