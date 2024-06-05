using System;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    Inventory inven;

    public Slot[] InvenSlot;
    public Transform InventoryHolder;


    private void Start()
    {
        InvenSlot = GetComponentsInChildren<Slot>();
        inven = ItemManager.Instance.Inventory;
        if(inven != null)
        {
            inven.onSlotCountChange += slotChange;
        }
        else
        {
            Debug.Log("error");
        }
        
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
