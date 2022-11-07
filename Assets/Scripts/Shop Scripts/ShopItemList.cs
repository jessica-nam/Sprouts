using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/New Shop Item List")]
public class ShopItemList : ScriptableObject
{
    [SerializeField] private List<ShopInventoryItem> _items;
    //[SerializeField] private int _maxAllowedGold;

    public List<ShopInventoryItem> Items => _items;
    //public int max
}

[System.Serializable]
public struct ShopInventoryItem
{
    public ShopItemSO ItemData;
    public int Amount;
}
