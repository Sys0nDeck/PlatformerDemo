using UnityEngine;
using UnityEngine.UI;

namespace PlatformerDemo.Ability
{
    public class VampirismView : MonoBehaviour
    {
        [SerializeField] private Transform _abilityEffect;
        [SerializeField] private Slider _slider;

        private void OnEnable()
        {
            HideEffect();
            HideBar();
        }

        private void OnDisable()
        {
            HideEffect();
            HideBar();
        }

        public void ShowEffect(float radius)
        {
            var diameter = radius * 2;
            _abilityEffect.localScale = new Vector3(1f, 1f, 0f) * diameter;
            _abilityEffect.gameObject.SetActive(true);
        }

        public void HideEffect()
        {
            _abilityEffect.gameObject.SetActive(false);
        }

        public void ShowBar()
        {
            _slider.gameObject.SetActive(true);
        }

        public void HideBar()
        {
            _slider.gameObject.SetActive(false);
        }

        public void UpdateBar(float currentState, float maxState)
        {
            _slider.value = currentState / maxState;
        }
    }
}

