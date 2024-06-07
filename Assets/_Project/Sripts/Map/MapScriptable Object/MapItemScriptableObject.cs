using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Food,
    Consumable
}

public enum ConsumableType
{
    PlayerSpeedUp,
    KeepPlayerWeight,
    TrainerSpeedDown
}

public enum FoodType
{
    HealthFood,
    JunkFood
}
[CreateAssetMenu(fileName = "MapItem", menuName = "MapItem/Default")]
public class MapItemScriptableObject : ScriptableObject
{
    [Header("Info")]
    public ItemType itemType;
    public GameObject dropPrefab;
}
