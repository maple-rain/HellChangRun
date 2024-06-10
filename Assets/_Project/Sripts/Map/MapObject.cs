using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObject : MonoBehaviour
{
    [SerializeField]
    private GameObject[] food;

    [SerializeField]
    private GameObject[] obstecle;


    public void SpanwFood(Vector3 vec)
    {
        int randomFood = Random.Range(0,food.Length);
        GameObject eat = Instantiate(food[randomFood]);
        eat.transform.position = vec;
    }

    public void SpanwObstecle(Vector3 vec)
    {
        int randomObstecle = Random.Range(0, obstecle.Length);
        GameObject _obstecle = Instantiate(obstecle[randomObstecle]);
        _obstecle.transform.position = vec;
    }
}
