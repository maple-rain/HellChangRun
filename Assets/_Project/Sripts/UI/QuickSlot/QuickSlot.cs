using System.Linq.Expressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class QuickSlot : MonoBehaviour
{
    public ItemData itemData;
    public TextMeshProUGUI quatityText;
    public int index;
    public int quantity;
    public Button QuickSlotButton;
    public Image icon;
    public UIInventory inventory;


    public void Start()
    {
        QuickSlotButton.onClick.AddListener(() => inventory.Quickregistration(index));
    }
    public void Set()
    {
        quatityText.text = inventory.seletedItem.quantity >= 1 ? inventory.seletedItem.quantity.ToString() : string.Empty;
    }
    public void Clear()
    {
        itemData = null;
        quatityText.text = string.Empty;
    }
}