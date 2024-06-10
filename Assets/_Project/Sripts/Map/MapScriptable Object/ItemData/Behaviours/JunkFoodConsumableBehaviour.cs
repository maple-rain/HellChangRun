using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkFoodConsumableBehaviour : MonoBehaviour, IConsumableBehaviour
{
    [SerializeField] private float gainWeight;

    public void OnConsumed(GameObject player)
    {
        player.GetComponent<PlayerPhysics>().GainWeight(gainWeight);
    }
}
