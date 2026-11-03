using PlatformerDemo;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCountView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Wallet _wallet;

    private void OnEnable()
    {
        _wallet.Collected += UpdateText;
    }

    private void OnDisable()
    {
        _wallet.Collected -= UpdateText;
    }

    private void UpdateText()
    {
        _text.text = _wallet.Coin.ToString();
    }
}
