using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MapItemType
{
    Food,
    Consumable
}

public enum MapItemConsumableType
{
    PlayerSpeedUp,
    KeepPlayerWeight,
    TrainerSpeedDown
}

public enum MapItemFoodType
{
    HealthFood,
    JunkFood
}
[CreateAssetMenu(fileName = "MapItem", menuName = "MapItem/Default")]
public class MapItemScriptableObject : ScriptableObject
{
    [Header("Info")]
    public MapItemType itemType;
    public GameObject dropPrefab;
}
