using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class MouseItemData : MonoBehaviour
{
    public Image itemSprite;
    public TextMeshProUGUI itemCount;
    public InventorySlot AssignedInvSlot;

    private void Awake()
    {
        itemSprite.color = Color.clear;
        itemCount.text = "";
    }

    public void UpdateMouseSlot(InventorySlot invSlot)
    {
        AssignedInvSlot.AssignItem(invSlot);
        itemSprite.sprite = invSlot.ItemData.icon;
        itemCount.text = invSlot.StackSize.ToString();
        itemSprite.color = Color.white;
    }

    private void Update()
    {
        if(AssignedInvSlot.ItemData != null) // if mouse has item on it
        {
            transform.position = Mouse.current.position.ReadValue(); // follow mouse 
        }
    }

    public void ClearSlot()
    {
        AssignedInvSlot.ClearSlot();
        itemCount.text = "";
        itemSprite.color = Color.clear;
        itemSprite.sprite = null;
    }
}
