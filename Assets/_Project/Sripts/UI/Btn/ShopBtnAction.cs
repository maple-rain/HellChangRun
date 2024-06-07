using UnityEngine;

public class ShopBtnAction : MonoBehaviour
{
    public GameObject Equip;
    public GameObject Consumeable;
    public GameObject Randombox;
    public GameObject ShopIteminfo;

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
        ShopIteminfo.SetActive(true);
    }
    public void CloseItemInfo()
    {
        ShopIteminfo.SetActive(false);
    }
}
