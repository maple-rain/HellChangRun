using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public ItemData itemData; 

    public TextMeshProUGUI itemNameText;
    public TextMeshProUGUI itemDescriptionText;
    public Image itemIconImage;
    public TextMeshProUGUI itemPriceText;
    public Button itemInfoButton;
    public GameObject itemInfo;

    void Awake()
    {
        itemInfoButton.onClick.AddListener(UpdateItemUI);
    }

    public void UpdateItemUI()
    {
        itemInfo.SetActive(true);
        itemNameText.text = itemData.itemName;
        itemDescriptionText.text = itemData.itemDescription;
        itemIconImage.sprite = itemData.itemIcon;
        itemPriceText.text = itemData.itemPrice.ToString();
    }
    public void BuyItem()
    {

    }
}

