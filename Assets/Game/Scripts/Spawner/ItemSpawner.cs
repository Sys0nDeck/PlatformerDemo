using System.Collections.Generic;
using UnityEngine;

namespace PlatformerDemo
{
    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField] private List<Item> _prefabs;
        [SerializeField] private RayPositioner _rayPositioner;
        [SerializeField] private int _maxSpawnItemCount = 20;

        private void Start()
        {
            ReplaceItems();
        }

        private void ReplaceItems()
        {
            for (int i = 0; i < _maxSpawnItemCount; i++)
            {
                var prefab = _prefabs[Random.Range(0, _prefabs.Count)];
                Vector3 point = _rayPositioner.GetRandomSpawnPosition();

                if (IsExistedItemNearby(new Vector2(point.x, point.y)) == false)
                    Spawn(prefab, point);
            }
        }

        private void Spawn(Item prefab, Vector3 point)
        {
            Instantiate(prefab, point, Quaternion.identity);
        }

        private bool IsExistedItemNearby(Vector2 point)
        {
            float radius = 0.5f;
            var hits = Physics2D.CircleCastAll(point, radius, Vector2.down);

            foreach (var hit in hits)
            {
                if (hit.collider.TryGetComponent<Item>(out _))
                {
                    return true;
                }
            }

            return false;
        }
    }
}

