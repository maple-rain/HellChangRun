using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    [Header("Slot")]
    public ItemSlot[] InvenSlot;
    public Transform InvenSlotHolder;
    public QuickSlot[] QuickSlots;
    public Transform QuickSlotsHolder;
    Inventory inven;
    public ItemSlot seletedItem;
    public Image ItemIcon;

    public void Awake()
    {
        inven = ItemManager.Instance.Inventory;
        InvenSlot = GetComponentsInChildren<ItemSlot>();
        for (int i = 0; i < InvenSlot.Length; i++)
        {
            InvenSlot[i].index = i;
            InvenSlot[i].inventory = this;
        }
        QuickSlots = GetComponentsInChildren<QuickSlot>();
        for (int i = 0; i < QuickSlots.Length; i++)
        {
            QuickSlots[i].index = i;
            QuickSlots[i].inventory = this;
        }
        //inven.onSlotCountChange += slotChange;
    }
    #region ¿Œ∫•≈‰∏ÆΩΩ∑‘ √ﬂ∞°
    private void slotChange(int val)
    {
        for (int i = 0; i < InvenSlot.Length; i++)
        {
            if (i < inven.SlotCount)
            {
                InvenSlot[i].GetComponent<Button>().interactable = true;
            }
            else
            {
                InvenSlot[i].GetComponent<Button>().interactable = false;
            }
        }
        
    }
    public void AddSlot()
    {
        inven.SlotCount++;
    }
    #endregion

    #region ƒ¸ΩΩ∑‘ æ∆¿Ã≈€
    public void Quickregistration(int index)
    {
        QuickSlot selectedSlot = QuickSlots[index];
        selectedSlot.itemData = seletedItem.itemData;
        selectedSlot.quantity = seletedItem.quantity;
        selectedSlot.icon.sprite = seletedItem.itemData.itemIcon;
        UpdateUI();
    }
    private void UpdateUI()
    {
        for (int i = 0; i < QuickSlots.Length; i++)
        {
            if (QuickSlots[i].itemData != null)
            {
                QuickSlots[i].Set();
            }
            else
            {
                QuickSlots[i].Clear();
            }
        }
    }
    #endregion
}