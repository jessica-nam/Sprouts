using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlotManager : MonoBehaviour
{

    public static PlotManager instance;

    public MouseItemData mouseObj;
    public ShopItemSO babyObj;
    public InventorySlot slotData;
    private GameObject invHolder;

    public Button NextDay;


    [SerializeField] private Sprite icon;

    GameObject SavedObjs;

    bool isPlanted = false;
    SpriteRenderer plant;

    public Sprite[] plantStages;
    int plantStage = 0;

    // Start is called before the first frame update
    void Start()
    {
        plant = transform.GetChild(0).GetComponent<SpriteRenderer>();
        NextDay.onClick.AddListener(NextDayButtonYes);
    }

    private void Awake()
    {
        instance = this;
        SavedObjs = SaveObject.savedObjs;
        invHolder = SavedObjs.gameObject.transform.Find("Inventory Holder").gameObject;
        mouseObj = SavedObjs.gameObject.transform.Find("Mouse Object").gameObject.GetComponent<MouseItemData>();
    }


    public void NextDayButtonYes()
    {
        if (plantStage < plantStages.Length - 1){
            plantStage+=1;
            UpdatePlant();
        }
        
    }

    private void OnMouseDown()
    {
        if (isPlanted)
        {
            if (plantStage == plantStages.Length - 1)
            {

                Harvest();

            }else{
                Debug.Log("Stop");
            }
        }
        else
        {
            Plant();
        }
    }

    void Harvest()
    {

        var inventory = invHolder.GetComponent<InventoryHolder>();
        var clone = Instantiate(babyObj);
        clone.icon = plant.sprite; // refers to serialize field at top
        inventory.InventorySystem.AddToInventory(clone, 1);

        isPlanted = false;
        plant.gameObject.SetActive(false);

    }

    void Plant()
    {
        if (MouseItemData.instance.hasItem)
        {

            babyObj = mouseObj.getCurrentMouseItem().ItemData;
            Debug.Log("Baby on mouse: ");

            isPlanted = true;
            plantStage = 0;
            UpdatePlant();
            plant.gameObject.SetActive(true);

            MouseItemData.instance.ClearSlot();
        }
    }

    void UpdatePlant()
    {
        plant.sprite = plantStages[plantStage];
    }
}