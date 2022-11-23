using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using Random = System.Random;
using System.Linq;
using UnityEngine.EventSystems;

public class ShopManager : MonoBehaviour
{
    public ShopItemSO[] shopItemsSO;
    public GameObject[] shopPanelsGO;
    public ShopTemplate[] shopPanels;
    public Button[] purchaseBtns;
    public List<Sprite> possibleIcons;
    public GameObject sellTemplate;

    GameObject SavedObjs; 
    private GameObject invHolder;
    private CoinMgr coinMgr;
    private MouseItemData mouseObj;
    private GameObject hotbarBG;

    public SellItem sellMgr;
    public Button buyBtn;
    public Button sellBtn;

    Transform childFound = null;

    public List<Attribute> possibleAttrs;

    private void Awake()
    {
        // instantiate saved objects
        SavedObjs = SaveObject.savedObjs; 

        invHolder = SavedObjs.gameObject.transform.Find("Inventory Holder").gameObject;
        coinMgr = SavedObjs.gameObject.transform.Find("Coin UI").gameObject.GetComponent<CoinMgr>();
        mouseObj = SavedObjs.gameObject.transform.Find("Mouse Object").gameObject.GetComponent<MouseItemData>();
    }

    void Start()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanelsGO[i].SetActive(true);
        }
        LoadPanels();
        CheckPurchaseable();
    }

    private void Update()
    {
        CheckIfSelling();
    }
    
    public void CheckIfSelling()
    {
        var results = mouseObj.getObjectsClickedOn();
        foreach (var result in results)
        {
            if (result.gameObject.name == "Shop" && mouseObj.hasItem && Mouse.current.leftButton.wasPressedThisFrame) // if item on mouse and player clicks on shop canvas
            {
                DisplayShopSell(); // swap to sell view
                DisplayItemsToSell(); // add template for every item dragged onto sell view
                mouseObj.ClearSlot(); // destroy item on mouse
            }
        }
    }
    
    public void DisplayShopSell()
    {
        // remove instructions text
        Transform instructions = CustomFindChild("Instructions Txt", this.transform);
        instructions.gameObject.SetActive(false);

        // show sell view
        sellBtn.onClick.Invoke();
    }

    public void DisplayItemsToSell()
    {
        Transform parentTransform = CustomFindChild("Templates Container", this.transform);
        if (parentTransform)
        {
            GameObject newItemToSell = Instantiate(sellTemplate, parentTransform); // instantiate new templates as children of that obj
            sellMgr.UpdateItemToSell(mouseObj.getCurrentMouseItem().ItemData, mouseObj.getCurrentMouseItem().StackSize, newItemToSell);
        }
        else
        {
            Debug.Log("Error: Cannot find object 'Templates Container'. Did you rename it?");
        }
    }

    Transform CustomFindChild(string key, Transform parent)
    {
        childFound = null; // reset

        // search through object tree for given object name
        foreach (Transform child in parent)
        {
            if (child.name == key)
            {
                childFound = child;
            }
            else
            {
                if (child.childCount > 0)
                {
                    if (childFound == null)
                    {
                        CustomFindChild(key, child);
                    }
                }
            }
        }
  
        return childFound;
    }

    // turns buttons off if not enough money to purchase item
    public void CheckPurchaseable()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            if (coinMgr.coins >= shopItemsSO[i].cost) //if i have enough money
                purchaseBtns[i].interactable = true;
            else
                purchaseBtns[i].interactable = false;
        }
    }

    // run when "purchase" bttns pressed
    public void PurchaseItem(int btnNum)
    {
        if (coinMgr.coins >= shopItemsSO[btnNum].cost)
        {
            // update coin value
            coinMgr.coins = coinMgr.coins - shopItemsSO[btnNum].cost;
            coinMgr.UpdateCoinUI();

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
            // set in inspector
            shopPanels[i].titleTxt.text = shopItemsSO[i].title;
            //shopPanels[i].descriptionTxt.text = shopItemsSO[i].description;

            // randomly selected
            shopPanels[i].image.sprite = GetRandomIcon(shopItemsSO[i]);

            // get 3 random attributes
            for (int j = 0; j < 3; j++)
            {
                shopPanels[i].attributesTxt.text += PickRandomAttribute(shopItemsSO[i]) + System.Environment.NewLine;
            }

            shopItemsSO[i].status = CalculateBabyStatus(shopItemsSO[i]);

            // cost based on status (good/bad)
            shopPanels[i].costTxt.text = SetCosts(shopItemsSO[i]).ToString();
        }
    }

    public string PickRandomAttribute(ShopItemSO shopItem)
    {        
        Random r = new Random();
        int rInt = r.Next(0, possibleAttrs.Count - 1);
        
        shopItem.attributes.Add(possibleAttrs[rInt]);
        
        return shopItem.attributes.LastOrDefault().attributeName;
    }

    public string CalculateBabyStatus(ShopItemSO shopItem)
    {
        int totalWeight = 0;
        foreach (Attribute attribute in shopItem.attributes)
        {
            totalWeight += attribute.weight; // calc total weight of attrs
        }

        if(totalWeight > 0)
        {
            shopItem.status = "good";
        }
        else if(totalWeight < 0)
        {
            shopItem.status = "bad";
        }
        else // = 0
        {
            Debug.Log("Error with calculating " + shopItem + " status; cannot equal 0");
        }

        return shopItem.status;
    }

    public int SetCosts(ShopItemSO shopItem)
    {
        if(shopItem.status == "good")
        {
            shopItem.cost = 75;
        }
        else if(shopItem.status == "bad")
        {
            shopItem.cost = 25;
        }

        return shopItem.cost;
    }

    public Sprite GetRandomIcon(ShopItemSO shopItem)
    {
        Random r = new Random();
        int rInt = r.Next(0, possibleIcons.Count - 1);

        shopItem.icon = possibleIcons[rInt];

        return shopItem.icon;
    }

    public void ResetShop()
    {
        // reset shop (randomize) each new day
        LoadPanels();
        CheckPurchaseable();
    }
}
