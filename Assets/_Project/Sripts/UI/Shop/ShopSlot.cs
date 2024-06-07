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
        Debug.Log($"buy������ {itemData}");
        Debug.Log($"buy�����۽��� {itemData.CanStack}");
        //�κ��丮�� �̵�
        //�ߺ�üũ
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
        // ����?
        if (emptySlot != null)
        {
            emptySlot.itemData = itemData;
            emptySlot.quantity = 1;
            UpdateUI();
            return;
        }
        
        // ����
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
        Debug.Log($"���� ������ ������ {data}");
        //Debug.Log($"���� ����12 {Inventory}");
        //Debug.Log($"���� ���� {Inventory.InvenSlot}");

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

