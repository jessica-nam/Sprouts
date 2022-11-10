using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    
    public ShopItemSO[] shopItemsSO;
    public GameObject[] shopPanelsGO;
    public ShopTemplate[] shopPanels;
    public Button[] myPurchaseBtns;

    GameObject SavedObjs; 
    private GameObject invHolder;
    private CoinMgr coinMgr;
  //  CoinMgr cm;

    private void Awake()
    {
        //Debug.Log(SavedObjs.gameObject.transform.Find("Player").gameObject.name);
        SavedObjs = SaveObject.savedObjs;
        invHolder = SavedObjs.gameObject.transform.Find("Inventory Holder").gameObject;
        coinMgr = SavedObjs.gameObject.transform.Find("Coin UI").gameObject.GetComponent<CoinMgr>();// GetComponent<TMP_Text>();
       // cm = coinMgr.GetComponent<CoinMgr>();
        //coins = coins
    }

    void Start()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanelsGO[i].SetActive(true);
        }
        coinMgr.coinUI.text = "Coins: " + coinMgr.coins.ToString();
        //coins.transform = coins;
        LoadPanels();
        CheckPurchaseable();
    }

    //public void AddCoins()
    //{
    //    coins++;
    //    coinUI.text = "Coins: " + coins.ToString();
    //    CheckPurchaseable();
    //}

    // turns buttons off if not enough money to purchase item
    public void CheckPurchaseable()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            if (coinMgr.coins >= shopItemsSO[i].baseCost) //if i have enough money
                myPurchaseBtns[i].interactable = true;
            else
                myPurchaseBtns[i].interactable = false;
        }
    }

    // run when "purchase" bttns pressed
    public void PurchaseItem(int btnNum)
    {
        if (coinMgr.coins >= shopItemsSO[btnNum].baseCost)
        {
            // update coin value
            coinMgr.coins = coinMgr.coins - shopItemsSO[btnNum].baseCost;
            coinMgr.coinUI.text = "Coins: " + coinMgr.coins.ToString();

            // add to player inventory
            var inventory = invHolder.GetComponent<InventoryHolder>(); // get player inventory
            inventory.InventorySystem.AddToInventory(shopItemsSO[btnNum], 1); // add item to it

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
