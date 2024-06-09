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
    public int slotIndex;

    public TextMeshProUGUI itemNameText;
    public TextMeshProUGUI itemDescriptionText;
    public TextMeshProUGUI ItemStatName;
    public TextMeshProUGUI ItemStatValue;
    public Image itemIconImage;
    public TextMeshProUGUI itemPriceText;
    

    private void Start()
    {
        if (inventory != null)
        {
            quickSlot = inventory.GetQuickSlot(slotIndex);
        }
        itemInfoButton.onClick.AddListener(UpdateItemUI);
        quantity = 0;
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
            //EquipBtn.onClick.AddListener(Quickregistration);
            Debug.Log(this);
            QucikSlotUpdate();
            
        }
    }
    public void QucikSlotUpdate()
    {
        quickSlot.SetSlot(this);
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

    #region Äü½½·Ô 
    //public void Quickregistration()
    //{
    //    QuickSlot emptySlot = GetItemEmpty();
    //    if (emptySlot != null)
    //    {
    //        emptySlot.itemData = itemData;
    //        emptySlot.quantity = quantity;
    //        Debug.Log($"µÎ¹øÂ° {emptySlot.itemData}");
    //        UpdateUI();
    //        return;
    //    }
    //}
    //private void UpdateUI()
    //{
    //    for (int i = 0; i < inventory.QuickSlots.Length; i++)
    //    {
    //        if (inventory.QuickSlots[i].itemData != null)
    //        {
    //            inventory.QuickSlots[i].Set();
    //        }
    //        else
    //        {
    //            inventory.QuickSlots[i].Clear();
    //        }
    //    }
    //}
    //private QuickSlot GetItemEmpty()
    //{
    //    for (int i = 0; i < inventory.QuickSlots.Length; i++)
    //    {
    //        if (inventory.QuickSlots[i].itemData == null)
    //        {
    //            return inventory.QuickSlots[i];
    //        }
    //    }
    //    return null;
    //}
    #endregion
}
