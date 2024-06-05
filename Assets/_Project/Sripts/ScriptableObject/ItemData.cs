using System;
using UnityEngine;

public enum ItemType
{
    Equip,
    Consume,
    Random
}

public enum ConsumableType
{
    Weight,
    Speed,
    trap
}

[Serializable]
public class ItemDataConsumable
{
    public ConsumableType type;
    public float value;
}

[CreateAssetMenu(fileName ="Item", menuName ="New Item")]
public class ItemData : ScriptableObject 
{
    [Header("Info")]
    public string itemName;
    public ItemType Type;
    public string itemDescription;
    public Sprite itemIcon;
    public int itemPrice;

    [Header("Stacking")]
    public bool CanStack;
    public int maxStackAmount;

    [Header("Consumable")]
    public ItemDataConsumable[] coumsumables;
}
