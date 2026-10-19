using System;
using UnityEngine;

namespace PlatformerDemo
{
    public class DistanceDetector : MonoBehaviour
    {
        [SerializeField] private float _threshold = 0.2f;

        private Vector3 _targetPosition;
        private DistanceCounter _distanceCounter;

        public event Action TargetReached;

        public void Start()
        {
            _distanceCounter = new DistanceCounter();
        }

        private void Update()
        {
            CheckDistanceToTarget(_threshold);
        }

        public void SetTarget(Vector3 target)
        {
            Vector3 correctedTarget = new Vector3(target.x, transform.position.y, 0f);
            _targetPosition = correctedTarget;
        }

        private void CheckDistanceToTarget(float minDistance)
        {
            if (_distanceCounter.IsTargetReached(transform.position, _targetPosition, minDistance))
            {
                TargetReached?.Invoke();
            }
        }
    }
}

