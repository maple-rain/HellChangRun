    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthyFoodConsumableBehaviour : MonoBehaviour, IConsumableBehaviour
{
    [SerializeField] private float loseWeight;

    public void OnConsumed(GameObject player)
    {
        player.GetComponent<WeightController>().Consume(loseWeight);
    }
}
