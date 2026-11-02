using System;
using UnityEngine;

namespace PlatformerDemo
{
    [RequireComponent(typeof(Collider2D))]
    public class AttackTriggerDetector : MonoBehaviour
    {
        public bool IsTargetInRange { get; private set; }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Player>(out _))
            {
                IsTargetInRange = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Player>(out _))
            {
                IsTargetInRange = false;
            }
        }
    }
}
