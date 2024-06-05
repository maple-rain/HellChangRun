using UnityEngine;

public class UIShop : MonoBehaviour
{
    public Slot[] Equipslots;
    public Transform EquipslotHolder;

    public Slot[] Consumslots;
    public Transform ConsumslotHolder;

    public Slot[] Boxslots;
    public Transform BoxslotHolder;
    void Start()
    {
        Equipslots = GetComponentsInChildren<Slot>();
        Consumslots = GetComponentsInChildren<Slot>();
        Boxslots = GetComponentsInChildren<Slot>();
    }
}
