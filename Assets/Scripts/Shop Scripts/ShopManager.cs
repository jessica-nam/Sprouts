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

    GameObject SavedObjs; 
    public GameObject Player;

    private void Awake()
    {
        //Debug.Log(SavedObjs.gameObject.transform.Find("Player").gameObject.name);
        SavedObjs = SaveObject.savedObjs;
        Player = SavedObjs.gameObject.transform.Find("Player").gameObject;
    }

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
            if (coins >= shopItemsSO[i].baseCost) //if i have enough money
                myPurchaseBtns[i].interactable = true;
            else
                myPurchaseBtns[i].interactable = false;
        }
    }

    // run when "purchase" bttns pressed
    public void PurchaseItem(int btnNum)
    {
        if (coins >= shopItemsSO[btnNum].baseCost)
        {
            // update coin value
            coins = coins - shopItemsSO[btnNum].baseCost;
            coinUI.text = "Coins: " + coins.ToString();

            // add to player inventory
            var inventory = Player.GetComponent<InventoryHolder>(); // get player inventory
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
