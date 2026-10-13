using UnityEngine;

namespace PlatformerDemo
{
    public class PhysicalRestDetector : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigitbody;
        [SerializeField] private float _velocityThreshold = 0.01f;

        public bool IsResting()
             => _rigitbody.velocity.y < _velocityThreshold;
    }
}

