using UnityEditor.Build;
using UnityEngine;

public class InventoryBtnAction : MonoBehaviour
{
    public GameObject Equip;
    public GameObject Iteminfo;
    public GameObject Inventory;

    public void OpenEquip()
    {
        Equip.SetActive(true);
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
    }

}
