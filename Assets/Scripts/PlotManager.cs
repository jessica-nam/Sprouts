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

    public GameObject sproutAnim;
    public GameObject babyAnim;
    public GameObject umbrella;
    private ShopItemSO umbrellaData; // the actual item data of any umbrella you place
    public Weather Weather;
    public Button NextDay;
    
    public GameObject UIObjs;
    public GameObject headstone;
    GameObject thisPlot;

    bool hasPlant = false;
    bool clickedOnPlot = false;
    bool canHarvest = false;
    bool isRain = false;
    SpriteRenderer plant;

    public Sprite[] plantStages;
    int plantStage = 0;
    //int clickCount = 0;

    public AudioSource plantHarvestSFX;
    public AudioClip plantNoise;
    public AudioClip harvestNoise;

    // Start is called before the first frame update
    void Start()
    {
        babyCopy = new ShopItemSO(); // init global obj to be used later
        plant = transform.GetChild(0).GetComponent<SpriteRenderer>();
        NextDay.onClick.AddListener(NextDayButtonYes);
        headstone.tag = "WillDie";
    }

    private void Awake()
    {
        instance = this;
        thisPlot = gameObject; // more readable
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
            plantStage += 1;
            UpdatePlant();
            
            sproutAnim.SetActive(false);

            if (hasPlant) 
            {
                if (!isRain) 
                {
                    canHarvest = true;
                    babyAnim.SetActive(true);
                }
                else // raining
                {
                    if (umbrella.activeSelf) // if has umbrella
                    {
                        canHarvest = true;
                        babyAnim.SetActive(true);
                    }
                    else
                    {
                        canHarvest = false;
                        //plant.gameObject.SetActive(false);
                        headstone.SetActive(true);
                    }
                }
            }
            
            //if (isRain)
            //{
            //    if (umbrella.activeSelf && hasPlant) 
            //    {
            //        canHarvest = true;
            //        babyAnim.SetActive(true);
            //    }
            //    else if (thisPlot.tag == "WillDie")
            //    {
            //        canHarvest = false;
            //        plant.gameObject.SetActive(false);
            //        dead.SetActive(true);
            //    }
            //}else{
            //    canHarvest = true;
            //}
        }

        // remove all umbrellas
        umbrella.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            // only true if just clicked on a plot
            clickedOnPlot = true; // fixes error where you can interact with plots through shop canvas
        }
        else
        {
            clickedOnPlot = false;
        }

        // clicks on plot while item on mouse
        if (MouseItemData.instance.hasItem && clickedOnPlot)
        {
            // get item
            ShopItemSO objOnMouse = mouseObj.getCurrentMouseItem().ItemData;
            
            // if obj is an upgrade
            if (objOnMouse.title == "Umbrella")
            {
                PlaceUmbrella(objOnMouse);
            }
            // else obj is a baby
            else
            {
                PlantBaby(objOnMouse);
            }
        }

        // clicks on plot that has umbrella
        else if (umbrella.activeSelf && clickedOnPlot)
        {
            // remove umbrella
            umbrella.SetActive(false);

            if (Weather.instance.isRaining)
            {
                thisPlot.tag = "WillDie";
            }
            else
            {
                thisPlot.tag = "Protected";
            }
            

            // add to inventory
            InventoryHolder inventory = invHolder.GetComponent<InventoryHolder>();
            inventory.InventorySystem.AddToInventory(umbrellaData);
        }

        // clicks on plot that has headstone
        if (headstone.activeSelf && clickedOnPlot)
        {
            // remove headstone
            headstone.SetActive(false);
            thisPlot.tag = "Protected";
            hasPlant = false;
        }

        // clicks on plot that has done baby
        if (hasPlant && clickedOnPlot)
        {
            if (plantStage == plantStages.Length - 1) // ?
            {
                if (isRain)
                {
                    if (canHarvest) // if plot is protected
                    {
                        Harvest();
                    }

                }
                else // not raining
                {
                    Harvest();
                }
            }
        }

    }

    void Harvest()
    {
        // sound
        plantHarvestSFX.pitch = (Random.Range(0.6f, .9f));
        plantHarvestSFX.PlayOneShot(harvestNoise);

        // if just clicked on plot with done baby
        if (thisPlot.tag == "Protected")
        {
            // add baby to inventory
            var inventory = invHolder.GetComponent<InventoryHolder>();
            babyCopy.icon = plant.sprite; 
            babyCopy.sellable = true; // can be sold in shop
            inventory.InventorySystem.AddToInventory(babyCopy);

            // remove any items on plot
            hasPlant = false;
            plant.gameObject.SetActive(false);
            umbrella.SetActive(false);
            headstone.SetActive(false);
            babyAnim.SetActive(false);
        }
        
        clickedOnPlot = false;
    }

    void PlantBaby(ShopItemSO babyToPlant) // regular 1 day baby
    {
        // sound
        plantHarvestSFX.pitch = (Random.Range(0.6f, .9f));
        plantHarvestSFX.PlayOneShot(plantNoise);

        if (!hasPlant) // as long as not already a plant on this plot
        {
            hasPlant = true;
            plantStage = 0;

            // copy baby on mouse to another ShopItemSO obj
            babyCopy = Instantiate(babyToPlant);
            UpdatePlant();
            plant.gameObject.SetActive(true);
            sproutAnim.SetActive(true);

            MouseItemData.instance.ClearSlot(); // destroy obj on mouse

            if (Weather.instance.isRaining)
            {
                thisPlot.tag = "WillDie";
            }
            else
            {
                thisPlot.tag = "Protected";
            }
        }
      
    }

    void PlaceUmbrella(ShopItemSO data)
    {
        // store this umbrella's data in global var
        // to use if user wants to remove umbrella
        umbrellaData = data;

        // sound
        plantHarvestSFX.pitch = (Random.Range(0.6f, .9f));
        plantHarvestSFX.PlayOneShot(plantNoise);
        
        umbrella.gameObject.SetActive(true);
        MouseItemData.instance.ClearSlot(); // destroy item on mouse
        thisPlot.tag = "Protected";
    }

    void UpdatePlant()
    {
        plant.sprite = plantStages[plantStage];
    }
}
