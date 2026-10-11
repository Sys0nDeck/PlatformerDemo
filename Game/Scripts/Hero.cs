using UnityEngine;

namespace PlatformerDemo
{
    public class Hero : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpPower;

        public float Speed => _speed;
        public float JumpPower => _jumpPower;
    }
}

