using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="ShopMenu", menuName ="Scriptable Objects/New Shop Item", order = 1)]
public class ShopItemSO : ScriptableObject
{
    public string title;
    public string description;
    public int cost;
    public Sprite icon;
    public List<Attribute> attributes;
    public string status; 
        // if preferred, I can make status a bool, but I figured a string was more human-readable
}
