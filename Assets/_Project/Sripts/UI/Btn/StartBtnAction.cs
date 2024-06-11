using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonAction : MonoBehaviour
{
    public GameObject shop;
    public GameObject start;
    public GameObject Inventroy;

    private void Awake()
    {
        Inventroy.SetActive(true);
    }
    private void Start()
    {
        Inventroy.SetActive(false);
    }
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
    
    public void StartBtn()
    {
        SceneManager.LoadScene(1);
    }
}
