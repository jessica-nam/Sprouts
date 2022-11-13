using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Plant : MonoBehaviour
{

    public static Plant instance;

    [SerializeField] private Tilemap interactableMap;
    [SerializeField] private Tile baby1;
    [SerializeField] private Tile baby2;
    [SerializeField] private Tile baby3;
    [SerializeField] private Tile baby4;
    [SerializeField] private Tile baby5;
    [SerializeField] private Tile baby6;


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
            }else if(InventoryDisplay.instance.babyName == "Baby 2"){
                interactableMap.SetTile(new Vector3Int(-5, -6, 0), baby2);
                Debug.Log("Plant");
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 3"){
                interactableMap.SetTile(new Vector3Int(-5, -6, 0), baby3);
                Debug.Log("Plant");
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 4"){
                interactableMap.SetTile(new Vector3Int(-5, -6, 0), baby4);
                Debug.Log("Plant");
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 5"){
                interactableMap.SetTile(new Vector3Int(-5, -6, 0), baby5);
                Debug.Log("Plant");
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 6"){
                interactableMap.SetTile(new Vector3Int(-5, -6, 0), baby6);
                Debug.Log("Plant");
                BabyPlanted = true;
            }
        }
    }
}
