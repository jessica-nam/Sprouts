using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestBaby : MonoBehaviour
{
    [SerializeField] private ShopItemSO DoneBaby;
    GameObject SavedObjs; 
    private GameObject invHolder;

    private void Awake()
    {
        // instantiate saved objects
        SavedObjs = SaveObject.savedObjs; 

        invHolder = SavedObjs.gameObject.transform.Find("Inventory Holder").gameObject;
    }

    public void Harvest(){
        Debug.Log(DoneBaby);
        var inventory = invHolder.GetComponent<InventoryHolder>();
        inventory.InventorySystem.AddToInventory(DoneBaby, 1);
    }
}
