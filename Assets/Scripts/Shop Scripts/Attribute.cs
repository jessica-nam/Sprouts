using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "ShopMenu", menuName = "Scriptable Objects/New Attribute", order = 1)]
public class Attribute : ScriptableObject
{
    [SerializeField] public string attributeName;
    [SerializeField] public int weight;
}

