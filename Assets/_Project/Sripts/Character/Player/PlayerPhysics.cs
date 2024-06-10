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
        IncreaseScale();
   }

    public void LoseWeight(float loseWeight)
    {
        currentWeight -= loseWeight;

        if(currentWeight < minWeight)
        {
            currentWeight = minWeight;
        }
        player.IncreaseSpeed(loseWeight);
       DecreaseScale(loseWeight);
    }

    private void IncreaseScale()
    {
        if (initialScale.x >= 2f && initialScale.z >= 2f)
        {
            return;
        }
        float scaleIncrease = (currentWeight - initialWeight) * 0.1f;
        transform.localScale = new Vector3(initialScale.x + scaleIncrease, initialScale.y, initialScale.z + scaleIncrease);
    }

    private void DecreaseScale(float loseWeight)
    {
        if(initialScale.x <= 0.6f && initialScale.z <= 0.6f)
        {
            return;
        }
        float scaleDecrease = loseWeight * 0.1f;
        transform.localScale = new Vector3(initialScale.x + scaleDecrease, initialScale.y, initialScale.z + scaleDecrease);
    }

   
}
