using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class ItemSlot : ISerializationCallbackReceiver
{
    [SerializeField] protected ShopItemSO itemData;
    [SerializeField] protected int stackSize;

    public ShopItemSO ItemData => itemData;
    public int StackSize => stackSize;

    public void ClearSlot()
    {
        itemData = null;
        stackSize = -1;
    }

    public void AssignItem(InventorySlot invSlot)
    {
        if (itemData == invSlot.itemData) AddToStack(invSlot.stackSize);
        else // overwrite slot with inventory slot we're passing to
        {
            itemData = invSlot.itemData;
            stackSize = 0;
            AddToStack(invSlot.stackSize);
        }
    }

    public void AssignItem(ShopItemSO data, int amount)
    {
        if (itemData == data) AddToStack(amount);
        else
        {
            itemData = data;
            stackSize = 0;
            AddToStack(amount);
        }
    }

    public void AddToStack(int amount)
    {
        stackSize += amount;
    }

    public void RemoveFromStack(int amount)
    {
        stackSize -= amount;
    }

    public void OnAfterDeserialize()
    {
    }

    public void OnBeforeSerialize()
    {
    }
}
