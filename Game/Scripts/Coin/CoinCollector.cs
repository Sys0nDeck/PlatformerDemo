using UnityEngine;

namespace PlatformerDemo
{
    public class CoinCollector : MonoBehaviour
    {
        [SerializeField] private Collider2D _collider;
        [SerializeField] private int _currentCoins = 0;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Coin coin))
            {
                _currentCoins++;
                coin.Disappear();
            }
        }
    }
}

