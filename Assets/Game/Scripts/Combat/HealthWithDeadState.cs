using System;
using UnityEngine;

namespace PlatformerDemo.Combat
{
    public class HealthWithDeadState : Health
    {
        public event Action Dead;

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            UpdateDeadState();
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

