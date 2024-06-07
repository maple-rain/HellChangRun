using UnityEngine;

public class UIShop : MonoBehaviour
{
    [Header("Slot")]
    public ShopSlot[] Equipslots;
    public Transform EquipslotHolder;

    public ShopSlot[] Consumslots;
    public Transform ConsumslotHolder;

    public ShopSlot[] Boxslots;
    public Transform BoxslotHolder;


    void Start()
    {
        Equipslots = GetComponentsInChildren<ShopSlot>();
        Consumslots = GetComponentsInChildren<ShopSlot>();
        Boxslots = GetComponentsInChildren<ShopSlot>();
    }
}