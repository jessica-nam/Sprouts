using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlotManager : MonoBehaviour
{
    public static PlotManager instance;

    private MouseItemData mouseObj;
    private ShopItemSO babyObj;
    private ShopItemSO upgradeObj;
    private GameObject invHolder;

    public string upgradeName;
    public bool canPlantUpgrade = false;

    public GameObject sproutAnim;
    public GameObject umbrella;
    public Weather Weather;
    public Button NextDay;
    
    [SerializeField] private Sprite icon;

    public GameObject UIObjs;

    public GameObject dead;

    bool isPlanted = false;
    bool clicked = false;
    bool canHarvest = false;
    bool isRain = false;
    SpriteRenderer plant;

    //int daycount = 1;

    public Sprite[] plantStages;
    int plantStage = 0;

    public AudioSource plantHarvestSFX;
    public AudioClip plantNoise;
    public AudioClip harvestNoise;

    // Start is called before the first frame update
    void Start()
    {
        plant = transform.GetChild(0).GetComponent<SpriteRenderer>();
        NextDay.onClick.AddListener(NextDayButtonYes);
        dead.tag = "WillDie";
    }

    private void Awake()
    {
        instance = this;
        invHolder = UIObjs.gameObject.transform.Find("Inventory Holder").gameObject;
        mouseObj = UIObjs.gameObject.transform.Find("Mouse Object").gameObject.GetComponent<MouseItemData>();
    }

    private void Update()
    {
       // Debug.Log(Weather.isRaining);

        if (Weather.isRaining)
            isRain = true;
        else
            isRain = false;
    }

    public void NextDayButtonYes()
    {
        
        if (plantStage < plantStages.Length - 1)
        {
            //if good baby
            //daycount+=1

            // else
            plantStage += 1;
            UpdatePlant();
            sproutAnim.SetActive(false);

            // if(daycount == 3){
            //     plantStage += 1;
            //     UpdatePlant();
            //     sproutAnim.SetActive(false);

            //     scarecrow.SetActive(false);

            // }

            if (isRain)
            {
                Debug.Log("tag = " + gameObject.tag);
                if (gameObject.tag == "Untagged")
                {
                    canHarvest = true;
                }
                else if (gameObject.tag == "WillDie")
                {
                    canHarvest = false;
                    plant.gameObject.SetActive(false);
                    dead.SetActive(true);
                }
            }
        }
    }

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            clicked = true; // fixes error where you can interact with plots through shop canvas
        }
        Debug.Log(dead.activeSelf);
        if(dead.activeSelf){
            dead.SetActive(false);
            gameObject.tag = "Untagged";
            isPlanted = false;
        }
        
        Debug.Log("Here");
        if (isPlanted)
        {
            if (plantStage == plantStages.Length - 1)
            {
                if(isRain){
                    if(canHarvest){
                        Harvest();

                        gameObject.tag = "Untagged";
                    }
                    // }else{
                    //     Debug.Log("Baby died");
                    //     dead.SetActive(false);
                    //     gameObject.tag = "Untagged";

                    // }
                }else{
                    Harvest();
                }
                

            }
            else
            {
                Upgrade();
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
        plantHarvestSFX.pitch = (Random.Range(0.6f, .9f));
        plantHarvestSFX.PlayOneShot(harvestNoise);
        if (clicked && gameObject.tag == "Untagged")
        {
            var inventory = invHolder.GetComponent<InventoryHolder>();
            var clone = Instantiate(babyObj);
            clone.icon = plant.sprite; // refers to serialize field at top
            clone.sellable = true;
            inventory.InventorySystem.AddToInventory(clone);

            isPlanted = false;
            plant.gameObject.SetActive(false);
            umbrella.SetActive(false);
            dead.SetActive(false);

        }


        clicked = false;
    }

    void Plant() // regular 1 day baby
    {
        plantHarvestSFX.pitch = (Random.Range(0.6f, .9f));
        plantHarvestSFX.PlayOneShot(plantNoise);
        if (clicked)
        {
            if (MouseItemData.instance.hasItem)
            {

                babyObj = mouseObj.getCurrentMouseItem().ItemData;
                //Debug.Log("Baby on mouse: ");
               // Debug.Log(babyObj.name);

                // if baby net positive == good baby
                //  good baby is true
                

                if (babyObj.name == "Baby 1" || babyObj.name == "Baby 2" || babyObj.name == "Baby 3" || babyObj.name == "Baby 4" || babyObj.name == "Baby 5" || babyObj.name == "Baby 6")
                {
                    isPlanted = true;
                    plantStage = 0;
                    UpdatePlant();
                    plant.gameObject.SetActive(true);
                    sproutAnim.SetActive(true);

                    MouseItemData.instance.ClearSlot();

                    if(Weather.instance.isRaining){
                        gameObject.tag = "WillDie";
                    }
                }
                else
                {
                    Debug.Log("Cannot Plant");
                }

            }
        }

        clicked = false;
    }


    void Upgrade()
    {
        if (MouseItemData.instance.hasItem)
        {
            upgradeObj = mouseObj.getCurrentMouseItem().ItemData;
            upgradeName = upgradeObj.title;
        }
        if (isPlanted && upgradeName == "Umbrella")
        {
            Debug.Log("Can plant because it is an upgrade");
            MouseItemData.instance.ClearSlot();
            canPlantUpgrade = true;
            umbrella.SetActive(true);
            gameObject.tag = "Untagged";
        }       
        
    }

    void UpdatePlant()
    {
        plant.sprite = plantStages[plantStage];
    }
}
