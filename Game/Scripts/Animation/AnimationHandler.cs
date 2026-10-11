using PlatformerDemo.Movement;
using System;
using UnityEngine;

namespace PlatformerDemo.Animation
{
    public class AnimationHandler : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private IdleDetector _idleDetector;
        [SerializeField] private Mover _mover;

        private void OnEnable()
        {
            if (_idleDetector != null)
                _idleDetector.IdleStateChanged += SetGroundTrigger;

            if (_mover != null)
                _mover.MoveStateChanged += SetMoveState;
        }

        private void OnDisable()
        {
            if (_idleDetector != null)
                _idleDetector.IdleStateChanged -= SetGroundTrigger;

            if (_mover != null)
                _mover.MoveStateChanged -= SetMoveState;
        }

        public void SetAnimationState(int id, float stateValue)
        {
            float currentState = _animator.GetFloat(id);

            if (currentState == stateValue)
                return;

            _animator.SetFloat(id, stateValue);
        }

        public void TriggerState(int id)
            => _animator.SetTrigger(id);

        private void SetGroundTrigger(bool isGrounded)
        {
            if (isGrounded)
                TriggerState(PlayerAnimatorData.Params.GroundTrigger);
        }

        private void SetMoveState(float stateValue)
            => SetAnimationState(PlayerAnimatorData.Params.MoveState, stateValue);
    }
}

