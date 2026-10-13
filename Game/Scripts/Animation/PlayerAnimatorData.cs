using UnityEngine;

namespace PlatformerDemo.Animation
{
    public static class PlayerAnimatorData
    {
        public static class Params
        {
            public static readonly int MoveState = Animator.StringToHash(nameof(MoveState));
            public static readonly int VerticalState = Animator.StringToHash(nameof(VerticalState));
        }
    }
}

