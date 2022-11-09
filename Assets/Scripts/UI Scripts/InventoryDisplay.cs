using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public abstract class InventoryDisplay : MonoBehaviour
{
    //[SerializeField] MouseItemData mouseInventoryItem;

    protected InventorySystem inventorySystem;
    protected Dictionary<InventorySlot_UI, InventorySlot> slotDictionary;

    // getters
    public InventorySystem InventorySystem => inventorySystem;
    public Dictionary<InventorySlot_UI, InventorySlot> SlotDictionary => slotDictionary;

    protected virtual void Start()
    {

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

    public void SlotClicked(InventorySlot_UI clickedSlot)
    {
        Debug.Log("slot clicked");
    }
}
