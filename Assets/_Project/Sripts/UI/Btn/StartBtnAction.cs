using UnityEngine;

public class StartButtonAction : MonoBehaviour
{
    public GameObject shop;
    public GameObject start;
    public GameObject Inventroy;
    public void OpenShop()
    {
        shop.SetActive(true);
        start.SetActive(false);
    }
    public void CloseShop()
    {
        shop.SetActive(false);
        start.SetActive(true);
    }
    public void OpenInventory()
    {
        start.SetActive(false);
        Inventroy.SetActive(true);
    }
    public void CloseInventory()
    {
        Inventroy.SetActive(false);
        start.SetActive(true);
    }
}
