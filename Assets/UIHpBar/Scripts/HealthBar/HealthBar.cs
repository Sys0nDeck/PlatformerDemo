using UnityEngine;
using UnityEngine.UI;

public class HealthBar : HealthView
{
    [SerializeField] private Slider _slider;

    private void Start()
    {
        ChangeSliderValue();
    }

    protected override void OnValueChanged()
    {
        ChangeSliderValue();
    }

    private void ChangeSliderValue()
    {
        _slider.value = Health.CurrentHealth / Health.MaxHealth;
    }
}
