using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class SellItem : MonoBehaviour
{
    private static List<ContainerTemplate> containersList = new List<ContainerTemplate>(); // templates (UI)
    private static List<ShopItemSO> itemsToSell = new List<ShopItemSO>(); // actual data 
    public ContainerTemplate containerTemplate;

    [SerializeField] GameObject UIObjs;
    private CoinMgr coinMgr;
    private ScoreMgr scoreMgr;
    private GameObject invHolder;
    private MouseItemData mouseObj;

    public GameObject instructions;
    public Button sellItemsButton;
    private Button undoBtn;

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

    private void Update()
    {
        if(totalRevenue > 0)
            sellItemsButton.interactable = true;
        else
            sellItemsButton.interactable = false;
    }

    public void UpdateSellScreen(Transform parentTransform)
    {
        ShopItemSO thisItem = mouseObj.getCurrentMouseItem().ItemData;
        if (thisItem.sellIndex > -1) // has already been assigned to a container
        {
            // set container at that index to active
            containersList[thisItem.sellIndex].gameObject.SetActive(true);
            UpdateUIValues(thisItem);
        }
        else 
        {
            // create new container and add to list
            GameObject newContainerGO = Instantiate(containerTemplate.gameObject, parentTransform);
            // enable undo functionality
            newContainerGO = SetUndo(newContainerGO);

            ContainerTemplate newContainer = newContainerGO.GetComponent<ContainerTemplate>();
            // add to list of containers (UI)
            containersList.Add(newContainer);
            // add to list of items (actual data)
            itemsToSell.Add(thisItem);
            // update indices of container and data -- can be used as ID
            newContainer.index = containersList.Count - 1;
            thisItem.sellIndex = itemsToSell.Count - 1;
            // combine data from mouse item with newly created container
            CreateItemToSell(thisItem, newContainer);
        }
        
    }

 
    public GameObject SetUndo(GameObject newItem)
    {
        undoBtn = newItem.transform.Find("Undo Btn").GetComponent<Button>();
        // attach undo bttn to undo function
        // have to do this in code instead of inspector because script is on object that prefab doesn't have access to until runtime
        undoBtn.onClick.AddListener(delegate { UndoContainerCreation(newItem); });
        return newItem;
    }

    public void CreateItemToSell(ShopItemSO data, ContainerTemplate thisContainer)
    {
        // fill container fields w/data 
        thisContainer.image.sprite = data.icon;
        thisContainer.image.color = Color.white;
        thisContainer.titleTxt.text = data.title;
        thisContainer.descriptionTxt.text = GetAttributesText(data);
        // set cost based on baby's status (good/bad)
        data.cost = SetSellPrice(data);
        thisContainer.costTxt.text = data.cost.ToString();
        // calc val to add to score
        Debug.Log(data.title + " " + data.score);
        if (data.score < 0)
            thisContainer.score.text = data.score.ToString();
        else
            thisContainer.score.text = "+" + data.score;

        UpdateUIValues(data);
    }

    public void UpdateUIValues(ShopItemSO thisItem)
    {
        // update val to be added to user's coins
        totalRevenue += thisItem.cost;
        // update val to be added to user's score
        totalScore += thisItem.score;
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
        foreach (var container in containersList)
        {
            Destroy(container.gameObject);
        }

        // reset container list
        containersList = new List<ContainerTemplate>();

        // reset
        totalRevenue = 0;
        totalScore = 0;

        instructions.SetActive(true);
        //sellItemsButton.gameObject.SetActive(false);
        goodSold += goodSoldTemp;

        //play sound for selling
        SellSFX.PlayOneShot(sellSound);
    }

    public int SetSellPrice(ShopItemSO shopItem)
    {
        shopItem.cost += 20;

        return shopItem.cost;
    }

    public void UndoContainerCreation(GameObject thisGO)
    {
        var thisContainer = thisGO.GetComponent<ContainerTemplate>();

        // get actual shopItem (data)
        ShopItemSO data = itemsToSell[thisContainer.index];

        // subtract undone item's revenue/score from total
        totalRevenue -= data.cost;
        totalScore -= data.score;

        // add back to inventory
        var inventory = invHolder.GetComponent<InventoryHolder>();
        inventory.InventorySystem.AddToInventory(data);

        // set sell template inactive
        thisContainer.gameObject.SetActive(false);
    }
}
