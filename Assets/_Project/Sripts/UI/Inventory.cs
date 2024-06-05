using UnityEngine;

public class Inventory : MonoBehaviour
{
    private void Awake()
    {
        ItemManager.Instance.Inventory = this;
    }

    public delegate void OnSlotCountChange(int val);
    public OnSlotCountChange onSlotCountChange;

    private int slotCnt;

    public int SlotCount
    {
        get=>slotCnt;
        set
        {
            slotCnt = value;
            onSlotCountChange?.Invoke(slotCnt);
        }
    }
    private void Start()
    {
        slotCnt = 4;
    }
}
