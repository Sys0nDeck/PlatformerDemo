using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _coinCount;

    public int Coin
        => _coinCount;

    public void AddCoin(int value)
    {
        _coinCount += value;
    }
}
