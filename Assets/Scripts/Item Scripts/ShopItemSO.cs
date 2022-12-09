using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="ShopMenu", menuName ="Scriptable Objects/New Shop Item", order = 1)]
public class ShopItemSO : ScriptableObject
{
    public string title;
    public int cost;
    public Sprite icon;
    public List<Attribute> attributes;
    public int score;
    public bool sellable = false;
    public int sellIndex = -1;

    public void Reset()
    {
       // title = "";
        cost = 0;
        //icon = 
        if(attributes != null)
            attributes.Clear();
        score = 0;
    }
}
