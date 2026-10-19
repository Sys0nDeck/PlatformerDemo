using PlatformerDemo.Combat;
using PlatformerDemo.Movement;
using UnityEngine;

namespace PlatformerDemo
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Mover _mover;
        [SerializeField] private Rotator _rotator;
        [SerializeField] private Health _health;
        [SerializeField] private Attacker _attaker;
        [SerializeField] private TargetSwitcher _targetSwither;
        [SerializeField] private AttackTriggerDetector _attackTrigger;
        [SerializeField] private GroundRayDetector _groundRayDetector;

        private Vector3 _currentTargetPosition;

        private void OnEnable()
        {
            _health.Dead += Die;
        }

        private void OnDisable()
        {
            _health.Dead -= Die;
        }

        private void Update()
        {
            CorrectiveTarget(_targetSwither.CurrentTarget.position);
            Move();
            Rotate();

            if (_attackTrigger.IsTargetInRange)
                Attack();
        }

        private void Move()
        {
            if( (_attackTrigger.IsTargetInRange == false) && _groundRayDetector.IsGroundExist()) 
                _mover.Move(_currentTargetPosition);
            else
                _mover.Move(transform.position);
        }

        private void Rotate()
        {
            float xAxis = Vector3.Dot((_currentTargetPosition - transform.position).normalized, Vector3.right);
            _rotator.Rotate(xAxis);
        }

        private void Attack()
        {
            _attaker.Attack();
        }

        private void CorrectiveTarget(Vector3 targetPosition)
        {
            _currentTargetPosition = new Vector3(targetPosition.x, transform.position.y, 0f);
        }

        private void Die()
        {
            gameObject.SetActive(false);
        }
    }
}

