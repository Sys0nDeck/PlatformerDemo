using TMPro;
using UnityEngine;

public class TextHealthView : HealthView
{
    [SerializeField] private TMP_Text _text;

    private void Start()
    {
        UpdateText();
    }

    protected override void OnValueChanged()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        _text.text = $"{Health.CurrentHealth}/{Health.MaxHealth}";
    }
}
