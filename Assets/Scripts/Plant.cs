using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class Plant : MonoBehaviour
{

    public static Plant instance;

    public Vector3Int currentSprout;

    public bool hasOneatOne = false;
    public bool hasTwoatOne = false;
    public bool hasThreeatOne = false;
    public bool hasFouratOne = false;
    public bool hasFiveatOne = false;
    public bool hasSixatOne = false;

    public bool hasOneatTwo = false;
    public bool hasTwoatTwo = false;
    public bool hasThreeatTwo = false;
    public bool hasFouratTwo = false;
    public bool hasFiveatTwo = false;
    public bool hasSixatTwo = false;

    public bool hasOneatThree = false;
    public bool hasTwoatThree = false;
    public bool hasThreeatThree = false;
    public bool hasFouratThree = false;
    public bool hasFiveatThree = false;
    public bool hasSixatThree = false;

    public bool hasOneatFour = false;
    public bool hasTwoatFour = false;
    public bool hasThreeatFour = false;
    public bool hasFouratFour = false;
    public bool hasFiveatFour = false;
    public bool hasSixatFour = false;

    public bool hasOneatFive = false;
    public bool hasTwoatFive = false;
    public bool hasThreeatFive = false;
    public bool hasFouratFive = false;
    public bool hasFiveatFive = false;
    public bool hasSixatFive = false;

    public bool hasOneatSix = false;
    public bool hasTwoatSix = false;
    public bool hasThreeatSix = false;
    public bool hasFouratSix = false;
    public bool hasFiveatSix = false;
    public bool hasSixatSix = false;


    [SerializeField] private ShopItemSO DoneBaby1;
    [SerializeField] private ShopItemSO DoneBaby2;
    [SerializeField] private ShopItemSO DoneBaby3;
    [SerializeField] private ShopItemSO DoneBaby4;
    [SerializeField] private ShopItemSO DoneBaby5;
    [SerializeField] private ShopItemSO DoneBaby6;

    GameObject SavedObjs; 
    private GameObject invHolder;


    // Animator animator;

    [SerializeField] private Tilemap interactableMap;

    [SerializeField] private Tile baby1;
    [SerializeField] private Tile baby2;
    [SerializeField] private Tile baby3;
    [SerializeField] private Tile baby4;
    [SerializeField] private Tile baby5;
    [SerializeField] private Tile baby6;


    [SerializeField] private Button slot1;
    [SerializeField] private Button slot2;
    [SerializeField] private Button slot3;
    [SerializeField] private Button slot4;
    [SerializeField] private Button slot5;
    [SerializeField] private Button slot6;

    // for animations
    [SerializeField] private GameObject one;
    [SerializeField] private GameObject two;
    [SerializeField] private GameObject three;
    [SerializeField] private GameObject four;
    [SerializeField] private GameObject five;
    [SerializeField] private GameObject six;

    


    public bool BabyPlanted = false;

    private void Awake()
    {
        instance = this;
        SavedObjs = SaveObject.savedObjs; 

        invHolder = SavedObjs.gameObject.transform.Find("Inventory Holder").gameObject;
        
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

    public void NewDayNewBabies(){
        if(hasOneatOne){
            interactableMap.SetTile(new Vector3Int(-5, -6, 0), baby1);
        }
        if(hasTwoatOne){
            interactableMap.SetTile(new Vector3Int(-5, -6, 0), baby2);
        }
        if(hasThreeatOne){
            interactableMap.SetTile(new Vector3Int(-5, -6, 0), baby3);
        }
        if(hasFouratOne){
            interactableMap.SetTile(new Vector3Int(-5, -6, 0), baby4);
        }
        if(hasFiveatOne){
            interactableMap.SetTile(new Vector3Int(-5, -6, 0), baby5);
        }
        if(hasSixatOne){
            interactableMap.SetTile(new Vector3Int(-5, -6, 0), baby6);
        }



        if(hasOneatTwo){
            interactableMap.SetTile(new Vector3Int(-11, -6, 0), baby1);
        }
        if(hasTwoatTwo){
            interactableMap.SetTile(new Vector3Int(-11, -6, 0), baby2);
        }
        if(hasThreeatTwo){
            interactableMap.SetTile(new Vector3Int(-11, -6, 0), baby3);
        }
        if(hasFouratTwo){
            interactableMap.SetTile(new Vector3Int(-11, -6, 0), baby4);
        }
        if(hasFiveatTwo){
            interactableMap.SetTile(new Vector3Int(-11, -6, 0), baby5);
        }
        if(hasSixatTwo){
            interactableMap.SetTile(new Vector3Int(-11, -6, 0), baby6);
        }


        if(hasOneatThree){
            interactableMap.SetTile(new Vector3Int(-17, -6, 0), baby1);
        }
        if(hasTwoatThree){
            interactableMap.SetTile(new Vector3Int(-17, -6, 0), baby2);
        }
        if(hasThreeatThree){
            interactableMap.SetTile(new Vector3Int(-17, -6, 0), baby3);
        }
        if(hasFouratThree){
            interactableMap.SetTile(new Vector3Int(-17, -6, 0), baby4);
        }
        if(hasFiveatThree){
            interactableMap.SetTile(new Vector3Int(-17, -6, 0), baby5);
        }
        if(hasSixatThree){
            interactableMap.SetTile(new Vector3Int(-17, -6, 0), baby6);
        }

        if(hasOneatFour){
            interactableMap.SetTile(new Vector3Int(-17, 1, 0), baby1);
        }
        if(hasTwoatFour){
            interactableMap.SetTile(new Vector3Int(-17, 1, 0), baby2);
        }
        if(hasThreeatFour){
            interactableMap.SetTile(new Vector3Int(-17, 1, 0), baby3);
        }
        if(hasFouratFour){
            interactableMap.SetTile(new Vector3Int(-17, 1, 0), baby4);
        }
        if(hasFiveatFour){
            interactableMap.SetTile(new Vector3Int(-17, 1, 0), baby5);
        }
        if(hasSixatFour){
            interactableMap.SetTile(new Vector3Int(-17, 1, 0), baby6);
        }


        if(hasOneatFive){
            interactableMap.SetTile(new Vector3Int(-11, 1, 0), baby1);
        }
        if(hasTwoatFive){
            interactableMap.SetTile(new Vector3Int(-11, 1, 0), baby2);
        }
        if(hasThreeatFive){
            interactableMap.SetTile(new Vector3Int(-11, 1, 0), baby3);
        }
        if(hasFouratFive){
            interactableMap.SetTile(new Vector3Int(-11, 1, 0), baby4);
        }
        if(hasFiveatFive){
            interactableMap.SetTile(new Vector3Int(-11, 1, 0), baby5);
        }
        if(hasSixatFive){
            interactableMap.SetTile(new Vector3Int(-11, 1, 0), baby6);
        }


        if(hasOneatSix){
            interactableMap.SetTile(new Vector3Int(-5, 1, 0), baby1);
        }
        if(hasTwoatSix){
            interactableMap.SetTile(new Vector3Int(-5, 1, 0), baby2);
        }
        if(hasThreeatSix){
            interactableMap.SetTile(new Vector3Int(-5, 1, 0), baby3);
        }
        if(hasFouratSix){
            interactableMap.SetTile(new Vector3Int(-5, 1, 0), baby4);
        }
        if(hasFiveatSix){
            interactableMap.SetTile(new Vector3Int(-5, 1, 0), baby5);
        }
        if(hasSixatSix){
            interactableMap.SetTile(new Vector3Int(-5, 1, 0), baby6);
        }
        
    }

    public void turnOffAnims(){
        one.SetActive(false);
        two.SetActive(false);
        three.SetActive(false);
        four.SetActive(false);
        five.SetActive(false);
        six.SetActive(false);
    }

    // public void Harvest(){
    //     var inventory = invHolder.GetComponent<InventoryHolder>();
    //     if(Plant.instance.seed == "Baby 1"){
    //         inventory.InventorySystem.AddToInventory(DoneBaby1, 1);
    //     }else if(Plant.instance.seed == "Baby 2"){ 
    //         inventory.InventorySystem.AddToInventory(DoneBaby2, 1);
    //     }else if(Plant.instance.seed == "Baby 3"){
    //         inventory.InventorySystem.AddToInventory(DoneBaby3, 1);
    //     }else if(Plant.instance.seed == "Baby 4"){
    //         inventory.InventorySystem.AddToInventory(DoneBaby4, 1);
    //     }else if(Plant.instance.seed == "Baby 5"){
    //         inventory.InventorySystem.AddToInventory(DoneBaby5, 1);
    //     }else if(Plant.instance.seed == "Baby 6"){
    //         inventory.InventorySystem.AddToInventory(DoneBaby6, 1);
    //     }
        
    // }

    public void PlantBabySlot1(){
        if(MouseItemData.instance.hasItem){
            Debug.Log(InventoryDisplay.instance.babyName);
            if(InventoryDisplay.instance.babyName == "Baby 1"){
                one.SetActive(true);
                //interactableMap.SetTile(new Vector3Int(-5, -6, 0), sprout);
                slot1.gameObject.SetActive(false);
                // animator.Play("seedling");
                currentSprout = new Vector3Int(-5, -6, 0);
                BabyPlanted = true;
                hasOneatOne = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 2"){
                one.SetActive(true);
                //interactableMap.SetTile(new Vector3Int(-5, -6, 0), sprout);
                slot1.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-5, -6, 0);
                BabyPlanted = true;
                hasTwoatOne = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 3"){
                one.SetActive(true);
                //interactableMap.SetTile(new Vector3Int(-5, -6, 0), sprout);
                slot1.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-5, -6, 0);
                BabyPlanted = true;
                hasThreeatOne = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 4"){
                one.SetActive(true);
                //interactableMap.SetTile(new Vector3Int(-5, -6, 0), sprout);
                slot1.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-5, -6, 0);
                BabyPlanted = true;
                hasFouratOne = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 5"){
                one.SetActive(true);
                //interactableMap.SetTile(new Vector3Int(-5, -6, 0), sprout);
                slot1.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-5, -6, 0);
                BabyPlanted = true;
                hasFiveatOne = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 6"){
                one.SetActive(true);
                //interactableMap.SetTile(new Vector3Int(-5, -6, 0), sprout);
                slot1.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-5, -6, 0);
                BabyPlanted = true;
                hasSixatOne = true;
            }
        }
    }

    public void PlantBabySlot2(){
        Debug.Log(MouseItemData.instance.hasItem);
        if(MouseItemData.instance.hasItem){
            if(InventoryDisplay.instance.babyName == "Baby 1"){
                two.SetActive(true);
                //interactableMap.SetTile(new Vector3Int(-11, -6, 0), sprout);
                slot2.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-11, -6, 0);
                BabyPlanted = true;
                hasOneatTwo = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 2"){
                two.SetActive(true);
                //interactableMap.SetTile(new Vector3Int(-11, -6, 0), sprout);
                slot2.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-11, -6, 0);
                BabyPlanted = true;
                hasTwoatTwo = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 3"){
                two.SetActive(true);
                //interactableMap.SetTile(new Vector3Int(-11, -6, 0), sprout);
                slot2.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-11, -6, 0);
                BabyPlanted = true;
                hasThreeatTwo = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 4"){
                two.SetActive(true);
                //interactableMap.SetTile(new Vector3Int(-11, -6, 0), sprout);
                slot2.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-11, -6, 0);
                BabyPlanted = true;
                hasFouratTwo = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 5"){
                two.SetActive(true);
                //interactableMap.SetTile(new Vector3Int(-11, -6, 0), sprout);
                slot2.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-11, -6, 0);
                BabyPlanted = true;
                hasFiveatTwo = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 6"){
                two.SetActive(true);
                //interactableMap.SetTile(new Vector3Int(-11, -6, 0), sprout);
                slot2.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-11, -6, 0);
                BabyPlanted = true;
                hasSixatTwo = true;
            }
        }
    }

    public void PlantBabySlot3(){
        Debug.Log(MouseItemData.instance.hasItem);
        if(MouseItemData.instance.hasItem){
            if(InventoryDisplay.instance.babyName == "Baby 1"){
                three.SetActive(true);
                //interactableMap.SetTile(new Vector3Int(-17, -6, 0), sprout);
                slot3.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-17, -6, 0);
                BabyPlanted = true;
                hasOneatThree = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 2"){
                three.SetActive(true);
                //interactableMap.SetTile(new Vector3Int(-17, -6, 0), sprout);
                slot3.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-17, -6, 0);
                BabyPlanted = true;
                hasTwoatThree = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 3"){
                three.SetActive(true);
                //interactableMap.SetTile(new Vector3Int(-17, -6, 0), sprout);
                slot3.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-17, -6, 0);
                BabyPlanted = true;
                hasThreeatThree = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 4"){
                three.SetActive(true);
                //interactableMap.SetTile(new Vector3Int(-17, -6, 0), sprout);
                slot3.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-17, -6, 0);
                BabyPlanted = true;
                hasFouratThree = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 5"){
                three.SetActive(true);
                //interactableMap.SetTile(new Vector3Int(-17, -6, 0), sprout);
                slot3.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-17, -6, 0);
                BabyPlanted = true;
                hasFiveatThree = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 6"){
                three.SetActive(true);
                //interactableMap.SetTile(new Vector3Int(-17, -6, 0), sprout);
                slot3.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-17, -6, 0);
                BabyPlanted = true;
                hasSixatThree = true;
            }
        }
    }

    public void PlantBabySlot4(){
        Debug.Log(MouseItemData.instance.hasItem);
        if(MouseItemData.instance.hasItem){
            if(InventoryDisplay.instance.babyName == "Baby 1"){
                four.SetActive(true);
                //interactableMap.SetTile(new Vector3Int(-17, 1, 0), sprout);
                slot4.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-17, 1, 0);
                BabyPlanted = true;
                hasOneatFour = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 2"){
                four.SetActive(true);
                //interactableMap.SetTile(new Vector3Int(-17, 1, 0), sprout);
                slot4.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-17, 1, 0);
                BabyPlanted = true;
                hasTwoatFour = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 3"){
                four.SetActive(true);
                //interactableMap.SetTile(new Vector3Int(-17, 1, 0), sprout);
                slot4.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-17, 1, 0);
                BabyPlanted = true;
                hasThreeatFour = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 4"){
                four.SetActive(true);
                //interactableMap.SetTile(new Vector3Int(-17, 1, 0), sprout);
                slot4.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-17, 1, 0);
                BabyPlanted = true;
                hasFouratFour = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 5"){
                four.SetActive(true);
                //interactableMap.SetTile(new Vector3Int(-17, 1, 0), sprout);
                slot4.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-17, 1, 0);
                BabyPlanted = true;
                hasFiveatFour = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 6"){
                four.SetActive(true);
                //interactableMap.SetTile(new Vector3Int(-17, 1, 0), sprout);
                slot4.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-17, 1, 0);
                BabyPlanted = true;
                hasSixatFour = true;
            }
        }
    }

    public void PlantBabySlot5(){
        Debug.Log(MouseItemData.instance.hasItem);
        if(MouseItemData.instance.hasItem){
            if(InventoryDisplay.instance.babyName == "Baby 1"){
                five.SetActive(true);
                //interactableMap.SetTile(new Vector3Int(-11, 1, 0), sprout);
                slot5.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-11, 1, 0);
                BabyPlanted = true;
                hasOneatFive = true;
            
            }else if(InventoryDisplay.instance.babyName == "Baby 2"){
                five.SetActive(true);
                //interactableMap.SetTile(new Vector3Int(-11, 1, 0), sprout);
                slot5.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-11, 1, 0);
                BabyPlanted = true;
                hasTwoatFive = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 3"){
                five.SetActive(true);
                //interactableMap.SetTile(new Vector3Int(-11, 1, 0), sprout);
                slot5.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-11, 1, 0);
                BabyPlanted = true;
                hasThreeatFive = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 4"){
                five.SetActive(true);
                //interactableMap.SetTile(new Vector3Int(-11, 1, 0), sprout);
                slot5.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-11, 1, 0);
                BabyPlanted = true;
                hasFouratFive = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 5"){
                five.SetActive(true);
                //interactableMap.SetTile(new Vector3Int(-11, 1, 0), sprout);
                slot5.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-11, 1, 0);
                BabyPlanted = true;
                hasFiveatFive = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 6"){
                five.SetActive(true);
                //interactableMap.SetTile(new Vector3Int(-11, 1, 0), sprout);
                slot5.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-11, 1, 0);
                BabyPlanted = true;
                hasSixatFive = true;
            }
        }
    }

    public void PlantBabySlot6(){
        Debug.Log(MouseItemData.instance.hasItem);
        if(MouseItemData.instance.hasItem){
            if(InventoryDisplay.instance.babyName == "Baby 1"){
                six.SetActive(true);
                //interactableMap.SetTile(new Vector3Int(-5, 1, 0), sprout);
                slot6.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-5, 1, 0);
                BabyPlanted = true;
                hasOneatSix = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 2"){
                six.SetActive(true);
                //interactableMap.SetTile(new Vector3Int(-5, 1, 0), sprout);
                slot6.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-5, 1, 0);
                BabyPlanted = true;
                hasTwoatSix = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 3"){
                six.SetActive(true);
                //interactableMap.SetTile(new Vector3Int(-5, 1, 0), sprout);
                slot6.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-5, 1, 0);
                BabyPlanted = true;
                hasThreeatSix = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 4"){
                six.SetActive(true);
                //interactableMap.SetTile(new Vector3Int(-5, 1, 0), sprout);
                slot6.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-5, 1, 0);
                BabyPlanted = true;
                hasFouratSix = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 5"){
                six.SetActive(true);
                //interactableMap.SetTile(new Vector3Int(-5, 1, 0), sprout);
                slot6.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-5, 1, 0);
                BabyPlanted = true;
                hasFiveatSix = true;
            }else if(InventoryDisplay.instance.babyName == "Baby 6"){
                six.SetActive(true);
                //interactableMap.SetTile(new Vector3Int(-5, 1, 0), sprout);
                slot6.gameObject.SetActive(false);
                currentSprout = new Vector3Int(-5, 1, 0);
                BabyPlanted = true;
                hasSixatSix = true;
            }
        }
    }
}
