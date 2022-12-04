using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public abstract class InventoryDisplay : MonoBehaviour
{

    public static InventoryDisplay instance;
    [SerializeField] MouseItemData mouseInventoryItem;

    public string babyName;

    protected InventorySystem inventorySystem;
    protected Dictionary<InventorySlot_UI, InventorySlot> slotDictionary;

    // getters
    public InventorySystem InventorySystem => inventorySystem;
    public Dictionary<InventorySlot_UI, InventorySlot> SlotDictionary => slotDictionary;

    protected virtual void Start()
    {
       // must keep for abstract class
    }

    private void Awake()
    {
        instance = this;

    }


    public abstract void AssignSlot(InventorySystem invToDisplay); // need to know which system slots correspond to UI slots

    // match system slots to UI slots
    protected virtual void UpdateSlot(InventorySlot updatedSlot)
    {
        foreach (var slot in SlotDictionary)
        {
            if(slot.Value == updatedSlot) // slot value - the "under the hood" inventory slot
            {
                slot.Key.UpdateUISlot(updatedSlot); // slot key - the UI representation of the value
            }
        }
    }

    public void SlotClicked(InventorySlot_UI clickedUISlot)
    {
        // clicked slot has an item, mouse doesn't have item -- pick up item
        if (clickedUISlot.AssignedInvSlot.ItemData != null && mouseInventoryItem.AssignedInvSlot.ItemData == null)
        {
           // Debug.Log(mouseInventoryItem.AssignedInvSlot.ItemData);
            mouseInventoryItem.UpdateMouseSlot(clickedUISlot.AssignedInvSlot);
            babyName = mouseInventoryItem.AssignedInvSlot.ItemData.name;
           // Debug.Log(babyName);
            clickedUISlot.ClearSlot();
            return;
        }

        // clicked slot doesn't have item, mouse does -- place mouse item into empty slot
        if (clickedUISlot.AssignedInvSlot.ItemData == null && mouseInventoryItem.AssignedInvSlot.ItemData != null)
        {
            clickedUISlot.AssignedInvSlot.AssignItem(mouseInventoryItem.AssignedInvSlot);
            clickedUISlot.UpdateUISlot();

            mouseInventoryItem.ClearSlot();
        }

        // both slots have item 
        if (clickedUISlot.AssignedInvSlot.ItemData != null && mouseInventoryItem.AssignedInvSlot.ItemData != null)
        {
            // If items same -- combine stack
            if (clickedUISlot.AssignedInvSlot.ItemData == mouseInventoryItem.AssignedInvSlot.ItemData)
            {
                clickedUISlot.AssignedInvSlot.AssignItem(mouseInventoryItem.AssignedInvSlot); // add to stack
                clickedUISlot.UpdateUISlot();
                mouseInventoryItem.ClearSlot();
            }

            // If not -- swap them
            else
            {
                SwapSlots(clickedUISlot);
            }
        }

    }

    private void SwapSlots(InventorySlot_UI clickedUISlot)
    {
        var clonedSlot = new InventorySlot(mouseInventoryItem.AssignedInvSlot.ItemData, mouseInventoryItem.AssignedInvSlot.StackSize); // temp slot containing mouse item
        mouseInventoryItem.ClearSlot(); // clear mouse

        mouseInventoryItem.UpdateMouseSlot(clickedUISlot.AssignedInvSlot); // mouse now has item from slot

        clickedUISlot.ClearSlot(); // clear slot (now mouse has item)

        clickedUISlot.AssignedInvSlot.AssignItem(clonedSlot); // get new slot item from temp
        clickedUISlot.UpdateUISlot(); 
    }
}
