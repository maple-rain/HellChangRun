using UnityEditor.Build;
using UnityEngine;

public class InventoryBtnAction : MonoBehaviour
{
    public GameObject Iteminfo;
    public GameObject Inventory;
    public GameObject start;
    public GameObject QuickSlot;
    public GameObject QuickSlotClose;
    private void Start()
    {
        QuickSlot.SetActive(false);
    }
    public void OpenItemInfo()
    {
        Iteminfo.SetActive(true);
    }
    public void CloseItemInfo()
    {
        Iteminfo.SetActive(false);
    }
    public void CloseInvenotry()
    {
        Inventory.SetActive(false);
        start.SetActive(true);
    }
    public void OpenQuickSlot()
    {
        Iteminfo.SetActive(false);
        QuickSlot.SetActive(true);
        QuickSlotClose.SetActive(true);
    }
    public void CloseQuickSlot()
    {
        Iteminfo.SetActive(true);
        QuickSlot.SetActive(false);
        QuickSlotClose.SetActive(false);
    }

}
