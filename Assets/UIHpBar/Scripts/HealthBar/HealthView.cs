using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
    [SerializeField] protected Health Health;

    private void OnEnable()
    {
        Health.ValueChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        Health.ValueChanged -= OnValueChanged;
    }

    protected abstract void OnValueChanged();
}
