using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuickSlot : MonoBehaviour
{
    public ItemData itemData;

    public TextMeshProUGUI quatityText;
    public int index;
    public int quantity;
    public Button QuickSlotButton;
    public Image icon;
    public UIInventory inventory;

    public ItemSlot slot;
    public void Start()
    {
        QuickSlotButton.onClick.AddListener(Quickregistration);
    }
    public void SetSlot(ItemSlot newSlot)
    {
        slot = newSlot;
        itemData = newSlot.itemData;
        quantity = newSlot.quantity;
        icon.sprite = newSlot.icon.sprite;  
        Debug.Log($"QuickSlot SetSlot called. Item: {itemData?.itemName}, Quantity: {quantity}");
    }
    public void Quickregistration()
    {
        Debug.Log(itemData);
        Debug.Log(quantity);

        QuickSlot emptySlot = GetItemEmpty();
        if (emptySlot != null)
        {
            emptySlot.itemData = itemData;
            emptySlot.quantity = quantity;
            Debug.Log($"µÎ¹øÂ° {emptySlot.itemData}");
            UpdateUI();
            return;
        }
    }
    private void UpdateUI()
    {
        for (int i = 0; i < inventory.QuickSlots.Length; i++)
        {
            if (inventory.QuickSlots[i].itemData != null)
            {
                inventory.QuickSlots[i].Set();
            }
            else
            {
                inventory.QuickSlots[i].Clear();
            }
        }
    }
    private QuickSlot GetItemEmpty()
    {
        for (int i = 0; i < inventory.QuickSlots.Length; i++)
        {
            if (inventory.QuickSlots[i].itemData == null)
            {
                return inventory.QuickSlots[i];
            }
        }
        return null;
    }

    public void Set()
    {
        icon.sprite = icon.sprite;
        quatityText.text = quantity > 1 ? quantity.ToString() : string.Empty;
    }

    public void Clear()
    {
        itemData = null;
        quatityText.text = string.Empty;
    }

}
