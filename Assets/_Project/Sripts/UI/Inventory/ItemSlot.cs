using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public ItemData itemData;

    public UIInventory inventory;
    public TextMeshProUGUI quatityText;
    public int index;
    public bool equipped;
    public int quantity;
    public Button itemInfoButton;
    public GameObject itemInfo;
    public Image icon;

    public TextMeshProUGUI itemNameText;
    public TextMeshProUGUI itemDescriptionText;
    public TextMeshProUGUI ItemStatName;
    public TextMeshProUGUI ItemStatValue;
    public Image itemIconImage;
    public TextMeshProUGUI itemPriceText;

    private void Start()
    {
        quantity = 0;
    }

    void Update()
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
        ItemStatName.text = string.Empty;
        ItemStatValue.text = string.Empty;

        for (int i = 0; i < itemData.coumsumables.Length; i++)
        {
            ItemStatName.text += itemData.coumsumables[i].type.ToString() + "\n";
            ItemStatValue.text += itemData.coumsumables[i].value.ToString() + "\n";
        }
    }
    public void Set()
    {
        icon.sprite = itemData.itemIcon;
        quatityText.text = quantity > 1 ? quantity.ToString() : string.Empty;
    }

    public void Clear()
    {
        itemData = null;
        quatityText.text = string.Empty;
    }

    public void ItemInfoOpen()
    {
        itemInfo.SetActive(true);
        inventory.SetItem(index);
    }
}
