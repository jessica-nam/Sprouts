using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlotManager : MonoBehaviour
{
    public static PlotManager instance;

    private MouseItemData mouseObj;
    private ShopItemSO babyCopy;
    private ShopItemSO upgradeObj;
    private GameObject invHolder;

    public string upgradeName;
    public bool canPlantUpgrade = false;

    public GameObject sproutAnim;
    public GameObject umbrella;
    public Weather Weather;
    public Button NextDay;
    
    //[SerializeField] private Sprite icon;

    public GameObject UIObjs;

    public GameObject dead;

    bool isPlanted = false;
    bool clicked = false;
    bool canHarvest = false;
    bool isRain = false;
    SpriteRenderer plant;

    public Sprite[] plantStages;
    int plantStage = 0;

    public AudioSource plantHarvestSFX;
    public AudioClip plantNoise;
    public AudioClip harvestNoise;

    // Start is called before the first frame update
    void Start()
    {
        babyCopy = new ShopItemSO(); // init global obj to be used later
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
                if (gameObject.tag == "Protected")
                {
                    canHarvest = true;
                }
                else if (gameObject.tag == "WillDie")
                {
                    canHarvest = false;
                    plant.gameObject.SetActive(false);
                    dead.SetActive(true);
                }
            }else{
                canHarvest = true;
            }
        }
    }

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            clicked = true; // fixes error where you can interact with plots through shop canvas
        }
        if(dead.activeSelf){
            dead.SetActive(false);
            gameObject.tag = "Protected";
            isPlanted = false;
        }
        
        if (isPlanted)
        {
            if (plantStage == plantStages.Length - 1)
            {
                if(isRain){
                    if(canHarvest){
                        Harvest();
                        gameObject.tag = "Protected";
                    }

                }else{
                    Harvest();
                }
                

            }
            else
            {
                Upgrade();
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
        if (clicked && gameObject.tag == "Protected")
        {
            var inventory = invHolder.GetComponent<InventoryHolder>();
            babyCopy.icon = plant.sprite; 
            babyCopy.sellable = true;
            inventory.InventorySystem.AddToInventory(babyCopy);

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
                ShopItemSO babyOnMouse = mouseObj.getCurrentMouseItem().ItemData;

                if (babyOnMouse.name == "Baby 1" || babyOnMouse.name == "Baby 2" || babyOnMouse.name == "Baby 3" || babyOnMouse.name == "Baby 4" || babyOnMouse.name == "Baby 5" || babyOnMouse.name == "Baby 6")
                {
                    isPlanted = true;
                    plantStage = 0;
                    // copy baby on mouse to another ShopItemSO obj
                    babyCopy = Instantiate(babyOnMouse);
                    UpdatePlant();
                    plant.gameObject.SetActive(true);
                    sproutAnim.SetActive(true);

                    MouseItemData.instance.ClearSlot();

                    if(Weather.instance.isRaining){
                        gameObject.tag = "WillDie";
                    }else{
                        gameObject.tag = "Protected";
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
            gameObject.tag = "Protected";
        }       
        
    }

    void UpdatePlant()
    {
        plant.sprite = plantStages[plantStage];
    }
}
