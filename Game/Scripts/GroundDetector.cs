using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerDemo
{
    public class GroundDetector : MonoBehaviour
    {
        [SerializeField] private Collider2D _collider;

        private bool _isGrounded;

        public event Action<bool> GroundStateChanged;

        public bool IsGrounded => _isGrounded;

        private void Update()
        {
            CheckGroundState();
        }

        private void CheckGroundState()
        {
            var newGroundState = IsContact();

            if (_isGrounded != newGroundState)
            {
                _isGrounded = newGroundState;
                GroundStateChanged?.Invoke(_isGrounded);
            }
        }

        private bool IsContact()
        {
            var hits = new List<Collider2D>();
            _collider.GetContacts(hits);

            foreach (var hit in hits)
                if (hit.TryGetComponent<Ground>(out _))
                    return true;

            return false;
        }
    }
}

