using UnityEngine;

namespace PlatformerDemo.Animation
{
    public class VerticalMotionAnimator : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigitbody;
        [SerializeField] private AnimationHandler _animationHandler;

        private void FixedUpdate()
        {
            float verticalVelocity = _rigitbody.velocity.y;
            _animationHandler.SetAnimationState(PlayerAnimatorData.Params.VerticalState, verticalVelocity);
        }
    }
}


