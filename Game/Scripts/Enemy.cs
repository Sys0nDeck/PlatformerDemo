using UnityEngine;

namespace PlatformerDemo
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float _speed = 2f;

        public float Speed => _speed;
    }
}

