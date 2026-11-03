using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _coinCount;

    public event Action Collected;

    public int Coin
        => _coinCount;

    public void AddCoin(int value)
    {
        _coinCount += value;
        Collected?.Invoke();
    }
}
