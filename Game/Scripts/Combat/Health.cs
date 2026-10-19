using System;
using UnityEngine;

namespace PlatformerDemo.Combat
{
    public class Health : MonoBehaviour, IDamagable
    {
        [SerializeField] private int _maxHealth;
        [SerializeField] private int _currentHealth;

        public event Action Dead;

        public int CurrentHealth
        {
            get 
            { 
                return _currentHealth; 
            }

            private set 
            {
                _currentHealth = value;

                if (_currentHealth > _maxHealth)
                    _currentHealth = _maxHealth;

                if (_currentHealth < 0)
                    _currentHealth = 0;
            }
        }

        private void Start()
        {
            CurrentHealth = _maxHealth;
        }

        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage;
            UpdateDeadState();
        }

        public void Heal(int healPoint)
        {
            CurrentHealth += healPoint;
        }

        private void UpdateDeadState()
        {
            if (CurrentHealth == 0)
            {
                Dead?.Invoke();
            }       
        }
    }
}

