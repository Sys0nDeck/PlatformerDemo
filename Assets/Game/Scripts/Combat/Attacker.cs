using System;
using System.Collections;
using UnityEngine;

namespace PlatformerDemo.Combat
{
    public class Attacker : MonoBehaviour
    {
        [SerializeField] private int _attackDamage;
        [SerializeField] private float _range;
        [SerializeField] private float _attackDelay;
        [SerializeField] private float _timeBeforeDamage;

        private Coroutine _attackDelayCoroutine;
        private bool _isAttackAvaiable;

        public event Action Attaked;

        private void Start()
        {
            _isAttackAvaiable = true;
        }

        private void OnDisable()
        {
            if (_attackDelayCoroutine != null)
                StopCoroutine( _attackDelayCoroutine );
        }

        public void Attack()
        {
            if (_isAttackAvaiable == false)
                return;

            var hits = GetHits();

            StartCoroutine(TakeDamageWithDelay(hits, _timeBeforeDamage));
            Attaked?.Invoke();
            _isAttackAvaiable = false;
            StartAttackDelay();
        }

        private void TakeDamageHittedObjects(RaycastHit2D[] hits)
        {
            foreach (var hit in hits)
            {
                if (this.gameObject.Equals(hit.collider.gameObject) == false && hit.collider.TryGetComponent(out IDamagable damagableObject))
                {
                    damagableObject.TakeDamage(_attackDamage);
                }
            }
        }

        private RaycastHit2D[] GetHits()
        {
            return Physics2D.LinecastAll(transform.position, transform.position + transform.right * _range);
        }

        private void StartAttackDelay()
        {
            if (_attackDelayCoroutine != null)
                StopCoroutine(_attackDelayCoroutine);

            _attackDelayCoroutine = StartCoroutine(DelayAttack(_attackDelay));
        }

        private IEnumerator DelayAttack(float delay)
        {
            yield return new WaitForSecondsRealtime(delay);
            _isAttackAvaiable = true;
        }

        private IEnumerator TakeDamageWithDelay(RaycastHit2D[] hits, float timeDelay)
        {
            yield return new WaitForSecondsRealtime(timeDelay);
            TakeDamageHittedObjects(hits);
        }
    }
}

