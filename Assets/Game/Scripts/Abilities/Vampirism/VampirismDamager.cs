using PlatformerDemo.Combat;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerDemo.Ability
{
    public class VampirismDamager : MonoBehaviour
    {
        [SerializeField] private Health _health;

        public void TakeDamage(float damage, float radius)
        {
            var hits = GetHits(radius);
            var currentTarget = GetNearTarget(hits);

            if (currentTarget == null)
                return;

            float currentDamage = damage * Time.deltaTime;
            currentTarget.TakeDamage(currentDamage);
            _health.Heal(currentDamage);
        }

        private IDamagable GetNearTarget(List<Collider2D> hits)
        {
            IDamagable currentTraget = null;
            float minDistance = float.MaxValue;

            foreach (var hit in hits)
            {
                var currentDistance = GetSqrDistance(transform.position, hit.transform.position);

                if (minDistance == float.MaxValue || currentDistance < minDistance)
                {
                    minDistance = currentDistance;
                    currentTraget = hit.GetComponent<IDamagable>();
                }
            }

            return currentTraget;
        }

        private List<Collider2D> GetHits(float radius)
        {
            var hits = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), radius);
            var filteredHits = new List<Collider2D>();

            foreach (var hit in hits)
            {
                if ((_health.gameObject.Equals(hit.gameObject) == false) && hit.TryGetComponent<IDamagable>(out _))
                {
                    filteredHits.Add(hit);
                }
            }

            return filteredHits;
        }

        private float GetSqrDistance(Vector3 from, Vector3 to)
        {
            var offset = to - from;
            var sqrDistance = offset.sqrMagnitude;
            return sqrDistance;
        }
    }
}

