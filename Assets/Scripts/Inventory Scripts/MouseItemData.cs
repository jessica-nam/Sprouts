using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class MouseItemData : MonoBehaviour
{

    public static MouseItemData instance;

    public Image itemSprite;
    public TextMeshProUGUI itemCount;
    public InventorySlot AssignedInvSlot;
    public bool hasItem = false;

    [SerializeField] private Tilemap interactableMap;

    private void Awake()
    {
        instance = this;
        itemSprite.color = Color.clear;
        itemCount.text = "";
    }

    public void UpdateMouseSlot(InventorySlot invSlot)
    {
        AssignedInvSlot.AssignItem(invSlot);
        itemSprite.sprite = invSlot.ItemData.icon;
        itemCount.text = invSlot.StackSize.ToString();
        itemSprite.color = Color.white;

        if (invSlot.StackSize > 1)
            itemCount.text = invSlot.StackSize.ToString();
        else
            itemCount.text = "";
    }

    private void Update()
    {
        if(AssignedInvSlot.ItemData != null) // if mouse has item on it
        {
            transform.position = Mouse.current.position.ReadValue(); // follow mouse 
            hasItem = true;
        }
        else
        {
            hasItem = false;
        }
        if(Plant.instance.BabyPlanted){
            ClearSlot();
        }
        
    }

    public List<RaycastResult> getObjectsClickedOn()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = Mouse.current.position.ReadValue();
        Debug.Log(eventDataCurrentPosition);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        
    
        return results;
    }

   

    public void ClearSlot()
    {
        AssignedInvSlot.ClearSlot();
        itemCount.text = "";
        itemSprite.color = Color.clear;
        itemSprite.sprite = null;
    }

    public InventorySlot getCurrentMouseItem()
    {
        return AssignedInvSlot;
    }

    
}
