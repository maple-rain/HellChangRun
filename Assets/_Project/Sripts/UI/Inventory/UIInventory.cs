using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    [Header("Slot")]
    public ItemSlot[] InvenSlot;
    public Transform InvenSlotHolder;

    Inventory inven;

    [Header("Select Item")]
    public TextMeshProUGUI ItemName;
    public TextMeshProUGUI ItemDescription;
    public TextMeshProUGUI ItemStatName;
    public TextMeshProUGUI ItemStatValue;
    public Image ItemIcon;


    public void Start()
    {
        inven = ItemManager.Instance.Inventory;
        InvenSlot = GetComponentsInChildren<ItemSlot>();
        for(int i  = 0; i < InvenSlot.Length; i++)
        {
            InvenSlot[i].index = i;
            InvenSlot[i].inventory = this;
        }
        ClearItemUI();
        //inven.onSlotCountChange += slotChange;
    }

    #region 인벤토리슬롯 추가
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

    void ClearItemUI()
    {
        ItemName.text = string.Empty;
        ItemDescription.text = string.Empty;
        ItemStatName.text = string.Empty;
        ItemStatValue.text = string.Empty;
    }

    public void SetItem(int index)
    {

    }
}
