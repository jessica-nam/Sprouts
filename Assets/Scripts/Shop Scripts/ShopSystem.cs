using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class ShopSystem
{
    [SerializeField] private List<ShopSlot> _shopInventory;
    //private int _availableGold;

    public ShopSystem(int size)
    {
        //_availableGold = gold;

        SetShopSize(size);
    }

    private void SetShopSize(int size)
    {
        _shopInventory = new List<ShopSlot>(size);

        for (int i = 0; i < size; i++)
        {
            _shopInventory.Add(new ShopSlot());
        }
    }

    public void AddToShop(ShopItemSO data, int amount)
    {
        if(ContainsItem(data, out ShopSlot shopSlot))
        {
            shopSlot.AddToStack(amount);
        }

        var freeSlot = GetFreeSlot();
        freeSlot.AssignItem(data, amount);
    }

    private ShopSlot GetFreeSlot()
    {
        var freeSlot = _shopInventory.FirstOrDefault(i => i.ItemData == null);

        // if not empty slot
        if(freeSlot == null)
        {
            freeSlot = new ShopSlot();
            _shopInventory.Add(freeSlot);
        }

        return freeSlot;
    }

    public bool ContainsItem(ShopItemSO itemToAdd, out ShopSlot shopSlot)
    {
        // if item in shop, get shop slot item is in
        shopSlot = _shopInventory.Find(i => i.ItemData == itemToAdd); // find first one
        return shopSlot != null;
    }
}
