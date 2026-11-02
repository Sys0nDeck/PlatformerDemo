using System;
using UnityEngine;

namespace PlatformerDemo
{
    [RequireComponent(typeof(Collider2D))]
    public class PlayerDetector : MonoBehaviour
    {
        private Collider2D _visionCollider;

        public event Action<Transform> Spotted;
        public event Action Losted;

        private void Awake()
        {
            _visionCollider = GetComponent<Collider2D>();
        }

        private void Start()
        {
            _visionCollider.isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Player>(out _))
            {
                Spotted?.Invoke(collision.transform);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Player>(out _))
            {
                Losted?.Invoke();
            }
        }
    }
}

