using PlatformerDemo.Combat;
using PlatformerDemo.Movement;
using UnityEngine;

namespace PlatformerDemo.Animation
{
    public class AnimationHandler : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Mover _mover;
        [SerializeField] private Attacker _attaker;

        private void OnEnable()
        {
            _mover.MoveStateChanged += SetMoveState;
            _attaker.Attaked += TriggerAttack;
        }

        private void OnDisable()
        {
            _mover.MoveStateChanged -= SetMoveState;
            _attaker.Attaked -= TriggerAttack;
        }

        public void SetAnimationState(int id, float stateValue)
        {
            float currentState = _animator.GetFloat(id);

            if (currentState == stateValue)
                return;

            _animator.SetFloat(id, stateValue);
        }

        private void SetMoveState(float stateValue)
            => SetAnimationState(PlayerAnimatorData.Params.MoveState, stateValue);

        private void TriggerAttack()
            => TriggerState(PlayerAnimatorData.Params.AttackTrigger);

        private void TriggerState(int id)
            => _animator.SetTrigger(id);
    }
}

