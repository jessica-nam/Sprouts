using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventorySlot : ItemSlot
{
    public InventorySlot(ShopItemSO source, int amount)
    {
        itemData = source;
        stackSize = amount;
    }

    public InventorySlot()
    {
        ClearSlot();
    }

    public void UpdateInventorySlot(ShopItemSO data, int amount)
    {
        itemData = data;
        stackSize = amount;
    }
}
