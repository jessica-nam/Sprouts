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
    public ShopItemSO[] shopItemsSeeds;
    public ShopItemSO[] shopItemsUpgrades;
    public GameObject[] shopPanelsGO;
    public ShopTemplate[] shopPanels;
    public Button[] purchaseBtns;
    public GameObject sellTemplate;

    GameObject SavedObjs; 
    private GameObject invHolder;
    private CoinMgr coinMgr;
    private ScoreMgr scoreMgr;
    private MouseItemData mouseObj;
    private GameObject hotbarBG;

    public SellItem sellMgr;
    public Button buyBtn;
    public Button sellBtn;
    public GameObject seedsContent;
    public GameObject upgradesContent;

    Transform childFound = null;

    public List<Attribute> possibleAttrs;
    public List<Sprite> possibleIcons;
    HashSet<int> chosenAttrs = new HashSet<int>(); // hash sets don't allow duplicates
    HashSet<int> chosenIcons = new HashSet<int>();

    public AudioSource shopSFX;
    public AudioClip buySound;

    private void Awake()
    {
        // instantiate saved objects
        SavedObjs = SaveObject.savedObjs; 

        invHolder = SavedObjs.gameObject.transform.Find("Inventory Holder").gameObject;
        coinMgr = SavedObjs.gameObject.transform.Find("Coin UI").gameObject.GetComponent<CoinMgr>();
        mouseObj = SavedObjs.gameObject.transform.Find("Mouse Object").gameObject.GetComponent<MouseItemData>();
        scoreMgr = SavedObjs.gameObject.transform.Find("Score UI").gameObject.GetComponent<ScoreMgr>();
    }

    void Start()
    {
        for (int i = 0; i < shopItemsSeeds.Length; i++)
        {
            shopItemsSeeds[i].Reset(); // reset all values
            //shopItemsUpgrades[i].Reset();
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
                DisplayShopSell();      // swap to sell view
                DisplayItemsToSell();   // add template for every item dragged onto sell view
                mouseObj.ClearSlot();   // destroy item on mouse
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
            sellMgr.UpdateItemToSell(mouseObj.getCurrentMouseItem().ItemData, newItemToSell);
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
        // seeds
        if (seedsContent.gameObject.activeSelf)
        {
            for (int i = 0; i < shopItemsSeeds.Length; i++)
            {
                if (coinMgr.coins >= shopItemsSeeds[i].cost) // if player has enough money
                    purchaseBtns[i].interactable = true;
                else
                    purchaseBtns[i].interactable = false;
            }
        }

        // upgrades
        else if (upgradesContent.gameObject.activeSelf)
        {
            for (int i = 0; i < shopItemsUpgrades.Length; i++)
            {
                if (coinMgr.coins >= shopItemsUpgrades[i].cost) // if player has enough money
                    purchaseBtns[i].interactable = true;
                else
                    purchaseBtns[i].interactable = false;
            }
        }
    }

    // run when "purchase" bttns pressed
    public void PurchaseItem(int btnNum)
    {
        // seeds
        if (seedsContent.gameObject.activeSelf)
        {
            if (coinMgr.coins >= shopItemsSeeds[btnNum].cost)
            {
                // update coin value
                coinMgr.coins = coinMgr.coins - shopItemsSeeds[btnNum].cost;
                coinMgr.UpdateCoinUI();

                // add to player inventory
                var inventory = invHolder.GetComponent<InventoryHolder>();          // get player inventory
                inventory.InventorySystem.AddToInventory(shopItemsSeeds[btnNum], 1);   // add item to it

                CheckPurchaseable();
                shopSFX.PlayOneShot(buySound);
            }
        }
       

        // upgrades
        else if (upgradesContent.gameObject.activeSelf)
        {
            if (coinMgr.coins >= shopItemsUpgrades[btnNum].cost)
            {
                // update coin value
                coinMgr.coins = coinMgr.coins - shopItemsUpgrades[btnNum].cost;
                coinMgr.UpdateCoinUI();

                // add to player inventory
                var inventory = invHolder.GetComponent<InventoryHolder>();          // get player inventory
                inventory.InventorySystem.AddToInventory(shopItemsUpgrades[btnNum], 1);   // add item to it

                CheckPurchaseable();
                shopSFX.PlayOneShot(buySound);
            }
        }
       
    }

    public void LoadPanels()
    {
        // seeds
        for (int i = 0; i < shopItemsSeeds.Length; i++)
        {
            // these are set in inspector
            shopPanels[i].titleTxt.text = shopItemsSeeds[i].title;

            // randomly selected
            shopPanels[i].image.sprite = GetRandomIcon(shopItemsSeeds[i]);

            // get 3 random attributes
            chosenAttrs.Clear();
            for (int j = 0; j < 3; j++)
            {
                shopPanels[i].attributesTxt.text += PickRandomAttribute(shopItemsSeeds[i]) + System.Environment.NewLine;

                // score is sum of attr weights 
                shopItemsSeeds[i].score += shopItemsSeeds[i].attributes[j].weight;
            }
            // cost is based on score
            shopPanels[i].costTxt.text = SetCosts(shopItemsSeeds[i]).ToString();
        }

        // upgrades
        for (int i = 0; i < shopItemsUpgrades.Length; i++)
        {
            // these are set in inspector
            shopPanels[i].titleTxt.text = shopItemsUpgrades[i].title;
            
            // prices
            //shopPanels[i].costTxt.text = SetCosts(shopItemsSeeds[i]).ToString();
        }
    }

  
    public string PickRandomAttribute(ShopItemSO shopItem)
    {        
        Random r = new Random();
        int rInt;

        // pick rand num, making sure it's not already been chosen
        do
        {
            rInt = r.Next(0, possibleAttrs.Count);
        }
        while (chosenAttrs.Contains(rInt));
        chosenAttrs.Add(rInt);
        
        shopItem.attributes.Add(possibleAttrs[rInt]);
        
        return shopItem.attributes.LastOrDefault().attributeName;
    }

    public int SetCosts(ShopItemSO shopItem)
    {
        float goodFactor = 8;   // cost = score * 8
        float badFactor = 100;  // cost = 100 / score
        int roundTo = 5;        // costs will be rounded to closest mult of 5

        Debug.Log(shopItem.title + " = " + shopItem.score);

        // if good 
        if(shopItem.score > 0)
        {
            shopItem.cost = (int)(Mathf.Round((shopItem.score * goodFactor) / roundTo)) * roundTo;
        }
        // if bad 
        else if(shopItem.score <= 0)
        {
            shopItem.cost = (int)Mathf.Round((badFactor / Mathf.Abs(shopItem.score)) / roundTo) * roundTo;
        }

        return shopItem.cost;
    }

    public Sprite GetRandomIcon(ShopItemSO shopItem)
    {
        Random r = new Random();
        int rInt;

        // pick rand num, making sure it's not already been chosen
        do
        {
            rInt = r.Next(0, possibleIcons.Count);
        }
        while (chosenIcons.Contains(rInt));
        chosenIcons.Add(rInt);

        // get icon at rand num
        shopItem.icon = possibleIcons[rInt];

        return shopItem.icon;
    }

    // reset shop (randomize) each new day
    public void ResetShop()
    {
        chosenAttrs.Clear(); // reset for randomize
        chosenIcons.Clear(); // reset for randomize

        // reset seeds only 
        for (int i = 0; i < shopItemsSeeds.Length; i++)
        {
            shopItemsSeeds[i].Reset(); // reset all values
            shopPanels[i].Reset();
            shopPanelsGO[i].SetActive(true);
        }

        LoadPanels();
        CheckPurchaseable();
    }
}
