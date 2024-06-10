using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    [SerializeField]
    public float initialWeight = 65f;
    [SerializeField]
    public float currentWeight= 65f;
    [SerializeField]
    public float maxWeight = 100f;
    [SerializeField]
    public float minWeight = 50f;

    private Vector3 initialScale;

    PlayerController player;

    private void Awake()
    {
        player= GetComponent<PlayerController>();
        initialScale = transform.localScale;
    }

    private void Update()
    {
        Debug.Log("ÇöÀç ¸ö¹«°Ô : " + currentWeight);
    }

    public void GainWeight(float gainWeight)
   {
        currentWeight += gainWeight;
        if(currentWeight > maxWeight)
        {
            currentWeight = maxWeight;
        }
        player.DecreaseSpeed(gainWeight);
   }

    public void LoseWeight(float loseWeight)
    {
        currentWeight -= loseWeight;

        if(currentWeight < minWeight)
        {
            currentWeight = minWeight;
        }
        player.IncreaseSpeed(loseWeight);
    }
}
