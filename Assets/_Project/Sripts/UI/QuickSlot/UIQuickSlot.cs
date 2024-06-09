using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIQuickSlot : MonoBehaviour
{
    [Header("Slot")]
    public QuickSlot[] QuickSlots;
    public Transform QuickSlotsHolder;

    


    void Start()
    {
        QuickSlots = GetComponentsInChildren<QuickSlot>();
        for (int i = 0; i < QuickSlots.Length; i++)
        {
            QuickSlots[i].index = i;
        }
    }
}
