using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapItemConsumable", menuName = "MapItem/ConsumableItem")]
public class MapItemConsumable : MapItemScriptableObject
{
    [Header("Consumable Type")]
    public ConsumableType consumableType;
    public float value;
}
