using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotManager : MonoBehaviour
{

    public MouseItemData mouseObj;
    public ShopItemSO babyObj;
    public ShopItemSO DoneBaby;
    public InventorySlot slotData;
    private GameObject invHolder;
    

    [SerializeField] private Sprite icon;
    [SerializeField] private string title;

    GameObject SavedObjs; 

    bool isPlanted = false;
    SpriteRenderer plant;

    public Sprite[] plantStages;
    int plantStage = 0;
    float timeBtwStages = 2f;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        plant = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    private void Awake(){
        SavedObjs = SaveObject.savedObjs; 
        invHolder = SavedObjs.gameObject.transform.Find("Inventory Holder").gameObject;
        mouseObj = SavedObjs.gameObject.transform.Find("Mouse Object").gameObject.GetComponent<MouseItemData>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlanted){
            
                if(TimeManager.instance.clickedYes){
                    Debug.Log("Clicked Yes");
                    timer = timeBtwStages;
                    plantStage++;
                    UpdatePlant();
                    TimeManager.instance.clickedYes = false;
                }else{
                    Debug.Log("NO");
                }
                
        }
    }

    private void OnMouseDown(){
        if(isPlanted)
        {
            if(plantStage == plantStages.Length-1){    
    
                Harvest();

            }
        }else
        {
            Plant();
        }
    }

    void Harvest(){

        var inventory = invHolder.GetComponent<InventoryHolder>();
        var clone = Instantiate(babyObj);
        clone.icon = icon; // refers to serialize field at top
        clone.title = title;
        inventory.InventorySystem.AddToInventory(clone, 1);

        isPlanted = false;
        plant.gameObject.SetActive(false);
        Debug.Log("Harvest object");
        Debug.Log(mouseObj.getCurrentMouseItem().ItemData);
        Debug.Log(DoneBaby);
    }

    void Plant(){
        if(MouseItemData.instance.hasItem){

            babyObj = mouseObj.getCurrentMouseItem().ItemData; 
            Debug.Log("Baby on mouse: ");

            
            Debug.Log(DoneBaby);

            isPlanted = true;
            plantStage = 0;
            UpdatePlant();
            timer = timeBtwStages;
            plant.gameObject.SetActive(true);

            MouseItemData.instance.ClearSlot();
        }
    }

    void UpdatePlant(){
        plant.sprite = plantStages[plantStage];
    }
}
