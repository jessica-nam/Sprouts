using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Plant : MonoBehaviour
{

    public static Plant instance;

    [SerializeField] private Tilemap interactableMap;
    [SerializeField] private Tile baby1;

    public bool BabyPlanted = false;

    private void Awake()
    {
        instance = this;

    }

    void Update(){

    }

    public void PlantBaby(){
        Debug.Log(MouseItemData.instance.hasItem);
        if(MouseItemData.instance.hasItem){
            if(InventoryDisplay.instance.babyName == "Baby 1"){
                interactableMap.SetTile(new Vector3Int(-5, -6, 0), baby1);
                Debug.Log("Plant");
                BabyPlanted = true;
            }
        }
    }
}
