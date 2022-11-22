using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantManager : MonoBehaviour
{

    public static PlantManager instance;

    [SerializeField] private Sprite itemSprite;

    bool isPlanted = false;
    public bool readyForHarvest = false;
    public GameObject plant;
    public GameObject baby;


    public ShopItemSO DoneBaby1;

    public MouseItemData mouseObj;
    public ShopItemSO babyObj;

    GameObject SavedObjs; 

    public static InventorySlot slotData;
    private GameObject invHolder;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake(){
        instance = this;

        SavedObjs = SaveObject.savedObjs; 
        invHolder = SavedObjs.gameObject.transform.Find("Inventory Holder").gameObject;
        mouseObj = SavedObjs.gameObject.transform.Find("Mouse Object").gameObject.GetComponent<MouseItemData>();
        

    }

    private void OnMouseDown(){
        Debug.Log("Clicked");
        if(!isPlanted){
            Plant();
        }

        if(readyForHarvest){
            Harvest();
        }
    }

    public void TurnOffAnim(){
        plant.SetActive(false);
    }

    public void TurnOnAnim(){
        plant.SetActive(true);
    }

    public void ReadyForHarvest(){
        
        isPlanted = false;
        plant.SetActive(false);
        readyForHarvest = true;
        baby.SetActive(true);
    }

    public void Harvest(){
        Debug.Log("Harvested");
        var inventory = invHolder.GetComponent<InventoryHolder>();
        Debug.Log("Baby Object before", babyObj);
        Debug.Log("Done baby" , DoneBaby1);

        babyObj = DoneBaby1;
        Debug.Log("Baby Object after", babyObj);
        inventory.InventorySystem.AddToInventory(babyObj, 1);
        baby.SetActive(false);
        readyForHarvest = false;
        
    }

    void Plant(){
        if(MouseItemData.instance.hasItem){
            // get status of obj currently attached to mouse
            babyObj = mouseObj.getCurrentMouseItem().ItemData; 
            Debug.Log("Baby on mouse: ", babyObj);

             
            Debug.Log("Planted");
            isPlanted = true;
            plant.SetActive(true);

            
            MouseItemData.instance.ClearSlot();
            Debug.Log("Baby on mouse after clear: ", babyObj);
            Debug.Log("On mouse after clear: ", mouseObj.getCurrentMouseItem().ItemData);


        }else{
            Debug.Log("No seed selected");
            isPlanted = false;
        }

    }
}
