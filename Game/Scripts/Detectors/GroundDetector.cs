using System.Collections.Generic;
using UnityEngine;

namespace PlatformerDemo
{
    public class GroundDetector : MonoBehaviour
    {
        [SerializeField] private Collider2D _collider;

        public bool IsContact()
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

