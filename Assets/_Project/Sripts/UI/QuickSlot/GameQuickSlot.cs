using UnityEngine;

public class GameQuickSlot : MonoBehaviour
{
    public UseQuickSlot[] useQuickSlots;
    public Transform QuickSlotsHolder;
 
    public GameObject QuickSlot;

    private void Awake()
    {
        useQuickSlots = GetComponentsInChildren<UseQuickSlot>();
        for (int i = 0; i < useQuickSlots.Length; i++)
        {
            useQuickSlots[i].index = i;
            useQuickSlots[i].GameQuickSlot = this;

            if (ItemManager.Instance.SelectedItemDates[i] != null)
            {
                useQuickSlots[i].itemData = ItemManager.Instance.SelectedItemDates[i];
                useQuickSlots[i].icon.sprite = ItemManager.Instance.SelectedItemDates[i].itemIcon;
            }
        }
    }

}
