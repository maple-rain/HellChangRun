using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBtnAction : MonoBehaviour
{
    public GameObject Equip;
    public GameObject Consumeable;
    public GameObject Randombox;

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
}
