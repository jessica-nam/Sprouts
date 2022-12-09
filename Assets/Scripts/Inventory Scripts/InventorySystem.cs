using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

[System.Serializable]
public class InventorySystem
{

    public static InventorySystem instance;

    [SerializeField] private List<InventorySlot> inventorySlots;

    public List<InventorySlot> InventorySlots => inventorySlots;
    public int InventorySize => InventorySlots.Count;

    public UnityAction<InventorySlot> OnInventorySlotChanged;

    private void Awake()
    {
        instance = this;

    }

    public InventorySystem(int size)
    {
        inventorySlots = new List<InventorySlot>(size);

        for (int i = 0; i < size; i++)
        {
            inventorySlots.Add(new InventorySlot());
        }
    }
    //l
    public bool AddToInventory(ShopItemSO itemToAdd)
    {
        // getting rid of stackability because doesn't carry over to planting functionality

        // check whether item exists in inventory
        //if (ContainsItem(itemToAdd, out List<InventorySlot> invSlot))
        //{
        //    // add to already existing stack of that item
        //    foreach (var slot in invSlot)
        //    {
        //        slot.AddToStack(amountToAdd);
        //        OnInventorySlotChanged.Invoke(slot);
        //    }
        //    return true;
        //}

        // gets first available slot
        if (HasFreeSlot(out InventorySlot freeSlot))
        {
            //Debug.Log("has free slot = " + freeSlot);
            freeSlot.UpdateInventorySlot(itemToAdd);
            OnInventorySlotChanged.Invoke(freeSlot);
            return true;
        }

        // else
        Debug.Log("inventory full");
        return false;
    }

    public bool ContainsItem(ShopItemSO itemToAdd, out List<InventorySlot> invSlot)
    {
        // Where Filters sequence of values based on a predicate (bool-valued function)

        // get item in slot list where its itemData equal to itemToAdd
        invSlot = InventorySlots.Where(i => i.ItemData == itemToAdd).ToList();
    
        // if there is no slot that contains same itemData as itemToAdd, return false
        return invSlot.Count == 0 ? false : true;
    }

    public bool HasFreeSlot(out InventorySlot freeSlot)
    {
        // get first element in inventory where there is no item
        freeSlot = InventorySlots.FirstOrDefault(i => i.ItemData == null);
        return freeSlot == null ? false : true;
    }
}
