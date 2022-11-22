using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantManager : MonoBehaviour
{

    public static PlantManager instance;

    bool isPlanted = false;
    public GameObject plant;

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
            // Harvest();
            Plant();
        }else if (isPlanted){
            Harvest();
        }
        // }else{
        //     Plant();
        //     mouseObj = null;
        // }
    }

    void Harvest(){
        Debug.Log("Harvested");
        var inventory = invHolder.GetComponent<InventoryHolder>();
        DoneBaby1 = babyObj;
        Debug.Log(DoneBaby1);
        inventory.InventorySystem.AddToInventory(DoneBaby1, 1);
        isPlanted = false;
        plant.SetActive(false);
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
