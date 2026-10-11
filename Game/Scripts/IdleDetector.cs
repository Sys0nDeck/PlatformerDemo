using System;
using UnityEngine;

namespace PlatformerDemo
{
    public class IdleDetector : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigitbody;
        [SerializeField] private GroundDetector _groundDetector;
        [SerializeField] private float _velocityThreshold = 0.01f;

        private bool _isIdle;

        public event Action<bool> IdleStateChanged;

        private void OnEnable()
        {
            _groundDetector.GroundStateChanged += CheckIdleState;
        }

        private void OnDisable()
        {
            _groundDetector.GroundStateChanged -= CheckIdleState;
        }

        private void FixedUpdate()
        {
            CheckIdleState(_groundDetector.IsGrounded);
        }

        private void CheckIdleState(bool isGrounded)
        {
            bool isVelocityZero = _rigitbody.velocity.y < _velocityThreshold;
            bool newIdleState = isGrounded && isVelocityZero;

            if (newIdleState != _isIdle)
            {
                _isIdle = newIdleState;
                IdleStateChanged?.Invoke(_isIdle);
            }
        }
    }
}

