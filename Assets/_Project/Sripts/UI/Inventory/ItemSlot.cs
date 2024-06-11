using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public ItemData itemData;
    public UIInventory inventory;
    public QuickSlot quickSlot;
    public TextMeshProUGUI quatityText;
    public int index;
    public bool equipped;
    public int quantity;
    public Button itemInfoButton;
    public Button EquipBtn;
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
        itemInfoButton.onClick.AddListener(UpdateItemUI);

    }
    public void UpdateItemUI()
    {
        if(itemData != null)
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
            inventory.seletedItem = this;
            Debug.Log("보여지는것 "+quatityText.text);
            Debug.Log(quantity);

        }
    }
    public void Set()
    {
        icon.sprite = itemData.itemIcon;
        quatityText.text = quantity >= 1 ? quantity.ToString() : string.Empty;
        Debug.Log(quantity.ToString());
    }

    public void Clear()
    {
        itemData = null;
        quatityText.text = string.Empty;
    }

    public void ItemInfoOpen()
    {
        itemInfo.SetActive(true);
    }
}
