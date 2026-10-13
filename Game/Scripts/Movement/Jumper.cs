using System;
using UnityEngine;

namespace PlatformerDemo.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Jumper : MonoBehaviour
    {
        [SerializeField] private GroundDetector _groundDetector;
        [SerializeField] private PhysicalRestDetector _restDetector;
        [SerializeField] private float _jumpPower;

        private Rigidbody2D _rigitbody;

        private void Awake()
        {
            _rigitbody = GetComponent<Rigidbody2D>();
        }

        public void Jump()
        {
            if (IsJumpAvaiable())
                _rigitbody.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);  
        }

        private bool IsJumpAvaiable()
            => _groundDetector.IsContact() && _restDetector.IsResting();
    }
}

