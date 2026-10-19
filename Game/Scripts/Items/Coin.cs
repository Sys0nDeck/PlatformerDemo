using UnityEngine;

namespace PlatformerDemo
{
    public class Coin : Item
    {
        public override void UseItem(Collider2D owner)
        {
            if (owner.TryGetComponent(out Wallet wallet))
            {
                wallet.AddCoin(1);
                Hide();
            }
        }
    }
}

