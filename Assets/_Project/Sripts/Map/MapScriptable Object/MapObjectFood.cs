using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapItemFood", menuName = "MapItem/FoodItem")]
public class MapObjectFood : MapItemScriptableObject
{
    [Header("Food Type")]
    public MapItemFoodType foodType;
    public float value;
}
