using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinMgr : MonoBehaviour
{
    public int coins;
    public TMP_Text coinUI;

    private void Awake()
    {
        UpdateCoinUI();
    }

    public void UpdateCoinUI()
    {
        coinUI.text = "Coins: " + coins.ToString();
    }

    public void AddCoins(int amount)
    {
        coins = coins + amount;
        UpdateCoinUI();
    }
}
