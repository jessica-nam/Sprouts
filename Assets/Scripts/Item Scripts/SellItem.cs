using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellItem : MonoBehaviour
{
    private List<SellTemplate> templateList = new List<SellTemplate>();
    private SellTemplate sellTemplate;
    GameObject SavedObjs;
    private CoinMgr coinMgr;
    public int goodSold = 0;

    int totalRevenue;
    public GameObject instructions;
    public Button sellItemsButton;

    private void Start()
    {
        // instantiate saved objects
        SavedObjs = SaveObject.savedObjs;
        coinMgr = SavedObjs.gameObject.transform.Find("Coin UI").gameObject.GetComponent<CoinMgr>();
    }

    public void UpdateItemToSell(ShopItemSO data, int amount, GameObject template)
    {
        sellItemsButton.gameObject.SetActive(true); // will be called every time a new template is added -- not ideal
        sellTemplate = template.GetComponent<SellTemplate>();

        // add to list of templates
        templateList.Add(sellTemplate);

        sellTemplate.image.sprite = data.icon;
        sellTemplate.image.color = Color.white;
        sellTemplate.titleTxt.text = data.title;
        sellTemplate.descriptionTxt.text = data.description;

        int revenue = data.cost * amount;
        totalRevenue += revenue;
        sellTemplate.costTxt.text = revenue.ToString() + " coins";
        sellTemplate.quantity.text = "x " + amount.ToString();

        if(data.status == "good")
        {
            goodSold += 1;
        }
    }

    public void SellItems()
    {
        // update coin value
        coinMgr.AddCoins(totalRevenue);

        // delete all templates
        foreach (var template in templateList)
        {
            Destroy(template.gameObject);
        }

        // reset template list
        templateList = new List<SellTemplate>();

        // reset total revenue
        totalRevenue = 0;

        instructions.SetActive(true);
        sellItemsButton.gameObject.SetActive(false);
    }
}
