using UnityEngine;

public class StartButtonAction : MonoBehaviour
{
    public GameObject shop;
    public GameObject start;
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


}
