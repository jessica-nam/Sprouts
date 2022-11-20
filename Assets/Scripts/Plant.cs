using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Plant : MonoBehaviour
{

    public static Plant instance;

    public Vector3Int currentSprout;

    [SerializeField] private Tilemap interactableMap;

    [SerializeField] private Tile sprout;


    public bool BabyPlanted = false;

    private void Awake()
    {
        instance = this;

    }

    public void PlantBabySlot1(){
        Debug.Log(MouseItemData.instance.hasItem);
        if(MouseItemData.instance.hasItem){
            Debug.Log(InventoryDisplay.instance.babyName);
            if(InventoryDisplay.instance.babyName == "Baby 1"){
                interactableMap.SetTile(new Vector3Int(-5, -6, 0), sprout);
                currentSprout = new Vector3Int(-5, -6, 0);
                Debug.Log("Plant");
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 2"){
                interactableMap.SetTile(new Vector3Int(-5, -6, 0), sprout);
                currentSprout = new Vector3Int(-5, -6, 0);
                Debug.Log("Plant");
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 3"){
                interactableMap.SetTile(new Vector3Int(-5, -6, 0), sprout);
                currentSprout = new Vector3Int(-5, -6, 0);
                Debug.Log("Plant");
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 4"){
                interactableMap.SetTile(new Vector3Int(-5, -6, 0), sprout);
                currentSprout = new Vector3Int(-5, -6, 0);
                Debug.Log("Plant");
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 5"){
                interactableMap.SetTile(new Vector3Int(-5, -6, 0), sprout);
                currentSprout = new Vector3Int(-5, -6, 0);
                Debug.Log("Plant");
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 6"){
                interactableMap.SetTile(new Vector3Int(-5, -6, 0), sprout);
                currentSprout = new Vector3Int(-5, -6, 0);
                Debug.Log("Plant");
                BabyPlanted = true;
            }
        }
    }

    public void PlantBabySlot2(){
        Debug.Log(MouseItemData.instance.hasItem);
        if(MouseItemData.instance.hasItem){
            if(InventoryDisplay.instance.babyName == "Baby 1"){
                interactableMap.SetTile(new Vector3Int(-11, -6, 0), sprout);
                currentSprout = new Vector3Int(-11, -6, 0);
                Debug.Log("Plant");
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 2"){
                interactableMap.SetTile(new Vector3Int(-11, -6, 0), sprout);
                currentSprout = new Vector3Int(-11, -6, 0);
                Debug.Log("Plant");
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 3"){
                interactableMap.SetTile(new Vector3Int(-11, -6, 0), sprout);
                currentSprout = new Vector3Int(-11, -6, 0);
                Debug.Log("Plant");
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 4"){
                interactableMap.SetTile(new Vector3Int(-11, -6, 0), sprout);
                currentSprout = new Vector3Int(-11, -6, 0);
                Debug.Log("Plant");
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 5"){
                interactableMap.SetTile(new Vector3Int(-11, -6, 0), sprout);
                currentSprout = new Vector3Int(-11, -6, 0);
                Debug.Log("Plant");
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 6"){
                interactableMap.SetTile(new Vector3Int(-11, -6, 0), sprout);
                currentSprout = new Vector3Int(-11, -6, 0);
                Debug.Log("Plant");
                BabyPlanted = true;
            }
        }
    }

    public void PlantBabySlot3(){
        Debug.Log(MouseItemData.instance.hasItem);
        if(MouseItemData.instance.hasItem){
            if(InventoryDisplay.instance.babyName == "Baby 1"){
                interactableMap.SetTile(new Vector3Int(-17, -6, 0), sprout);
                currentSprout = new Vector3Int(-17, -6, 0);
                Debug.Log("Plant");
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 2"){
                interactableMap.SetTile(new Vector3Int(-17, -6, 0), sprout);
                currentSprout = new Vector3Int(-17, -6, 0);
                Debug.Log("Plant");
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 3"){
                interactableMap.SetTile(new Vector3Int(-17, -6, 0), sprout);
                currentSprout = new Vector3Int(-17, -6, 0);
                Debug.Log("Plant");
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 4"){
                interactableMap.SetTile(new Vector3Int(-17, -6, 0), sprout);
                currentSprout = new Vector3Int(-17, -6, 0);
                Debug.Log("Plant");
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 5"){
                interactableMap.SetTile(new Vector3Int(-17, -6, 0), sprout);
                currentSprout = new Vector3Int(-17, -6, 0);
                Debug.Log("Plant");
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 6"){
                interactableMap.SetTile(new Vector3Int(-17, -6, 0), sprout);
                currentSprout = new Vector3Int(-17, -6, 0);
                Debug.Log("Plant");
                BabyPlanted = true;
            }
        }
    }

    public void PlantBabySlot4(){
        Debug.Log(MouseItemData.instance.hasItem);
        if(MouseItemData.instance.hasItem){
            if(InventoryDisplay.instance.babyName == "Baby 1"){
                interactableMap.SetTile(new Vector3Int(-17, 1, 0), sprout);
                currentSprout = new Vector3Int(-17, 1, 0);
                Debug.Log("Plant");
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 2"){
                interactableMap.SetTile(new Vector3Int(-17, 1, 0), sprout);
                currentSprout = new Vector3Int(-17, 1, 0);
                Debug.Log("Plant");
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 3"){
                interactableMap.SetTile(new Vector3Int(-17, 1, 0), sprout);
                currentSprout = new Vector3Int(-17, 1, 0);
                Debug.Log("Plant");
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 4"){
                interactableMap.SetTile(new Vector3Int(-17, 1, 0), sprout);
                currentSprout = new Vector3Int(-17, 1, 0);
                Debug.Log("Plant");
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 5"){
                interactableMap.SetTile(new Vector3Int(-17, 1, 0), sprout);
                currentSprout = new Vector3Int(-17, 1, 0);
                Debug.Log("Plant");
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 6"){
                interactableMap.SetTile(new Vector3Int(-17, 1, 0), sprout);
                currentSprout = new Vector3Int(-17, 1, 0);
                Debug.Log("Plant");
                BabyPlanted = true;
            }
        }
    }

    public void PlantBabySlot5(){
        Debug.Log(MouseItemData.instance.hasItem);
        if(MouseItemData.instance.hasItem){
            if(InventoryDisplay.instance.babyName == "Baby 1"){
                interactableMap.SetTile(new Vector3Int(-11, 1, 0), sprout);
                currentSprout = new Vector3Int(-11, 1, 0);
                Debug.Log("Plant");
                BabyPlanted = true;
            
            }else if(InventoryDisplay.instance.babyName == "Baby 2"){
                interactableMap.SetTile(new Vector3Int(-11, 1, 0), sprout);
                currentSprout = new Vector3Int(-11, 1, 0);
                Debug.Log("Plant");
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 3"){
                interactableMap.SetTile(new Vector3Int(-11, 1, 0), sprout);
                currentSprout = new Vector3Int(-11, 1, 0);
                Debug.Log("Plant");
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 4"){
                interactableMap.SetTile(new Vector3Int(-11, 1, 0), sprout);
                currentSprout = new Vector3Int(-11, 1, 0);
                Debug.Log("Plant");
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 5"){
                interactableMap.SetTile(new Vector3Int(-11, 1, 0), sprout);
                currentSprout = new Vector3Int(-11, 1, 0);
                Debug.Log("Plant");
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 6"){
                interactableMap.SetTile(new Vector3Int(-11, 1, 0), sprout);
                currentSprout = new Vector3Int(-11, 1, 0);
                Debug.Log("Plant");
                BabyPlanted = true;
            }
        }
    }

    public void PlantBabySlot6(){
        Debug.Log(MouseItemData.instance.hasItem);
        if(MouseItemData.instance.hasItem){
            if(InventoryDisplay.instance.babyName == "Baby 1"){
                interactableMap.SetTile(new Vector3Int(-5, 1, 0), sprout);
                currentSprout = new Vector3Int(-5, 1, 0);
                Debug.Log("Plant");
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 2"){
                interactableMap.SetTile(new Vector3Int(-5, 1, 0), sprout);
                currentSprout = new Vector3Int(-5, 1, 0);
                Debug.Log("Plant");
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 3"){
                interactableMap.SetTile(new Vector3Int(-5, 1, 0), sprout);
                currentSprout = new Vector3Int(-5, 1, 0);
                Debug.Log("Plant");
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 4"){
                interactableMap.SetTile(new Vector3Int(-5, 1, 0), sprout);
                currentSprout = new Vector3Int(-5, 1, 0);
                Debug.Log("Plant");
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 5"){
                interactableMap.SetTile(new Vector3Int(-5, 1, 0), sprout);
                currentSprout = new Vector3Int(-5, 1, 0);
                Debug.Log("Plant");
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 6"){
                interactableMap.SetTile(new Vector3Int(-5, 1, 0), sprout);
                currentSprout = new Vector3Int(-5, 1, 0);
                Debug.Log("Plant");
                BabyPlanted = true;
            }
        }
    }
}
