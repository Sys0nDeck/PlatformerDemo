using UnityEngine;

namespace PlatformerDemo.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Jumper : MonoBehaviour
    {
        [SerializeField] private GroundDetector _groundDetector;
        [SerializeField] private IdleDetector _idleDetector;
        private Rigidbody2D _rigitbody;
        private bool _canJump;

        private void Awake()
        {
            _rigitbody = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            _idleDetector.IdleStateChanged += SetJumpState;
        }

        private void OnDisable()
        {
            _idleDetector.IdleStateChanged -= SetJumpState;
        }

        public void Jump(float power)
        {
            if (_canJump)
            {
                _canJump = false;
                _rigitbody.AddForce(Vector2.up * power, ForceMode2D.Impulse);
            } 
        }

        private void SetJumpState(bool idleState)
            => _canJump = idleState;
    }
}

