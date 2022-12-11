using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using Random = System.Random;
using System.Linq;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    public ShopItemSO[] shopItemsSeeds;
    public ShopItemSO[] shopItemsUpgrades;
    public GameObject[] shopPanelsGO_Seeds;
    public GameObject[] shopPanelsGO_Upgrades;
    public ShopTemplate[] shopPanelsSeeds;
    public ShopTemplate[] shopPanelsUpgrades;
    public Button[] purchaseBtns;

    public GameObject UIObjs; 
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
        // instantiate UI objs
        invHolder = UIObjs.gameObject.transform.Find("Inventory Holder").gameObject;
        coinMgr = UIObjs.gameObject.transform.Find("Coin UI").gameObject.GetComponent<CoinMgr>();
        mouseObj = UIObjs.gameObject.transform.Find("Mouse Object").gameObject.GetComponent<MouseItemData>();
        scoreMgr = UIObjs.gameObject.transform.Find("Score UI").gameObject.GetComponent<ScoreMgr>();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // reset persistent values every time user replays game
        coinMgr.ResetCoins();
        scoreMgr.ResetScore();
    }

    void Start()
    {
        for (int i = 0; i < shopItemsSeeds.Length; i++)
        {
            shopItemsSeeds[i].Reset(); // reset all values
            shopPanelsGO_Seeds[i].SetActive(true);
        }
        for(int i = 0; i < shopItemsUpgrades.Length; i++)
        {
            shopPanelsGO_Upgrades[i].SetActive(true);
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
        var thisItem = mouseObj.getCurrentMouseItem().ItemData;
        foreach (var result in results)
        {
            if (result.gameObject.name == "Shop" && mouseObj.hasItem && Mouse.current.leftButton.wasPressedThisFrame && thisItem.sellable) // if item on mouse and player clicks on shop canvas and obj is sellable
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
            sellMgr.UpdateSellScreen(parentTransform);
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
        Debug.Log(shopItemsSeeds[btnNum].title + " " + shopItemsSeeds[btnNum].score);
        if (seedsContent.gameObject.activeSelf)
        {
            if (coinMgr.coins >= shopItemsSeeds[btnNum].cost)
            {
                // update coin value
                coinMgr.coins = coinMgr.coins - shopItemsSeeds[btnNum].cost;
                coinMgr.UpdateCoinUI();

                // add to player inventory
                var inventory = invHolder.GetComponent<InventoryHolder>();          // get player inventory
                inventory.InventorySystem.AddToInventory(shopItemsSeeds[btnNum]);   // add item to it

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
                inventory.InventorySystem.AddToInventory(shopItemsUpgrades[btnNum]);   // add item to it

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
            shopPanelsSeeds[i].titleTxt.text = shopItemsSeeds[i].title;
            shopPanelsSeeds[i].titleTxtShadow.text = shopItemsSeeds[i].title;

            // randomly selected
            shopPanelsSeeds[i].image.sprite = GetRandomIcon(shopItemsSeeds[i]);

            // get 3 random attributes
            chosenAttrs.Clear();
            for (int j = 0; j < 3; j++)
            {
                Attribute temp = PickRandomAttribute(shopItemsSeeds[i]);
                shopPanelsSeeds[i].attributesTxt.text += temp.attributeName + " " + temp.weight + System.Environment.NewLine;
         
                // score is sum of attr weights 
                shopItemsSeeds[i].score += shopItemsSeeds[i].attributes[j].weight;
            }
            // cost is based on score
            shopPanelsSeeds[i].costTxt.text = SetCosts(shopItemsSeeds[i]).ToString();
        }

        // upgrades
        for (int i = 0; i < shopItemsUpgrades.Length; i++)
        {
            // these are set in inspector
            shopPanelsUpgrades[i].titleTxt.text = shopItemsUpgrades[i].title;
            shopPanelsUpgrades[i].titleTxtShadow.text = shopItemsUpgrades[i].title;
            shopPanelsUpgrades[i].costTxt.text = shopItemsUpgrades[i].cost.ToString();
        }
    }

  
    public Attribute PickRandomAttribute(ShopItemSO shopItem)
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
        
        return shopItem.attributes.LastOrDefault();
    }

    public int SetCosts(ShopItemSO shopItem)
    {
        float goodFactor = 3.5f;   // cost = score * 3.5 + 25
        float goodAdder = 25;
        float badFactor = 0.7f;  // cost = 0.7 * score + 20
        float badAdder = 20;
        int roundTo = 5;        // costs will be rounded to closest mult of 5

        // if good 
        if(shopItem.score >= 0)
        {
            float temp = 0;
            temp = Mathf.Round((shopItem.score * goodFactor) + goodAdder);
            temp = (temp / roundTo) * roundTo; // round to upper mult of 5
            shopItem.cost = (int)temp;
        }
        // if bad 
        else if(shopItem.score < 0)
        {
            float temp = 0;
            temp = Mathf.Round((shopItem.score * badFactor) + badAdder);
            temp = (temp / roundTo) * roundTo; // round to upper mult of 5
            shopItem.cost = (int)temp;
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
        Debug.Log("new day");
        chosenAttrs.Clear(); // reset for randomize
        chosenIcons.Clear(); // reset for randomize

        // reset seeds only 
        for (int i = 0; i < shopItemsSeeds.Length; i++)
        {
            shopItemsSeeds[i].Reset(); // reset all values
            shopPanelsSeeds[i].Reset();
            shopPanelsGO_Seeds[i].SetActive(true);
        }
        LoadPanels();
        CheckPurchaseable();
    }
}
