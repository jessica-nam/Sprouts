using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

[System.Serializable]
public class InventorySystem
{
    [SerializeField] private List<InventorySlot> inventorySlots;

    public List<InventorySlot> InventorySlots => inventorySlots;
    public int InventorySize => InventorySlots.Count;

    public UnityAction<InventorySlot> OnInventorySlotChanged;

    public InventorySystem(int size)
    {
        inventorySlots = new List<InventorySlot>(size);

        for (int i = 0; i < size; i++)
        {
            inventorySlots.Add(new InventorySlot());
        }
    }
    //l
    public bool AddToInventory(ShopItemSO itemToAdd, int amountToAdd)
    {
        // currently can't stack inventory because I can't figure out the "ContainsItem" method


        // check whether item exists in inventory
        //if (ContainsItem(itemToAdd, out List<InventorySlot> invSlot))
        //{
        //    Debug.Log("contains item = " + itemToAdd);
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
            freeSlot.UpdateInventorySlot(itemToAdd, amountToAdd);
            OnInventorySlotChanged.Invoke(freeSlot);
            return true;
        }

        // else
        Debug.Log("inventory full");
        return false;
    }

    public bool ContainsItem(ShopItemSO itemToAdd, out List<InventorySlot> invSlot)
    {
        // fill inventory slots
        invSlot = InventorySlots.Where(i => i.ItemData == itemToAdd).ToList();

        return invSlot == null ? false : true;
    }

    public bool HasFreeSlot(out InventorySlot freeSlot)
    {
        // get first element in inventory where itemData is null
        freeSlot = InventorySlots.FirstOrDefault(i => i.ItemData == null);
        return freeSlot == null ? false : true;
    }
}