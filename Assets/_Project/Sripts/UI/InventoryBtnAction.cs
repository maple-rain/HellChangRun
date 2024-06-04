using UnityEngine;

public class InventoryBtnAction : MonoBehaviour
{
    public GameObject Equip;
    public GameObject Consumeable;
    public GameObject Randombox;

    public GameObject Iteminfo;

    public void OpenEquip()
    {
        Equip.SetActive(true);
        Consumeable.SetActive(false);
        Randombox.SetActive(false);
    }
    public void OpenConsumeable()
    {
        Equip.SetActive(false);
        Consumeable.SetActive(true);
        Randombox.SetActive(false);
    }
    public void OpenRandombox()
    {
        Equip.SetActive(false);
        Consumeable.SetActive(false);
        Randombox.SetActive(true);
    }

    public void OpenItemInfo()
    {
        Iteminfo.SetActive(true);
    }
    public void CloseItemInfo()
    {
        Iteminfo.SetActive(false);
    }

}
