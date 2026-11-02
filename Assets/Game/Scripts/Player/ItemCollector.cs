using UnityEngine;

namespace PlatformerDemo
{
    public class ItemCollector : MonoBehaviour
    {
        [SerializeField] private Collider2D _collider;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Item item))
            {
                item.UseItem(_collider);
            }
        }
    }
}

