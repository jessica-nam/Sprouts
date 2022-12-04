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

    public GameObject UIObjs;
    private CoinMgr coinMgr;
    private ScoreMgr scoreMgr;
    private GameObject invHolder;
    
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

    public void UndoTemplateCreation()
    {
        // get order in hierarchy -- should match order in global lists storing templates/data 
        int index = gameObject.transform.GetSiblingIndex(); 

        // add back to inventory
        var inventory = invHolder.GetComponent<InventoryHolder>();
        inventory.InventorySystem.AddToInventory(itemsToSell.ElementAt(index), 1);

        // set sell template inactive
        templateList.ElementAt(index).gameObject.SetActive(false);
    }
}
