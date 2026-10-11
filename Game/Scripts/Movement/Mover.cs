using System;
using UnityEngine;

namespace PlatformerDemo.Movement
{
    public class Mover : MonoBehaviour
    {
        private float _currentState;

        public event Action<float> MoveStateChanged;

        public void Move(Vector3 direction, float speed)
        {
            transform.position = Vector3.MoveTowards(transform.position, direction, speed * Time.deltaTime);

            Vector3 offset = Vector3.Normalize(direction - transform.position);
            var state = Mathf.Abs(Vector3.Dot(Vector3.right, offset));

            if (_currentState != state)
            {
                _currentState = state;
                MoveStateChanged?.Invoke(_currentState);
            }
        }
    }
}

