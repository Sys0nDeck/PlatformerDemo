using UnityEngine;

namespace PlatformerDemo.Combat
{
    public class MedKit : Item
    {
        [SerializeField] private int _healPoint = 20;

        public override void UseItem(Collider2D owner)
        {
            if (owner.TryGetComponent(out Health health))
            {
                health.Heal(_healPoint);
                Hide();
            }
        }
    }
}

