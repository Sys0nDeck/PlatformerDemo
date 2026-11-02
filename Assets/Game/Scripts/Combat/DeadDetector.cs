using System;
using UnityEngine;

public class DeadDetector : MonoBehaviour
{
    [SerializeField] private Health _health;

    public event Action Dead;

    private void OnEnable()
    {
        _health.ValueChanged += CheckDeadStatus;
    }

    private void OnDisable()
    {
        _health.ValueChanged -= CheckDeadStatus;
    }

    private void CheckDeadStatus()
    {
        if (_health.CurrentHealth == 0)
            Dead?.Invoke();
    }
}
