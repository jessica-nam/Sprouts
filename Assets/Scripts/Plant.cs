using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class Plant : MonoBehaviour
{

    public static Plant instance;

    public MouseItemData mouseObj;

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

    public static ShopItemSO babyObj;
    public static InventorySlot slotData;

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

    [SerializeField] private Button harvest1;
    [SerializeField] private Button harvest2;
    [SerializeField] private Button harvest3;
    [SerializeField] private Button harvest4;
    [SerializeField] private Button harvest5;
    [SerializeField] private Button harvest6;

    // for animations
    [SerializeField] private GameObject one;
    [SerializeField] private GameObject two;
    [SerializeField] private GameObject three;
    [SerializeField] private GameObject four;
    [SerializeField] private GameObject five;
    [SerializeField] private GameObject six;

    public string h1;
    public string h2;
    public string h3;
    public string h4;
    public string h5;
    public string h6;
    


    public bool BabyPlanted = false;

    private void Awake()
    {
        instance = this;
        SavedObjs = SaveObject.savedObjs; 

        invHolder = SavedObjs.gameObject.transform.Find("Inventory Holder").gameObject;
        mouseObj = SavedObjs.gameObject.transform.Find("Mouse Object").gameObject.GetComponent<MouseItemData>();

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
            Debug.Log("Name");
            Debug.Log(interactableMap.GetTile(new Vector3Int(-5, -6, 0)).name);
            h1 = interactableMap.GetTile(new Vector3Int(-5, -6, 0)).name;
            harvest1.gameObject.SetActive(true);
        }
        if(hasTwoatOne){
            interactableMap.SetTile(new Vector3Int(-5, -6, 0), baby2);
            Debug.Log("Name");
            Debug.Log(interactableMap.GetTile(new Vector3Int(-5, -6, 0)).name);
            h1 = interactableMap.GetTile(new Vector3Int(-5, -6, 0)).name;
            harvest1.gameObject.SetActive(true);
        }
        if(hasThreeatOne){
            interactableMap.SetTile(new Vector3Int(-5, -6, 0), baby3);
            Debug.Log("Name");
            Debug.Log(interactableMap.GetTile(new Vector3Int(-5, -6, 0)).name);
            h1 = interactableMap.GetTile(new Vector3Int(-5, -6, 0)).name;
            harvest1.gameObject.SetActive(true);
        }
        if(hasFouratOne){
            interactableMap.SetTile(new Vector3Int(-5, -6, 0), baby4);
            Debug.Log("Name");
            Debug.Log(interactableMap.GetTile(new Vector3Int(-5, -6, 0)).name);
            h1 = interactableMap.GetTile(new Vector3Int(-5, -6, 0)).name;
            harvest1.gameObject.SetActive(true);
        }
        if(hasFiveatOne){
            interactableMap.SetTile(new Vector3Int(-5, -6, 0), baby5);
            Debug.Log("Name");
            Debug.Log(interactableMap.GetTile(new Vector3Int(-5, -6, 0)).name);
            h1 = interactableMap.GetTile(new Vector3Int(-5, -6, 0)).name;
            harvest1.gameObject.SetActive(true);
        }
        if(hasSixatOne){
            interactableMap.SetTile(new Vector3Int(-5, -6, 0), baby6);
            Debug.Log("Name");
            Debug.Log(interactableMap.GetTile(new Vector3Int(-5, -6, 0)).name);
            h1 = interactableMap.GetTile(new Vector3Int(-5, -6, 0)).name;
            harvest1.gameObject.SetActive(true);
        }



        if(hasOneatTwo){
            interactableMap.SetTile(new Vector3Int(-11, -6, 0), baby1);
            h2 = interactableMap.GetTile(new Vector3Int(-11, -6, 0)).name;
            harvest2.gameObject.SetActive(true);
        }
        if(hasTwoatTwo){
            interactableMap.SetTile(new Vector3Int(-11, -6, 0), baby2);
            h2 = interactableMap.GetTile(new Vector3Int(-11, -6, 0)).name;
            harvest2.gameObject.SetActive(true);
        }
        if(hasThreeatTwo){
            interactableMap.SetTile(new Vector3Int(-11, -6, 0), baby3);
            h2 = interactableMap.GetTile(new Vector3Int(-11, -6, 0)).name;
            harvest2.gameObject.SetActive(true);
        }
        if(hasFouratTwo){
            interactableMap.SetTile(new Vector3Int(-11, -6, 0), baby4);
            h2 = interactableMap.GetTile(new Vector3Int(-11, -6, 0)).name;
            harvest2.gameObject.SetActive(true);
        }
        if(hasFiveatTwo){
            interactableMap.SetTile(new Vector3Int(-11, -6, 0), baby5);
            h2 = interactableMap.GetTile(new Vector3Int(-11, -6, 0)).name;
            harvest2.gameObject.SetActive(true);
        }
        if(hasSixatTwo){
            interactableMap.SetTile(new Vector3Int(-11, -6, 0), baby6);
            h2 = interactableMap.GetTile(new Vector3Int(-11, -6, 0)).name;
            harvest2.gameObject.SetActive(true);
        }


        if(hasOneatThree){
            interactableMap.SetTile(new Vector3Int(-17, -6, 0), baby1);
            h3 = interactableMap.GetTile(new Vector3Int(-17, -6, 0)).name;
            harvest3.gameObject.SetActive(true);
        }
        if(hasTwoatThree){
            interactableMap.SetTile(new Vector3Int(-17, -6, 0), baby2);
            h3 = interactableMap.GetTile(new Vector3Int(-17, -6, 0)).name;
            harvest3.gameObject.SetActive(true);
        }
        if(hasThreeatThree){
            interactableMap.SetTile(new Vector3Int(-17, -6, 0), baby3);
            h3 = interactableMap.GetTile(new Vector3Int(-17, -6, 0)).name;
            harvest3.gameObject.SetActive(true);
        }
        if(hasFouratThree){
            interactableMap.SetTile(new Vector3Int(-17, -6, 0), baby4);
            h3 = interactableMap.GetTile(new Vector3Int(-17, -6, 0)).name;
            harvest3.gameObject.SetActive(true);
        }
        if(hasFiveatThree){
            interactableMap.SetTile(new Vector3Int(-17, -6, 0), baby5);
            h3 = interactableMap.GetTile(new Vector3Int(-17, -6, 0)).name;
            harvest3.gameObject.SetActive(true);
        }
        if(hasSixatThree){
            interactableMap.SetTile(new Vector3Int(-17, -6, 0), baby6);
            h3 = interactableMap.GetTile(new Vector3Int(-17, -6, 0)).name;
            harvest3.gameObject.SetActive(true);
        }

        if(hasOneatFour){
            interactableMap.SetTile(new Vector3Int(-17, 1, 0), baby1);
            h4 = interactableMap.GetTile(new Vector3Int(-17, 1, 0)).name;
            harvest4.gameObject.SetActive(true);
        }
        if(hasTwoatFour){
            interactableMap.SetTile(new Vector3Int(-17, 1, 0), baby2);
            h4 = interactableMap.GetTile(new Vector3Int(-17, 1, 0)).name;
            harvest4.gameObject.SetActive(true);
        }
        if(hasThreeatFour){
            interactableMap.SetTile(new Vector3Int(-17, 1, 0), baby3);
            h4 = interactableMap.GetTile(new Vector3Int(-17, 1, 0)).name;
            harvest4.gameObject.SetActive(true);
        }
        if(hasFouratFour){
            interactableMap.SetTile(new Vector3Int(-17, 1, 0), baby4);
            h4 = interactableMap.GetTile(new Vector3Int(-17, 1, 0)).name;
            harvest4.gameObject.SetActive(true);
        }
        if(hasFiveatFour){
            interactableMap.SetTile(new Vector3Int(-17, 1, 0), baby5);
            h4 = interactableMap.GetTile(new Vector3Int(-17, 1, 0)).name;
            harvest4.gameObject.SetActive(true);
        }
        if(hasSixatFour){
            interactableMap.SetTile(new Vector3Int(-17, 1, 0), baby6);
            h4 = interactableMap.GetTile(new Vector3Int(-17, 1, 0)).name;
            harvest4.gameObject.SetActive(true);
        }


        if(hasOneatFive){
            interactableMap.SetTile(new Vector3Int(-11, 1, 0), baby1);
            h5 = interactableMap.GetTile(new Vector3Int(-11, 1, 0)).name;
            harvest5.gameObject.SetActive(true);
        }
        if(hasTwoatFive){
            interactableMap.SetTile(new Vector3Int(-11, 1, 0), baby2);
            h5 = interactableMap.GetTile(new Vector3Int(-11, 1, 0)).name;
            harvest5.gameObject.SetActive(true);
        }
        if(hasThreeatFive){
            interactableMap.SetTile(new Vector3Int(-11, 1, 0), baby3);
            h5 = interactableMap.GetTile(new Vector3Int(-11, 1, 0)).name;
            harvest5.gameObject.SetActive(true);

        }
        if(hasFouratFive){
            interactableMap.SetTile(new Vector3Int(-11, 1, 0), baby4);
            h5 = interactableMap.GetTile(new Vector3Int(-11, 1, 0)).name;
            harvest5.gameObject.SetActive(true);
        }
        if(hasFiveatFive){
            interactableMap.SetTile(new Vector3Int(-11, 1, 0), baby5);
            h5 = interactableMap.GetTile(new Vector3Int(-11, 1, 0)).name;
            harvest5.gameObject.SetActive(true);
        }
        if(hasSixatFive){
            interactableMap.SetTile(new Vector3Int(-11, 1, 0), baby6);
            h5 = interactableMap.GetTile(new Vector3Int(-11, 1, 0)).name;
            harvest5.gameObject.SetActive(true);
        }


        if(hasOneatSix){
            interactableMap.SetTile(new Vector3Int(-5, 1, 0), baby1);
            h6 = interactableMap.GetTile(new Vector3Int(-5, 1, 0)).name;
            harvest6.gameObject.SetActive(true);
        }
        if(hasTwoatSix){
            interactableMap.SetTile(new Vector3Int(-5, 1, 0), baby2);
            h6 = interactableMap.GetTile(new Vector3Int(-5, 1, 0)).name;
            harvest6.gameObject.SetActive(true);
        }
        if(hasThreeatSix){
            interactableMap.SetTile(new Vector3Int(-5, 1, 0), baby3);
            h6 = interactableMap.GetTile(new Vector3Int(-5, 1, 0)).name;
            harvest6.gameObject.SetActive(true);
        }
        if(hasFouratSix){
            interactableMap.SetTile(new Vector3Int(-5, 1, 0), baby4);
            h6 = interactableMap.GetTile(new Vector3Int(-5, 1, 0)).name;
            harvest6.gameObject.SetActive(true);
        }
        if(hasFiveatSix){
            interactableMap.SetTile(new Vector3Int(-5, 1, 0), baby5);
            h6 = interactableMap.GetTile(new Vector3Int(-5, 1, 0)).name;
            harvest6.gameObject.SetActive(true);
        }
        if(hasSixatSix){
            interactableMap.SetTile(new Vector3Int(-5, 1, 0), baby6);
            h6 = interactableMap.GetTile(new Vector3Int(-5, 1, 0)).name;
            harvest6.gameObject.SetActive(true);
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

    public void turnOnAnims(){
        if(hasOneatOne || hasTwoatOne || hasThreeatOne || hasFouratOne || hasFiveatOne || hasSixatOne){
            one.SetActive(true);
        }
        
        if(hasOneatTwo || hasTwoatTwo || hasThreeatTwo || hasFouratTwo || hasFiveatTwo || hasSixatTwo){
            two.SetActive(true);
        }

        if(hasOneatThree || hasTwoatThree || hasThreeatThree || hasFouratThree || hasFiveatThree || hasSixatThree){
            three.SetActive(true);
        }

        if(hasOneatFour || hasTwoatFour || hasThreeatFour || hasFouratFour || hasFiveatFour || hasSixatFour){
            four.SetActive(true);
        }
        
        if(hasOneatFive || hasTwoatFive || hasThreeatFive || hasFouratFive || hasFiveatFive || hasSixatFive){
            five.SetActive(true);
        }
        
        if(hasOneatSix || hasTwoatSix || hasThreeatSix || hasFouratSix || hasFiveatSix || hasSixatSix){
            six.SetActive(true);
        }
    }

    public void Harvest1(){
        var inventory = invHolder.GetComponent<InventoryHolder>();

        if(h1 == "baby1"){
            DoneBaby1.status = babyObj.status;
            inventory.InventorySystem.AddToInventory(DoneBaby1, 1);
            interactableMap.SetTile(new Vector3Int(-5, -6, 0), null);
            harvest1.gameObject.SetActive(false);
            hasOneatOne = false;
        }else if(h1 == "baby 2"){
            DoneBaby2.status = babyObj.status;
            inventory.InventorySystem.AddToInventory(DoneBaby2, 1);
            interactableMap.SetTile(new Vector3Int(-5, -6, 0), null);
            harvest1.gameObject.SetActive(false);
            hasTwoatOne = false;
        }else if(h1 == "baby 3"){
            DoneBaby3.status = babyObj.status;
            inventory.InventorySystem.AddToInventory(DoneBaby3, 1);
            interactableMap.SetTile(new Vector3Int(-5, -6, 0), null);
            harvest1.gameObject.SetActive(false);
            hasThreeatOne = false;
        }else if(h1 == "baby 4"){
            DoneBaby4.status = babyObj.status;
            inventory.InventorySystem.AddToInventory(DoneBaby4, 1);
            interactableMap.SetTile(new Vector3Int(-5, -6, 0), null);
            harvest1.gameObject.SetActive(false);
            hasFouratOne = false;
        }else if(h1 == "baby 5"){
            DoneBaby5.status = babyObj.status;
            inventory.InventorySystem.AddToInventory(DoneBaby5, 1);
            interactableMap.SetTile(new Vector3Int(-5, -6, 0), null);
            harvest1.gameObject.SetActive(false);
            hasFiveatOne = false;
        }else if(h1 == "baby 6"){
            DoneBaby6.status = babyObj.status;
            inventory.InventorySystem.AddToInventory(DoneBaby6, 1);
            interactableMap.SetTile(new Vector3Int(-5, -6, 0), null);
            harvest1.gameObject.SetActive(false);
            hasSixatOne = false;
        }


    }
    public void Harvest2(){

        var inventory = invHolder.GetComponent<InventoryHolder>();

        if(h2 == "baby1"){
            DoneBaby1.status = babyObj.status;
            inventory.InventorySystem.AddToInventory(DoneBaby1, 1);
            interactableMap.SetTile(new Vector3Int(-11, -6, 0), null);
            harvest2.gameObject.SetActive(false);
            hasOneatTwo = false;
        }else if(h2 == "baby 2"){
            DoneBaby2.status = babyObj.status;
            inventory.InventorySystem.AddToInventory(DoneBaby2, 1);
            interactableMap.SetTile(new Vector3Int(-11, -6, 0), null);
            harvest2.gameObject.SetActive(false);
            hasTwoatTwo = false;
        }else if(h2 == "baby 3"){
            DoneBaby3.status = babyObj.status;
            inventory.InventorySystem.AddToInventory(DoneBaby3, 1);
            interactableMap.SetTile(new Vector3Int(-11, -6, 0), null);
            harvest2.gameObject.SetActive(false);
            hasThreeatTwo = false;
        }else if(h2 == "baby 4"){
            DoneBaby4.status = babyObj.status;
            inventory.InventorySystem.AddToInventory(DoneBaby4, 1);
            interactableMap.SetTile(new Vector3Int(-11, -6, 0), null);
            harvest2.gameObject.SetActive(false);
            hasFouratTwo = false;
        }else if(h2 == "baby 5"){
            DoneBaby5.status = babyObj.status;
            inventory.InventorySystem.AddToInventory(DoneBaby5, 1);
            interactableMap.SetTile(new Vector3Int(-11, -6, 0), null);
            harvest2.gameObject.SetActive(false);
            hasFiveatTwo = false;
        }else if(h2 == "baby 6"){
            DoneBaby6.status = babyObj.status;
            inventory.InventorySystem.AddToInventory(DoneBaby6, 1);
            interactableMap.SetTile(new Vector3Int(-11, -6, 0), null);
            harvest2.gameObject.SetActive(false);
            hasSixatTwo = false;
        }




    }

    public void Harvest3(){

        var inventory = invHolder.GetComponent<InventoryHolder>();


        if(h3 == "baby1"){
            DoneBaby1.status = babyObj.status;
            inventory.InventorySystem.AddToInventory(DoneBaby1, 1);
            interactableMap.SetTile(new Vector3Int(-17, -6, 0), null);
            harvest3.gameObject.SetActive(false);
            hasOneatThree = false;
        }else if(h3 == "baby 2"){
            DoneBaby2.status = babyObj.status;
            inventory.InventorySystem.AddToInventory(DoneBaby2, 1);
            interactableMap.SetTile(new Vector3Int(-17, -6, 0), null);
            harvest3.gameObject.SetActive(false);
            hasTwoatThree = false;
        }else if(h3 == "baby 3"){
            DoneBaby3.status = babyObj.status;
            inventory.InventorySystem.AddToInventory(DoneBaby3, 1);
            interactableMap.SetTile(new Vector3Int(-17, -6, 0), null);
            harvest3.gameObject.SetActive(false);
            hasThreeatThree = false;
        }else if(h3 == "baby 4"){
            DoneBaby4.status = babyObj.status;
            inventory.InventorySystem.AddToInventory(DoneBaby4, 1);
            interactableMap.SetTile(new Vector3Int(-17, -6, 0), null);
            harvest3.gameObject.SetActive(false);
            hasFouratThree = false;
        }else if(h3 == "baby 5"){
            DoneBaby5.status = babyObj.status;
            inventory.InventorySystem.AddToInventory(DoneBaby5, 1);
            interactableMap.SetTile(new Vector3Int(-17, -6, 0), null);
            harvest3.gameObject.SetActive(false);
            hasFiveatThree = false;
        }else if(h3 == "baby 6"){
            DoneBaby6.status = babyObj.status;
            inventory.InventorySystem.AddToInventory(DoneBaby6, 1);
            interactableMap.SetTile(new Vector3Int(-17, -6, 0), null);
            harvest3.gameObject.SetActive(false);
            hasSixatThree = false;
        }



    }

    public void Harvest4(){

        var inventory = invHolder.GetComponent<InventoryHolder>();


        if(h4 == "baby1"){
            DoneBaby1.status = babyObj.status;
            inventory.InventorySystem.AddToInventory(DoneBaby1, 1);
            interactableMap.SetTile(new Vector3Int(-17, 1, 0), null);
            harvest4.gameObject.SetActive(false);
            hasOneatFour = false;
        }else if(h4 == "baby 2"){
            DoneBaby2.status = babyObj.status;
            inventory.InventorySystem.AddToInventory(DoneBaby2, 1);
            interactableMap.SetTile(new Vector3Int(-17, 1, 0), null);
            harvest4.gameObject.SetActive(false);
            hasTwoatFour = false;
        }else if(h4 == "baby 3"){
            DoneBaby3.status = babyObj.status;
            inventory.InventorySystem.AddToInventory(DoneBaby3, 1);
            interactableMap.SetTile(new Vector3Int(-17, 1, 0), null);
            harvest4.gameObject.SetActive(false);
            hasThreeatFour = false;
        }else if(h4 == "baby 4"){
            DoneBaby4.status = babyObj.status;
            inventory.InventorySystem.AddToInventory(DoneBaby4, 1);
            interactableMap.SetTile(new Vector3Int(-17, 1, 0), null);
            harvest4.gameObject.SetActive(false);
            hasFouratFour = false;
        }else if(h4 == "baby 5"){
            DoneBaby5.status = babyObj.status;
            inventory.InventorySystem.AddToInventory(DoneBaby5, 1);
            interactableMap.SetTile(new Vector3Int(-17, 1, 0), null);
            harvest4.gameObject.SetActive(false);
            hasFiveatFour = false;
        }else if(h4 == "baby 6"){
            DoneBaby6.status = babyObj.status;
            inventory.InventorySystem.AddToInventory(DoneBaby6, 1);
            interactableMap.SetTile(new Vector3Int(-17, 1, 0), null);
            harvest4.gameObject.SetActive(false);
            hasSixatFour = false;
        }


    }
    public void Harvest5(){

        var inventory = invHolder.GetComponent<InventoryHolder>();


        if(h5 == "baby1"){
            DoneBaby1.status = babyObj.status;
            inventory.InventorySystem.AddToInventory(DoneBaby1, 1);
            interactableMap.SetTile(new Vector3Int(-11, 1, 0), null);
            harvest5.gameObject.SetActive(false);
            hasOneatFive = false;
        }else if(h5 == "baby 2"){
            DoneBaby2.status = babyObj.status;
            inventory.InventorySystem.AddToInventory(DoneBaby2, 1);
            interactableMap.SetTile(new Vector3Int(-11, 1, 0), null);
            harvest5.gameObject.SetActive(false);
            hasTwoatFive = false;
        }else if(h5 == "baby 3"){
            DoneBaby3.status = babyObj.status;
            inventory.InventorySystem.AddToInventory(DoneBaby3, 1);
            interactableMap.SetTile(new Vector3Int(-11, 1, 0), null);
            harvest5.gameObject.SetActive(false);
            hasThreeatFive = false;
        }else if(h5 == "baby 4"){
            DoneBaby4.status = babyObj.status;
            inventory.InventorySystem.AddToInventory(DoneBaby4, 1);
            interactableMap.SetTile(new Vector3Int(-11, 1, 0), null);
            harvest5.gameObject.SetActive(false);
            hasFouratFive = false;
        }else if(h5 == "baby 5"){
            DoneBaby5.status = babyObj.status;
            inventory.InventorySystem.AddToInventory(DoneBaby5, 1);
            interactableMap.SetTile(new Vector3Int(-11, 1, 0), null);
            harvest5.gameObject.SetActive(false);
            hasFiveatFive = false;
        }else if(h5 == "baby 6"){
            DoneBaby6.status = babyObj.status;
            inventory.InventorySystem.AddToInventory(DoneBaby6, 1);
            interactableMap.SetTile(new Vector3Int(-11, 1, 0), null);
            harvest5.gameObject.SetActive(false);
            hasSixatFive = false;
        }


    }

    public void Harvest6(){

        var inventory = invHolder.GetComponent<InventoryHolder>();


        if(h6 == "baby1"){
            DoneBaby1.status = babyObj.status;
            inventory.InventorySystem.AddToInventory(DoneBaby1, 1);
            interactableMap.SetTile(new Vector3Int(-5, 1, 0), null);
            harvest6.gameObject.SetActive(false);
            hasOneatSix = false;
        }
        else if(h6 == "baby 2"){
            DoneBaby2.status = babyObj.status;
            inventory.InventorySystem.AddToInventory(DoneBaby2, 1);
            interactableMap.SetTile(new Vector3Int(-5, 1, 0), null);
            harvest6.gameObject.SetActive(false);
            hasTwoatSix = false;
        }else if(h6 == "baby 3"){
            DoneBaby3.status = babyObj.status;
            inventory.InventorySystem.AddToInventory(DoneBaby3, 1);
            interactableMap.SetTile(new Vector3Int(-5, 1, 0), null);
            harvest6.gameObject.SetActive(false);
            hasThreeatSix = false;
        }else if(h6 == "baby 4"){
            DoneBaby4.status = babyObj.status;
            inventory.InventorySystem.AddToInventory(DoneBaby4, 1);
            interactableMap.SetTile(new Vector3Int(-5, 1, 0), null);
            harvest6.gameObject.SetActive(false);
            hasFouratSix = false;
        }else if(h6 == "baby 5"){
            DoneBaby5.status = babyObj.status;
            inventory.InventorySystem.AddToInventory(DoneBaby5, 1);
            interactableMap.SetTile(new Vector3Int(-5, 1, 0), null);
            harvest6.gameObject.SetActive(false);
            hasFiveatSix = false;
        }else if(h6 == "baby 6"){
            DoneBaby6.status = babyObj.status;
            inventory.InventorySystem.AddToInventory(DoneBaby6, 1);
            interactableMap.SetTile(new Vector3Int(-5, 1, 0), null);
            harvest6.gameObject.SetActive(false);
            hasSixatSix = false;
        }
        
    }

    public void PlantBabySlot1(){
        if(MouseItemData.instance.hasItem){

            // get status of obj currently attached to mouse
            babyObj = mouseObj.getCurrentMouseItem().ItemData; 
            babyObj.status = mouseObj.getCurrentMouseItem().ItemData.status; 

            if (InventoryDisplay.instance.babyName == "Baby 1"){
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
        // get status of obj currently attached to mouse
        babyObj = mouseObj.getCurrentMouseItem().ItemData;
        babyObj.status = mouseObj.getCurrentMouseItem().ItemData.status;
        if (MouseItemData.instance.hasItem){
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
        // get status of obj currently attached to mouse
        babyObj = mouseObj.getCurrentMouseItem().ItemData;
        babyObj.status = mouseObj.getCurrentMouseItem().ItemData.status;
        if (MouseItemData.instance.hasItem){
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
        // get status of obj currently attached to mouse
        babyObj = mouseObj.getCurrentMouseItem().ItemData;
        babyObj.status = mouseObj.getCurrentMouseItem().ItemData.status;
        if (MouseItemData.instance.hasItem){
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
        // get status of obj currently attached to mouse
        babyObj = mouseObj.getCurrentMouseItem().ItemData;
        babyObj.status = mouseObj.getCurrentMouseItem().ItemData.status;
        if (MouseItemData.instance.hasItem){
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
        // get status of obj currently attached to mouse
        babyObj = mouseObj.getCurrentMouseItem().ItemData;
        babyObj.status = mouseObj.getCurrentMouseItem().ItemData.status;
        if (MouseItemData.instance.hasItem){
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
