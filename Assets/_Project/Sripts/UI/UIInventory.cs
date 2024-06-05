using System;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    Inventory inven;

    [Header("Slot")]
    public Slot[] InvenSlot;
    public Transform EquipslotHolder;

    private void Awake()
    {
        InvenSlot = GetComponentsInChildren<Slot>();
    }
    private void Start()
    {
        inven = ItemManager.Instance.Inventory;
        inven.onSlotCountChange += slotChange;
    }

    private void slotChange(int val)
    {
        for(int i = 0; i< InvenSlot.Length; i++)
        {
            if(i < inven.SlotCount)
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
}
