using System.Collections;
using UnityEngine;

namespace PlatformerDemo.Ability
{
    public class Vampirism : AbilityView
    {
        [SerializeField] private VampirismDamager _damager;
        [SerializeField] private VampirismView _view;
        [SerializeField] private float _damage;
        [SerializeField] private float _duration;
        [SerializeField] private float _radius;

        private Coroutine _abilityCoroutine;

        private void OnEnable()
        {
            IsCooldown = false;
        }

        private void OnDisable()
        {
            if (_abilityCoroutine != null)
            {
                StopCoroutine(_abilityCoroutine);
                _abilityCoroutine = null;
            }
        }

        protected override void CastSpell()
        {
            _abilityCoroutine = StartCoroutine(StartAbility());
        }

        private IEnumerator StartAbility()
        {
            IsCooldown = true;
            float elapsedTime = _duration;

            _view.ShowBar();
            _view.ShowEffect(_radius);

            while(elapsedTime > 0)
            {
                _damager.TakeDamage(_damage, _radius);
                _view.UpdateBar(elapsedTime, _duration);
                elapsedTime -= Time.deltaTime;
                yield return null;
            }

            _view.HideEffect();

            float cooldownTime = 0;

            while(cooldownTime < Cooldown)
            {
                _view.UpdateBar(cooldownTime, Cooldown);
                cooldownTime += Time.deltaTime;
                yield return null;
            }

            _view.HideBar();
            IsCooldown = false;
        }
    }
}

