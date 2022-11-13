using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Plant : MonoBehaviour
{

    public static Plant instance;

    [SerializeField] private Tilemap interactableMap;
    [SerializeField] private Tile LeafBabyTile;

    public bool BabyPlanted = false;

    private void Awake()
    {
        instance = this;

    }

    public void PlantBaby(){
        Debug.Log(MouseItemData.instance.hasItem);
        if(MouseItemData.instance.hasItem){
            interactableMap.SetTile(new Vector3Int(-5, -6, 0), LeafBabyTile);
            Debug.Log("Plant");
            BabyPlanted = true;
        }
    }
}
