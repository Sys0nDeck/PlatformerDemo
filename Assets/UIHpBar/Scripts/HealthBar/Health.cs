using PlatformerDemo.Combat;
using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamagable
{
    [SerializeField] private float _maxHealth;
    
    private float _currentHealth;

    public event Action ValueChanged;

    public float CurrentHealth
    {
        get {  return _currentHealth; }
        private set { _currentHealth = Mathf.Clamp(value, 0, _maxHealth); }
    }

    public float MaxHealth
        => _maxHealth;

    private void Awake()
    {
        CurrentHealth = _maxHealth;
    }

    public virtual void TakeDamage(int damage)
    {
        if (damage <= 0)
            return;

        CurrentHealth -= damage;
        Notify();
    }

    public virtual void Heal(int healPoint)
    {
        if (healPoint <= 0)
            return;

        CurrentHealth += healPoint;
        Notify();
    }

    private void Notify()
    {
        ValueChanged?.Invoke();
    }
}
