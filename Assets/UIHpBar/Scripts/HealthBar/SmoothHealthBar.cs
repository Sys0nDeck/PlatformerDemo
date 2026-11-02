using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthBar : HealthView
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _deltaSpeed;

    private Coroutine _lineBarCoroutine;

    private void Start()
    {
        _slider.value = GetSliderValue();
    }

    private void OnDisable()
    {
        if (_lineBarCoroutine != null)
            StopCoroutine(_lineBarCoroutine);
    }

    protected override void OnValueChanged()
    {
        float currentValue = GetSliderValue();

        if (_lineBarCoroutine != null)
            StopCoroutine(_lineBarCoroutine);

        if (gameObject.activeInHierarchy)
            _lineBarCoroutine = StartCoroutine(SlideLineBar(currentValue));
    }

    private float GetSliderValue()
        => Health.CurrentHealth / Health.MaxHealth;

    private IEnumerator SlideLineBar(float target)
    {
        float startValue = _slider.value;
        float delta = 0;

        while (delta < 1)
        {
            delta += Time.deltaTime * _deltaSpeed;
            _slider.value = Mathf.Lerp(startValue, target, delta);
            yield return null;
        }
    }
}
