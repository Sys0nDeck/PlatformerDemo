using System;
using UnityEngine;

namespace PlatformerDemo
{
    public class DistanceDetector : MonoBehaviour
    {
        [SerializeField] private float _threshold = 0.2f;

        private Vector3 _targetPosition;

        public event Action TargetReached;

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
            var sqrDistance = (_targetPosition - transform.position).sqrMagnitude;
            if (sqrDistance <= Mathf.Pow(minDistance, 2))
                TargetReached?.Invoke();
        }
    }
}

