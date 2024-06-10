using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapItemData : MonoBehaviour
{
       

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
    }
}
