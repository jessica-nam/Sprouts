using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class SellItem : MonoBehaviour
{
    private static List<SellTemplate> templateList = new List<SellTemplate>(); // templates (UI)
    private static List<ShopItemSO> itemsToSell = new List<ShopItemSO>(); // actual data 
    private SellTemplate sellTemplate;

    [SerializeField] GameObject UIObjs;
    private CoinMgr coinMgr;
    private ScoreMgr scoreMgr;
    private GameObject invHolder;
    private MouseItemData mouseObj;

    public GameObject instructions;
    public Button sellItemsButton;

    private int goodSoldTemp = 0;
    public int goodSold = 0;
    int totalRevenue;
    int totalScore;

    public AudioSource SellSFX;
    public AudioClip sellSound;

    private void Start()
    {
        // instantiate UI objs
        coinMgr = UIObjs.gameObject.transform.Find("Coin UI").gameObject.GetComponent<CoinMgr>();
        scoreMgr = UIObjs.gameObject.transform.Find("Score UI").gameObject.GetComponent<ScoreMgr>();
        invHolder = UIObjs.gameObject.transform.Find("Inventory Holder").gameObject;
        mouseObj = UIObjs.gameObject.transform.Find("Mouse Object").gameObject.GetComponent<MouseItemData>();
    }

    public void CreateNewSellItem(GameObject sellTemplate, Transform parentTransform)
    {
        GameObject newItemTemplate = Instantiate(sellTemplate, parentTransform); // instantiate new templates as children of that obj
        // enable undo functionality
        newItemTemplate = SetUndo(newItemTemplate);
        // combine data from mouse item with newly created template
        UpdateItemToSell(mouseObj.getCurrentMouseItem().ItemData, newItemTemplate);
    }

    Button undoBtn;
    public GameObject SetUndo(GameObject newItem)
    {
        undoBtn = newItem.transform.Find("Undo Btn").GetComponent<Button>();
        // attach undo bttn to undo function
        // have to do this in code instead of inspector because script is on object that prefab doesn't have access to until runtime
        undoBtn.onClick.AddListener(delegate { UndoTemplateCreation(newItem); });
        return newItem;
    }

    public void UpdateItemToSell(ShopItemSO data, GameObject template)
    {
        sellItemsButton.gameObject.SetActive(true); // will be called every time a new template is added -- not ideal
        sellTemplate = template.GetComponent<SellTemplate>();

        // add to list of templates (UI)
        templateList.Add(sellTemplate);
        
        // add to list of items (actual data)
        itemsToSell.Add(data);

        sellTemplate.image.sprite = data.icon;
        sellTemplate.image.color = Color.white;
        sellTemplate.titleTxt.text = data.title;
        sellTemplate.descriptionTxt.text = GetAttributesText(data);

        // set cost based on status
        data.cost = SetSellPrice(data);
        sellTemplate.costTxt.text = data.cost.ToString();
        totalRevenue += data.cost;

        // calc val to add to score
        if(data.score < 0)
            sellTemplate.score.text = data.score.ToString();
        else
            sellTemplate.score.text = "+" + data.score;
        totalScore += data.score;

        //if(data.score == "good")
        //{
        //    goodSoldTemp += 1;
        //}
    }

    public string GetAttributesText(ShopItemSO shopItem)
    {
        string attributesText = "";
        foreach(var attr in shopItem.attributes)
        {
            attributesText += attr.attributeName + " ";
        }

        return attributesText;
    }

    public void SellItems()
    {
        // update coin value
        coinMgr.AddCoins(totalRevenue);

        // update score 
        scoreMgr.AddScore(totalScore);

        // delete all templates
        foreach (var template in templateList)
        {
            Destroy(template.gameObject);
        }

        // reset template list
        templateList = new List<SellTemplate>();

        // reset
        totalRevenue = 0;
        totalScore = 0;

        instructions.SetActive(true);
        sellItemsButton.gameObject.SetActive(false);
        goodSold += goodSoldTemp;

        //play sound for selling
        SellSFX.PlayOneShot(sellSound);
    }

    public int SetSellPrice(ShopItemSO shopItem)
    {
        //int goodFactor = 100;   // cost = 100 / score 
        //int badFactor = 10;     // cost = score * 10
        //int roundTo = 5;        // prices will be rounded to closest mult of 5

        //// if good baby
        //if (shopItem.score > 0)
        //{
        //    shopItem.cost = (int)Mathf.Abs((Mathf.Round((goodFactor / shopItem.score)) / roundTo) * roundTo);
        //}
        //// if bad baby
        //else if (shopItem.score <= 0)
        //{
        //    shopItem.cost = (int)(Mathf.Round(Mathf.Abs(shopItem.score) * badFactor) / roundTo) * roundTo;
        //}

        shopItem.cost += 20;

        return shopItem.cost;
    }

    public void UndoTemplateCreation(GameObject thisItem)
    {
        // get order in hierarchy -- should match order in global lists storing templates/data 
        int index = thisItem.transform.GetSiblingIndex();

        // get actual shopItem (data)
        ShopItemSO data = itemsToSell[index];

        // get template storing that data 
        SellTemplate template = templateList[index];

        // add back to inventory
        var inventory = invHolder.GetComponent<InventoryHolder>();
        inventory.InventorySystem.AddToInventory(itemsToSell.ElementAt(index), 1);

        // subtract undone item's revenue from total
        totalRevenue -= data.cost;

        // set sell template inactive
        template.gameObject.SetActive(false);
    }
}
