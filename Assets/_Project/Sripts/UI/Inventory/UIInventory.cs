using System;
using TMPro;
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

    //[Header("Select Item")]
    //public TextMeshProUGUI ItemName;
    //public TextMeshProUGUI ItemDescription;
    //public TextMeshProUGUI ItemStatName;
    //public TextMeshProUGUI ItemStatValue;
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

        QuickSlots = GetComponentsInChildren<QuickSlot>();
        for (int i = 0; i < QuickSlots.Length; i++)
        {
            QuickSlots[i].index = i;
            QuickSlots[i].inventory = this;
        }

        //for (int i = 0; i < InvenSlot.Length; i++)
        //{
        //    int index = i; 
        //    InvenSlot[i].GetComponent<Button>().onClick.AddListener(() => OnItemSlotClick(index));
        //}
        //ClearItemUI();
        //inven.onSlotCountChange += slotChange;
    }

    //void OnItemSlotClick(int index)
    //{
    //    Debug.Log($"{index}번째 클릭  ");

    //    // Assign the clicked slot to an empty quick slot
    //    for (int i = 0; i < QuickSlots.Length; i++)
    //    {
    //        if (QuickSlots[i].itemData == null)
    //        {
    //            QuickSlots[i].SetSlot(InvenSlot[index]);
    //            break;
    //        }
    //    }
    //}

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

    //void ClearItemUI()
    //{
    //    ItemName.text = string.Empty;
    //    ItemDescription.text = string.Empty;
    //    ItemStatName.text = string.Empty;
    //    ItemStatValue.text = string.Empty;
    //}

    public void SetItem(int index)
    {

    }
}
