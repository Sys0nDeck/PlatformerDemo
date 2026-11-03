using UnityEngine;

namespace PlatformerDemo.Ability
{
    public abstract class AbilityView : MonoBehaviour
    {
        [SerializeField] protected float Cooldown;

        protected bool IsCooldown;

        public void Activate()
        {
            if (IsCooldown == false)
                CastSpell();
        }

        protected abstract void CastSpell();
    }
}

