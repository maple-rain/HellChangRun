using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    public ItemData itemData; 

    public TextMeshProUGUI itemNameText;
    public TextMeshProUGUI itemDescriptionText;
    public TextMeshProUGUI ItemStatName;
    public TextMeshProUGUI ItemStatValue;
    public Image itemIconImage;
    public TextMeshProUGUI itemPriceText;
    public Button itemInfoButton;
    public Button purchaseButton;
    public GameObject itemInfo;

    public UIInventory Inventory;

    public static event Action<ItemData> OnItemSelected;
    public void Start()
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

        purchaseButton.onClick.RemoveAllListeners();
        purchaseButton.onClick.AddListener(BuyItem);


    }


    public void BuyItem()
    {
        Debug.Log($"buy아이템 {itemData}");
        Debug.Log($"buy아이템스택 {itemData.CanStack}");
        //인벤토리로 이동
        //중복체크
        if (itemData.CanStack)
        {
            
            ItemSlot slot = GetItemStack(itemData);
            if (slot != null)
            {
                slot.quantity++;
                UpdateUI();
                return;
            }
        }
        ItemSlot emptySlot = GetItemEmpty();
        // 있음?
        if (emptySlot != null)
        {
            emptySlot.itemData = itemData;
            emptySlot.quantity = 1;
            UpdateUI();
            return;
        }
        
        // 못삼
        NobuyItem();
        itemInfo.SetActive(false);
    }

    void UpdateUI()
    {
        for (int i = 0; i < Inventory.InvenSlot.Length; i++)
        {
            if (Inventory.InvenSlot[i].itemData != null)
            {
                Inventory.InvenSlot[i].Set();
            }
            else
            {
                Inventory.InvenSlot[i].Clear();
            }
        }
    }
    private void NobuyItem()
    {

    }

    ItemSlot GetItemStack(ItemData data)
    {
        Debug.Log($"스택 아이템 데이터 {data}");
        //Debug.Log($"스택 슬롯12 {Inventory}");
        //Debug.Log($"스택 슬롯 {Inventory.InvenSlot}");

        for (int i = 0; i < Inventory.InvenSlot.Length; i++)
        {
            if (Inventory.InvenSlot[i].itemData == itemData && Inventory.InvenSlot[i].quantity < itemData.maxStackAmount)
            {
                return Inventory.InvenSlot[i];
            }
        }
        return null;
    }
    ItemSlot GetItemEmpty()
    {
        for (int i = 0; i < Inventory.InvenSlot.Length; i++)
        {
            if (Inventory.InvenSlot[i].itemData == null)
            {
                return Inventory.InvenSlot[i];
            }
        }
        return null;
    }

}

