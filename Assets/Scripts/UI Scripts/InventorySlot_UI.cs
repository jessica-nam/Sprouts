using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot_UI : MonoBehaviour
{
    [SerializeField] private Image itemSprite;
    [SerializeField] private TextMeshProUGUI itemCount;
    [SerializeField] private InventorySlot assignedInvSlot;

    private Button button;

    public InventorySlot AssignedInvSlot => assignedInvSlot;
    public InventoryDisplay ParentDisplay { get; private set; }

    private void Awake()
    {
        ClearSlot();

        button = GetComponent<Button>();
        button?.onClick.AddListener(OnUISlotClick); // if null

        ParentDisplay = transform.parent.GetComponent<InventoryDisplay>();
    }

    public void Init(InventorySlot slot)
    {
        assignedInvSlot = slot;
        UpdateUISlot(slot);
    }

    public void UpdateUISlot(InventorySlot slot)
    {
        if (slot.ItemData != null)
        {
            itemSprite.sprite = slot.ItemData.icon;
            itemSprite.color = Color.white;

            if (slot.StackSize > 1)
                itemCount.text = slot.StackSize.ToString();
            else
                itemCount.text = "";
        }
        else
        {
            ClearSlot();
        }
    }

    // refresh slot without passing any args
    public void UpdateUISlot()
    {
        if (assignedInvSlot != null)
            UpdateUISlot(assignedInvSlot);
    }

    public void ClearSlot()
    {
        assignedInvSlot?.ClearSlot(); // if null clear slot
        itemSprite.sprite = null;
        itemSprite.color = Color.clear;
        itemCount.text = "";
    }

    public void OnUISlotClick()
    {
        // access display class function
        ParentDisplay?.SlotClicked(this);
    }
}
