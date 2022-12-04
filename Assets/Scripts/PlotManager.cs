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

    public Button NextDay;


    [SerializeField] private Sprite icon;

    public GameObject UIObjs;

    bool isPlanted = false;
    bool clicked = false;
    SpriteRenderer plant;

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
    }

    private void Awake()
    {
        instance = this;
        invHolder = UIObjs.gameObject.transform.Find("Inventory Holder").gameObject;
        mouseObj = UIObjs.gameObject.transform.Find("Mouse Object").gameObject.GetComponent<MouseItemData>();
    }

    public void NextDayButtonYes()
    {
        if (plantStage < plantStages.Length - 1)
        {
            plantStage += 1;
            UpdatePlant();
            sproutAnim.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            clicked = true; // fixes error where you can interact with plots through shop canvas
        }

        if (isPlanted)
        {
            if (plantStage == plantStages.Length - 1)
            {

                Harvest();

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
        if (clicked)
        {
            var inventory = invHolder.GetComponent<InventoryHolder>();
            var clone = Instantiate(babyObj);
            clone.icon = plant.sprite; // refers to serialize field at top
            inventory.InventorySystem.AddToInventory(clone, 1);

            isPlanted = false;
            plant.gameObject.SetActive(false);

        }

        clicked = false;
    }

    void Plant()
    {
        plantHarvestSFX.pitch = (Random.Range(0.6f, .9f));
        plantHarvestSFX.PlayOneShot(plantNoise);
        if (clicked)
        {
            if (MouseItemData.instance.hasItem)
            {

                babyObj = mouseObj.getCurrentMouseItem().ItemData;
                Debug.Log("Baby on mouse: ");
                Debug.Log(babyObj.name);

                if (babyObj.name == "Baby 1" || babyObj.name == "Baby 2" || babyObj.name == "Baby 3" || babyObj.name == "Baby 4" || babyObj.name == "Baby 5" || babyObj.name == "Baby 6")
                {
                    isPlanted = true;
                    plantStage = 0;
                    UpdatePlant();
                    plant.gameObject.SetActive(true);
                    sproutAnim.SetActive(true);

                    MouseItemData.instance.ClearSlot();
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
            upgradeName = upgradeObj.name;
        }
        if (isPlanted && upgradeName == "Upgrade 1")
        {
            Debug.Log("Can plant because it is an upgrade");
            MouseItemData.instance.ClearSlot();
            canPlantUpgrade = true;

        }
    }

    void UpdatePlant()
    {
        plant.sprite = plantStages[plantStage];
    }
}
