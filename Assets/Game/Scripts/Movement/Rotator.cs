using UnityEngine;

namespace PlatformerDemo.Movement
{
    public class Rotator : MonoBehaviour
    {
        private float _currentRotateState;

        public void Rotate(float xAxis)
        {
            if (xAxis == 0)
                return;

            if (xAxis == _currentRotateState)
                return;

            _currentRotateState = xAxis;
            float rightDirection = 1f;

            if (xAxis == rightDirection)
                transform.rotation = GetRotationFromDirection(Vector3.right);
            else
                transform.rotation = GetRotationFromDirection(Vector3.left);
        }

        private Quaternion GetRotationFromDirection(Vector3 direction)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            return Quaternion.Euler(0f, angle, 0f);
        }
    }
}

