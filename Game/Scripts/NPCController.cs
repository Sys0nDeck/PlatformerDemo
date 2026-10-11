using PlatformerDemo.Movement;
using UnityEngine;

namespace PlatformerDemo
{
    public class NPCController : MonoBehaviour
    {
        [SerializeField] private Enemy _enemy;
        [SerializeField] private Mover _mover;
        [SerializeField] private Rotator _rotator;
        [SerializeField] private WaypointRouter _router;

        private Vector3 _currentTargetPosition;

        private void Start()
        {
            _router.Launch();
        }

        private void Update()
        {
            CorrectiveTarget(_router.CurrentWaypoint.transform.position);
            Move();
            Rotate();
        }

        private void Move()
        {
            _mover.Move(_currentTargetPosition, _enemy.Speed);
        }

        private void Rotate()
        {
            float xAxis = Vector3.Dot((_currentTargetPosition - transform.position).normalized, Vector3.right);
            _rotator.Rotate(xAxis);
        }

        private void CorrectiveTarget(Vector3 targetPosition)
        {
            _currentTargetPosition = new Vector3(targetPosition.x, transform.position.y, 0f);
        }

    }
}

