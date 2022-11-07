using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public int coins = 100;
    public TMP_Text coinUI;
    public ShopItemSO[] shopItemsSO;
    public GameObject[] shopPanelsGO;
    public ShopTemplate[] shopPanels;
    public Button[] myPurchaseBtns;

   // public InventorySystem InvSysMgr;
    public Player PlayerMgr;
    public InventorySlot_UI InvSlotUIMgr;

    void Start()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanelsGO[i].SetActive(true);
        }
        coinUI.text = "Coins: " + coins.ToString();
        LoadPanels();
        CheckPurchaseable();
    }

    public void AddCoins()
    {
        coins++;
        coinUI.text = "Coins: " + coins.ToString();
        CheckPurchaseable();
    }

    public void CheckPurchaseable()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            if (coins >= shopItemsSO[i].baseCost) //if i have enough money.
                myPurchaseBtns[i].interactable = true;
            else
                myPurchaseBtns[i].interactable = false;
        }
    }

    public void PurchaseItem(int btnNum)
    {
        if (coins >= shopItemsSO[btnNum].baseCost)
        {
            coins = coins - shopItemsSO[btnNum].baseCost;
            coinUI.text = "Coins: " + coins.ToString();

            // add to inventory
            var inventory = PlayerMgr.GetComponent<InventoryHolder>();
            inventory.InventorySystem.AddToInventory(shopItemsSO[btnNum], 1);
            InvSlotUIMgr.UpdateUISlot();


            CheckPurchaseable();
        }
    }

    public void LoadPanels()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanels[i].titleTxt.text = shopItemsSO[i].title;
            shopPanels[i].descriptionTxt.text = shopItemsSO[i].description;
            shopPanels[i].costTxt.text = "Coins: " + shopItemsSO[i].baseCost.ToString();
            shopPanels[i].image.sprite = shopItemsSO[i].icon;
        }
    }
}
