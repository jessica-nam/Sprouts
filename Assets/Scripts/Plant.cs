using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class Plant : MonoBehaviour
{

    public static Plant instance;

    public Vector3Int currentSprout;


    // Animator animator;

    [SerializeField] private Tilemap interactableMap;

    [SerializeField] private Tile sprout;

    [SerializeField] private Button slot1;
    [SerializeField] private Button slot2;
    [SerializeField] private Button slot3;
    [SerializeField] private Button slot4;
    [SerializeField] private Button slot5;
    [SerializeField] private Button slot6;

    


    public bool BabyPlanted = false;

    private void Awake()
    {
        instance = this;
        
        // animator = GetComponent<Animator>();

    }

    void Update(){
        if(MouseItemData.instance.hasItem == true){
            slot1.gameObject.SetActive(true);
            slot2.gameObject.SetActive(true);
            slot3.gameObject.SetActive(true);
            slot4.gameObject.SetActive(true);
            slot5.gameObject.SetActive(true);
            slot6.gameObject.SetActive(true);

            
        }else{
            slot1.gameObject.SetActive(false);
            slot2.gameObject.SetActive(false);
            slot3.gameObject.SetActive(false);
            slot4.gameObject.SetActive(false);
            slot5.gameObject.SetActive(false);
            slot6.gameObject.SetActive(false);

        }
    }

    public void PlantBabySlot1(){
        if(MouseItemData.instance.hasItem){
            Debug.Log(InventoryDisplay.instance.babyName);
            if(InventoryDisplay.instance.babyName == "Baby 1"){
                interactableMap.SetTile(new Vector3Int(-5, -6, 0), sprout);
                slot1.gameObject.SetActive(false);
                // animator.Play("seedling");
                currentSprout = new Vector3Int(-5, -6, 0);
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 2"){
                interactableMap.SetTile(new Vector3Int(-5, -6, 0), sprout);
                slot1.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-5, -6, 0);
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 3"){
                interactableMap.SetTile(new Vector3Int(-5, -6, 0), sprout);
                slot1.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-5, -6, 0);
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 4"){
                interactableMap.SetTile(new Vector3Int(-5, -6, 0), sprout);
                slot1.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-5, -6, 0);
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 5"){
                interactableMap.SetTile(new Vector3Int(-5, -6, 0), sprout);
                slot1.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-5, -6, 0);
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 6"){
                interactableMap.SetTile(new Vector3Int(-5, -6, 0), sprout);
                slot1.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-5, -6, 0);
                BabyPlanted = true;
            }
        }
    }

    public void PlantBabySlot2(){
        Debug.Log(MouseItemData.instance.hasItem);
        if(MouseItemData.instance.hasItem){
            if(InventoryDisplay.instance.babyName == "Baby 1"){
                interactableMap.SetTile(new Vector3Int(-11, -6, 0), sprout);
                slot2.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-11, -6, 0);
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 2"){
                interactableMap.SetTile(new Vector3Int(-11, -6, 0), sprout);
                slot2.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-11, -6, 0);
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 3"){
                interactableMap.SetTile(new Vector3Int(-11, -6, 0), sprout);
                slot2.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-11, -6, 0);
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 4"){
                interactableMap.SetTile(new Vector3Int(-11, -6, 0), sprout);
                slot2.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-11, -6, 0);
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 5"){
                interactableMap.SetTile(new Vector3Int(-11, -6, 0), sprout);
                slot2.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-11, -6, 0);
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 6"){
                interactableMap.SetTile(new Vector3Int(-11, -6, 0), sprout);
                slot2.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-11, -6, 0);
                BabyPlanted = true;
            }
        }
    }

    public void PlantBabySlot3(){
        Debug.Log(MouseItemData.instance.hasItem);
        if(MouseItemData.instance.hasItem){
            if(InventoryDisplay.instance.babyName == "Baby 1"){
                interactableMap.SetTile(new Vector3Int(-17, -6, 0), sprout);
                slot3.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-17, -6, 0);
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 2"){
                interactableMap.SetTile(new Vector3Int(-17, -6, 0), sprout);
                slot3.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-17, -6, 0);
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 3"){
                interactableMap.SetTile(new Vector3Int(-17, -6, 0), sprout);
                slot3.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-17, -6, 0);
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 4"){
                interactableMap.SetTile(new Vector3Int(-17, -6, 0), sprout);
                slot3.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-17, -6, 0);
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 5"){
                interactableMap.SetTile(new Vector3Int(-17, -6, 0), sprout);
                slot3.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-17, -6, 0);
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 6"){
                interactableMap.SetTile(new Vector3Int(-17, -6, 0), sprout);
                slot3.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-17, -6, 0);
                BabyPlanted = true;
            }
        }
    }

    public void PlantBabySlot4(){
        Debug.Log(MouseItemData.instance.hasItem);
        if(MouseItemData.instance.hasItem){
            if(InventoryDisplay.instance.babyName == "Baby 1"){
                interactableMap.SetTile(new Vector3Int(-17, 1, 0), sprout);
                slot4.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-17, 1, 0);
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 2"){
                interactableMap.SetTile(new Vector3Int(-17, 1, 0), sprout);
                slot4.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-17, 1, 0);
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 3"){
                interactableMap.SetTile(new Vector3Int(-17, 1, 0), sprout);
                slot4.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-17, 1, 0);
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 4"){
                interactableMap.SetTile(new Vector3Int(-17, 1, 0), sprout);
                slot4.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-17, 1, 0);
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 5"){
                interactableMap.SetTile(new Vector3Int(-17, 1, 0), sprout);
                slot4.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-17, 1, 0);
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 6"){
                interactableMap.SetTile(new Vector3Int(-17, 1, 0), sprout);
                slot4.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-17, 1, 0);
                BabyPlanted = true;
            }
        }
    }

    public void PlantBabySlot5(){
        Debug.Log(MouseItemData.instance.hasItem);
        if(MouseItemData.instance.hasItem){
            if(InventoryDisplay.instance.babyName == "Baby 1"){
                interactableMap.SetTile(new Vector3Int(-11, 1, 0), sprout);
                slot5.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-11, 1, 0);
                BabyPlanted = true;
            
            }else if(InventoryDisplay.instance.babyName == "Baby 2"){
                interactableMap.SetTile(new Vector3Int(-11, 1, 0), sprout);
                slot5.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-11, 1, 0);
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 3"){
                interactableMap.SetTile(new Vector3Int(-11, 1, 0), sprout);
                slot5.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-11, 1, 0);
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 4"){
                interactableMap.SetTile(new Vector3Int(-11, 1, 0), sprout);
                slot5.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-11, 1, 0);
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 5"){
                interactableMap.SetTile(new Vector3Int(-11, 1, 0), sprout);
                slot5.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-11, 1, 0);
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 6"){
                interactableMap.SetTile(new Vector3Int(-11, 1, 0), sprout);
                slot5.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-11, 1, 0);
                BabyPlanted = true;
            }
        }
    }

    public void PlantBabySlot6(){
        Debug.Log(MouseItemData.instance.hasItem);
        if(MouseItemData.instance.hasItem){
            if(InventoryDisplay.instance.babyName == "Baby 1"){
                interactableMap.SetTile(new Vector3Int(-5, 1, 0), sprout);
                slot6.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-5, 1, 0);
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 2"){
                interactableMap.SetTile(new Vector3Int(-5, 1, 0), sprout);
                slot6.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-5, 1, 0);
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 3"){
                interactableMap.SetTile(new Vector3Int(-5, 1, 0), sprout);
                slot6.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-5, 1, 0);
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 4"){
                interactableMap.SetTile(new Vector3Int(-5, 1, 0), sprout);
                slot6.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-5, 1, 0);
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 5"){
                interactableMap.SetTile(new Vector3Int(-5, 1, 0), sprout);
                slot6.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-5, 1, 0);
                BabyPlanted = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 6"){
                interactableMap.SetTile(new Vector3Int(-5, 1, 0), sprout);
                slot6.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-5, 1, 0);
                BabyPlanted = true;
            }
        }
    }
}
