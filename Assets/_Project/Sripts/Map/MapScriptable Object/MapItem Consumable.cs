using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapItemConsumable", menuName = "MapItem/ConsumableItem")]
public class MapItemConsumable : MapItemScriptableObject
{
    [Header("Consumable Type")]
    public MapItemConsumableType consumableType;
    public float value;
}
