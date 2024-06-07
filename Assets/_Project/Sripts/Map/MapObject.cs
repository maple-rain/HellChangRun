using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObject : MonoBehaviour
{
    [SerializeField]
    private GameObject[] food;

    public LayerMask layerMask;

    public void SpanwFood(Vector3 vec)
    {
        int randomFood = Random.Range(0,food.Length);
        GameObject Eat = Instantiate(food[randomFood]);
        Eat.transform.position = vec;
    }

}
